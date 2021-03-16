using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONG.BL
{
   public class BeneficiariosBL
    {
        Contexto _contexto;

        public List<Beneficiario> ListadeBeneficiarios { get; set; }


        public BeneficiariosBL()
        {
            _contexto = new Contexto();
            ListadeBeneficiarios = new List<Beneficiario>();
        }


        public List<Beneficiario> ObtenerBeneficiariosActivos()
        {

            ListadeBeneficiarios = _contexto.Beneficiarios.ToList();
            return ListadeBeneficiarios;
        }

        public void GuardarBeneficiario(Beneficiario beneficiario)
        {

            if (beneficiario.Id == 0)
            {
                _contexto.Beneficiarios.Add(beneficiario);
            }
            else
            {
                var beneficiarioExistente = _contexto.Beneficiarios.Find(beneficiario.Id);
                beneficiarioExistente.Nombre = beneficiario.Nombre;
                beneficiarioExistente.Telefono = beneficiario.Telefono;
                beneficiarioExistente.Direccion = beneficiario.Direccion;

            }

            _contexto.SaveChanges();
        }

        public Beneficiario ObtenerBeneficiario(int Id)
        {
            var beneficiario = _contexto.Beneficiarios.Find(Id);
            return beneficiario;
        }

        public void EliminarBeneficiario(int Id)
        {
            var beneficiario = _contexto.Beneficiarios.Find(Id);

            _contexto.Beneficiarios.Remove(beneficiario);
            _contexto.SaveChanges();
        }

    }
}