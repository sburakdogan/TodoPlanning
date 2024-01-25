using TodoPlanning.Providers.Abstract;
using TodoPlanning.Providers.Concrete;

namespace TodoPlanning.Providers.Factory
{
    public class TodoProviderFactory : ITodoProviderFactory
    {
        public ITodoProvider CreateTodoProvider(string providerType)
        {
            switch (providerType)
            {
                case "First":
                    return new FirstTodoProvider();
                case "Second":
                    return new SecondTodoProvider();
                case "Third":
                    return new ThirdTodoProvider();
                default:
                    throw new ArgumentException("Invalid provider type");
            }
        }
    }
}
