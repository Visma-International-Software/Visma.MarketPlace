
namespace Visma.MarketPlace.Bootstrapping.DependencyInjection.Autofac
{
    using global::Autofac.Core;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// A property selector that injects properties marked with <see cref="DependencyAttribute"/>.
    /// </summary>
    public class DependencyAttributePropertySelector : IPropertySelector
    {
        /// <summary>
        /// Determines whether a property should be injected.
        /// </summary>
        /// <param name="propertyInfo">The property information.</param>
        /// <param name="instance">The instance of the object.</param>
        /// <returns><c>true</c> if the property should be injected; otherwise, <c>false</c>.</returns>
        public bool InjectProperty(PropertyInfo propertyInfo, object instance)
        {
            return propertyInfo.GetCustomAttributes<DependencyAttribute>(inherit: true).Any();
        }
    }
}