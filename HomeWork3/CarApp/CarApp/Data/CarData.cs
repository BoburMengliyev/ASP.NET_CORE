using CarApp.Models;

namespace CarApp.Data
{
    public static class CarData
    {
        public static List<Car> Cars = new List<Car>
        {
            new Car 
            {
                Id = 1,
                Brand = "Toyota",
                Model = "Camry",
                Year = 2022,
                Color = "White",
                FuelType = "Petrol",
                EngineSize = 2.5,
                HorsePower = 203,
                Transmission = "Automatic",
                Price = 28000m,
                IsAvailable = true
            },

            new Car 
            {
                Id = 2,
                Brand = "BMW",
                Model = "X5",
                Year = 2021,
                Color = "Black",
                FuelType = "Diesel",
                EngineSize = 3.0,
                HorsePower = 335,
                Transmission = "Automatic",
                Price = 52000m,
                IsAvailable = false
            }
        };
    }
}
