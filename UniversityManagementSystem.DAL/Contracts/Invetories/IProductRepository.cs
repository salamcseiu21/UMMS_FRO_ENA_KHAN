using System.Collections.Generic;
using UniversityManagementSystem.Models.EntityModels.Invetories;

namespace UniversityManagementSystem.DAL.Contracts.Invetories
{
    public interface IProductRepository:IRepository<Product>
    {
       
        bool IsProductExist(Product product);
        long LastId();
        
       
    }
}
