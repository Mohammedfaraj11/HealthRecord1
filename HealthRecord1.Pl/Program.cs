 using HealthRecord1.DAL.Database;
using HealthRecord1.BLL.Interfaces;
using HealthRecord1.BLL.Repository;
using Microsoft.EntityFrameworkCore;
using HealthRecord1.BLL.Mapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using HealthRecord1.DAL.Extends;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Conection String
var connectionString = builder.Configuration.GetConnectionString("workshopConnection");

builder.Services.AddDbContext<MyContext>(options=>options.UseSqlServer(connectionString));


// Auto mapper
builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));

// Transient : One Object for Operation
//builder.Services.AddTransient<IOperation, OperationRepo>();

// Transient : One Object for Operation
builder.Services.AddScoped<IOperation, OperationRepo>();

// Scoped : One Object for Operation
//builder.Services.AddSingleton<IOperation, OperationRepo>();

// Scoped : One Object for Patient
builder.Services.AddScoped<IPatient, PatientRepo>();

// Transient : One Object for Vaccination
builder.Services.AddScoped<IVaccination, VaccinationRepo>();

// Transient : One Object for ChronicDisease
builder.Services.AddScoped<IChronicDisease, ChronicDiseaseRepo>();

// Add DbContext configuration
builder.Services.AddDbContext<MyContext>();

//--------------------------------------------------------------------------
// Configure Identity (includes Authentication, Cookies, SignInManager, etc.)
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    // SignIn settings
    options.SignIn.RequireConfirmedAccount = false;
    
    // User settings
    options.User.RequireUniqueEmail = true;
    
    // Password settings
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 0;
})
.AddEntityFrameworkStores<MyContext>()
.AddDefaultTokenProviders();

//--------------------------------------------------------------------------
// Configure Application Cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = new PathString("/Account/Login");
    options.AccessDeniedPath = new PathString("/Account/Login");
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.SlidingExpiration = true;
});


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();  // ⚠️ Important: Must be before UseAuthorization
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
