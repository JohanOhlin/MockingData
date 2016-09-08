using System;

namespace MockingData.Model.Interfaces
{
    public interface IPerson
    {
        Gender Gender { get; }
        string Title { get; }
        string FirstName { get; }
        string LastName { get; }
        Street Street { get; }
        string PostalCode { get; }
        City City { get; }
        State State { get; }
        ICountry Country { get; }
        Uri RobohashImage { get; }
        string Email { get; }
    }
}