using FactoryPatternUsingReflection.FactoryUtility;
using System;

namespace FactoryPatternUsingReflection.ShapeFactory
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ShapeTypeAttrbute : Attribute, IEnumBasedAttribute<ShapeType>
    {
        public ShapeType _shapeType { get; }

        public ShapeTypeAttrbute(ShapeType shapeType)
        {
            _shapeType = shapeType;
        }

        public ShapeType GetAttributeEnumValue()
        {
            return _shapeType;
        }
    }
}
