using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FactoryPatternUsingReflection.FactoryUtility
{
    public interface IBaseFactory
    {
        object GetObject(Enum enumType);
    }

    public interface IBaseFactory<TBaseClass>
    {
        TBaseClass GetObject(Enum enumType);
    }

    public abstract class BaseFactory<TBaseClass, TDiscriminator, TDiscriminatorAttribute>: IBaseFactory<TBaseClass> 
                                                                                           where TDiscriminator: Enum
                                                                                           where TDiscriminatorAttribute: Attribute, IEnumBasedAttribute<TDiscriminator>
    {
        private readonly IServiceProvider _serviceProvider;

        public BaseFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public TBaseClass GetObject(TDiscriminator enumType)
        {
            TDiscriminator objEnumValue;
            TDiscriminatorAttribute objAttribute;
            List<Type> subClassTypes;

            
            if (typeof(TBaseClass).IsInterface)
            {
                subClassTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                              .Where(x => typeof(TBaseClass).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).ToList();
            }
            else if (typeof(TBaseClass).IsAbstract)
            {
                subClassTypes = Assembly.GetAssembly(typeof(TBaseClass)).GetTypes()
                                 .Where(x => x.IsSubclassOf(typeof(TBaseClass)) && !x.IsInterface && !x.IsAbstract).ToList();
            }
            else
            {
                throw new Exception("TBaseClass must either be a abstract class or an interface");
            }

            foreach(var subType in subClassTypes)
            {
                objAttribute = Attribute.GetCustomAttribute(subType, typeof(TDiscriminatorAttribute)) as TDiscriminatorAttribute;
                objEnumValue = objAttribute.GetAttributeEnumValue();

                if(objEnumValue.Equals(enumType))
                {
                    return (TBaseClass)_serviceProvider.GetService(subType);
                }
            }
            return default;
        }

        public TBaseClass GetObject(Enum enumType)
        {
            return GetObject((TDiscriminator)enumType);
        }
    }
}
