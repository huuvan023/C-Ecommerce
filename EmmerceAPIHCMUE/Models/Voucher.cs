using EmmerceAPIHCMUE.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmmerceAPIHCMUE.Models
{
    public class Voucher
    {

        private string idVoucher;
        private int price;
        private string expiredDate;
        private int isUse;

        public bool AddVoucher()
        {
            string query = "insert into dbo.vouchers values('" + Helper.Instance.GenarateID() + "','" + this.price + "', '" + this.expiredDate + "', '" + this.isUse + "')";
            int rowExec = Connection.Instance.ExecuteNonQuery(query);
            if (rowExec == 1)
            {
                return true;
            }
            return false;
        }

        public bool DeleteVoucher()
        {
            string query = "delete from dbo.vouchers where idVoucher='" + this.idVoucher + "'";
            int rowExec = Connection.Instance.ExecuteNonQuery(query);
            if (rowExec == 1)
            {
                return true;
            }
            return false;
        }

        public string IdVoucher { get => idVoucher; set => idVoucher = value; }
        public int Price { get => price; set => price = value; }
        public string ExpiredDate { get => expiredDate; set => expiredDate = value; }
        public int IsUse { get => isUse; set => isUse = value; }


        
    }
}
