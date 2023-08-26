using Microsoft.AspNetCore.Mvc;
using SecondHandDealership.Interfaces;
using SecondHandDealership.Models;
using SecondHandDealership.Services;

namespace SecondHandDealership.Controllers
{
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService) 
        {
            this._carService = carService;
        }

        [HttpPost]
        [Route("cars")]
        public IActionResult Add(Car car)
        {
            _carService.Add(car);

            return Ok();
        }

        [HttpGet]
        [Route("cars")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();

            return Ok(result);
        }

        [HttpGet]
        [Route("cars/{carId}")] 
        public IActionResult GetById(Guid carId)
        {
            var result = _carService.Get(carId);

            return result is null ? NotFound() : Ok(result);
        }

        [HttpPut]
        [Route("cars/{carId}")]
        public IActionResult Update(Guid carId, Car car)
        {
            _carService.Update(carId, car); 

            return Ok();
        }

        [HttpDelete]
        [Route("cars/{carId}")]
        public IActionResult Delete(Guid carId)
        {
            _carService.Delete(carId);

            return NoContent(); 
        }
    }
}
