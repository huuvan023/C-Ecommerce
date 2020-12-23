using EmmerceAPIHCMUE.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EmmerceAPIHCMUE.Models
{
    public class ProductBrand
    {
        private string IdBrand;
        private string BrandName;
        private string BrandDetail;
        public string idBrand { get => IdBrand; set => IdBrand = value; }
        public string brandName { get => BrandName; set => BrandName = value; }
        public string brandDetail { get => BrandDetail; set => BrandDetail = value; }

        public bool AddProductBrand()
        {
            string query = "insert into dbo.productBrand values('" + this.idBrand + "','" + this.brandName + "', '"+this.brandDetail+"')";
            int rowExec = Connection.Instance.ExecuteNonQuery(query);
            if (rowExec == 1)
            {
                return true;
            }
            return false;
        }
        public bool DeleteProductBrand()
        {
            string query = "delete from dbo.productBrand where idBrand = '" + this.idBrand + "'";
            int rowExec = Connection.Instance.ExecuteNonQuery(query);
            if (rowExec == 1)
            {
                return true;
            }
            return false;
        }
        public bool UpdateProductBrand()
        {
            string query = "update dbo.productBrand set brandName = '" + this.brandName + "', brandDetail = '" + this.brandDetail + "' where idBrand = '" + this.idBrand + "'";
            int rowExec = Connection.Instance.ExecuteNonQuery(query);
            if (rowExec == 1)
            {
                return true;
            }
            return false;
        }
        public DataTable GetAllBrand()
        {
            string query = "select * from dbo.productBrand";
            return Connection.Instance.ExecuteQuery(query);
        }
    }
}
