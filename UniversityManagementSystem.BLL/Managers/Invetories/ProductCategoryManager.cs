using System;
using UniversityManagementSystem.BLL.Contracts.Invetories;
using UniversityManagementSystem.DAL.Contracts.Invetories;
using UniversityManagementSystem.Models.EntityModels.Invetories;

namespace UniversityManagementSystem.BLL.Managers.Invetories
{
    public class ProductCategoryManager:Manager<ProductCategory>,IProductCategoryManager
    {
        private IProductCategoryRepository _productCategoryRepository;
        public ProductCategoryManager(IProductCategoryRepository repository) : base(repository)
        {
            _productCategoryRepository = repository;
        }
        public override bool Add(ProductCategory productCategory)
        {
            if (IsProductClassNameExist(productCategory.Name))
            {
                throw new Exception("Product Class Name Already Exist");
            }
            return base.Add(productCategory);
        }
        public override bool Update(ProductCategory productCategory)
        {
            if (IsProductClassNameExist(productCategory.Name))
            {
                throw new Exception("ProductCategory Name Already Exist");
            }
            return base.Update(productCategory);
        }
        public bool IsProductClassNameExist(string productClassName)
        {
            return _productCategoryRepository.IsProductClassNameExist(productClassName);
        }
    }
}
