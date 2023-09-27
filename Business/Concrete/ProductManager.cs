using Business.Abstract;
using Entities.Concrete;
using System;
using DataAccess.Abstract;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;
using Core.Utilities.Results;
using FluentValidation;
using Business.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Aspectcs.Autofac.Validation;
using System.Linq;
using Core.Utilities.Business;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspectcs.Autofac.Caching;

namespace Business.Concrete
{
   public class ProductManager : IProductService
    {
        IProductDal _productdal;
        ICategoryService _categoryservice;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productdal = productDal;
            _categoryservice = categoryService;
        }
        //Claim
        //Salting
        [SecuredOperation("product.add")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {

            //ValidationTool.Validate(new ProductValidator(), product);

            IResult result =  BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.ProductId), CheckIfSameNameExists(product.ProductName), 
                CheckIfCategoryExceded());

            if (result != null)
            {
                return result;
            }

            _productdal.Add(product);

            return new SuccessResult(Messages.ProductAdded);

        }
        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 5)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<List<Product>>(_productdal.GetAll(), Messages.ProductsListed);

            }
        }



        public List<Product> GetAllByCategoryId(int id)
        {
            return _productdal.GetAll(p => p.CategoryId == id);
        }

        public Product GetById(int productId)
        {
            return _productdal.Get(p => p.ProductId == productId);
        }

        public IDataResult<List<ProductDetailDTO>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDTO>>(_productdal.GetProductDetails());
        }

        IResult IProductService.Add(Product product)
        {
            _productdal.Add(product);

            return new Result(true, "Product addded");
        }

        IDataResult<List<Product>> IProductService.GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productdal.GetAll(p => p.CategoryId == id));
        }

        IDataResult<Product> IProductService.GetById(int productId)
        {
            throw new NotImplementedException();
        }

        IDataResult<List<ProductDetailDTO>> IProductService.GetProductDetails()
        {
            throw new NotImplementedException();
        }
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productdal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }


        private IResult CheckIfSameNameExists(string categoryName)
        {
            var result = _productdal.GetAll(p => p.ProductName == categoryName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCategoryExceded()
        {
            var result = _categoryservice.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }

        public IDataResult<List<Product>> GetList()
        {
            throw new NotImplementedException();
        }

        //public IDataResult<List<Product>> All()
        //{
        //    throw new NotImplementedException();
        //}



    }
}
