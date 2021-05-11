using FactoryPatternUsingReflection.FactoryUtility;
using FactoryPatternUsingReflection.ShapeFactory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPatternUsingReflection
{
    public class ExecuteProgam
    {
        private readonly IBaseFactory<IShape> _baseFactory;
        private readonly ILogger<ExecuteProgam> _logger;
        public ExecuteProgam(IBaseFactory<IShape> baseFactory, ILogger<ExecuteProgam> logger)
        {
            _baseFactory = baseFactory ?? throw new ArgumentNullException(nameof(baseFactory));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public void Run()
        {
            _logger.LogInformation("Circle");
            _logger.LogInformation(_baseFactory.GetObject(ShapeType.Circle).GetShapeDescripton());

            _logger.LogInformation("Square");
            _logger.LogInformation(_baseFactory.GetObject(ShapeType.Square).GetShapeDescripton());

            _logger.LogInformation("Rectangle");
            _logger.LogInformation(_baseFactory.GetObject(ShapeType.Rectangle).GetShapeDescripton());

        }
    }
}
