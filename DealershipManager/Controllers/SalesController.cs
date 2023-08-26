using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecondHandDealership.Interfaces;
using SecondHandDealership.Models;
using SecondHandDealership.Services;
using System.Diagnostics.CodeAnalysis;

namespace SecondHandDealership.Controllers
{
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SalesController(ISaleService saleService)
        {
            this._saleService = saleService;
        }

        [HttpPost]
        [Route("sales")] // Adresa endpoint-ului. Exemplu: localhost:7090/sales

        public IActionResult Add(Sale sale)
        {
            _saleService.Add(sale);

            return Ok();
        }

        [HttpGet]
        [Route("sales")] // get all sales => HTTP GET => /students

        public IActionResult GetAll() 
        {
            var result = _saleService.GetAll();

            return Ok(result);
        }

        [HttpGet]
        [Route("sales/{saleId}")] // get specific sale (by id) => HTTP GET => /students/id

        public IActionResult GetById(Guid saleId)
        {
            var result = _saleService.Get(saleId);

            return Ok(result);
        }

        [HttpPut]
        [Route("sales/{saleId}")]
        public IActionResult Update(Guid saleId, Sale sale)
        {
            _saleService.Update(sale);

            return Ok();
        }

        [HttpDelete]
        [Route("sales/{saleId}")]

        public IActionResult DeleteById(Guid saleId)
        {
            _saleService.Equals(saleId);

            return NoContent();
        }
    }
}
