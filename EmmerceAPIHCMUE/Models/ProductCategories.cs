using EmmerceAPIHCMUE.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EmmerceAPIHCMUE.Models
{
    public class ProductCategories
    {
        private string IdCategory;
        private string CategoryName;

        public string idCategory { get => IdCategory; set => IdCategory = value; }
        public string categoryName { get => CategoryName; set => CategoryName = value; }

        public bool AddProductCategory()
        {
            string query = "insert into dbo.productCategories values('" + this.idCategory + "','" + this.categoryName + "')";
            int rowExec = Connection.Instance.ExecuteNonQuery(query);
            if (rowExec == 1)
            {
                return true;
            }
            return false;
        }
        public bool DeleteProductCategory()
        {
            string query = "delete from dbo.productCategories where idCategory = '" + this.idCategory + "'";
            int rowExec = Connection.Instance.ExecuteNonQuery(query);
            if (rowExec == 1)
            {
                return true;
            }
            return false;
        }
        public bool UpdateProductCategory()
        {
            string query = "update dbo.productCategories set categoryName = '" + this.categoryName + "' where idCategory = '" + this.idCategory + "'";
            int rowExec = Connection.Instance.ExecuteNonQuery(query);
            if (rowExec == 1)
            {
                return true;
            }
            return false;
        }
        public DataTable GetAllCaregory()
        {
            string query = "select * from dbo.productCategories";
            return Connection.Instance.ExecuteQuery(query);
        }
    }
}
