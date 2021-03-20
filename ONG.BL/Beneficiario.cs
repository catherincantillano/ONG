using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONG.BL
{
    public class Beneficiario
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre del Beneficiario")]
        [MinLength(3, ErrorMessage = "Ingrese mínimo 3 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese el Telefono")]
        [MinLength(8, ErrorMessage = "El telefono debe ser de 8 digitos")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Ingrese la Direccion")]
        [MinLength(3, ErrorMessage = "Ingrese mínimo 3 caracteres")]
        public string Direccion { get; set; }

        public bool Activo { get; set; }
    }
}