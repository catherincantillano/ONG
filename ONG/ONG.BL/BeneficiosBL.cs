using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONG.BL
{
   public class BeneficiosBL
    {
        Contexto _contexto;

        public List<Beneficio> ListadeBeneficios { get; set; }


        public BeneficiosBL()
        {
            _contexto = new Contexto();
            ListadeBeneficios = new List<Beneficio>();
        }


        public List<Beneficio> ObtenerBeneficios()
        {

            ListadeBeneficios = _contexto.Beneficios
                .Include("Categoria")
                 .OrderBy(r => r.Categoria.Descripcion)
                  .ThenBy(r => r.descripcion)
                .ToList();

            return ListadeBeneficios;
        }
        public List<Beneficio> ObtenerBeneficiosActivos()
        {

            ListadeBeneficios = _contexto.Beneficios
                .Include("Categoria")
                .Where(r => r.Activo == true )
                .OrderBy(r => r.Categoria.Descripcion)
                .ToList();

            return ListadeBeneficios;
        }

        public void GuardarBeneficio(Beneficio beneficio)
        {

            if (beneficio.id == 0)
            {
                _contexto.Beneficios.Add(beneficio);
            }
            else
            {
                var beneficioExistente = _contexto.Beneficios.Find(beneficio.id);
                beneficioExistente.descripcion = beneficio.descripcion;
                beneficioExistente.valor = beneficio.valor;
                beneficioExistente.UrlImagen = beneficio.UrlImagen;
                beneficioExistente.Activo = beneficio.Activo;
            }

            _contexto.SaveChanges();
        }

        public Beneficio ObtenerBeneficio(int id)
        {
            var beneficio = _contexto.Beneficios
                .Include("Categoria").FirstOrDefault(p => p.id == id);
            return beneficio;
        }

        public void EliminarBeneficio(int id)
        {
            var producto = _contexto.Beneficios.Find(id);

            _contexto.Beneficios.Remove(producto);
            _contexto.SaveChanges();
        }

    }
}