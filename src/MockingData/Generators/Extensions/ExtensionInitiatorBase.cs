using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MockingData.Generators.Extensions.Interfaces;
using MockingData.Generators.Random.Interfaces;

namespace MockingData.Generators.Extensions
{
    public abstract class ExtensionInitiatorBase : IExtensionInitiator
    {
        protected readonly IRandomGenerator Generator;
        protected readonly IExtensionService ExtensionService;

        protected ExtensionInitiatorBase(IRandomGenerator generator, IExtensionService extensionService)
        {
            Generator = generator;
            ExtensionService = extensionService;
        }

        public abstract IExtensionGenerator CreateGenericGenerator();
        public abstract GeneratorExtensionTypes GetExtensionType();
    }
}
