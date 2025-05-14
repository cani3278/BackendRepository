using Dal.newModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
  public  interface IDalEmployee
    {
       Task< List<Employee>> GetAll();
        Task<Employee> GetByID(int id);
        Task Add(Employee e);
    }
}
