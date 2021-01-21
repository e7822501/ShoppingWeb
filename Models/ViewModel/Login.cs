using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingWeb.Models.ViewModel
{
    [Serializable]
    public class Login
    {
        public string Account { get; set; }
        public string Password { get; set; }
    }
}