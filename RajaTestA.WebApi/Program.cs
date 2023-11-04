using Microsoft.EntityFrameworkCore;
using RajaTestA.DataLayer.AppContext;
using RajaTestA.Services.Services;
using RajaTestA.Services.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RajaDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString1"));
});
builder.Services.AddDbContext<IRajaDbContext, RajaDbContext>();
builder.Services.AddScoped<IPersonnelService, PersonnelService>();
builder.Services.AddScoped<IPersonnelCertificateService, PersonnelCertificateService>();
builder.Services.AddScoped<ICertificateService, CertificateService>();
builder.Services.AddCors();

builder.Services
    .AddMvc()
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;//این کد جهت جلوگیری از لوورکیس شدن خروجی ای پی ]ی ها میباشد
                                                                  //options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });


var app = builder.Build();

app.UseCors(
    op =>
    {
        op.WithOrigins("").AllowAnyMethod();
        op.WithOrigins("").AllowAnyHeader();
        op.WithOrigins("").AllowAnyOrigin();
    }
    );

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
