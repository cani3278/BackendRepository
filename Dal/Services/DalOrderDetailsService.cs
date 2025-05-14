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
    public class DalOrderDetailsService : IDalOrderDetails
    {

          dbcontext dbcontext;
        public DalOrderDetailsService(dbcontext d)
        {
            dbcontext = d;
        }

        public void AddDetailsForOrder(List<OrderDetail> list)
        {
            foreach (var item in list)
            {
                dbcontext.OrderDetails.Add(item);
            }
            dbcontext.SaveChanges();
            dbcontext.OrderDetails.ToList();
        }

        public List<OrderDetail> DetailsForOrder(int orderId)
        {
            return dbcontext.OrderDetails.ToList().Where(e=>e.OrderId==orderId).ToList();
        }

        public List<OrderDetail> GetAll()
        {
            return dbcontext.OrderDetails.ToList();
        }

      
    }
}
