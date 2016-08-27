using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MockingData.Generators.Extensions.Interfaces;
using MockingData.Generators.Random.Interfaces;

namespace MockingData.Generators.Extensions
{
    public class ExtensionService : IExtensionService
    {
        private IDictionary<GeneratorExtensionTypes, ExtensionCreateDefinition> GeneratorTypeList { get; set; }
        private readonly IRandomGenerator _generator;
        public ExtensionService(IRandomGenerator randomGenerator)
        {
            _generator = randomGenerator;

            // Register all extensions
            GeneratorTypeList = new ConcurrentDictionary<GeneratorExtensionTypes, ExtensionCreateDefinition>();
            GeneratorTypeList.Add(GeneratorExtensionTypes.CountryExtension, 
                    ExtensionCreateDefinition.Create(GeneratorExtensionTypes.CountryExtension, typeof(CountryInitator),
                        typeof(ICountryInitiator), typeof(ICountryGenerator))
                );
            GeneratorTypeList.Add(GeneratorExtensionTypes.EmailExtension,
                    ExtensionCreateDefinition.Create(GeneratorExtensionTypes.EmailExtension, typeof(EmailInitiator),
                        typeof(IEmailInitiator), typeof(IEmailGenerator))
                );
            GeneratorTypeList.Add(GeneratorExtensionTypes.ItExtension,
                    ExtensionCreateDefinition.Create(GeneratorExtensionTypes.ItExtension, typeof(ItInitiator),
                        typeof(IItInitiator), typeof(IItGenerator))
                );
            GeneratorTypeList.Add(GeneratorExtensionTypes.RobohashExtension,
                    ExtensionCreateDefinition.Create(GeneratorExtensionTypes.RobohashExtension, typeof(RobohashInitiator),
                        typeof(IRobohashInitiator), typeof(IRobohashGenerator))
                );
            GeneratorTypeList.Add(GeneratorExtensionTypes.PersonExtension,
                    ExtensionCreateDefinition.Create(GeneratorExtensionTypes.PersonExtension, typeof(PersonInitiator),
                        typeof(IPersonInitiator), typeof(IPersonGenerator))
            );

        }

        /// <summary>
        /// Creates a new instance of the Country initiator class
        /// </summary>
        /// <returns></returns>
        public ICountryInitiator CountryExtensionInitiator()
        {
            return (ICountryInitiator)GetInitiator(GeneratorExtensionTypes.CountryExtension);
        }

        /// <summary>
        /// Creates a new instance of the Email initiator class
        /// </summary>
        /// <returns></returns>
        public IEmailInitiator EmailExtensionInitiator()
        {
            return (IEmailInitiator)GetInitiator(GeneratorExtensionTypes.EmailExtension);
        }

        /// <summary>
        /// Creates a new instance of the Robohash initiator class
        /// </summary>
        /// <returns></returns>
        public IRobohashInitiator RobohashExtensionInitiator()
        {
            return (IRobohashInitiator)GetInitiator(GeneratorExtensionTypes.RobohashExtension);
        }

        /// <summary>
        /// Creates a new instance of the It initiator class
        /// </summary>
        /// <returns></returns>
        public IItInitiator ItExtensionInitiator()
        {
            return (IItInitiator)GetInitiator(GeneratorExtensionTypes.ItExtension);
        }

        /// <summary>
        /// Creates a new instance of the Person initiator class
        /// </summary>
        /// <returns></returns>
        public IPersonInitiator PersonExtensionInitiator()
        {
            return (IPersonInitiator)GetInitiator(GeneratorExtensionTypes.PersonExtension);
        }

        /// <summary>
        /// Creates a new instance of the initiator class for the given type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IExtensionInitiator GetInitiator(GeneratorExtensionTypes type)
        {
            var item = GeneratorTypeList[type];

            if (item == null)
                throw new ArgumentOutOfRangeException($"Invalid extension type {type.ToString()} used");

            // We have no instance and need to create one
            return (IExtensionInitiator)Activator.CreateInstance(item.InstantiationClass, _generator, this);
        }


