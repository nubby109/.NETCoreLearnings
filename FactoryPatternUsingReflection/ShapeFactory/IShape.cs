using Microsoft.Extensions.Logging;

namespace FactoryPatternUsingReflection.ShapeFactory
{
    public interface IShape
    {
        string GetShapeDescripton();
    }

    [ShapeTypeAttrbute(ShapeType.Circle)]
    public class Circle : IShape
    {
        public readonly ILogger<Circle> _logger;
        public Circle(ILogger<Circle> logger)
        {
            _logger = logger;
        }
        public string GetShapeDescripton()
        {
            _logger.LogInformation("Getting Circle's Description");
            return "I am a circle";
        }
    }

    [ShapeTypeAttrbute(ShapeType.Square)]
    public class Square : IShape
    {
        public readonly ILogger<Square> _logger;
        public Square(ILogger<Square> logger)
        {
            _logger = logger;
        }
        public string GetShapeDescripton()
        {
            _logger.LogInformation("Getting Square's Description");
            return "I am a square";
        }
    }

    [ShapeTypeAttrbute(ShapeType.Rectangle)]
    public class Rectangle : IShape
    {
        public readonly ILogger<Rectangle> _logger;
        public Rectangle(ILogger<Rectangle> logger)
        {
            _logger = logger;
        }
        public string GetShapeDescripton()
        {
            _logger.LogInformation("Getting Rectangle's Description");
            return "I am a rectangle";
        }
    }
}
