using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeneralChat.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Введите логин")]
        public string Name { get; set; }
    }
}