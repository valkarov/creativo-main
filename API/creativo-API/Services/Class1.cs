using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace creativo_API.Services
{
    public class SessionService
    {
        private static SessionService instance;
        private Dictionary<string, object> sessions;

        private SessionService()
        {
            sessions = new Dictionary<string, object>();
        }

        public static SessionService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SessionService();
                }
                return instance;
            }
        }

        public void AddSession(string sessionId, object sessionData)
        {
            sessions.Add(sessionId, sessionData);
        }

        public object GetSession(string sessionId)
        {
            if (sessions.ContainsKey(sessionId))
            {
                return sessions[sessionId];
            }
            return null;
        }

        public void RemoveSession(string sessionId)
        {
            sessions.Remove(sessionId);
        }
    }
}