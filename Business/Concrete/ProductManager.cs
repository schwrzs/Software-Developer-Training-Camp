using Business.Abstract;
using Entities.Concrete;
using System;
using DataAccess.Abstract;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
   public class ProductManager : IProductService
    {
        IProductDal _productdal;

        public ProductManager(IProductDal productDal)
        {
            _productdal = productDal;
        }


        public List<Product> GetAll()
        {
            return _productdal.GetAll();
        }

    }
}
