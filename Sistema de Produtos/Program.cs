using Microsoft.EntityFrameworkCore;
using Sistema_de_Produtos.Data;
using Sistema_de_Produtos.Repository;
using Sistema_de_Produtos.Repository.Interfaces;

namespace Sistema_de_Produtos
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
            
            builder.Services.
                AddDbContext<ProdutoDBContext>(
                    options => options.UseSqlServer(
                        builder.Configuration.GetConnectionString("Database"))
                );

            builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();


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