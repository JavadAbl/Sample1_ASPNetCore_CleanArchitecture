using API.Filter;
using API.Middlewares;
using Application.Extentions;
using Infrastructure.Extentions;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(op =>
{
    op.Filters.Add<FluentValidationFilterAsync>();
    // op.Filters.Add<FluentValidationFilter>();
});

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

//builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddProblemDetails(op =>
{
    op.CustomizeProblemDetails = context =>
    {
        // Add the request ID to the problem details response
        context.ProblemDetails.Extensions["requestId"] = context.HttpContext.TraceIdentifier;

        // You can also add other custom properties if needed
        // context.ProblemDetails.Extensions["customProperty"] = "value";
    };
});

builder.Services.AddExceptionHandler<ValidationExceptionHandler>();
builder.Services.AddExceptionHandler<ExceptionHandler>();

//builder.Services.AddLogging();


// App-------------------------------------------------
var app = builder.Build();
app.UseExceptionHandler();
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