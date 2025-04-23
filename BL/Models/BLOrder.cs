using Dal.newModels;
using Dal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
  public  class BLOrder
    {
        public int OrderId { get; }

        //public string? OrdersDetails { get; set; }

        public string OrderDate { get; set; }

        public int CustId { get; set; }

        public int EmpId { get; set; }
        public string? PaymentType { get; set; }

        public bool? Sent { get; set; }
        //public /*virtual*/ ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        public BLOrder(Order o)
        {
            this.OrderId = o.OrderId;
            this.CustId = o.CustId;
            this.OrderDate = o.OrderDate;
            this.PaymentType = o.PaymentType;
            this.Sent = o.Sent;
        }
        override
        public  string ToString()
        {
            return OrderId + " " + OrderDate + " " + CustId;
        }
       
    }
}
