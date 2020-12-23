using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using EmmerceAPIHCMUE.Provider;
using System.Data;
using Newtonsoft.Json;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EmmerceAPIHCMUE.Models
{
    public class User
    {
        public string idUser { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string birthday { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public string note { get; set; }
        public string province { get; set; }
        public string interestedIn { get; set; }
        public string lastLogin { get; set; }
        public string avatar { get; set; }
        /*public void SetUser( string email, string password, string idUser, string firstName, string lastName , string birthday, string phoneNumber , string addrress , string note , string province, string interestedIn , string lastLogin , string avatar)
        {
            this.idUser = idUser;
            this.email = email;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthday = birthday;
            this.phoneNumber = phoneNumber;
            this.addrress = addrress;
            this.note = note;
            this.province = province;
            this.interestedIn = interestedIn;
            this.lastLogin = lastLogin;
            this.avatar = avatar;
        }*/
       

        public bool SignUp()
        {
            string query = "insert into dbo.users values('" + Helper.Instance.GenarateID() + "', '" + this.email + "', '" + Helper.Instance.HashPassword(this.password) + "', N'" + this.firstName + "', N'" + this.lastName + "', '" + this.birthday + "', '" + this.phoneNumber + "', '" + this.address + "', '" + this.note + "', '" + this.province + "', '" + this.interestedIn + "', '" + this.lastLogin + "', '" + this.avatar + "')";


            int rowExec = Connection.Instance.ExecuteNonQuery(query);
            if (rowExec == 1)
            {
                return true;
            }
            return false;
        }
        public bool IsEmailExits()
        {
            string query = "SELECT Count(*) from dbo.users where email='" + this.email + "'";
            object row = Connection.Instance.ExecuteScalar(query);
            if ((int)(row) >= 1)
            {
                return true;
            }
            return false;
        }
        public bool SignIn()
        {
            string query = "select password from dbo.users where email = '" + this.email + "'";
            string pass = (string)Connection.Instance.ExecuteScalar(query);
            bool compare = Helper.Instance.ValidatePassword(this.password, pass);
            return compare;
        }
        public DataTable fetchUser(string id)
        {
            string query = "Select * from dbo.users where idUser='" + id + "'";
            DataTable dt =  Connection.Instance.ExecuteQuery(query);
            return dt;
        }
        public string GetToken()
        {
            string query = "Select idUser from dbo.users where email='" + this.email + "'";
            string id = (string)Connection.Instance.ExecuteScalar(query);
            return Helper.Instance.GenerateToken(id);
        }
                
    }
}
