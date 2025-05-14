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
    public class DalCustomerService : IDalCustomers
    {
        dbcontext dbcontext;
        public DalCustomerService(dbcontext d)
        {
            dbcontext = d;
        }

        public async Task Create(Customer c)
        {
            if (c.CustId != 0 && c.CustName != "string" && c.CustEmail != "string")
            {

                dbcontext.Customers.AddAsync(c);
               await dbcontext.SaveChangesAsync();
            } 
        }

        public async Task< List<Customer>> Get()
        {
            return dbcontext.Customers.ToList();
        }

        public async Task<List<Customer>> GetAsync()
        {
            return await dbcontext.Customers.ToListAsync();
        }

        public async Task<Customer> Update(Customer newC)
        {
            var x = dbcontext.Customers.ToList().Find(i => i.CustId == newC.CustId);
            dbcontext.Customers.Remove(x);
            dbcontext.Customers.AddAsync(newC);
          await  dbcontext.SaveChangesAsync();
            return newC;

        }
    }
}
