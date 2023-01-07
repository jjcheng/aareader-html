using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index(string culture = "en")
    {
        if(culture == "en")
        {
            return View("EnIndex");
        }
        else
        {
            return View("ZhIndex");
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }
}