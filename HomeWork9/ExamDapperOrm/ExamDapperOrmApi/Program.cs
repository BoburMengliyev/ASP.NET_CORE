
using ExamDapperOrm.Infrastructure.Services;
using Scalar.AspNetCore;

namespace ExamDapperOrmApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddOpenApi();
            builder.Services.AddScoped<IPassportRepository, PassportRepository>();
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();

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
