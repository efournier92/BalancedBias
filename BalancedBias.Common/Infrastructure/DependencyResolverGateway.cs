using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using BalancedBias.Web;

namespace BalancedBias.Common.Infrastructure
{
    public static class DependencyResolverGateway
    {
        //public static IDependencyResolver Resolver { get; private set; }
        private static readonly IContainer Container;

        static DependencyResolverGateway()
        {
            Container = new Container(new StructureMapRegistryInitializer());
        } 

        //public static _resolver = IDependencyResolver;

        //public static IDictionary<Type, Object> ResolveFamily(Type openGenericType)
        //{
        //    return Resolver.ResolveFamily(openGenericType);
        //}

        public static T Resolve<T>()
        {
            return Container.GetInstance<T>();
        }

        //public static object Resolve(Type type)
        //{
        //    return Resolver.Resolve(type);
        //}

        //public static void InitializeWith(IDependencyResolver resolver)
        //{
        //    if (resolver == null) throw new ArgumentNullException("resolver");
        //    Resolver = resolver;
        //}
    }
}
