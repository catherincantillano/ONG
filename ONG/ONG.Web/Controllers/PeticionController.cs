using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ONG.Web.Controllers
{
    public class PeticionController : Controller
    {
        // GET: Peticion
        public ActionResult Index()
        {
            return View();
        }
    }
}