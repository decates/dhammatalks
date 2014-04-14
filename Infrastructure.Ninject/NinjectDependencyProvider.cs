namespace DhammaTalks.Infrastructure.Ninject
{
    using global::Ninject;

    public class NinjectDependencyProvider : IDependencyProvider
    {
        private readonly IKernel kernel;

        public NinjectDependencyProvider(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public T Get<T>()
        {
            return this.kernel.Get<T>();
        }
    }
}
