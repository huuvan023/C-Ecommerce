using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EmmerceAPIHCMUE.Models
{
    public class Token
    {
		private string tokenString;
        public string TokenString { get => tokenString; set => tokenString = value; }
        public Token(string token)
        {
            this.tokenString = token;
        }
		
	}
}
