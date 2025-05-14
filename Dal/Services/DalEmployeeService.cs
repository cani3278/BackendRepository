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
   public class DalEmployeeService : IDalEmployee
    {
        dbcontext Dal;

        public DalEmployeeService(dbcontext db)
        {
            Dal = db;
        }
        public async Task Add(Employee e)
        {
            Dal.Employees.Add(e);
            Dal.SaveChanges();
        }

        
        public async Task<List<Employee>> getAll()
        {
          return await Dal.Employees.ToListAsync();
        }

        public async Task<Employee> getByID(int id)
        {
            return Dal.Employees.ToList().Find(e =>e.EmpId==id);
        }

        
    }
}
