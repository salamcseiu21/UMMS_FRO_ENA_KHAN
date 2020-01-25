using System.Linq;
using UniversityManagementSystem.DAL.Contracts.Invetories;
using UniversityManagementSystem.Models.EntityModels.Invetories;

namespace UniversityManagementSystem.DAL.Repositories.Invetories
{
    public class ProductCategoryRepository:Repository<ProductCategory>,IProductCategoryRepository
    {
       public bool IsProductClassNameExist(string productClassName)
        {
            if (db.ProductClasses.Any(e=>e.Name == productClassName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
