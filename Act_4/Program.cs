
using Act_04.Models.Context;
using Act_4.Repositories.ShipmentRepo;
using Act_4.Services.ShipmentService;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;

namespace Act_4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //context
            builder.Services.AddDbContext<ShipmentContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
            //shipment
            builder.Services.AddScoped<IShipmentRepository, ShipmentRepository>();
            builder.Services.AddScoped<IShipmentService, ShipmentService>();

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
}
