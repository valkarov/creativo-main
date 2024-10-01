using creativo_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace creativo_API.Services
{
    public class SessionService
    {
        private static SessionService instance;
        private Dictionary<string, User> sessions;

        private SessionService()
        {
            sessions = new Dictionary<string, User>();
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
        private string generateSessionId ()
        {
            return Guid.NewGuid().ToString();
        }
        public string AddSession(User sessionData)
        {
            string sessionId = generateSessionId();
            sessions.Add(sessionId, sessionData);
            return sessionId;
        }

        public User GetSession(string sessionId)
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