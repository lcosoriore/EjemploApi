using EjemploApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace EjemploApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloworldController : ControllerBase
    {
        IHelloworldServices services;
        private readonly ILogger<HelloworldController> _logger;
        public HelloworldController(IHelloworldServices helloWorldServices, ILogger<HelloworldController> logger)
        {
            _logger = logger;
            services =  helloWorldServices;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogDebug("Se realiza la implementacion de Logger en el controlador");
            return Ok(services.GetHelloWorld());
        }
    }
}
