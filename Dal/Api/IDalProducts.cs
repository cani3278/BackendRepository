using Dal.newModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
  public  interface IDalProducts
    {

        List<ProductsSum> Get();
       Task<List<ProductsSum>> RemoveFromActualList(int prodId);
        Task<List<ProductsSum>> UpdateSum(int prodId, int count);
        Task<List<ProductsSum>> Add(ProductsSum product);
        Task<List<ProductsSum>> Update(ProductsSum product);

    }
}
