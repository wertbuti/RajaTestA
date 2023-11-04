using Microsoft.EntityFrameworkCore;
using RajaTestA.DataLayer.AppContext;
using RajaTestA.Services.Services;
using RajaTestA.Services.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<RajaDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString1"));
});
builder.Services.AddDbContext<IRajaDbContext, RajaDbContext>();
builder.Services.AddScoped<IPersonnelService, PersonnelService>();
builder.Services.AddScoped<ICertificateService, CertificateService>();
builder.Services.AddScoped<IPersonnelCertificateService, PersonnelCertificateService>();

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
    pattern: "{controller=Personnel}/{action=Index}/{id?}");

app.Run();
