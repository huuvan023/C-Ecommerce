using EmmerceAPIHCMUE.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EmmerceAPIHCMUE.Models
{
    public class ProductType
    {
        private string IdType;
        private string TypeName;

        public string idType { get => IdType; set => IdType = value; }
        public string typeName { get => TypeName; set => TypeName = value; }

        public bool AddProductType()
        {
            string query = "insert into dbo.productTypes values('" + this.idType + "','" + this.typeName + "')";
            int rowExec = Connection.Instance.ExecuteNonQuery(query);
            if (rowExec == 1)
            {
                return true;
            }
            return false;
        }
        public bool DeleteProductType()
        {
            string query = "delete from dbo.productTypes where idType = '" + this.idType + "'";
            int rowExec = Connection.Instance.ExecuteNonQuery(query);
            if (rowExec == 1)
            {
                return true;
            }
            return false;
        }
        public bool UpdateProductType()
        {
            string query = "update dbo.productTypes set typeName = '" + this.typeName + "' where idType = '" + this.idType + "'";
            int rowExec = Connection.Instance.ExecuteNonQuery(query);
            if (rowExec == 1)
            {
                return true;
            }
            return false;
        }
        public DataTable GetAllType()
        {
            string query = "select * from dbo.productTypes";
            return Connection.Instance.ExecuteQuery(query);
        }
        public ProductType FindByID()
        {
            string query = "select * from dbo.productTypes where idType = '" + this.idType + "'";
            DataTable dt = Connection.Instance.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                this.idType = row["idType"].ToString();
                this.typeName = row["typeName"].ToString();
            }
            return this;
        }
    }
}
