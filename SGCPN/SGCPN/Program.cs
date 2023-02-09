using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SGCPN.Models;
using SGCPN.Services;
using SGCPN.Validators;
using System.Web.WebPages;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SGCPNContext>(options =>
    options.UseInMemoryDatabase("SGCPNContext"));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IValidator<Institution>, InstitutionValidator>();
builder.Services.AddScoped<IValidator<Patron>, PatronValidator>();
var app = builder.Build();


//builder.Services.AddScoped<IUserService, UserService>();

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
