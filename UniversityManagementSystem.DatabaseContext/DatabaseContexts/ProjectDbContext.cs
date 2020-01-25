using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagementSystem.Models.EntityModels.Company;
using UniversityManagementSystem.Models.EntityModels.HR;
using UniversityManagementSystem.Models.EntityModels.Invetories;

namespace UniversityManagementSystem.DatabaseContext.DatabaseContexts
{
   public class ProjectDbContext:DbContext
    {
        public DbSet<University> Universitiess { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<ProductCategory> ProductClasses { get; set; }

     

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductDetails> ProductDetails { get; set; }

    }
}
