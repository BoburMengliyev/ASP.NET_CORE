using GeometryGuruAsyncApi.Models;

namespace GeometryGuruAsyncApi.Services
{
    public class GeometryService : IGeometryService
    {
        public async Task<double> GetTotalAreaAsync(List<Shape> shapes) 
        {
            double total = 0;
            foreach (Shape shape in shapes) 
            {
                total += await shape.GetAreaAsync();
            }
            return total;
        }

        public async Task<double> GetTotalPerimeterAsync(List<Shape> shapes) 
        {
            double total = 0;
            foreach (Shape shape in shapes) 
            {
                total += await shape.GetPerimeterAsync();
            }
            return total;
        }
    }
}
