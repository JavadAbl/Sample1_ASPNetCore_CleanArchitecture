using API.Filter;
using Application.Extentions;
using Infrastructure.Extentions;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(op =>
{
    op.Filters.Add<FluentValidationFilterAsync>();
});
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});


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

await app.RunAsync();