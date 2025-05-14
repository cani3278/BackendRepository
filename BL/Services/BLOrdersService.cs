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
        IDal Dal;

        public BLOrdersService(IDal dal)
        {
            this.Dal = dal;
        }

        public async Task<int> Add(int custId, int? empId)
        {
            Order o = new()
            {
                
                OrderDate= DateOnly.FromDateTime(DateTime.Today).ToShortDateString(),
                CustId = custId,
                EmpId = empId==0?empId:null,
                //PaymentType = bLOrder.PaymentType,
                Sent = false
            };
           return  Dal.Orders.Create(o).Result;
        }

        public async Task<List<BLOrder>> AddDetails(List<BLOrderDetail> list,int orderId)
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
               await Dal.Products.UpdateSum(item.ProdId, item.Count);
                dalList.Add(od);
            }
           await Dal.OrderDetail.AddDetailsForOrder(dalList);
            return Get();
        }

        public async Task DeleteAll()
        {
           await Dal.Orders.Delete();
        }

       
        public List<BLOrder> Get()
        {
            List<Order> dallist = Dal.Orders.Get();
            List<BLOrder> bllist = new();

            foreach (var item in dallist)
            {
                string email = null;
                string name = null;

                if (item.EmpId.HasValue) // Check if EmpId has a value
                {
                    email = Dal.Employees.GetByID(item.EmpId.Value).Result.Egmail; // Use .Value to access the int value
                    name = Dal.Employees.GetByID(item.EmpId.Value).Result.Ename;
                }

                bllist.Add(new BLOrder(item, email, name));
            }
            return bllist;
        }

        public List<BLOrder> GetForCustomer(int custId)
        {
            List<Order> dallist = Dal.Orders.GetForCustomer(custId);
            List<BLOrder> bllist = new();

            foreach (var item in dallist)
            {
                string email = null;
                string name = null;

                if (item.EmpId.HasValue) // Check if EmpId has a value
                {
                    email = Dal.Employees.GetByID(item.EmpId.Value).Result.Egmail; // Use .Value to access the int value
                    name = Dal.Employees.GetByID(item.EmpId.Value).Result.Ename;
                }

                bllist.Add(new BLOrder(item, email, name));
            }
            return bllist;
        }

        public List<BLOrder> GetForEmployee(int empId)
        {
            List<Order> dallist = Dal.Orders.GetForEmployee(empId);
            List<BLOrder> bllist = new();

            foreach (var item in dallist)
            {
                if (!(bool)item.Sent)
                {
                string email = Dal.Customers.Get().Result.ToList().Find(cust=>cust.CustId==item.CustId).CustEmail;
                string name = Dal.Customers.Get().Result.ToList().Find(cust => cust.CustId == item.CustId).CustName;
                bllist.Add(new BLOrder(item, email, name));
                }
                
            }
            return bllist;
        }
        public List<BLOrder> GetCompletedForEmployee(int empId)
        {
            List<Order> dallist = Dal.Orders.GetForEmployee(empId);
            List<BLOrder> bllist = new();

            foreach (var item in dallist)
            {
                if ((bool)item.Sent)
                {
                string email = Dal.Customers.Get().Result.ToList().Find(cust => cust.CustId == item.CustId).CustEmail;
                string name = Dal.Customers.Get().Result.ToList().Find(cust => cust.CustId == item.CustId).CustName;
                bllist.Add(new BLOrder(item, email, name));
                }
             
            }
            return bllist;
        }

        public List<BLOrder> GetNews()
        {
            List<Order> dallist = Dal.Orders.Get();
            List<BLOrder> bllist = new();

            foreach (var item in dallist)
            {
                if (item.Sent == false && item.EmpId == 0) { 
                    string email = Dal.Customers.Get().Result.ToList().Find(cust => cust.CustId == item.CustId).CustEmail;
                    string name = Dal.Customers.Get().Result.ToList().Find(cust => cust.CustId == item.CustId).CustName;
                    bllist.Add(new BLOrder(item, email, name));
                }
            }
            return bllist;
        }
        //the employee update about  sending the order
        public async Task UpdateSending(int orderId,int empId)
        {
           await Dal.Orders.UpdateSending(orderId, empId);
           
        }
      

        public async Task AssignOrders(int empId, List<BLOrder> orderList)
        {
            orderList.ToList().ForEach(async o =>
            {
               await Dal.Orders.AssignOrdersToEmp(empId, o.OrderId);
            });
        }

       
    }
}
