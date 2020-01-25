using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using UniversityManagementSystem.BLL.Contracts.Company;
using UniversityManagementSystem.BLL.Contracts.HR;
using UniversityManagementSystem.BLL.Contracts.Invetories;
using UniversityManagementSystem.BLL.Managers.Company;
using UniversityManagementSystem.BLL.Managers.HR;
using UniversityManagementSystem.BLL.Managers.Invetories;
using UniversityManagementSystem.DAL.Contracts.Company;
using UniversityManagementSystem.DAL.Contracts.HR;
using UniversityManagementSystem.DAL.Contracts.Invetories;
using UniversityManagementSystem.DAL.Repositories.Company;
using UniversityManagementSystem.DAL.Repositories.HR;
using UniversityManagementSystem.DAL.Repositories.Invetories;

namespace UniversityManagementSystem
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));


            container.RegisterType<IUniversityManager, UniversityManager>();
            container.RegisterType<IUniversityRepository, UniversityRepository>();

            container.RegisterType<ISupplierManager, SupplierManager>();
            container.RegisterType<ISupplierRepository, SupplierRepository>();

            container.RegisterType<IDepartmentManager, DepartmentManager>();
            container.RegisterType<IDepartmentRepository, DepartmentRepository>();

            container.RegisterType<IProductCategoryManager, ProductCategoryManager>();
            container.RegisterType<IProductCategoryRepository, ProductCategoryRepository>();

            container.RegisterType<IProductManager,ProductManager>();
            container.RegisterType<IProductRepository, ProductRepository>();

            container.RegisterType<IProductDetailsManager, ProductDetailsManager>();
            container.RegisterType<IProductDetailsRepository, ProductDetailsRepository>();
        }
    }
}