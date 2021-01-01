using EmmerceAPIHCMUE.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmmerceAPIHCMUE.Models
{
    public class OrdersList
    {
        private string IdOrderList;
        private string IdOrder;
        private string IdUser;
        private string TotalPrice;
        private string IdVoucher;
        private List<MultipleProduct> Products;
        public string idOrderList { get => IdOrderList; set => IdOrderList = value; }
        public string idOrder { get => IdOrder; set => IdOrder = value; }
        public string idUser { get => IdUser; set => IdUser = value; }
        
        public List<MultipleProduct> products { get => Products; set => Products = value; }
        public string totalPrice { get => TotalPrice; set => TotalPrice = value; }
        public string idVoucher { get => IdVoucher; set => IdVoucher = value; }

        public bool AddCheckout()
        {   
            string idOd = Helper.Instance.CreateRandomPassword(4);
            string queryinitOrderDetail = "insert into dbo.odersList values('" + idOd + "','" + this.idUser+ "',0,'" + DateTime.UtcNow.ToString() + "','"+this.idVoucher+"','"+this.totalPrice+"')";
            string delVoucher = "update dbo.vouchers set isUse = 1 where idVoucher='" + this.idVoucher + "'";
            Connection.Instance.ExecuteNonQuery(delVoucher);
            if (Connection.Instance.ExecuteNonQuery(queryinitOrderDetail) < 1)
            {
                return false;
            }
            foreach (MultipleProduct item in this.products)
            {
                string query1 = "insert into dbo.odersDetails values('" + Helper.Instance.CreateRandomPassword(6) + "','" + idOd + "','" + item.idProduct + "', '" + item.quanlity + "')";
                if (Connection.Instance.ExecuteNonQuery(query1) == 1)
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public bool ValidateVoucher(string voucher)
        {
            string query = "select isUse from dbo.vouchers where idVoucher = '" + voucher + "'";
            int status = Int32.Parse(Connection.Instance.ExecuteScalar(query).ToString());
            return status == 0;
        } 
        public bool UpdateStatusCheckout()
        {
            string query = "update dbo.odersDetails set status = status + 1 where idOder = '"+this.idOrder+"'";
            if (Connection.Instance.ExecuteNonQuery(query) == 1)
            {
                return true;
            }
            return false;
        }
    }
    public class MultipleProduct
    {
        private string IdProduct;
        private int Quanlity;
        public string idProduct { get => IdProduct; set => IdProduct = value; }
        public int quanlity { get => Quanlity; set => Quanlity = value; }
    }
}
