using FlipkartApi.Filters;
using FlipkartApi.Interfaces;
using FlipkartApi.Providers;
using Microsoft.EntityFrameworkCore;

namespace FlipkartApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var myPolicy = "MyPolicy";
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers(config =>
            {
                config.Filters.Add(new LogActionFilter());
            });
            builder.Services.AddDbContext<ProductDbContext>(options =>
            {
                options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ProductsDb;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=True");

            });
            builder.Services.AddScoped<IProductDbContext>(p => p.GetService<ProductDbContext>());
            builder.Services.AddScoped<IProductProvider, ProductProvider>();
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddScoped<LogActionFilter>(provider => new LogActionFilter());
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: myPolicy, policy =>
                {
                    policy.AllowAnyOrigin();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(myPolicy);
            app.MapControllers();

            app.Run();
        }
    }
}