using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmmerceAPIHCMUE.Provider;
using System.Data;
using Newtonsoft.Json;

namespace EmmerceAPIHCMUE
{
    public class Home
    {
        //Ctrl R E 
        private int name;

        public int Age;

        public string Hobby ;

        public int Name { get => name; set => name = value; }
        public Home(int Name, int Age, string Hobby)
        {
            this.name = Name;
            this.Age = Age;
            this.Hobby = Hobby;
        }
        public string getAll()
        {
            DataTable dt = Connection.Instance.ExecuteQuery("Select * from admin");

            return JsonConvert.SerializeObject(dt);
        }
    }
}
