using DealershipManager.Dtos;
using Microsoft.AspNetCore.Mvc;
using SecondHandDealership.Interfaces;

namespace SecondHandDealership.Controllers
{
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService) 
        {
            _carService = carService;
        }

        [HttpPost]
        [Route("cars")]
        public IActionResult Add(AddCarDto car)
        {
            var result = _carService.Add(car);

            return result.IsSucces ? Ok() : BadRequest(result.ErrorMessage);
        }

        [HttpGet]
        [Route("cars")]
        public IActionResult GetAll(bool isSold)
        {
            var result = _carService.GetAll(isSold);

            return Ok(result);
        }

        [HttpGet]
        [Route("cars/{carId}")] 
        public IActionResult GetById(Guid carId)
        {
            var operationResult = _carService.Get(carId);

            return operationResult.IsSucces
                ? Ok(operationResult.Result) 
                : NotFound(operationResult.ErrorMessage);
        }

        [HttpPut]
        [Route("cars/{carId}")]
        public IActionResult Update(Guid carId, UpdateCarDto carDto)
        {
            _carService.Update(carId, carDto); 

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
