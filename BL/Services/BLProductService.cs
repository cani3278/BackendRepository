﻿using BL.Api;
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
    public class BLProductService : IBLProducts
    {
        IDal dal;
        public BLProductService(IDal dal)
        {
            this.dal = dal;
        }

        public async Task<List<BLProduct>> Add(BLProduct product)
        {
            ProductsSum DalProduct = new()
            {
                 ProdId =product.ProdId,
                Pname=product.Pname,
                Psum =product.Psum, 
                Pimporter =product.Pimporter,
                Pcompany=product.Pcompany,
                Pdescription=product.Pdescription,
                Ppicture=product.Ppicture
            };
           await dal.Products.Add(DalProduct);
            return Get();
        }

        public async Task<List<BLProduct>> DeleteFromList(int prod)
        {
            await dal.Products.RemoveFromActualList(prod);
            return Get();
        }

        public List<BLProduct> Get()
        {
            List<BLProduct> list = new();
            foreach (var item in dal.Products.Get())
            {
                if(item.Ppicture.EndsWith(".jpg")&& !item.Ppicture.StartsWith("/IMG"))
                list.Add(new BLProduct(item));
            }
            return list;
        }
        public BLProduct GetByID(int id)
        {
            
           ProductsSum p= dal.Products.Get().ToList().Find(p=>p.ProdId==id);
            return new BLProduct(p);
        }

       

        public async Task<List<BLProduct>> Update(BLProduct product)
        {
            ProductsSum dalProd = new ProductsSum()
            {
                ProdId = product.ProdId,
                Pname = product.Pname,
                Psum = product.Psum,
                Pimporter = product.Pimporter,
                Pcompany = product.Pcompany,
                Pdescription = product.Pdescription,
                Ppicture = product.Ppicture

            };
           await dal.Products.Update(dalProd);
            return Get();
            
        }

        public async Task<List<BLProduct>> UpdateAmount(int prodId, int amount)
        {
            await dal.Products.UpdateSum(prodId, amount);
            return Get();
        }
    }
}
