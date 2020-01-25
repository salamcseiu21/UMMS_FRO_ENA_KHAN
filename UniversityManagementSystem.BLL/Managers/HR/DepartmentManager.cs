using UniversityManagementSystem.BLL.Contracts.HR;
using UniversityManagementSystem.DAL.Contracts.HR;
using UniversityManagementSystem.Models.EntityModels.HR;

namespace UniversityManagementSystem.BLL.Managers.HR
{
   public class DepartmentManager:Manager<Department>,IDepartmentManager
   {

       private IDepartmentRepository _departmentRepository;

       public DepartmentManager(IDepartmentRepository repository) : base(repository)
       {
           _departmentRepository = repository;
       }


}
}
