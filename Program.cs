using CRUD_Project.BL;
using CRUD_Project.DAL;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Project.APIs
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

            var connectionString = builder.Configuration.GetConnectionString("connection");
            builder.Services.AddDbContext<ItemsContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IItemsRepo, ItemsRepo>();
            builder.Services.AddScoped<IItemsManager, ItemManager>();
           
                builder.Services.AddCors(options =>
                {
                    options.AddPolicy("AllowAngularApp",
                        builder => builder.WithOrigins("http://localhost:4200")
                                          .AllowAnyMethod()
                                          .AllowAnyHeader());
                });

                builder.Services.AddControllers();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowAngularApp");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
