using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.Services.Items;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Interfaces.Repositories;

namespace WebAPI.Application.Extencions
{
    public static class ApplicationExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ItemService>();
        }
    }
}
