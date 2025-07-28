
using Scalar.AspNetCore;
using Workplace.Infrastructure.Services.Branches;
using Workplace.Infrastructure.Services.Branchs;
using Workplace.Infrastructure.Services.Companys;
using Workplace.Infrastructure.Services.Departments;
using Workplace.Infrastructure.Services.Employees;

namespace Workplace.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            builder.Services.AddScoped<IBranchService, BranchService>();
            builder.Services.AddScoped<ICompanyService, CompanyService>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
