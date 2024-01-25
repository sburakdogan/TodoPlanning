using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TodoPlanning.Business.Abstract;
using TodoPlanning.Business.Concrete;
using TodoPlanning.Data;
using TodoPlanning.Data.Repositories.Abstract;
using TodoPlanning.Data.Repositories.Concrete;
using TodoPlanning.Providers.Factory;
using TodoPlanning.Providers.Singleton;
using TodoPlanning.Services;

#region DI

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();


var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<ApplicationDbContext>(options =>  options.UseSqlServer(configuration.GetConnectionString("DefaultDatabase")));
        services.AddTransient<IDeveloperRepository, DeveloperRepository>();
        services.AddTransient<ITaskRepository, TaskRepository>();
        services.AddTransient<ITodoOperations, TodoOperations>();
        services.AddDbContext<ApplicationDbContext>();
    })
    .Build();

var serviceProvider = host.Services;

var todoOperations = serviceProvider.GetRequiredService<ITodoOperations>();

#endregion

const string PROVIDER_NAME = "First";
ProviderSingleton.Instance.ProviderName = PROVIDER_NAME;

ITodoProviderFactory todoProviderFactory = new TodoProviderFactory();
ITodoService todoService = new TodoService(todoProviderFactory, PROVIDER_NAME);

var processedTodoItems = await todoService.GetProcessedTodoItems();

await todoOperations.AddDevelopers(processedTodoItems.Developer);
await todoOperations.AddTasks(processedTodoItems.Tasks);