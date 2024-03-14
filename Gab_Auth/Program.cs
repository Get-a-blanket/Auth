using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace GaB_Auth;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "Auth API",
                    Version = "v1"
                }
             );

            var filePath = Path.Combine(AppContext.BaseDirectory, "Documentation.xml");
            c.IncludeXmlComments(filePath);
        });

        var app = builder.Build();

        Configuration = app.Configuration;

        //DB setup
        GetContext().Database.Migrate();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }

        //app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }

    public static IConfiguration Configuration { get; private set; }

    public static DbConnector.ApplicationContext GetContext()
    {
        return new DbConnector.ApplicationContext(Configuration);
    }
}