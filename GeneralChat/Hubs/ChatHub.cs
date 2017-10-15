using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using GeneralChat.Models;

namespace GeneralChat.Hubs
{
    public class ChatHub : Hub
    {        
        public void Send(string message)
        {
            using (UserContext db = new UserContext())
            {
                db.Messages.Add(new MessageModel() { Message = message, Time = DateTime.Now, UserId = db.Users.FirstOrDefault(u => u.Name == Context.User.Identity.Name).Id });
                db.SaveChanges();
            }
            Clients.All.addMessage(Context.User.Identity.Name, message, DateTime.Now.ToString("t"));
        }
    }
}