namespace MockingData.Model.Interfaces
{
    public interface IPersonEmail
    {
        void SetEmailAddress(string email);
        string GetEmailAddress();
        bool HasEmailAddress();
    }
}
