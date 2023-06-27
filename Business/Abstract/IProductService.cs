using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();

        //List<Product> GetAll();

        IDataResult<List<Product>> GetAllByCategoryId(int id);

        IDataResult<List<ProductDetailDTO>> GetProductDetails();
        //List<ProductDetailDTO> GetProductDetails();

        IDataResult<Product> GetById(int productId);

        //void Add(Product product);

        IResult Add(Product product);

    }
}
