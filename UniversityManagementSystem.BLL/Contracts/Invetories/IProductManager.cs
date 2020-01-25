using System.Collections.Generic;
using UniversityManagementSystem.Models.EntityModels.Invetories;

namespace UniversityManagementSystem.BLL.Contracts.Invetories
{
    public interface IProductManager:IManager<Product>
    {
        bool IsProductExist(Product product);
       
        long LastId();

    }
}
