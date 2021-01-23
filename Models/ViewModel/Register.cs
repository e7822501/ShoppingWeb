using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace ShoppingWeb.Models.ViewModel
{
    [Serializable]
    public class Register
    {
        public string Name { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
        public string Sex { get; set; }
        public string Village { get; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}