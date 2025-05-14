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

        public async Task AssignOrdersToEmp(int empId, int ordId)
        {
            Order o = await dbcontext.Orders.ToListAsync().ContinueWith(task => task.Result.Find(i => i.OrderId == ordId));
            o.EmpId = empId;
            dbcontext.Orders.Update(o); // Removed 'await' as Update is not asynchronous
            await dbcontext.SaveChangesAsync(); // Save changes asynchronously
        }

        public async Task<int> Create(Order o)
        {
            var x = dbcontext.Orders.Add(o);
           await dbcontext.SaveChangesAsync();
            return dbcontext.Orders.ToList().Last().OrderId;
        }

        public async Task Delete()
        {
            dbcontext.Orders.ToList().RemoveAll(e => e.OrderId != 0);
        }

        public List<Order> Get()
        {
            var list = dbcontext.Orders.ToList();
            return list;
        }

        public List<Order> GetForCustomer(int custId)
        {
            List<Order> list = dbcontext.Orders.ToList();
            List<Order> custList = list.Where(a => a.CustId == custId)
              .OrderBy(a => a.OrderDate).ToList();
            return custList;
        }

        public List<Order> GetForEmployee(int empId)
        {
            List<Order> list = dbcontext.Orders.ToList();
            List<Order> empList = list.Where(a => a.EmpId == empId)
              .OrderBy(a => a.OrderDate).ToList();
            return empList;
        }

        public async Task UpdateSending(int orderId, int empId)
        {
            Order o = dbcontext.Orders.ToList().Find(e => e.OrderId == orderId);
            o.Sent = true;
            o.EmpId = empId;
          await  dbcontext.SaveChangesAsync();
        }
    }
}
