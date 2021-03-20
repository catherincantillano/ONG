using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONG.BL
{
   public class OrdenesBL
    {
        Contexto _contexto;
        public List<Orden> ListadeOrdenes { get; set; }

        public OrdenesBL()
        {
            _contexto = new BL.Contexto();
            ListadeOrdenes = new List<Orden>();
        }
        public List<Orden> ObtenerOrdenes()
        {
            ListadeOrdenes = _contexto.Ordenes
                .Include("Beneficiario")
                .ToList();

            return ListadeOrdenes;
        }

        public List<OrdenDetalle> ObtenerOrdenDetalle(int ordenId)
        {
            var listadeOrdenesDetalle = _contexto.OrdenDetalle
                .Include("Beneficio")
                .Where(o => o.OrdenId == ordenId).ToList();

            return listadeOrdenesDetalle;
        }

        public OrdenDetalle ObtenerOrdenDetallePorId(int id)
        {
            var ordenDetalle = _contexto.OrdenDetalle
               .Include("Beneficio")
                .FirstOrDefault(p => p.Id == id);
            return ordenDetalle;
        }

        public void GuardarOrden(Orden orden)
        {
            if (orden.Id == 0)
            {
                _contexto.Ordenes.Add(orden);
            }else
            {
                var ordenExistente = _contexto.Ordenes.Find(orden.Id);
                ordenExistente.BeneficiarioId = orden.BeneficiarioId;
                ordenExistente.Activo = orden.Activo;
            }
           
            _contexto.SaveChanges();
        }

        public Orden ObtenerOrden(int Id)
        {
            var orden = _contexto.Ordenes
                .Include("Beneficiario")
                .FirstOrDefault(p => p.Id == Id);

            return orden;
        }

        public void GuardarOrdenDetalle(OrdenDetalle ordenDetalle)
        {
            var beneficio = _contexto.Beneficios.Find(ordenDetalle.Beneficioid);

            ordenDetalle.Valor = beneficio.valor;
            ordenDetalle.Total = ordenDetalle.Meses * ordenDetalle.Valor;

            _contexto.OrdenDetalle.Add(ordenDetalle);

            var orden = _contexto.Ordenes.Find(ordenDetalle.OrdenId);
            orden.Total = orden.Total + ordenDetalle.Total;

            _contexto.SaveChanges();
        }

        public void EliminarOrdenDetalle(int id)
        {
            var OrdenDetalle = _contexto.OrdenDetalle.Find(id);
            _contexto.OrdenDetalle.Remove(OrdenDetalle);

            var orden = _contexto.Ordenes.Find(OrdenDetalle.OrdenId);
            orden.Total = orden.Total - OrdenDetalle.Total;

            _contexto.SaveChanges();
        }
    }
}
