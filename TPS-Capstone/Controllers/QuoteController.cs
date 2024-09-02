using Microsoft.AspNetCore.Mvc;

namespace TPS_Capstone.Controllers
{
    public class QuoteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TermsAndConditions()
        {
            return View();
        }
    }
}
