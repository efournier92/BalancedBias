using System;
using System.Collections.Generic;

namespace BalancedBias.Common.Infrastructure
{
    public interface IDependencyResolver
    {
        //IDictionary<Type, Object> ResolveFamily(Type openGenericType);

        T Resolve<T>();

        object Resolve(Type type);
    }
}
 