namespace Visma.MarketPlace.Bootstrapping.DependencyInjection.Autofac
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    /// <summary>
    /// Middleware that injects dependencies into properties marked with <see cref="DependencyAttribute"/>.
    /// </summary>
    public class AutofacDependencyMiddleware
    {
        private readonly RequestDelegate next;

        /// <summary>
        /// Initializes a new instance of the <see cref="AutofacDependencyMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next middleware in the pipeline.</param>
        public AutofacDependencyMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        /// <summary>
        /// Invokes the middleware to inject dependencies.
        /// </summary>
        /// <param name="context">The HTTP context.</param>
        public async Task InvokeAsync(HttpContext context)
        {
            object targetObject = context.Items["TargetObject"];
            if (targetObject is not null)
            {
                IEnumerable<PropertyInfo> properties = targetObject.GetType()
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.CanWrite && p.GetCustomAttribute<DependencyAttribute>() is not null && p.IsDefined(typeof(DependencyAttribute), false));

                IServiceProvider serviceProvider = context.RequestServices;

                foreach (PropertyInfo property in properties)
                {
                    if (property.GetValue(targetObject) == null)
                    {
                        throw new InvalidOperationException($"Dependency for property {property.Name} is not set.");
                    }

                    object service = serviceProvider.GetService(property.PropertyType);
                    if (service is not null)
                    {
                        property.SetValue(targetObject, service);
                    }
                }
            }

            await next(context);
        }
    }
}