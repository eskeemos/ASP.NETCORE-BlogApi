using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class DependencyIjection
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddScoped<IPostService, PostService>();
            services.AddSingleton(AutoMapperConfig.Initialize());

            return services;
        }
    }
}
