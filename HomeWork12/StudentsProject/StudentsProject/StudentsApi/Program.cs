using Scalar.AspNetCore;
using Students.Application.Services.Users;
using Students.Infrastructure.Data;
using Students.Infrastructure.Repositories.Users;

namespace StudentsApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;


            builder.Services.AddScoped<ApplicationDbContext>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

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
