using System;
using System.Linq;
using System.Web.Http.Dependencies;

using Ninject.Activation;
using Ninject.Parameters;
using Ninject.Syntax;

namespace DhammaTalks.Infrastructure.Ninject
{
    public class NinjectDependencyScope : IDependencyScope
    {
        private IResolutionRoot resolutionRoot;

        public NinjectDependencyScope(IResolutionRoot resolver)
        {
            this.resolutionRoot = resolver;
        }

        public object GetService(Type serviceType)
        {
            IRequest request = this.resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
            var service = this.resolutionRoot.Resolve(request).SingleOrDefault();
            return service;
        }

        public System.Collections.Generic.IEnumerable<object> GetServices(Type serviceType)
        {
            IRequest request = this.resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
            var services = this.resolutionRoot.Resolve(request).ToList();
            return services;
        }

        public void Dispose()
        {
            IDisposable disposable = this.resolutionRoot as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }

            this.resolutionRoot = null;
        }
    }
}
