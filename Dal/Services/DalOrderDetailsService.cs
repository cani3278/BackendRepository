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

        public async Task AddDetailsForOrder(List<OrderDetail> list)
        {
            foreach (var item in list)
            {
                dbcontext.OrderDetails.Add(item);
            }
           await dbcontext.SaveChangesAsync();
            dbcontext.OrderDetails.ToListAsync();
        }

        public List<OrderDetail> DetailsForOrder(int orderId)
        {//async not ok
            return dbcontext.OrderDetails.ToList().Where(e=>e.OrderId==orderId).ToList();
        }

        public List<OrderDetail> GetAll()
        {
            return dbcontext.OrderDetails.ToList();
        }

      
    }
}
