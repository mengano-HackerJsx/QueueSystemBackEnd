using Application.Person.Handler;
using Application.QueueLine.Handler;
using Application.QueuePerson.Handlers;
using Application.QueuePerson.Validations.Custom;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class IOC
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddFluentValidation(c => 
            c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddTransient<IPersonHandler, PersonHandler>();

            services.AddTransient<IQueueLineHandler, QueueLineHandler>();

            services.AddTransient<IQueuePersonHandler, QueuePersonHandler>();

            services.AddTransient<IQueuePersonValidationMethods, QueuePersonValidationMethods>();

            services.AddTransient<IConditionsHandler, ConditionsHandler>();

            return services;
        }
    }
}
