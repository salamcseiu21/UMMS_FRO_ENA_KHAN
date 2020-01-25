using System;

namespace UniversityManagementSystem.Models.EntityModels.Invetories
{
   public class ProductDetails
    {

        public long ProductDetailsId { get; set; }
        public long ProductId { get; set; }
        public virtual  Product Product { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
