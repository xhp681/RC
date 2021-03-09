using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rs.LPY.Areas.Admin.Models;

namespace Rs.LPY.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public virtual async Task<IActionResult> Index()
        {
            var model = new LoginModel()
            {

            };
            return View(model);
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public virtual async Task<IActionResult> Index(LoginModel model)
        {
            return View(model);
        }
    }
}
