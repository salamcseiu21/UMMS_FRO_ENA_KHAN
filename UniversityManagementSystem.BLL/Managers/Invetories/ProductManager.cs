using System;
using System.Collections.Generic;
using UniversityManagementSystem.BLL.Contracts.Invetories;
using UniversityManagementSystem.DAL.Contracts.Invetories;
using UniversityManagementSystem.Models.EntityModels.Invetories;

namespace UniversityManagementSystem.BLL.Managers.Invetories
{
    public class ProductManager:Manager<Product>,IProductManager
    {
        private readonly IProductRepository _productRepository;
        
        public ProductManager(IProductRepository repository) : base(repository)
        {
            _productRepository = repository;
            
        }


        public override bool Add(Product product)
        {
            if (IsProductExist(product))
            {
                throw new Exception("This Product Already Exist");
            }



            return base.Add(product);

        }

        public override bool Update(Product product)
        {
            if (IsProductExist(product))
            {
                throw new Exception("This Product Already Exist");
            }
            return base.Update(product);
        }
        public bool IsProductExist(Product product)
        {
            return _productRepository.IsProductExist(product);
        }

        public long LastId()
        {
            return _productRepository.LastId();
        }


    }
}
