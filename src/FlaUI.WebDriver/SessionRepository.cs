using System.Collections.Generic;
using System.Linq;

namespace FlaUI.WebDriver
{
    public class SessionRepository : ISessionRepository
    {
        private List<Session> Sessions { get; } = new List<Session>();

        public Session? FindById(string sessionId)
        {
            return Sessions.SingleOrDefault(session => session.SessionId == sessionId);
        }

        public void Add(Session session)
        {
            Sessions.Add(session);
        }

        public void Delete(Session session)
        {
            Sessions.Remove(session);
        }
    }
}
