using System;
using System.Collections.Generic;

namespace UniversityManagementSystem.Models.EntityModels.Invetories
{
   public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string ProductSerialNo { get; set; }
       
        // P000011
       
        public long ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }

        
       
        public string Note { get; set; }

       
    }
}
