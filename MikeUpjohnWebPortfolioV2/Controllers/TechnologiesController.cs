using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MikeUpjohnWebPortfolioV2.Controllers
{
    public class TechnologiesController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.BodyClass = Code.Settings.BodyClass.TECHNOLOGIES;
            return View();
        }
    }
}