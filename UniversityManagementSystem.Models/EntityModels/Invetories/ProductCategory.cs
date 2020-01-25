using System;
using System.Collections.Generic;

namespace UniversityManagementSystem.Models.EntityModels.Invetories
{
   public class ProductCategory
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual List<Product> Products { get; set; }
       
    }
}
