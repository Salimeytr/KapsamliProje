using KapsamliProje.Dal;
using KapsamliProje.Ent;
using KapsamliProje.Repos.Abstract;
using KapsamliProje.Repos.Concrete;
using KapsamliProje.Ui.Models;
using KapsamliProje.Ui.Models.ViewModels;
using KapsamliProje.Uow;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();  //bu kodlarý .net core session microsoft sitesinden alýp yapýþtýrdýk

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});  // bu kýsma kadar
builder.Services.AddDbContext<Context>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Baglanti")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthRepos, AuthRepos>();
builder.Services.AddScoped<ICategoriesRepos,CategoriesRepos>();
builder.Services.AddScoped<IProductsRepos, ProductsRepos>();
builder.Services.AddScoped<ISuppliersRepos,SuppliersRepos>();
builder.Services.AddScoped<ICitiesRepos, CitiesRepos>();
builder.Services.AddScoped<ICountiesRepos, CountiesRepos>();
builder.Services.AddScoped<IEmployeesRepos, EmployeesRepos>();
builder.Services.AddScoped<IEndConsumersRepos, EndConsumersRepos>();
builder.Services.AddScoped<ICustomersRepos, CustomersRepos>();
builder.Services.AddScoped<IUserRepos, UserRepos>();
builder.Services.AddScoped<IFatMasterRepos, FatMasterRepos>();

builder.Services.AddScoped<IFatDetailRepos, FatDetailRepos>();

builder.Services.AddScoped<ProductsModel>();
builder.Services.AddScoped<LoginModel>();
builder.Services.AddScoped<FatMaster>();
builder.Services.AddScoped<FatDetail>();
builder.Services.AddScoped<FatMasterModel>();
builder.Services.AddScoped<FatDetailModel>();
builder.Services.AddScoped<Users>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession(); // bu kodlarý .net core microsoft sitesinden alýp yapýþtýrdýk

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
