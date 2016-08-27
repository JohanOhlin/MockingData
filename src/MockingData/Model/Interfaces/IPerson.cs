﻿using System;

namespace MockingData.Model.Interfaces
{
    public interface IPerson
    {
        Gender Gender { get; }
        string Title { get; }
        string FirstName { get; }
        string LastName { get; }
        City City { get; }
        State State { get; }
        ICountry Country { get; }
        Uri RobohashImage { get; }
    }
}