using TodoPlanning.Data;
using Microsoft.EntityFrameworkCore;
using TodoPlanning.Data.Repositories.Abstract;
using TodoPlanning.Data.Repositories.Concrete;
using TodoPlanning.Business.Abstract;
using TodoPlanning.Business.Concrete;
using TodoPlanning.Providers.Singleton;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationDbContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDatabase")));
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<ITaskRepository, TaskRepository>();
builder.Services.AddTransient<IDeveloperRepository, DeveloperRepository>();
builder.Services.AddTransient<ITodoOperations, TodoOperations>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
