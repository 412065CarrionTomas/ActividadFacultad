
using Act_01.Data;
using Act_01.Domain;
using Actividad_Facultad.Data.Implement;
using Actividad_Facultad.Data.Interfaces;
using Actividad_Facultad.Data.Repositories;
using Actividad_Facultad.Service.Implement;
using Actividad_Facultad.Service.Interfaces;

namespace Act_02
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
            //UnitOfWork
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            //Article
            builder.Services.AddScoped<IGenericRepository<Article>, ArticleRepository>();
            builder.Services.AddScoped<IGenericService<Article>, ArticleService>();
            //PaymentMethod
            builder.Services.AddScoped<IGenericRepository<PaymentMethod>, PaymentMethodRepository>();
            builder.Services.AddScoped<IGenericService<PaymentMethod>, PaymentMethodService>();
            //InvoicesServices
            builder.Services.AddScoped<IGenericRepository<Invoice>, InvoiceRepository>();
            builder.Services.AddScoped<IGenericService<Invoice>, InvoiceServices>();
            //InvocesDetails
            builder.Services.AddScoped<IGenericRepository<InvoiceDetail>, InvoiceDetailRepository>();
            builder.Services.AddScoped<IGenericService<InvoiceDetail>, InvoiceDetailService>();

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
