using System;
using MockingData.Model.Interfaces;

namespace MockingData.Generators.Extensions.Interfaces
{
    public interface IRobohashGenerator : IExtensionGenerator
    {
        Uri Generate();
        Uri Generate(string text);
        Uri Generate(IPerson person);
    }
}
