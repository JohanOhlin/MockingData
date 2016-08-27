namespace MockingData.Generators.Extensions.Interfaces
{
    public interface IPersonInitiator : IExtensionInitiator
    {
        IPersonGenerator Create();
    }
}
