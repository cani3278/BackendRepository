using Dal.newModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
   public interface IDalOrders
    {

        List<Order> Get();
        List<Order> GetForCustomer(int custId);
        List<Order> GetForEmployee(int empId);

       Task<int> Create(Order o);
        Task Delete();
        Task UpdateSending(int orderId,int empId);
        Task AssignOrdersToEmp(int empId,int ordId);


    }
}
