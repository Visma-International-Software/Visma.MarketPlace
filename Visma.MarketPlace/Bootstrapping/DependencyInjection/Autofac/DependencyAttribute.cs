namespace Visma.MarketPlace.Bootstrapping.DependencyInjection.Autofac
{
    using System;

    /// <summary>
    /// This attribute is used to define dependencies for properties of interfaces.
    /// </summary>
    /// <remarks>
    /// Used with the Autofac container to inject dependencies with properties.
    /// Note: Class Type property injection is supported, although is best advised to be avoided.
    /// </remarks>
    /// <exception cref="InvalidOperationException">The attribute must be specified.</exception>
    [AttributeUsage(AttributeTargets.Property)]
    public class DependencyAttribute : Attribute
    {
    }
}