using UniversityManagementSystem.BLL.Contracts.Company;
using UniversityManagementSystem.DAL.Contracts.Company;
using UniversityManagementSystem.Models.EntityModels.Company;

namespace UniversityManagementSystem.BLL.Managers.Company
{
    public class UniversityManager: Manager<University>, IUniversityManager
    {

        private IUniversityRepository _universityRepository;
        public UniversityManager(IUniversityRepository repository) : base(repository)
        {
            _universityRepository = repository;
        }


    }
}
