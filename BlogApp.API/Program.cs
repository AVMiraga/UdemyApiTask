
using BlogApp.Business.Services.Implementations;
using BlogApp.Business.Services.Interfaces;
using BlogApp.DAL.Context;
using BlogApp.DAL.Repository.Implementations;
using BlogApp.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

            builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
