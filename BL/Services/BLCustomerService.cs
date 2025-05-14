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
    public class BLCustomerService : IBLCustomer
    {
        IDal dal;
        public BLCustomerService(IDal dal)
        {
            this.dal = dal;
        }
        public async Task<BLCustomer?> Create(BLCustomer newBlCustomer)
        {

            Customer c = new()
            {
                CustId = newBlCustomer.CustId,
                CustAddress = newBlCustomer.CustAddress,
                CustEmail = newBlCustomer.CustEmail,
                CustName = newBlCustomer.CustName,
                CustPhone = newBlCustomer.CustPhone
            };
            await dal.Customers.Create(c);
            return new BLCustomer(dal.Customers.Get().Result.Find(item => item.CustId == newBlCustomer.CustId));

        }

        public  List<BLCustomer> Get()
        {
            List<BLCustomer> list = new();
            foreach (var item in  dal.Customers.GetAsync().Result)
            {
                list.Add(new BLCustomer(item));
            }
            return list;
        }


        public BLCustomer GetById(int id, string name)
        {
        
            BLCustomer a = Get().Find(item => item.CustId == id);
            if (a?.CustName == name)
                return a;
            else return null;
        }

        public async Task<BLCustomer> Update(BLCustomer newBlCustomer)
        {
            BLCustomer a = Get().Find(item => item.CustId == item.CustId);
            if (a == null)
                return null;
            Customer c = new()
            {
                CustId = newBlCustomer.CustId,
                CustAddress = newBlCustomer.CustAddress,
                CustNum = newBlCustomer.CustNum,
                CustEmail = newBlCustomer.CustEmail,
                CustName = newBlCustomer.CustName,
                CustPhone = newBlCustomer.CustPhone
            };
            var result = await dal.Customers.Update(c);
            return new BLCustomer(result); 
        }
    }
}


