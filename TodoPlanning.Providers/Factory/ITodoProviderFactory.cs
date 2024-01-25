using TodoPlanning.Providers.Abstract;

namespace TodoPlanning.Providers.Factory
{
    public interface ITodoProviderFactory
    {
        ITodoProvider CreateTodoProvider(string providerType);
    }
}
