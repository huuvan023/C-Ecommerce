using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Data.Enums;

namespace WebAPI.ViewModels.Orders
{
    public class OrderVm
    {
        public int Id { get; set; }

        public int ProductId { set; get; }

        public Guid UserId { get; set; }

        public string UserName { set; get; }

        public string ShipName { set; get; }

        public string ShipAddress { set; get; }
      
        public string ShipEmail { set; get; }
        
        public string ShipPhoneNumber { set; get; }

        public int Quantity { set; get; }

        public decimal Price { set; get; }


        public DateTime OrderDate { set; get; }

        public Status Status { set; get; }

        public string LanguageId { set; get; }
    }
}
