using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using RManager.Controllers;
using RManager.Models;
using RManager.Models.Repositoryes;

namespace RManager
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            ControllerBuilder.Current.SetControllerFactory(new ControllerFactory());
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FirstStart();
        }

        private void FirstStart()
        {
            ModelContainer cont = new ModelContainer();
            BranchRepository branchRepository = new BranchRepository(cont);
            CategoryRepository categoryRepository = new CategoryRepository(cont);
            CompanyOwnerRepository companyOwnerRepository = new CompanyOwnerRepository(cont);
            PersonRepository personRepository = new PersonRepository(cont);
            PositionRepository positionRepository = new PositionRepository(cont);
            RoomRepository roomRepository = new RoomRepository(cont);
            TableRepository tableRepository = new TableRepository(cont);
            ClientRepository clientRepository = new ClientRepository(cont);

            if (positionRepository.Positions().Count() == 0)
                positionRepository.AddPosition("Суперпользователь", true, true, true, true, true, true);

            CompanyOwner co = new CompanyOwner();
            if (personRepository.Persones().Count() == 0)
                co = companyOwnerRepository.AddCompanyOwner("Суперпользователь", "", "", "", "", "super", "super".GetHashCode().ToString(), "", "", "",
                    positionRepository.GetPositionByName("Суперпользователь"));

            Branch b = new Branch();
            if (branchRepository.Branches().Count() == 0)
                b = branchRepository.AddBranch("", "", DateTime.Now, DateTime.Now, "", "", "", "", "", co, null);

            Room r = new Room();
            if (roomRepository.Rooms().Count() == 0)
                r = roomRepository.AddRoom("", b);

            if (categoryRepository.Categotyes().Count() == 0)
                categoryRepository.AddCategory("");

            if (tableRepository.Tables().Count() == 0)
                tableRepository.AddTable(1, "", r);

            if (clientRepository.Clients().Count() == 0)
                clientRepository.AddClient("Клиент", "", "", "", "", "", "", "", "", "", "", "");
        }
    }
}
