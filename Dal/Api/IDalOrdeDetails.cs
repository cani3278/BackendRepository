using Dal.newModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
   public interface IDalOrderDetails
    {

        List<OrderDetail> DetailsForOrder(int orderId);
        List<OrderDetail> GetAll();
        void AddDetailsForOrder(List<OrderDetail> list);


    }
}
