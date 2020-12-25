using EmmerceAPIHCMUE.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EmmerceAPIHCMUE.Models
{
    public class Product
    {
        private string idProduct;
        private string idSize;
        private string idBrand;
        private string idColor;
        private string idCategory;
        private string idType;
        private string price;
        private string salePrice;
        private string photoReview;
        private string detail;
        private int isSaling;
        private string expiredSalingDate;
        private string dateAdded;

        private DateTime dateNow = DateTime.Now; 
        public bool AddProduct()
        {
            string query = "insert into dbo.products values('" + Helper.Instance.GenarateID() + "','" + this.idSize + "', '" + this.idBrand + "', " +
                "'" + this.idColor + "','" + this.idCategory + "','" + this.idType + "','" + this.price + "','" + this.salePrice + "',"+
                 "'" + this.photoReview + "' ,'" + this.detail + "','" + this.isSaling + "','" + this.expiredSalingDate + "','" + this.dateNow + "')";
            int rowExec = Connection.Instance.ExecuteNonQuery(query);
            if (rowExec == 1)
            {
                return true;
            }
            return false;
        }

        public bool DeleteProduct()
        {
            string query = "delete from dbo.products where idProduct='" + this.idProduct + "'";
            int rowExec = Connection.Instance.ExecuteNonQuery(query);
            if (rowExec == 1)
            {
                return true;
            }
            return false;
        }
        public bool UpdateProduct()
        {
            string query = "update dbo.products set ";
            if (this.idSize != null && this.idSize != "")
            {
                query += "idSize = '" + this.idSize + "',";
            }
            if (this.idBrand != null && this.idBrand != "")
            {
                query += "idBrand = '" + this.idBrand + "',";
            }
            if (this.idColor != null && this.idColor != "")
            {
                query += "idColor = '" + this.idColor + "',";
            }
            if (this.idCategory != null && this.idCategory != "")
            {
                query += "idCategory = '" + this.idCategory + "',";
            }
            if (this.idType != null && this.idType != "")
            {
                query += "idType = '" + this.idType + "',";
            }
            if (this.price != null && this.price != "")
            {
                query += " price = '" + this.price + "',";
            }
            if (this.salePrice != null && this.salePrice != "")
            {
                query += "salePrice = '" + this.salePrice + "',";
            }
            if (this.photoReview != null && this.photoReview != "")
            {
                query += "photoReview = '" + this.photoReview + "',";
            }
            if (this.detail != null && this.detail != "")
            {
                query += "detail = '" + this.detail + "',";
            }
            query += "isSaling = '" + this.isSaling + "',";
            if (this.expiredSalingDate != null && this.expiredSalingDate != "")
            {
                query += "expiredSalingDate = '" + this.expiredSalingDate + "',";
            }

            query = query.Remove(query.Length - 1);
            query += " where idProduct = '" + this.idProduct + "'";
            int rowExec = Connection.Instance.ExecuteNonQuery(query);
            if (rowExec == 1)
            {
                return true;
            }
            return false;
        }

        public DataTable GetAllProduct()
        {
            string query = "select * from dbo.products";
            return Connection.Instance.ExecuteQuery(query);
        }
        public Product GetProductById()
        {
            string query = "select * from dbo.products where idProduct = '" + this.idProduct + "'";
            Product a = new Product();
            DataTable dt = Connection.Instance.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                a.idProduct = row["idProduct"].ToString();
                a.idSize = row["idSize"].ToString();
                a.idBrand = row["idBrand"].ToString();
                a.idColor = row["idColor"].ToString();
                a.idCategory = row["idCategory"].ToString();
                a.idType = row["idType"].ToString();
                a.price = row["price"].ToString();
                a.salePrice = row["salePrice"].ToString();
                a.photoReview = row["photoReview"].ToString();
                a.detail = row["detail"].ToString();
                a.isSaling = Int32.Parse(row["isSaling"].ToString());
                a.expiredSalingDate = row["expiredSalingDate"].ToString();
                a.dateAdded = row["dateAdded"].ToString();
            }
            return a;
        }

        public DataTable GetProductByType()
        {
            string query = "select * from dbo.products where idType = '" + this.idType + "'";
            return Connection.Instance.ExecuteQuery(query);
        }
        public string IdProduct { get => idProduct; set => idProduct = value; }
        public string IdSize { get => idSize; set => idSize = value; }
        public string IdBrand { get => idBrand; set => idBrand = value; }
        public string IdColor { get => idColor; set => idColor = value; }
        public string IdCategory { get => idCategory; set => idCategory = value; }
        public string IdType { get => idType; set => idType = value; }
        public string Price { get => price; set => price = value; }
        public string SalePrice { get => salePrice; set => salePrice = value; }
        public string PhotoReview { get => photoReview; set => photoReview = value; }
        public string Detail { get => detail; set => detail = value; }
        public int IsSaling { get => isSaling; set => isSaling = value; }
        public string ExpiredSalingDate { get => expiredSalingDate; set => expiredSalingDate = value; }
        public string DateAdded { get => dateAdded; set => dateAdded = value; }
    }
}
