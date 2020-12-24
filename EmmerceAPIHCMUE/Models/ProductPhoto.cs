using EmmerceAPIHCMUE.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EmmerceAPIHCMUE.Models
{
    public class ProductPhoto
    {
        private string IdPhoto;
        private string IdProduct;
        private string Link;
        private string UploadedTime;

        public string idPhoto { get => IdPhoto; set => IdPhoto = value; }
        public string idProduct { get => IdProduct; set => IdProduct = value; }
        public string link { get => Link; set => Link = value; }
        public string uploadedTime { get => UploadedTime; set => UploadedTime = value; }

        public bool AddProductPhoto()
        {
            string query = "insert into dbo.productPhotos values('"+this.idProduct+"','" + this.link + "','" + DateTime.Now.ToString() + "','" + this.idPhoto + "')";
            int rowExec = Connection.Instance.ExecuteNonQuery(query);
            if (rowExec == 1)
            {
                return true;
            }
            return false;
        }
        public bool DeleteProductPhoto()
        {
            string query = "delete from dbo.productPhotos where idPhoto = '" + this.idPhoto + "'";
            int rowExec = Connection.Instance.ExecuteNonQuery(query);
            if (rowExec == 1)
            {
                return true;
            }
            return false;
        }
        public bool UpdateProductPhoto()
        {
            string query = "update dbo.productPhotos set uploadedTime = '" + this.uploadedTime + "',link = '"+this.link+"' where idPhoto = '" + this.idPhoto + "'";
            int rowExec = Connection.Instance.ExecuteNonQuery(query);
            if (rowExec == 1)
            {
                return true;
            }
            return false;
        }
        public DataTable GetAllPhoto()
        {
            string query = "select * from dbo.productPhotos";
            return Connection.Instance.ExecuteQuery(query);
        }
        public List<ProductPhoto> FindByProductID(string id)
        {
            string query = "select * from dbo.productPhotos where idProduct = '" + id + "'";
            DataTable dt = Connection.Instance.ExecuteQuery(query);
            List<ProductPhoto> photos = new List<ProductPhoto>();

            foreach (DataRow row in dt.Rows)
            {
                ProductPhoto a = new ProductPhoto();
                a.idPhoto = row["idPhoto"].ToString();
                a.idProduct = row["idProduct"].ToString();
                a.link = row["link"].ToString();
                a.uploadedTime = row["uploadedTime"].ToString();
                photos.Add(a);
            }

            return photos;
        }
    }
}
