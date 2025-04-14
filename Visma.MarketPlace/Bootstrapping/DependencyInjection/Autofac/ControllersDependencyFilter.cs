namespace Visma.MarketPlace.Bootstrapping.DependencyInjection.Autofac
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    /// <summary>
    /// An action filter that injects dependencies into controller properties marked with <see cref="DependencyAttribute"/>.
    /// </summary>
    public class ControllersDependencyFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.Controller is not null)
            {
                var properties = context.Controller.GetType()
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.CanWrite && p.GetCustomAttribute<DependencyAttribute>() is not null);

                var serviceProvider = context.HttpContext.RequestServices;

                foreach (PropertyInfo property in properties)
                {
                    object service = serviceProvider.GetService(property.PropertyType);
                    if (service != null)
                    {
                        property.SetValue(context.Controller, service);
                    }
                }
            }

            await next();
        }
    }
}
