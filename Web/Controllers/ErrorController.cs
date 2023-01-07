using AAReader.Web.ViewModels.Error;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AAReader.Web.Controllers;

public class ErrorController : Controller
{
    [ResponseCache(Duration = 600, Location = ResponseCacheLocation.Any)]
    public IActionResult Index(int? code = null)
    {
        ErrorViewModel errorViewModel = new ErrorViewModel()
        {
            StatusCode = code
        };
        if (code.HasValue)
        {
            if (code.Value == (int)HttpStatusCode.Unauthorized)
            {
                errorViewModel.Message = "Unauthorized";
            }
            else if (code.Value == (int)HttpStatusCode.NotFound)
            {
                errorViewModel.Message = "Page not found";
            }
            else
            {
                errorViewModel.Message = "Internal server error";
            }
        }
        return View(errorViewModel);
    }

    [ResponseCache(Duration = 600, Location = ResponseCacheLocation.Any)]
    public new ActionResult Unauthorized()
    {
        ErrorViewModel errorViewModel = new ErrorViewModel()
        {
            StatusCode = (int)HttpStatusCode.Unauthorized,
            Message = "Unauthorized"
        };
        return View("Index", errorViewModel);
    }
}
