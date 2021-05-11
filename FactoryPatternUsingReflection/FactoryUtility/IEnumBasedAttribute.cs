using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPatternUsingReflection.FactoryUtility
{
    public interface IEnumBasedAttribute<T>
    {
        public T GetAttributeEnumValue();
    }
}
