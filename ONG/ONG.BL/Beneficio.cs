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
        public string descripcion { get; set; }

        [Display(Name ="Valor")]
        public double valor { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        [Display(Name = "Imagen")]
        public string UrlImagen { get; set; }
        public bool Activo { get; set; }
    }
}