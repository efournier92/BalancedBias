using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BalancedBias.Common.Infrastructure;
using Spring.Context.Support;
using StructureMap;



namespace BalancedBias.Common.Plugins
{
    public class SpringAndStructureMapDependencyResolver: IDependencyResolver
    {
        public SpringAndStructureMapDependencyResolver()
        {
            var container = new Container();

            try
            {
                // Load all instances from spring repository to structure map
                // so we can always fetch them using structure map
                var applicationContext = ContextRegistry.GetContext();
                var objectNames = applicationContext.GetObjectDefinitionNames();
                foreach (var objectName in objectNames)
                {
                    var @object = applicationContext.GetObject(objectName);
                    // go through each interface of the given object
                    foreach (var @interface in @object.GetType().GetInterfaces())
                    {
                        // register object with the interface
                        container.Inject(@interface, @object);
                    }
                }
            }
            catch (Exception exception)
            {
                //var loggerProvider = new NewPchLoggerProvider(); // Cannot use PchLogger because that uses Dependency Resolver
                //loggerProvider.LogXmlException(exception, null);
            }
        }
        //public IDictionary<Type, object> ResolveFamily(Type openGenericType)
        //{
        //    var container = new Container();

        //    var typesAndInstances = new Dictionary<Type, object>();
        //    var instances =
        //        container.Model.AllInstances;
        //    foreach (var instance in instances)
        //    {
        //        if (instance.ConcreteType == null || !instance.PluginType.IsGenericType || instance.PluginType.GetGenericTypeDefinition() != openGenericType) continue;
        //        typesAndInstances.Add(instance.PluginType, Resolve(instance.PluginType));
        //    }

        //    return typesAndInstances;
        //}

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        public object Resolve(Type type)
        {
            if (type == null) throw new ArgumentNullException("type");

            // Try resolving using spring repository first
            IDictionary<string, object> objectsOfGivenType = null;
            try
            {
                var applicationContext = ContextRegistry.GetContext();
                objectsOfGivenType = applicationContext.GetObjectsOfType(type);
            }
            catch
            {
                // Ignore error in lookup
            }

            // get from structure map if not found in spring registry
            //if (objectsOfGivenType == null || objectsOfGivenType.Count <= 0)
            //{
            //    return ObjectFactory.TryGetInstance(type);
            //}

            // return from spring registry
            var key = objectsOfGivenType.Keys.First();
            return objectsOfGivenType[key];
        }
    }
}
