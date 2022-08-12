using Microsoft.AspNetCore.Mvc;

namespace tg_api.Controllers;

public class AuthController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}