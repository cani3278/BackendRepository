using Dal.Api;
using Dal.newModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class DalOrdersService : IDalOrders
    {

          dbcontext dbcontext;
        public DalOrdersService(dbcontext d)
        {
            dbcontext = d;
        }



        //public void Create(Order o,List< OrderDetail>  od)
        //{
        //    dbcontext.Orders.Add(o);
        //    od.ForEach(item => dbcontext.OrderDetails.Add(item));
        //    dbcontext.SaveChanges();

        //}
        public int Create(Order o)
        {
          var x=  dbcontext.Orders.Add(o);
          dbcontext.SaveChanges();
           
          return  dbcontext.Orders.ToList().Last().OrderId ;
           

        }

        public void Delete()
        {
            dbcontext.Orders .ToList().RemoveAll(e=>e.OrderId!=0);

        }

        public List<Order> Get()
        {
         var list=   dbcontext.Orders.ToList();//Include(x=>x.OrderDetails).
            var x = list;
            //foreach (var item in list)
            //{
            //    item.OrderDetails = dbcontext.OrderDetails.ToList().Where(i => i.OrderId == item.OrderId).ToList();  
            //}
            return list;
        }

        public List<Order> GetForCustomer(int custId)
        {
            List<Order> list= dbcontext.Orders.ToList();
            List<Order> custList = list.Where(a => a.CustId == custId)
          .OrderBy(a => a.OrderDate).ToList();
            //.ForEach( item => item.OrderDetails = dbcontext.OrderDetails.ToList().Where(i => i.OrderId == item.OrderId).ToList())
         /*   foreach (var item in custList)
            {
                item.OrderDetails = dbcontext.OrderDetails.ToList().Where(i => i.OrderId == item.OrderId).ToList();
            }*/

            return custList;

        }

        public List<Order> GetForEmployee(int empId)
        {
            List<Order> list = dbcontext.Orders.ToList();
            List<Order> empList = list.Where(a => a.EmpId == empId)
          .OrderBy(a => a.OrderDate).ToList();
            return empList;
        }

        public List<Order> GetNews()
        {
            throw new NotImplementedException();
        }

      

        //List<Order> IDalOrders.Get()
        //{
        //    return dbcontext.Orders.ToList();

        //}

        //List<Order> IDalOrders.GetForCustomer(int custId)
        //{
        //    throw new NotImplementedException();
        //}

        //List<Order> IDalOrders.GetForEmployee(int empId)
        //{
        //    throw new NotImplementedException();
        //}

        //List<Order> IDalOrders.GetNews()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
