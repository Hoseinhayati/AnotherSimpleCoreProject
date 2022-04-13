using System.Diagnostics;
using Asp.netCore_MVC_.Models;
using Asp.netCore_MVC_.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Asp.netCore_MVC_.Controllers
{
    public class HomeController : Controller
    {
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
