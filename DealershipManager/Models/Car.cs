namespace SecondHandDealership.Models
{
    public class Car
    {
        public Guid Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int ProductionYear { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public CarCategories Category { get; set; }

        public bool IsSold { get; set; }
    }
}
