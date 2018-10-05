using Microsoft.AspNetCore.Mvc;

namespace SistemaDeVigilancia.API.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger/");
        }
    }
}