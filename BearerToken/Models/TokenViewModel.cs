using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BearerToken.Models
{
    public class TokenViewModel
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public int ExpiresIn { get; set; }
    }
}