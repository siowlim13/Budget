
using BudgetAPI.Data;
using BudgetAPI.Extentions;
using Microsoft.EntityFrameworkCore;

namespace BudgetAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddApplicationServices(builder.Configuration);

            //builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // builder.Services.AddDbContext<DataContext>(options =>
            // {
            //     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            // });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod()
                .WithOrigins("http://localhost:4200", "https://localhost:4200"));

            app.UseAuthorization();
            app.MapControllers();

            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;

            app.Run();
        }
    }
}
