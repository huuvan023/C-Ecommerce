using EmmerceAPIHCMUE.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EmmerceAPIHCMUE.Models
{
    public class ProductSize
    {
        private string IdSize;
        private string SizeName;

        public string idSize { get => IdSize; set => IdSize = value; }
        public string sizeName { get => SizeName; set => SizeName = value; }

        public bool AddProductSize()
        {
            string query = "insert into dbo.productSize values('" + this.idSize + "','" + this.sizeName + "')";
            int rowExec = Connection.Instance.ExecuteNonQuery(query);
            if (rowExec == 1)
            {
                return true;
            }
            return false;
        }
        public bool DeleteProductSize()
        {
            string query = "delete from dbo.productSize where idSize = '"+this.idSize+"'";
            int rowExec = Connection.Instance.ExecuteNonQuery(query);
            if (rowExec == 1)
            {
                return true;
            }
            return false;
        }
        public bool UpdateProductSize()
        {
            string query = "update dbo.productSize set sizeName = '"+this.sizeName+"' where idSize = '" + this.idSize + "'";
            int rowExec = Connection.Instance.ExecuteNonQuery(query);
            if (rowExec == 1)
            {
                return true;
            }
            return false;
        }
        public DataTable GetAllSize()
        {
            string query = "select * from dbo.productSize";
            return Connection.Instance.ExecuteQuery(query);
        }
    }
}