        /// <summary>
        /// Returns a generic generator for the specified type. You need to cast this one to the specific one you need. If you
        /// request the EmailGenerator type, you need to cast the return value to IEmailGenerator
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IExtensionGenerator GetGenerator(GeneratorExtensionTypes type)
        {
            var item = GeneratorTypeList[type];

            if (item == null)
                throw new ArgumentOutOfRangeException($"Invalid extension type {type.ToString()} used");

            if (item.Instance != null)
                return item.Instance;

            // We have no instance and need to create one
            var initiator = (IExtensionInitiator)Activator.CreateInstance(item.InstantiationClass, _generator, this);
            if (initiator == null)
                throw new Exception($"Failed to instantiate class for type {item.ExtensionType}");

            var instance = initiator.CreateGenericGenerator();
            item.Instance = instance;
            return instance;
        }

        /// <summary>
        /// Returns a specific generator for the type asked for. 
        /// 
        /// Possible generators include:
        /// - IEmailGenerator
        /// - IRobohashGenerator
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetGenerator<T>() where T : IExtensionGenerator
        {
            var type = typeof(T);
            if (GeneratorTypeList.All(x => x.Value.GeneratorInterfaceType != type))
                throw new ArgumentException($"Type {nameof(type)} not found in the extension service");

            var extensionType = GeneratorTypeList.FirstOrDefault(x => x.Value.GeneratorInterfaceType == type);
            return (T)GetGenerator(extensionType.Key);
        }

        /// <summary>
        /// Registers a generator and replaces the old one, if one was already stored
        /// </summary>
        /// <param name="generator"></param>
        public void RegisterGenerator(IExtensionGenerator generator)
        {
            var extensionType = generator.GetExtensionType();
            var item = GeneratorTypeList[extensionType];
            if (item == null)
                throw new ArgumentException($"Can't register type {nameof(generator)} because it's not found in the extension service");

            item.Instance = generator;
        }

        /// <summary>
        /// Internal type information for the Extension classes registered
        /// </summary>
        private class ExtensionCreateDefinition
        {
            public static ExtensionCreateDefinition Create(GeneratorExtensionTypes extensionType, 
                Type initiatorClass, Type initiatorInterfaceType, Type generatorInterfaceType)
            {
                var typeinfo = initiatorClass.GetTypeInfo();
                if (typeinfo.IsAbstract || !typeinfo.IsClass)
                {
                    throw new ArgumentException($"The instantiation type {nameof(initiatorClass)} isn't valid since it can't be instantiated into an object.");
                }

                var initiatorTypeInfo = typeof(IExtensionInitiator).GetTypeInfo();

                if (!initiatorTypeInfo.IsAssignableFrom(typeinfo))
                {
                    throw new ArgumentException($"The instantiation type {nameof(initiatorClass)} doesn't implement the IExtensionInitiator interface.");
                }
                
                var def = new ExtensionCreateDefinition()
                {
                    ExtensionType = extensionType,
                    GeneratorInterfaceType = generatorInterfaceType,
                    InitiatorInterfaceType = initiatorInterfaceType,
                    InstantiationClass = initiatorClass
                };
                return def;
            }

            /// <summary>
            /// Used by non-generic functions to identify the instance
            /// </summary>
            public GeneratorExtensionTypes ExtensionType { get; private set; }

            /// <summary>
            /// Used by the generic function GetGenerator<T> to identify the instance
            /// </summary>
            public Type GeneratorInterfaceType { get; private set; }

            /// <summary>
            /// Used by the generic function GetInitiator<T> to identify the instance
            /// </summary>
            public Type InitiatorInterfaceType { get; private set; }

            /// <summary>
            /// Used internally for instantiating the initiator class
            /// </summary>
            public Type InstantiationClass { get; private set; }

            /// <summary>
            /// The generator instance, once it's created
            /// </summary>
            public IExtensionGenerator Instance { get; set; }
        }
    }
}
