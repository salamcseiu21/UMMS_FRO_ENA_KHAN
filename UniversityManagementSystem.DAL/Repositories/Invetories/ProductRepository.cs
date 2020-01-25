using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using UniversityManagementSystem.DAL.Contracts.Invetories;
using UniversityManagementSystem.Models.EntityModels.Invetories;

namespace UniversityManagementSystem.DAL.Repositories.Invetories
{
    public class ProductRepository : Repository<Product>,IProductRepository
    {       

            
        
            public bool IsProductExist(Product product)
            {
                if (db.Products.Any(e => e.Name == product.Name && e.ProductCategoryId == product.ProductCategoryId))
                {
                    return true;
                }
                else
                {
              
                    return false;
                }
            }

        public override ICollection<Product> GetAll()
        {
            return db.Products.Include(e => e.ProductCategory)
             .ToList();
        }

        public override Product GetById(long? id)
        {

           
            return db.Products.Include(e => e.ProductCategory)
               .FirstOrDefault(e => e.Id == id);

        }

        public long LastId()
            {
            return db.Products.Max(e => e.Id);
            }

     

       

       
    }

}
