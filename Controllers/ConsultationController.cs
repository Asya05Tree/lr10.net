using Lr10.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lr10.Controllers
{
    public class ConsultationController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View(new ConsultationRegistrationViewModel());
        }

        [HttpPost]
        public IActionResult Register(ConsultationRegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["SuccessMessage"] = "Реєстрація успішна!";
                return RedirectToAction("Success");
            }
            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}

