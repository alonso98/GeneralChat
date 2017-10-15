using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeneralChat.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Online { get; set; }
        public virtual IList<MessageModel> Messages { get; set; }
    }
}