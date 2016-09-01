# Mocking Data Generator for .NET and .NET core

The Mocking Data library is a structured localized random generator for .NET (4.5 or greater) and .NET Core (.NET Standard 1.4 or greater). It is made to help you create realistic simulation data with focus on persons/users/customers and settings related to them. 

In the centre of the library you have a Person generator that generates Person objects. Each object has a number of properties that are randomly generated as you access them. Most of the data is localized so if a person is randomly selected US as country, then on the state level it will be one of the states in the US and on the city level it will be one of the cities in the randomly selected state.

Most of the localized data is tied to the country level, but some depends on state and others on city.

A simple example, where we need to generate 1000 random persons, could look like this:
>     var md = new MockingDataGenerator();
>     var persons = md.PersonGenerator
>                 .RandomPersons()
>                 .Select(p => new
>                 {
>                     p.FirstName,
>                     p.LastName,
>                     p.City
>                 })
>                 .Take(1000);

For more extensive examples please refer to the [project wiki](https://github.com/JohanOhlin/MockingData/wiki). 

If you would like to contribute to this project then you can read more about it [here](https://github.com/JohanOhlin/MockingData/wiki/Contributions).
