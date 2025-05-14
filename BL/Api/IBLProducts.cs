using BL.Models;
using Dal.newModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
 public   interface IBLProducts
    {
        List<BLProduct> Get();
        BLProduct GetByID(int id);
        Task<List<BLProduct>> DeleteFromList(int prod);
        Task<List<BLProduct>> Add(BLProduct product);
        Task<List<BLProduct>> UpdateAmount(int prodId,int amount);
        Task<List<BLProduct>> Update(BLProduct product);
    }
}
