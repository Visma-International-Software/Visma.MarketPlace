namespace Visma.MarketPlace.Bootstrapping.DependencyInjection.Autofac
{
    using global::Autofac;
    using global::Autofac.Core;

    public static class AutofacContainerExtensions
    {
        /// <summary>
        /// Register a type as a service per lifetime scope.
        /// </summary>
        /// <typeparam name="TInterface">The service interface type.</typeparam>
        /// <typeparam name="TConcrete">The service class type.</typeparam>
        /// <param name="container">The current service lifetime container, provided by Autofac</param>
        /// <remarks>
        /// Use this method to register services that require property injection with the <c><see cref="DependencyAttribute"/></c> attribute.
        /// </remarks>
        /// <example>
        /// <c>
        /// [Dependency]
        /// required public IComplexServiceWrapper ServiceInstance { private get; init; }
        /// </c>
        /// </example>
        public static void RegisterScoped<TInterface, TConcrete>(this ContainerBuilder container)
            where TInterface : class
            where TConcrete : class, TInterface
        {
            container.RegisterType<TConcrete>().As<TInterface>().InstancePerLifetimeScope().PropertiesAutowired(new DependencyAttributePropertySelector());
        }

        /// <summary>
        /// Register a type as a singleton service.
        /// </summary>
        /// <typeparam name="TConcrete">The service class type.</typeparam>
        /// <param name="container">The current service lifetime container, provided by Autofac</param>
        public static void RegisterSingleton<TConcrete>(this ContainerBuilder container)
            where TConcrete : class
        {
            container.RegisterType<TConcrete>().SingleInstance().PropertiesAutowired(new DependencyAttributePropertySelector());
        }

        /// <summary>
        /// Register a type as a singleton service if it is not already registered.
        /// </summary>
        /// <typeparam name="TConcrete">The service class type.</typeparam>
        /// <param name="container">The current service lifetime container, provided by Autofac</param>
        public static void RegisterSafeSingleton<TConcrete>(this ContainerBuilder container)
            where TConcrete : class
        {
            if (!container.ComponentRegistryBuilder.IsRegistered(new TypedService(typeof(TConcrete))))
            {
                container.RegisterType<TConcrete>().SingleInstance();
            }
        }

        /// <summary>
        /// Register a type as a transient service.
        /// </summary>
        /// <typeparam name="TInterface">The service interface type.</typeparam>
        /// <typeparam name="TConcrete">The service class type.</typeparam>
        /// <param name="container">The current service lifetime container, provided by Autofac</param>
        public static void RegisterTransient<TInterface, TConcrete>(this ContainerBuilder container)
            where TInterface : class
            where TConcrete : class, TInterface
        {
            container.RegisterType<TConcrete>().As<TInterface>().InstancePerRequest().PropertiesAutowired(new DependencyAttributePropertySelector());
        }

        /// <summary>
        /// Register a type as a singleton service.
        /// </summary>
        /// <typeparam name="TInterface">The service interface type.</typeparam>
        /// <typeparam name="TConcrete">The service class type.</typeparam>
        /// <param name="container">The current service lifetime container, provided by Autofac</param>
        public static void RegisterSingleton<TInterface, TConcrete>(this ContainerBuilder container)
            where TInterface : class
            where TConcrete : class, TInterface
        {
            container.RegisterType<TConcrete>().As<TInterface>().SingleInstance().PropertiesAutowired(new DependencyAttributePropertySelector());
        }
    }
}