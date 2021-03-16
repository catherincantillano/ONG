using ONG.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ONG.Web.Controllers
{
    public class DesaparecidosController : Controller
    {
        // GET: Desaparecidos
        public ActionResult Index()
        {
            var desaparecidosBL = new DesaparecidosBL();
            var listadeDesaparecidos = desaparecidosBL.ObtenerDesaparecidos();


            return View(listadeDesaparecidos);
        }
    }
}