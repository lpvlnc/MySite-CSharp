using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Application.Interfaces;
using Portfolio.Application.Services;
using Portfolio.Data;
using System;

namespace Portfolio.IoC
{
    public static class DependencyInjectorExtensions
    {
        public static IServiceCollection AddInfraDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetSection("ConnectionStrings:default").Value));
            
            services.AddTransients();
            return services;
        }

        private static void AddTransients(this IServiceCollection services)
        {
            services.AddTransient<IMeService, MeService>();
            services.AddTransient<IExperienceService, ExperienceService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<ITestimonialService, TestimonialService>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<ISocialService, SocialService>();
            services.AddTransient<IHomeService, HomeService>();
        }
    }
}
