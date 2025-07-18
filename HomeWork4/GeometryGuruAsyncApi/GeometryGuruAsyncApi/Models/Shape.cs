namespace GeometryGuruAsyncApi.Models
{
    public abstract class Shape
    {
        public abstract Task<double> GetAreaAsync();
        public abstract Task<double> GetPerimeterAsync();
    }
}
