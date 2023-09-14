using DealershipManager.Dtos;
using Microsoft.AspNetCore.Mvc;
using SecondHandDealership.Interfaces;

namespace SecondHandDealership.Controllers
{
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpPost]
        [Route("sales")]

        public IActionResult Add(AddSaleDto sale)
        {
            _saleService.Add(sale);

            return Ok();
        }

        [HttpGet]
        [Route("sales")]

        public IActionResult GetAll(DateTime startDate, DateTime endDate)
        {
            var result = _saleService.GetAll(startDate, endDate);

            return Ok(result);
        }
    }
}
