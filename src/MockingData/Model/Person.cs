using System;
using MockingData.Generators.Extensions;
using MockingData.Generators.Extensions.Interfaces;
using MockingData.Generators.Random;
using MockingData.Generators.Random.Extensions;
using MockingData.Generators.Random.Interfaces;
using MockingData.Model.Interfaces;
using NodaTime;

namespace MockingData.Model
{
    public class Person : IPersonInternal
    {
        private readonly IRandomGenerator _generator;
        private readonly IExtensionService _extensionService;
        private readonly IPatternMatching _patternMatching;

        private ICountryGenerator _countryGenerator;
        private ICountryGenerator CountryGenerator => _countryGenerator ?? (_countryGenerator = _extensionService.GetGenerator<ICountryGenerator>());

        private IPersonGenerator _personGenerator;
        private IPersonGenerator PersonGenerator => _personGenerator ?? (_personGenerator = _extensionService.GetGenerator<IPersonGenerator>());

        public Person(IRandomGenerator generator, IExtensionService extensionService)
        {
            _generator = generator;
            _extensionService = extensionService;
            _patternMatching = new PatternMatching(_generator);
        }

        private Gender? _gender;
        public Gender Gender {
            get
            {
                if (!_gender.HasValue)
                {
                    _gender = PersonGenerator.RandomGender;
                }
                return _gender.Value;
            }
        }

        private string _title;
 
        public string Title => _title ?? (_title = PersonGenerator.RandomTitle(Country, Gender));


        private string _firstName;
        public string FirstName => _firstName ?? (_firstName = PersonGenerator.RandomFirstName(Country, Gender));


        private string _lastName;
        public string LastName => _lastName ?? (_lastName = PersonGenerator.RandomLastName(Country));


        private Street _street;
        public Street Street => _street ?? (_street = City.Streets.RandomFromList());


        private string _postalCode;
        public string PostalCode => _postalCode ?? (_postalCode = _patternMatching.RandomAlphaNumFromPattern(Street.PostalCode));


        private City _city;
        public City City => _city ?? (_city = CountryGenerator.RandomCity(State));


        private State _state;
        public State State => _state ?? (_state = CountryGenerator.RandomState(Country));


        private ICountry _country;
        public ICountry Country => _country ?? (_country = CountryGenerator.RandomCountry());


        private string _email;
        public string Email {
            get {
                if (!string.IsNullOrEmpty(_email)) return _email;

                var generator = (IEmailGenerator)_extensionService.GetGenerator(GeneratorExtensionTypes.EmailExtension);
                generator.RandomEmail(this);
                return _email;
            }
        }

        public void SetEmailAddress(string email)
        {
            _email = email;
        }

        public string GetEmailAddress()
        {
            return _email;
        }

        public bool HasEmailAddress()
        {
            return !string.IsNullOrEmpty(_email);
        }

        private Uri _robohashImage;
        public Uri RobohashImage
        {
            get {
                if (_robohashImage != null) return _robohashImage;

                var generator = (IRobohashGenerator) _extensionService.GetGenerator(GeneratorExtensionTypes.RobohashExtension);
                _robohashImage = generator.Generate(this);
                return _robohashImage;
            }
        }

        public DateTimeZone TimeZone => CountryGenerator.TimeZone(Country);

        public ZonedDateTime ZonedDateTime(ZonedDateTime fromDateTime) => CountryGenerator.ZonedDateTime(Country, fromDateTime);

        public ZonedDateTime ZonedDateTime() => CountryGenerator.ZonedDateTime(Country);
    }
}
