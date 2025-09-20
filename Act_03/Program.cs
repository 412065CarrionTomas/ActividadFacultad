
using Act_01.Domain;
using Act_03.Models.Context;
using Act_03.Models.Domain.DTOs;
using Act_03.Models.Interface.Repositories;
using Act_03.Models.Repositories;
using Act_03.Models.Repositories.Implement;
using Act_03.Models.Repositories.InterfaceRepository;
using Act_03.Models.Repositories.RepositoryIndependet;
using Act_03.Services;
using Act_03.Services.Implement;
using Act_03.Services.ImplementDTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Act_03
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
            builder.Services.AddDbContext<InvoiceContext>(options => options.UseSqlServer(builder.Configuration.
                GetConnectionString("DefaultConnection")));
            //builder para invoice 
            builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            builder.Services.AddScoped<IGenericService<Invoice>, InvoiceService>();
            builder.Services.AddScoped<IGenericDTOService<InvoiceDTO>, InvoiceDTOService>();
            //builder para invoiceDetail
            builder.Services.AddScoped<IInvoiceDetailRepository, InvoiceDetailRepository>();
            builder.Services.AddScoped<IGenericService<InvoiceDetail>, InvoiceDetailService>();
            //builder para article
            builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
            builder.Services.AddScoped<IGenericService<Article>, ArticleService>();
            //builder para paymentMethod
            builder.Services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
            builder.Services.AddScoped<IGenericService<PaymentMethod>, PaymentMethodService>();

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
