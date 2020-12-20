using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebAPI.Data.Enums;

namespace WebAPI.Data.Entities
{   
    public class Order
    {
        public int Id { set; get; }
        public string UserName { set; get; }

        public Guid UserId { get; set; }
        public DateTime OrderDate { set; get; }
        public string ShipName { set; get; }
        public string ShipAddress { set; get; }
        public string ShipEmail { set; get; }
        public string ShipPhoneNumber { set; get; }

        public string LanguageId { set; get; }

        [DefaultValue(Status.Active)]
        public Status Status { set; get; } = Status.Active;

        public List<OrderDetail> OrderDetails { get; set; }

        public Language Language { get; set; }


    }
}
