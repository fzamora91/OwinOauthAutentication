//using client;
using OwinOauthAutentication;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}


//var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();

//var app = builder.Build();

// Configure the HTTP request pipeline.

/*app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();*/
