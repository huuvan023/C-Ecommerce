using EmmerceAPIHCMUE.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EmmerceAPIHCMUE.Models
{
    public class ProductColor
    {
        private string IdColor;
        private string ColorName;

        public string idColor { get => IdColor; set => IdColor = value; }
        public string colorName { get => ColorName; set => ColorName = value; }

        public bool AddProductColor()
        {
            string query = "insert into dbo.productColor values('" + this.idColor + "','" + this.colorName + "')";
            int rowExec = Connection.Instance.ExecuteNonQuery(query);
            if (rowExec == 1)
            {
                return true;
            }
            return false;
        }
        public bool DeleteProductColor()
        {
            string query = "delete from dbo.productColor where idColor = '" + this.idColor + "'";
            int rowExec = Connection.Instance.ExecuteNonQuery(query);
            if (rowExec == 1)
            {
                return true;
            }
            return false;
        }
        public bool UpdateProductColor()
        {
            string query = "update dbo.productColor set colorName = '" + this.colorName + "' where idColor = '" + this.idColor + "'";
            int rowExec = Connection.Instance.ExecuteNonQuery(query);
            if (rowExec == 1)
            {
                return true;
            }
            return false;
        }
        public DataTable GetAllColor()
        {
            string query = "select * from dbo.productColor";
            return Connection.Instance.ExecuteQuery(query);
        }
    }
}
