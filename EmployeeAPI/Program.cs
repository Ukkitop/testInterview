using AutoMapper;
using EmployeeAPI.MapperProfiles;
using EmployeeRole.Data;
using EmployeeRole.Data.Interfaces;
using EmployeeRole.Data.Repositories;
using EmployeeRole.Domain.Interfaces;
using EmployeeRole.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddEntityFrameworkMySql().AddDbContext<ApplicationDbContext>(
            options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll));

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<IRoleService, RoleService>();
        builder.Services.AddScoped<IEmployeeService, EmployeeService>();
        builder.Services.AddScoped<IRoleRepository, RoleRepository>();
        builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();


        var configuration = new MapperConfiguration(cfg => cfg.AddProfile<EmployeeRoleMappingProfile>());
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


        var app = builder.Build();

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
    }
}