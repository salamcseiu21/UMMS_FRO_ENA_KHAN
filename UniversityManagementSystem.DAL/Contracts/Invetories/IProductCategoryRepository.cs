using UniversityManagementSystem.Models.EntityModels.Invetories;

namespace UniversityManagementSystem.DAL.Contracts.Invetories
{
    public interface IProductCategoryRepository:IRepository<ProductCategory>
    {
        bool IsProductClassNameExist(string productClassName);
    }
}
