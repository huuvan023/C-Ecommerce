using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace EmmerceAPIHCMUE.Provider
{
    public class CustomMiddleware
    {
        private string tokenString;

        public string TokenString { get => tokenString; set => tokenString = value; }
        public CustomMiddleware (string tokenString)
        {
            this.tokenString = tokenString;
        }

        public bool ValidateToken(int Role)
        {
            if (this.tokenString == null || this.tokenString == "")
            {
                return false;
            }
            if (!Helper.Instance.ValidateCurrentToken(this.tokenString))
            {
                return false;
            }
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(this.tokenString);

            if (Role == Constants.Instance.ADMIN_ROLE1)
            {
                var idUser = token.Claims.Where(c => c.Type == "nameid").Select(c => c.Value).SingleOrDefault();
                string query = "select count(*) from dbo.admin where idAdmin = '" + idUser + "'";
                int rowExec = (int)Connection.Instance.ExecuteScalar(query);
                if (rowExec >= 1)
                {
                    return true;
                }
                return false;
            }
            if (Role == Constants.Instance.USER_ROLE1)
            {
                var idUser = token.Claims.Where(c => c.Type == "nameid").Select(c => c.Value).SingleOrDefault();
                string query = "select count(*) from dbo.users where idUser = '" + idUser + "'";
                int rowExec = (int)Connection.Instance.ExecuteScalar(query);
                if (rowExec >= 1)
                {
                    return true;
                }
                return false;
            }
            return true;
        }
    }
}
