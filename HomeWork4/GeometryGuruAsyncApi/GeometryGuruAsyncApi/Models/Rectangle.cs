namespace GeometryGuruAsyncApi.Models
{
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public override Task<double> GetAreaAsync() 
        {
            double area = Width * Height;
            return Task.FromResult(area);
        }

        public override Task<double> GetPerimeterAsync() 
        {
            double perimeter = 2 * (Width + Height);
            return Task.FromResult(perimeter);
        }
    }
}