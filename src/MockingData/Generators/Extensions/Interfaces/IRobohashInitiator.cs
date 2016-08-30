using System;
using MockingData.Model.Interfaces;

namespace MockingData.Generators.Extensions.Interfaces
{
    public interface IRobohashInitiator : IExtensionInitiator
    {
        IRobohashInitiator WithSize(int width, int height);
        IRobohashInitiator WithCreateMethod(Func<IPerson, string> method);
        IRobohashInitiator WithBaseUrl(string url);
        IRobohashGenerator Create();
    }
}
