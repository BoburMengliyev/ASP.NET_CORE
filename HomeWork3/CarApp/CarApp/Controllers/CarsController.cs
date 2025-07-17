using CarApp.Data;
using CarApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllCar()
        {
            return Ok(CarData.Cars);
        }

        [HttpGet("{id}")]
        public IActionResult GetCarById(int id)
        {
            var car = CarData.Cars.FirstOrDefault(x => x.Id == id);
            if (car is null)
            {
                return NotFound($"Id {id} bo‘yicha mashina topilmadi.");
            }
            return Ok(car);
        }

        [HttpPost]
        public IActionResult AddCar(Car car) 
        {
            car.Id = CarData.Cars.Max(x => x.Id) + 1;
            CarData.Cars.Add(car);
            return CreatedAtAction(nameof(GetCarById), new { id = car.Id }, car);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCar(int id, Car updatedCar) 
        {
            var car = CarData.Cars.FirstOrDefault(x => x.Id == id);
            if (car is null)
            {
                return NotFound($"Id {id} bo‘yicha mashina topilmadi.");
            }

            car.Brand = updatedCar.Brand;
            car.Model = updatedCar.Model;
            car.Year = updatedCar.Year;
            car.Color = updatedCar.Color;
            car.FuelType = updatedCar.FuelType;
            car.EngineSize = updatedCar.EngineSize;
            car.HorsePower = updatedCar.HorsePower;
            car.Transmission = updatedCar.Transmission;
            car.Price = updatedCar.Price;
            car.IsAvailable = updatedCar.IsAvailable;

            return Ok(car);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id) 
        {
            var car = CarData.Cars.FirstOrDefault(x => x.Id == id);
            if (car is null) 
            {
                return NotFound($"Id {id} bo‘yicha mashina topilmadi.");
            }

            CarData.Cars.Remove(car);
            return NoContent();
        }
    }
}
