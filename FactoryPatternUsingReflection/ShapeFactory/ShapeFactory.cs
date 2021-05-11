using System;
using FactoryPatternUsingReflection.FactoryUtility;

namespace FactoryPatternUsingReflection.ShapeFactory
{
    public class ShapeTypeFactory : BaseFactory<IShape, ShapeType, ShapeTypeAttrbute>
    {
        public ShapeTypeFactory(IServiceProvider serviceProvider) : base(serviceProvider) { }
    }
}
