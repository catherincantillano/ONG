using ONG.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ONG.WebAdmin.Controllers
{
    public class BeneficiosController : Controller
    {
        BeneficiosBL _beneficiosBL;
        CategoriasBL _categoriasBL;

        public BeneficiosController()
        {
            _beneficiosBL = new BeneficiosBL();
            _categoriasBL = new CategoriasBL();
        }

        // GET: Beneficios
        public ActionResult Index()
        {

            var listadeBeneficios = _beneficiosBL.ObtenerBeneficios();


            return View(listadeBeneficios);
        }


        public ActionResult Crear()
        {
            var nuevoBeneficio = new Beneficio();
            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId =
                new SelectList(categorias, "Id", "Descripcion");
            return View(nuevoBeneficio);
        }

        [HttpPost]
        public ActionResult Crear(Beneficio beneficio, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if (beneficio.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccione una categoria");
                    return View(beneficio);
                }

                if (imagen != null)
                {
                    beneficio.UrlImagen = GuardarImagen(imagen);
                }
                _beneficiosBL.GuardarBeneficio(beneficio);

                return RedirectToAction("Index");
            }
            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId =
                new SelectList(categorias, "Id", "Descripcion");
            return View(beneficio);
        }

        public ActionResult Editar(int id)
        {
            var beneficio = _beneficiosBL.ObtenerBeneficio(id);
            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId =
                new SelectList(categorias, "Id", "Descripcion", beneficio.CategoriaId);
            return View(beneficio);

        }

        [HttpPost]
        public ActionResult Editar(Beneficio beneficio)
        {
            if (ModelState.IsValid)
            {
                if (beneficio.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccione una categoria");
                    return View(beneficio);
                }
                _beneficiosBL.GuardarBeneficio(beneficio);

                return RedirectToAction("Index");
            }
            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId =
                new SelectList(categorias, "Id", "Descripcion");
            return View(beneficio);
        }

        public ActionResult Detalle(int id)
        {
            var beneficio = _beneficiosBL.ObtenerBeneficio(id);

            return View(beneficio);
        }

        public ActionResult Eliminar(int id)
        {
            var beneficio = _beneficiosBL.ObtenerBeneficio(id);


            return View(beneficio);
        }

        [HttpPost]
        public ActionResult Eliminar(Beneficio beneficio)
        {

            _beneficiosBL.EliminarBeneficio(beneficio.id);
            return RedirectToAction("Index");

        }

        private string GuardarImagen(HttpPostedFileBase imagen)
        {
            string path = Server.MapPath("~/Imagenes/" + imagen.FileName);
            imagen.SaveAs(path);

            return "/Imagenes/" + imagen.FileName;
        }
    }
}
