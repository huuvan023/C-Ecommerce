using EmmerceAPIHCMUE.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmmerceAPIHCMUE.Models
{
    public class Admin
    {
        private string idAdmin;
        private string email;
        private string password;

        public string IdAdmin { get => idAdmin; set => idAdmin = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }

        public bool AdminLogin()
        {
            string query = "select password from dbo.admin where email = '" + this.email + "'";
            string pass = (string)Connection.Instance.ExecuteScalar(query);
            if (pass == null || pass == "")
            {
                return false;
            }
            bool compare = Helper.Instance.ValidatePassword(this.password, pass);
            return compare;
        }
        public bool AdminSignUp()
        {
            string query = "insert into dbo.admin values('" + Helper.Instance.GenarateID() + "','" + this.email + "', '" + Helper.Instance.HashPassword(this.password) + "')";
            int rowExec = Connection.Instance.ExecuteNonQuery(query);
            if (rowExec == 1)
            {
                return true;
            }
            return false;
        }
        public string GetToken()
        {
            string query = "Select idAdmin from dbo.admin where email='" + this.email + "'";
            string id = (string)Connection.Instance.ExecuteScalar(query);
            return Helper.Instance.GenerateToken(id);
        }
    }
}
