using GeometryGuruAsyncApi.Models;
using GeometryGuruAsyncApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeometryGuruAsyncApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShapesController : ControllerBase
    {
        private readonly IGeometryService _geometryService;

        public ShapesController(IGeometryService geometryService)
        {
            _geometryService = geometryService;
        }

        [HttpPost("area")]
        public async Task<IActionResult> GetArea([FromBody] List<ShapeDto> shapesDto)
        {
            if (shapesDto == null || shapesDto.Count == 0)
                return BadRequest("Shakllar ro'yxati bo'sh yoki noto‘g‘ri.");

            var shapes = new List<Shape>();

            foreach (var dto in shapesDto)
            {
                if (dto.Type == null)
                    return BadRequest("Shakl turi kiritilmagan.");

                switch (dto.Type.ToLower())
                {
                    case "circle":
                        if (dto.Radius <= 0)
                            return BadRequest("Radius musbat bo‘lishi kerak.");
                        shapes.Add(new Circle(dto.Radius));
                        break;

                    case "rectangle":
                        if (dto.Width <= 0 || dto.Height <= 0)
                            return BadRequest("Eni va bo‘yi musbat bo‘lishi kerak.");
                        shapes.Add(new Rectangle(dto.Width, dto.Height));
                        break;

                    default:
                        return BadRequest($"Noma'lum shakl turi: {dto.Type}");
                }
            }

            var totalArea = await _geometryService.GetTotalAreaAsync(shapes);
            return Ok(totalArea);
        }

        [HttpPost("peri")]
        public async Task<IActionResult> GetPeri([FromBody] List<ShapeDto> shapesDto)
        {
            if (shapesDto == null || shapesDto.Count == 0)
                return BadRequest("Shakllar ro'yxati bo'sh yoki noto‘g‘ri.");

            var shapes = new List<Shape>();

            foreach (var dto in shapesDto)
            {
                if (dto.Type == null)
                    return BadRequest("Shakl turi kiritilmagan.");

                switch (dto.Type.ToLower())
                {
                    case "circle":
                        if (dto.Radius <= 0)
                            return BadRequest("Radius musbat bo‘lishi kerak.");
                        shapes.Add(new Circle (dto.Radius));
                        break;

                    case "rectangle":
                        if (dto.Width <= 0 || dto.Height <= 0)
                            return BadRequest("Eni va bo‘yi musbat bo‘lishi kerak.");
                        shapes.Add(new Rectangle (dto.Width, dto.Height));
                        break;

                    default:
                        return BadRequest($"Noma'lum shakl turi: {dto.Type}");
                }
            }

            var totalPerimeter = await _geometryService.GetTotalPerimeterAsync(shapes);
            return Ok(totalPerimeter);
        }
    }
}
