using UniversityManagementSystem.Models.EntityModels.Invetories;

namespace UniversityManagementSystem.BLL.Contracts.Invetories
{
    public interface IProductCategoryManager:IManager<ProductCategory>
    {
        bool IsProductClassNameExist(string productClassName);
    }
}
