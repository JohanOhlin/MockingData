namespace MockingData.Generators.Extensions.Interfaces
{
    public interface IRobohashInitiator : IExtensionInitiator
    {
        IRobohashInitiator WithSize(int width, int height);
        IRobohashGenerator Create();
    }
}
