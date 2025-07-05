using System.Reflection;
using Application.Domain.Guests.Command;
using Application.Domain.Guests.Validator;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;


namespace Application.Extentions;

public static class ServiceCollectionExtensions
{
    // private static Assembly ApplicationAssembly = Assembly.GetExecutingAssembly();
    private static Assembly ApplicationAssembly = typeof(ServiceCollectionExtensions).Assembly;

    public static void AddApplication(this IServiceCollection services)
    {
        AddServices(services);
    }


    private static void AddServices(IServiceCollection services)
    {
        services.AddAutoMapper(ApplicationAssembly);
        services.AddMediatR(op => op.RegisterServicesFromAssembly(ApplicationAssembly));
        //   services.AddScoped<IValidator<CreateGuestCommand>, CreateGuestCommandValidator>();
        //  services.AddValidatorsFromAssemblyContaining<CreateGuestCommand>();
        services.AddValidatorsFromAssembly(ApplicationAssembly);


    }
}

