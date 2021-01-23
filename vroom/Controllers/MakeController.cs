using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vroom.Models;

namespace vroom.Controllers
{
    public class MakeController : Controller
    {
        [Route("make")]
        [Route("make/bikes")]
        public IActionResult Bikes()
        {
            Make make = new Make { Id = 1, Name = "Honda" };
            return View(make);
        }

        [Route("make/bikes/{year:int:length(4)}/{month:int:range(1,13)}")]
        public IActionResult ByMonthYear(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}