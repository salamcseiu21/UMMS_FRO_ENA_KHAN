using UniversityManagementSystem.BLL.Contracts.Invetories;
using UniversityManagementSystem.DAL.Contracts.Invetories;
using UniversityManagementSystem.Models.EntityModels.Invetories;

namespace UniversityManagementSystem.BLL.Managers.Invetories
{
    public class ProductDetailsManager : Manager<ProductDetails>,IProductDetailsManager
    {
        public ProductDetailsManager(IProductDetailsRepository repository) : base(repository)
        {
        }
    }
}
