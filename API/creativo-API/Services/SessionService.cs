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
        private Dictionary<string, int> sessions;
        private Dictionary<int, string> usersessions;

        private SessionService()
        {
            sessions = new Dictionary<string, int>();
            usersessions = new Dictionary<int, string>();
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
        public string AddSession(int sessionData)
        {
            string sessionId = generateSessionId();
            if(usersessions.ContainsKey(sessionData))
            {
                sessions.Remove(usersessions[sessionData]);
                usersessions.Remove(sessionData);
            }
            sessions.Add(sessionId, sessionData);
            usersessions.Add(sessionData, sessionId);
            return sessionId;
        }

        public int GetSession(string sessionId)
        {
            if (sessions.ContainsKey(sessionId))
            {
                return sessions[sessionId];
            }
            return -1;
        }

        public void RemoveSession(string sessionId)
        {
            sessions.Remove(sessionId);
        }
    }
}