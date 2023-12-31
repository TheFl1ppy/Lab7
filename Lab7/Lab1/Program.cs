using Domain.Interfaces;
using BusinessLogic.Services;
using Microsoft.EntityFrameworkCore;
using DataAccess.Wrapper;
using OnlineShop.Models;

namespace Lab1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<OnlineShopContext>(options => options.UseSqlServer("Server=DESKTOP-QTN9LC5;Database=OnlineShop;User Id=Flip;Password=123;"));


            builder.Services.AddScoped<Domain.Wrapper.IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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