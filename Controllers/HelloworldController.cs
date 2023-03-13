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

        public HelloworldController(IHelloworldServices helloWorldServices)
        {
            services =  helloWorldServices;
        }

        public IActionResult Get()
        {
            return Ok(services.GetHelloWorld());
        }
    }
}
