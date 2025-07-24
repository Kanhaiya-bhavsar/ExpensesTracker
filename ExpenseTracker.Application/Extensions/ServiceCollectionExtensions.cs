﻿using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Extensions.DependencyInjection;


namespace ExpenseTracker.Application.Extensions
{
    public static class ServiceCollectionExtensions

    {
        public static void AddApplication(this IServiceCollection services) {

            var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));

        }
        
    }
}
