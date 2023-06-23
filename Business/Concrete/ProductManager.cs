using Business.Abstract;
using Entities.Concrete;
using System;
using DataAccess.Abstract;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;

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

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productdal.GetAll(p => p.CategoryId == id);
        }

        public List<ProductDetailDTO> GetProductDetails()
        {
            return _productdal.GetProductDetails();
        }
    }
}
