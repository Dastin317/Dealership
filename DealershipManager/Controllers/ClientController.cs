using DealershipManager.Dtos;
using DealershipManager.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DealershipManager.Controllers
{
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        [Route("clients")]

        public IActionResult Add(AddClientDto clientDto)
        {
            _clientService.Add(clientDto);

            return Ok();
        }

        [HttpGet]
        [Route("clients")]

        public IActionResult GetAll()
        {
            var result = _clientService.GetAll();

            return Ok(result);
        }
    }
}
