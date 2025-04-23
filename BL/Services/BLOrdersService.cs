using BL.Api;
using BL.Models;
using Dal.Api;
using Dal.newModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BLOrdersService : IBLOrders
    {
        IDal dal;
        public BLOrdersService(IDal dal)
        {
            this.dal = dal;
        }
        //public void Add(BLOrder bLOrder)
        //{
        //    Order o = new()
        //    {
        //        OrderId = bLOrder.OrderId,
        //       //OrdersDetais = bLOrder.OrdersDetais,
        //        OrderDate = bLOrder.OrderDate,
        //        CustId = bLOrder.CustId,
        //        EmpId = bLOrder.EmpId,
        //        PaymentType = bLOrder.PaymentType,
        //        Sent = bLOrder.Sent
        //    };
        //   // dal.Orders.Create(o, bLOrder.OrderDetails);
        //}
        public int Add(int custId)
        {
            DateTime dt=DateTime.Now;
            Console.WriteLine("DateTime in Normal format: ");
            string sqlFormattedDate=dt.ToString("yyyy-MM-dd HH:mm:ss");
            Console.WriteLine("DateTime in SQL format: ");
            
                        Order o = new()
            {
                
                OrderDate= DateOnly.FromDateTime(DateTime.Today).ToShortDateString(),
                CustId = custId,
                EmpId = dal.Employees.AvailableEmployee().EmpId,
                //PaymentType = bLOrder.PaymentType,
                Sent = false
            };
           return  dal.Orders.Create(o);
        }

        public List<BLOrder> addDetails(List<BLOrderDetail> list,int orderId)
        {
            List<OrderDetail> dalList = new();
            foreach (var item in list)
            {
                OrderDetail od = new()
                {
                    OrderId=orderId,
                    ProdId=item.ProdId,
                    Count=item.Count
                };
                dalList.Add(od);
            }
            dal.OrderDetail.addDetailsForOrder(dalList);
            return Get();
        }

        public void deleteAll()
        {
            dal.Orders.Delete();
        }

        public List<BLOrder> Get()
        {
         List<Order>  dallist=dal.Orders.Get();
         List<BLOrder>  bllist=new();

            foreach (var item in dallist)
            {
                bllist.Add(new BLOrder(item));
            }
            return bllist;
        }

        public List<BLOrder> GetForCustomer(int custId)
        {
            List<Order> dallist = dal.Orders.GetForCustomer(custId);
            List<BLOrder> bllist = new();

            foreach (var item in dallist)
            {
                bllist.Add(new BLOrder(item));
            }
            return bllist;
        }

        public List<BLOrder> GetForEmployee(int empId)
        {
            List<Order> dallist = dal.Orders.GetForEmployee(empId);
            List<BLOrder> bllist = new();

            foreach (var item in dallist)
            {
                bllist.Add(new BLOrder(item));
            }
            return bllist;
        }

        public List<BLOrder> GetNews()
        {
            throw new NotImplementedException();
        }
    }
}
