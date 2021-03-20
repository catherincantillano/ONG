using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONG.BL
{
    public class Beneficio
    {
        public Beneficio()
        {
            Activo = true;
        }

        public int id { get; set; }

        [Display(Name ="Descripción")]
        [Required(ErrorMessage = "Ingrese la descripción")]
        [MinLength(3, ErrorMessage = "Ingrese minimo 3 caracteres")]
        [MaxLength(1000, ErrorMessage = "Ingrese un maximo de 20 caracteres")]
        public string descripcion { get; set; }

        [Display(Name ="Valor")]
        [Range(0, 999999, ErrorMessage = "Ingrese un precio entre 0 y 1000")]
        public double valor { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        [Display(Name = "Imagen")]
        public string UrlImagen { get; set; }

        public bool Activo { get; set; }
    }
}