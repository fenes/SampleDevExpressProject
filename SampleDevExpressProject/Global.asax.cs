using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using SampleDevExpressProject.DataAccessLayer;
using SampleDevExpressProject.DataAccessLayer.Implementation;
using SampleDevExpressProject.Repository;
using SampleDevExpressProject.Repository.Implementation;

namespace SampleDevExpressProject {

    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start()
        {
            DependencyInjectionProcess();
            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
            ModelBinders.Binders.DefaultBinder = new DevExpress.Web.Mvc.DevExpressEditorsBinder();

            DevExpress.Web.ASPxWebControl.CallbackError += Application_Error;
        }

        private void DependencyInjectionProcess()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<AccountService>().As<IAccountService>();
            builder.RegisterType<AccountRepository>().As<IAccountRepository>();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        protected void Application_Error(object sender, EventArgs e) {
            Exception exception = System.Web.HttpContext.Current.Server.GetLastError();
            //TODO: Handle Exception
        }
    }
}