using BL.Models;
using Dal.newModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
   public interface IBLOrders
    {
        Task<int> Add(int custId,int? empId);
        Task<List<BLOrder>> AddDetails(List<BLOrderDetail> list,int orderId);
        Task UpdateSending(int orderId, int empId);
        List<BLOrder> Get();
        Task DeleteAll();
        List<BLOrder> GetNews();
        List<BLOrder> GetForCustomer(int custId);
        List<BLOrder> GetForEmployee(int empId);
        List<BLOrder> GetCompletedForEmployee(int empId);
        Task AssignOrders(int empId, List<BLOrder> ordList);



    }
}
