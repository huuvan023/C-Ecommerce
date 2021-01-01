
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
    private string IdOrderList;
    private string IdProduct;
    private string Quanlity;
    public string idOder { get => IdOder; set => IdOder = value; }
    public string idOrderList { get => IdOrderList; set => IdOrderList = value; }
    public string idProduct { get => IdProduct; set => IdProduct = value; }
    public string quanlity { get => Quanlity; set => Quanlity = value; }

    public DataTable GetDetailsOder()
        {
            string query = "select * from dbo.odersDetails where idOrderList = '" + this.idOrderList + "'";
            return Connection.Instance.ExecuteQuery(query);
        }
    }
}
