namespace GeometryGuruAsyncApi.Models
{
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public override Task<double> GetAreaAsync() 
        {
            double area = Math.PI * Radius * Radius;
            return Task.FromResult(area);
        }

        public override Task<double> GetPerimeterAsync() 
        {
            double perimeter = 2 * Math.PI * Radius;
            return Task.FromResult(perimeter);
        }
    }
}
