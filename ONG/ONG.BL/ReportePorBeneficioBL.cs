using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONG.BL
{
    public class ReportePorBeneficioBL
    {
        Contexto _contexto;
        public List<ReportePorBeneficio> ListaPorBeneficio { get; set; }

        public ReportePorBeneficioBL()
        {
            _contexto = new Contexto();
            ListaPorBeneficio = new List<ReportePorBeneficio>();
        }
        public List<ReportePorBeneficio> ObtenerBeneficio()
        {
            ListaPorBeneficio = _contexto.OrdenDetalle
                .Include("Beneficio")
                .Where(r => r.Orden.Activo)
                .GroupBy(r => r.Beneficio.descripcion)
                .Select(r => new ReportePorBeneficio()
                {
                    Beneficio = r.Key,
                    Meses = r.Sum(s => s.Meses),
                    Total = r.Sum(s => s.Total)
                }).ToList();
            return ListaPorBeneficio;

        }

        public static implicit operator ReportePorBeneficioBL(ReportePorBeneficio v)
        {
            throw new NotImplementedException();
        }
    }
}
