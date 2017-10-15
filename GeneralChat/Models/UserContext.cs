using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GeneralChat.Models
{
    public class UserContext:DbContext
    {
        public UserContext():base("ChatDB"){}

        public DbSet<User> Users { get; set; }
        public DbSet<MessageModel> Messages { get; set; }
    }
}