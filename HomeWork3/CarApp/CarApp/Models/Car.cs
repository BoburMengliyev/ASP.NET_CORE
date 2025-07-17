namespace CarApp.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string FuelType { get; set; }
        public double EngineSize { get; set; }
        public int HorsePower { get; set; }
        public string Transmission { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
    }
}
