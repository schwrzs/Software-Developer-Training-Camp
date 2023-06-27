using Business.Abstract;
using Entities.Concrete;
using System;
using DataAccess.Abstract;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;
using Core.Utilities.Results;

namespace Business.Concrete
{
   public class ProductManager : IProductService
    {
        IProductDal _productdal;

        public ProductManager(IProductDal productDal)
        {
            _productdal = productDal;
        }

        public IResult Add(Product product)
        {
        if (product.ProductName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productdal.Add(product);

            return new SuccesResult(Messages.ProductAdded);

        }

        public IDataResult<List<Product>> GetAll()
        {
            return new DataResult<List<Product>>(_productdal.GetAll(),true,"");
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productdal.GetAll(p => p.CategoryId == id);
        }

        public Product GetById(int productId)
        {
            return _productdal.Get(p => p.ProductId == productId);
        }

        public List<ProductDetailDTO> GetProductDetails()
        {
            return _productdal.GetProductDetails();
        }

        IResult IProductService.Add(Product product)
        {
            _productdal.Add(product);

            return new Result(true, "Product addded");
        }

        IDataResult<List<Product>> IProductService.GetAllByCategoryId(int id)
        {
            throw new NotImplementedException();
        }

        IDataResult<Product> IProductService.GetById(int productId)
        {
            throw new NotImplementedException();
        }

        IDataResult<List<ProductDetailDTO>> IProductService.GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
