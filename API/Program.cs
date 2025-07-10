using System.Text.Json.Serialization;
using API.Filter;
using API.Middlewares;
using Application.Extentions;
using Infrastructure.Extentions;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

//Contoller--------------------------------------------------------
builder.Services.AddControllers(op =>
{
    op.Filters.Add<FluentValidationFilterAsync>();
})
.AddJsonOptions(options =>
 {
     options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
 });

//builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


//Services--------------------------------------------------------
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

//Configure--------------------------------------------------------
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    // options.SuppressModelStateInvalidFilter = true;
});

//Error Handling--------------------------------------------------------
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



// App----------------------------------------------------------------
var app = builder.Build();
app.UseExceptionHandler();
app.UseRouting();
app.MapControllers();

// Seed the database--------------------------------------------------
using (app.Services.CreateScope())
{
    var scope = app.Services.CreateScope();
    var seeder = scope.ServiceProvider.GetRequiredService<ISeeder>();
    seeder.SeedAppDb();
}

await app.RunAsync();