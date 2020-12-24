
﻿using EmmerceAPIHCMUE.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EmmerceAPIHCMUE.Models
{
    public class OrdersDetails
    {
        private string IdOder;
        private string Date;
        private string Status;
        private string TotalPrice;
        private string IdUser; 
        public string idOder { get => IdOder; set => IdOder = value; }
        public string date { get => Date; set => Date = value; }
        public string status { get => Status; set => Status = value; }
        public string totalPrice { get => TotalPrice; set => TotalPrice = value; }
        public string idUser { get => IdUser; set => IdUser = value; }

        public DataTable GetDetailsOder()
        {
            string query = "select * from dbo.odersList where idOder = '" + this.idOder + "'";
            return Connection.Instance.ExecuteQuery(query);
        }
    }
}
