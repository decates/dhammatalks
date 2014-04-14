using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

using Ninject;

namespace DhammaTalks.Infrastructure.Ninject
{
    public class NinjectIocRegistration
    {
        public static void RegisterIoc(HttpConfiguration config, ControllerBuilder controllerBuilder, IKernel kernel)
        {
            // Standard ASP.NET MVC controllers
            controllerBuilder.SetControllerFactory(new NinjectControllerFactory(kernel));

            // WebAPI controllers and other core dependencies
            config.DependencyResolver = new NinjectDependencyResolver(kernel);

            // ASP.NET MVC Dependency Resolver
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
