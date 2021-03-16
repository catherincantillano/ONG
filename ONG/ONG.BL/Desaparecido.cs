using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONG.BL
{
    public class Desaparecido
    {
        public Desaparecido()
        {
            Activo = true;
        }

        public int Id { get; set; }

        [Display(Name = " Primer Nombre")]
        [Required(ErrorMessage ="Este campo es Obligatorio")]
        [MinLength(3, ErrorMessage ="Ingrese Minimo tres Caracteres")]
        [MaxLength(20, ErrorMessage ="Ingrese Maximo 20 caracteres")]
        public string Primer_Nombre { get; set; }

        [Display(Name = " Segundo Nombre")]
        [MinLength(3, ErrorMessage = "Ingrese Minimo tres Caracteres")]
        [MaxLength(20, ErrorMessage = "Ingrese Maximo 20 caracteres")]
        public string Segundo_Nombre { get; set; }

        [Display(Name = " Primer Apellido")]
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        [MinLength(3, ErrorMessage = "Ingrese Minimo tres Caracteres")]
        [MaxLength(20, ErrorMessage = "Ingrese Maximo 20 caracteres")]
        public string Primer_Apellido { get; set; }

        [Display(Name = " Segundo Apellido")]
        [MinLength(3, ErrorMessage = "Ingrese Minimo tres Caracteres")]
        [MaxLength(20, ErrorMessage = "Ingrese Maximo 20 caracteres")]
        public string Segundo_Apellido { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        [MinLength(3, ErrorMessage = "Ingrese Minimo tres Caracteres")]
        [MaxLength(200,ErrorMessage = "Ingrese Maximo 20 caracteres")]
        public string Residencia { get; set; }

        [Required(ErrorMessage = "Ingrese La Edad")]
        [Range(1,500, ErrorMessage ="Ingrese una Edad Correcta")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        [MinLength(3, ErrorMessage = "Ingrese Minimo tres Caracteres")]
        [MaxLength(200, ErrorMessage = "Ingrese Maximo 20 caracteres")]
        public string Sexo { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        [Display(Name = "Imagen")]
        public string UrlImagen { get; set; }

        public bool Activo { get; set; }

    }
}
