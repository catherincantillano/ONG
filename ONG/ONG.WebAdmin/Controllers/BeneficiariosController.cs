using ONG.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ONG.WebAdmin.Controllers
{
    public class BeneficiariosController : Controller
    {
        BeneficiariosBL _beneficiariosBL;

        public BeneficiariosController()
        {
            _beneficiariosBL = new BeneficiariosBL();
        }

        // GET: Beneficiarios
        public ActionResult Index()
        {
            var listadeBeneficiarios = _beneficiariosBL.ObtenerBeneficiarios();

            return View(listadeBeneficiarios);
        }

        public ActionResult Crear()
        {
            var nuevoBeneficiario = new Beneficiario();

            return View(nuevoBeneficiario);
        }

        [HttpPost]
        public ActionResult Crear(Beneficiario beneficiario)
        {
            if (ModelState.IsValid)
            {
                
                _beneficiariosBL.GuardarBeneficiario(beneficiario);

                return RedirectToAction("Index");
            }

            return View(beneficiario);

        }

        public ActionResult Editar(int Id)
        {
            var beneficiario = _beneficiariosBL.ObtenerBeneficiario(Id);

            return View(beneficiario);
        }

        [HttpPost]
        public ActionResult Editar(Beneficiario beneficiario)
        {
            if (ModelState.IsValid)
            {
                
                _beneficiariosBL.GuardarBeneficiario(beneficiario);

                return RedirectToAction("Index");
            }
            return View(beneficiario);
        }

        public ActionResult Detalle(int Id)
        {
            var beneficiario = _beneficiariosBL.ObtenerBeneficiario(Id);
            return View(beneficiario);
        }

        public ActionResult Eliminar(int Id)
        {
            var beneficiario = _beneficiariosBL.ObtenerBeneficiario(Id);
            return View(beneficiario);
        }

        [HttpPost]

        public ActionResult Eliminar(Beneficiario beneficiario)
        {
            _beneficiariosBL.EliminarBeneficiario(beneficiario.Id);
            return RedirectToAction("Index");
        }
    }

}