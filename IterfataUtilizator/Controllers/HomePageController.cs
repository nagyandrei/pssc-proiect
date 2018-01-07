using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IterfataUtilizator.Controllers
{
    public class HomePageController : Controller
    {


        // formaction='@Url.Action("IncrementareEchipa1")'
        [HttpPost]
        public ActionResult CautaMasina()
        {

            return RedirectToAction("AfisareMasinaCautata","User");
        }

    }
}