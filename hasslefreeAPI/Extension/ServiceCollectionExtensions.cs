using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace hasslefreeAPI.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static void AddScopedImplementations(this IServiceCollection services)
        {
            foreach (Type type in Assembly.GetEntryAssembly().GetTypes()
              .Where(t => t.Namespace == "hasslefreeAPI.Services")
              .Where(t => !t.GetTypeInfo().IsDefined(typeof(CompilerGeneratedAttribute), true))
              .Where(t => t.GetTypeInfo().IsClass))
            {
                services.AddScoped(type.GetTypeInfo().GetInterface("I" + type.Name), type);
            }
        }
    }
}
