using SecondHandDealership.Models;

namespace DealershipManager.Dtos
{
    public class AddCarDto
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public int ProductionYear { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public CarCategories Category { get; set; }
    }
}
