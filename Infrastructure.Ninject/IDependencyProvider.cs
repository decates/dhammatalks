namespace DhammaTalks.Infrastructure.Ninject
{
    public interface IDependencyProvider
    {
        T Get<T>();
    }
}