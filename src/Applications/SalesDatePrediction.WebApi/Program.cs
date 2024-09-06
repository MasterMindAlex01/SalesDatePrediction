using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SalesDatePrediction.Application.Interfaces.Services;
using SalesDatePrediction.Infrastructure.Contexts;
using SalesDatePrediction.Infrastructure.Services;

namespace SalesDatePrediction.WebApi
{
    public class Program
    {
        private const string CORS_POLICY = "CorsPolicy";

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<StoreDBContext>(options => options
                    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddTransient<ICustomerService, CustomerService>();
            builder.Services.AddTransient<IEmployeeService, EmployeeService>();
            builder.Services.AddTransient<IOrderService, OrderService>();
            builder.Services.AddTransient<IShipperService, ShipperService>();
            builder.Services.AddTransient<IProductService, ProductService>();

            builder.Services.AddControllers();
            var origins = new List<string>();
            builder.Configuration.GetSection("Cors").Bind(origins);

            builder.Services.AddCors(opt =>
                opt.AddPolicy(CORS_POLICY, policy =>
                    policy.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .WithOrigins(origins.ToArray())
                    )
                );

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseCors(CORS_POLICY);

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
}
