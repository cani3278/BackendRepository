using Dal.newModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
   public interface IDalCustomers
    {
        Task<List<Customer>> Get();
        Task<List<Customer>> GetAsync();
        Task Create(Customer c);
        Task<Customer> Update(Customer c);
    }
}
