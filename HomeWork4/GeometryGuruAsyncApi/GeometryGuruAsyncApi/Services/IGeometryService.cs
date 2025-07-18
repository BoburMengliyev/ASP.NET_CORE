using GeometryGuruAsyncApi.Models;

namespace GeometryGuruAsyncApi.Services
{
    public interface IGeometryService
    {
        Task<double> GetTotalAreaAsync(List<Shape> shapes);
        Task<double> GetTotalPerimeterAsync(List<Shape> shapes);
    }
}