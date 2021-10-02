using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace testing.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
    //    public ActionResult Index()
    //    {
    //        return View();
    //    }

    public ActionResult List()
        {
            ViewBag.Name = "fahad poran";
            string[] names = new string[3];
            names[0] = "jakir";
            names[1] = "jakir";
            names[2] = "jakir";

            ViewBag.names = names;
            return View();
            //person/list
        }

    }
}