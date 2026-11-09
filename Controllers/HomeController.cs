using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    public HomeController()
    {

    }

    [HttpGet]
    public string Test()
    {
        return "test";
    }
}
