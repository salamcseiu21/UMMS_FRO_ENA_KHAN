using UniversityManagementSystem.BLL.Contracts.Company;
using UniversityManagementSystem.DAL.Contracts.Company;
using UniversityManagementSystem.Models.EntityModels.Company;

namespace UniversityManagementSystem.BLL.Managers.Company
{
   public class SupplierManager : Manager<Supplier>, ISupplierManager
   {
       public SupplierManager(ISupplierRepository repository) : base(repository)
       {
       }
   }

}
