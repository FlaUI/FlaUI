namespace FlaUI.WebDriver
{
    public interface ISessionRepository
    {
        void Add(Session session);
        void Delete(Session session);
        Session? FindById(string sessionId);
    }
}
