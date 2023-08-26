using SecondHandDealership.Interfaces;
using SecondHandDealership.Models;

namespace SecondHandDealership.Services
{
    public class SaleService : ISaleService
    {
        private readonly List<Sale> sales;

        public SaleService()
        {
            sales = new List<Sale>();
        }

        public void Add(Sale sale)
        {
            sales.Add(sale);
        }

        public void Delete(Guid id)
        {
            var saleToDelete = sales.FirstOrDefault(s => s.Id == id);

            if (saleToDelete != null)
            {
                sales.Remove(saleToDelete);
            }
        }

        public Sale Get(Guid id)
        {
            return sales.FirstOrDefault(x => x.Id == id);
        }

        public List<Sale> GetAll()
        {
            return sales;
        }

        public void Update(Sale sale)
        {
            var saleToUpdate = sales.FirstOrDefault(s => s.Id == sale.Id);

            if (saleToUpdate != null)
            {
                saleToUpdate.Car = sale.Car;
                saleToUpdate.Client = sale.Client;
                saleToUpdate.Date = DateTime.Now;
                saleToUpdate.FinalPrice = sale.FinalPrice;
            }
        }
    }
}
