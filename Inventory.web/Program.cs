using Inventory.Utility.HelperClass;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Inventory.Repository.BillTypeService;
using Inventory.Models;
using Inventory.Repository;
using Inventory.Repository.CustomerTypeService;
using Inventory.Repository.SalesTypeService;
using Inventory.Repository.InvoiseServices;
using Inventory.Repository.VendorTypeService;
using Inventory.Repository.PaymentTypes;
using Inventory.Repository.PurchaseTypeService;
using Inventory.Repository.ProductTypeService;
using Inventory.Repository.ShipmentTypeService;
using Inventory.Repository.CustomerService;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection");
builder.Services.Configure<SuperAdmin>(builder.Configuration.GetSection("SuperAdmin"));

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<AppUser,IdentityRole>().AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDbContext>();


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IBillTypeRepo, BillTypeRepo>();
builder.Services.AddScoped<ICustomerTypeRepo, CustomerTypeRepo>();
builder.Services.AddScoped<ISalesTypeService, SalesTypeService>();
builder.Services.AddScoped<IInvoiceTypeRepo, InvoiceTypeRepo>();
builder.Services.AddScoped<IVendorTypeRepo, VendorTypeRepo>();
builder.Services.AddScoped<IPaymentTypeRepo, PaymentTypeRepo>();
builder.Services.AddScoped<IPurchaseTypeRepo, PurchaseTypeRepo>();
builder.Services.AddScoped<IProductTypeRepo, ProductTypeRepo>();
builder.Services.AddScoped<IShipmentTypeRepo, ShipmentTypeRepo>();
builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
