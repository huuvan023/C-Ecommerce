using EmmerceAPIHCMUE.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EmmerceAPIHCMUE.Models
{
    public class Rating
    {
        public string idUser { get; set; }
        public string idProduct { get; set; }
        public int rate { get; set; }
        public string comment { get; set; }
        public string rateDate { get; set; }

        DateTime now = DateTime.Now;
        public bool AddRating()
        {
            string query = "insert into dbo.rating values('" + this.idUser + "','" + this.idProduct + "','" + this.rate + "',N'" + this.comment + "','" + now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            int rowExec = Connection.Instance.ExecuteNonQuery(query);
            if (rowExec == 1)
            {
                return true;
            }
            return false;
        }

        public bool DeleteRating()
        {
            string query = "delete from dbo.rating where idProduct='" + this.idProduct + "' and idUser='" + this.idUser + "'";
            int rowExec = Connection.Instance.ExecuteNonQuery(query);
            if (rowExec == 1)
            {
                return true;
            }
            return false;
        }

        public bool UpdateRating()
        {
            string query = "update dbo.rating set ";
            if (this.rate >= 0 && this.rate <= 5)
            {
                query += "rate = '" + this.rate + "',";
            }
            if (this.comment != null && this.comment != "")
            {
                query += "comment = '" + this.comment + "',";
            }
            query += "rateDate = '" + now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            

            //query = query.Remove(query.Length - 1);
            query += " where idProduct = '" + this.idProduct + "' and idUser = '" + this.idUser + "'";
            int rowExec = Connection.Instance.ExecuteNonQuery(query);
            if (rowExec == 1)
            {
                return true;
            }
            return false;
        }

        public DataTable GetAllRating()
        {
            string query = "select * from dbo.rating";
            return Connection.Instance.ExecuteQuery(query);
        }
    }
}
