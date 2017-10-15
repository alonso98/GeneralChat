using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Threading;

namespace GeneralChat.Modules
{
    public class RemoveMessagesModule : IHttpModule
    {
        private Timer timer;
        long interval = 30000;
        static object synclock = new object();

        public void Init(HttpApplication app)
        {
            timer = new Timer(new TimerCallback(RemoveMessage), null, 0, interval);
        }

        private void RemoveMessage(object obj)
        {
            DateTime dd = DateTime.Now;
            lock (synclock)
            {
                if (dd.Hour == 0 && dd.Minute == 0)
                {
                    using (Models.UserContext db = new Models.UserContext())
                    {
                        db.Messages.RemoveRange(db.Messages);
                        db.SaveChanges();
                    }
                }
            }
        }

        public void Dispose() { }
    }
}