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
    public class BLOrderDetailsService : IBLOrderDetails
    {
        IDal dal;
        public BLOrderDetailsService(IDal dal)
        {
            this.dal = dal;
        }

        public List<BLOrderDetail> GetAll()
        {
            List<BLOrderDetail> list = new();
            foreach (var item in dal.OrderDetail.GetAll())
            {
                BLOrderDetail newbl = new BLOrderDetail(item);
                 list.Add(newbl);

            }
            return list;
        }

        public List<BLOrderDetail> GetForOrderId(int orderId)
        {
            List<BLOrderDetail> list = new();
            foreach (var item in dal.OrderDetail.DetailsForOrder(orderId))
            {
                BLOrderDetail newbl =new BLOrderDetail(item);
                var a = dal.Products.Get().Find(p => p.ProdId == item.ProdId);
                newbl.ProdName = a.Pname;
                newbl.ProdPic = a.Ppicture;

                list.Add(newbl);

            }
            return list ;
        }

        

        
    }
}
