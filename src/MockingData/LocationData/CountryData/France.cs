using System.Collections.Generic;
using MockingData.Model;

namespace MockingData.LocationData.CountryData
{
    public class France : Country
    {
        public France(int countryId) : base(countryId)
        {
            CountryName = "France";
            CountryCodeIsoAlpha2 = "FR";
            Currency = "EUR";
            GeoCoordinate = new GeoCoordinate(46.227638, 2.213749);
            HasCompleteData = false;
            TitlesLocalizedMale = new List<string> { };
            TitlesLocalizedFemale = new List<string> { };
            FirstNamesMale = new List<string> { "Aaron", "Adam", "Adrien", "Alexandre", "Alexis", "Amaury", "Amine", "Antoine", "Antonin", "Arthur", "Augustin", "Axel", "Ayoub", "Baptiste", "Bastien", "Benjamin", "Clément", "Corentin", "Diego", "Dorian", "Dylan", "Eliott", "Enzo", "Erwan", "Esteban", "Ethan", "Evan", "Florian", "Gabin", "Gabriel", "Gaspard", "Hugo", "Ilan", "Ilyes", "Ismael", "Jean", "Jules", "Julien", "Kais", "Kenzo", "Kylian", "Lenny", "Léo", "Liam", "Lilian", "Loan", "Lorenzo", "Loris", "Louis", "Louka", "Luca", "Lucas", "Maël", "Marius", "Martin", "Mateo", "Matheo", "Mathias", "Mathieu", "Mathis", "Mathys", "Matteo", "Maxence", "Maxime", "Mehdi", "Mohamed", "Nael", "Nathan", "Nicolas", "Nino", "Noa", "Noah", "Noam", "Noé", "Nolan", "Oscar", "Paul", "Pierre", "Quentin", "Rafael", "Raphaël", "Rayan", "Robin", "Romain", "Sacha", "Samuel", "Simon", "Théo", "Thibault", "Thomas", "Tiago", "Timeo", "Timothe", "Titouan", "Tom", "Tristan", "Valentin", "Victor", "William", "Yanis" };
            FirstNamesFemale = new List<string> { "Adèle", "Agathe", "Alice", "Alicia", "Amandine", "Ambre", "Anaelle", "Anaïs", "Anna", "Apolline", "Assia", "Aya", "Camille", "Candice", "Capucine", "Celia", "Charlotte", "Chloé", "Clara", "Clémence", "Cloé", "Elea", "Elena", "Elisa", "Élise", "Éloïse", "Elsa", "Émilie", "Emma", "Emmy", "Emy", "Eva", "Faustine", "Gabrielle", "Héloïse", "Inaya", "Inès", "Jade", "Jeanne", "Julia", "Julie", "Juliette", "Justine", "Kenza", "Lana", "Laura", "Léa", "Leana", "Leane", "Lena", "Léonie", "Lilou", "Lily", "Lina", "Lisa", "Lise", "Lola", "Lou", "Louane", "Louise", "Louna", "Lucie", "Luna", "Lyna", "Maëlle", "Maëlys", "Maeva", "Maissa", "Manel", "Manon", "Margaux", "Margot", "Marie", "Marion", "Mathilde", "Maya", "Melina", "Méline", "Mélissa", "Mila", "Morgane", "Nina", "Ninon", "Noémie", "Océane", "Olivia", "Pauline", "Romane", "Rose", "Salomé", "Sara", "Sarah", "Sofia", "Stella", "Thais", "Valentine", "Victoria", "Yasmine", "Zelie", "Zoé" };
            LastNames = new List<string> { };
            States = new List<State>
            {
                new State
                {
                    Code = "",
                    Name = "",
                    AreaSquareKilometers = 0,
                    Population = 0,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "", Population = 102000, IsStateCapital = true}
                    }
                }
            };
        }
    }
}
