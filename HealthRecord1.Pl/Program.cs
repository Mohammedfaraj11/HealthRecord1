 using HealthRecord1.DAL.Database;
using HealthRecord1.BLL.Interfaces;
using HealthRecord1.BLL.Repository;
using Microsoft.EntityFrameworkCore;
using HealthRecord1.BLL.Mapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Auto mapper
builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));

// Transient : One Object for Operation
//builder.Services.AddTransient<IOperation, OperationRepo>();

// Transient : One Object for Operation
builder.Services.AddScoped<IOperation, OperationRepo>();

// Scoped : One Object for Operation
//builder.Services.AddSingleton<IOperation, OperationRepo>();


// Add DbContext configuration
builder.Services.AddDbContext<MyContext>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
