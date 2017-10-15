using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeneralChat.Models
{
    public class MessageModel
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}