

using System;
using System.Web.Mvc;
using System.Web.Routing;

using Ninject;

namespace DhammaTalks.Infrastructure.Ninject
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory(IKernel kernel)
        {
            this.ninjectKernel = kernel;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                       ? null
                       : (IController)this.ninjectKernel.Get(controllerType);
        }
    }
}