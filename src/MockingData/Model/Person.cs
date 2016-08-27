using System;
using MockingData.Generators.Extensions;
using MockingData.Generators.Extensions.Interfaces;
using MockingData.Generators.Random.Interfaces;
using MockingData.Model.Interfaces;
using NodaTime;

namespace MockingData.Model
{
    public class Person : IPersonInternal
    {
        private readonly IRandomGenerator _generator;
        private readonly IExtensionService _extensionService;

        private ICountryGenerator _countryGenerator;
        private ICountryGenerator CountryGenerator => _countryGenerator ?? (_countryGenerator = _extensionService.GetGenerator<ICountryGenerator>());

        private IPersonGenerator _personGenerator;
        private IPersonGenerator PersonGenerator => _personGenerator ?? (_personGenerator = _extensionService.GetGenerator<IPersonGenerator>());

        public Person(IRandomGenerator generator, IExtensionService extensionService)
        {
            _generator = generator;
            _extensionService = extensionService;
        }

        private Gender? _gender;
        public Gender Gender
        {
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

        public string Title
        {
            get
            {
                if (string.IsNullOrEmpty(_title))
                {
                    _title = PersonGenerator.RandomTitle(Country, Gender);
                }
                return _title;
            }
        }

        private string _firstName;
        public string FirstName
        {
            get
            {
                if (string.IsNullOrEmpty(_firstName)){
                    _firstName = PersonGenerator.RandomFirstName(Country, Gender);  
                }
                return _firstName;
            }
        }

        private string _lastName;
        public string LastName {
            get {
                if (string.IsNullOrEmpty(_lastName)) {
                    _lastName = PersonGenerator.RandomLastName(Country);
                }
                return _lastName;
            }
        }

        private City _city;
        public City City => _city ?? (_city = CountryGenerator.RandomCity(State));

        private State _state;
        public State State => _state ?? (_state = CountryGenerator.RandomState(Country));

        private ICountry _country;
        public ICountry Country {
            get
            {
                if (_country != null) return _country;
                _country = CountryGenerator.RandomCountry();
                return _country;
            }
        }

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
