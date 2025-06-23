using Application.Extentions;
using Infrastructure.Extentions;
using Infrastructure.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();
app.UseRouting();
app.MapControllers();

// Seed the database-------------------------------------
using (app.Services.CreateScope())
{
    var scope = app.Services.CreateScope();
    var seeder = scope.ServiceProvider.GetRequiredService<ISeeder>();
    seeder.SeedAppDb();
}


app.Run();
