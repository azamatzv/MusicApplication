using Application;
using Infrastructure;
using N_Tier.DataAccess.Persistence;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;
        builder.Services.AddDataAccess(builder.Configuration).AddApplication(builder.Environment);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        using var scope = app.Services.CreateScope();
        
        await AutomatedMigration.MigrateAsync(scope.ServiceProvider);

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

namespace API
{
    public partial class Program { }
}