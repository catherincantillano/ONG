using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONG.BL
{
    public class Orden
    {
        public int Id { get; set; }
        public int BeneficiarioId { get; set; }
        public Beneficiario Beneficiario { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public bool Activo { get; set; }

        public List<OrdenDetalle> ListadeOrdenDetalle { get; set; }

        public Orden()
        {
            Activo = true;
            Fecha = DateTime.Now;
            ListadeOrdenDetalle = new List<OrdenDetalle>();
        }
    }

    public class OrdenDetalle
    {
        public int Id { get; set; }
        public int OrdenId { get; set; }
        public Orden Orden { get; set; }

        public int Beneficioid { get; set; }
        public Beneficio Beneficio { get; set; }

        public int Meses { get; set; }
        public double Valor { get; set; }
        public double Total { get; set; }
    }
}
