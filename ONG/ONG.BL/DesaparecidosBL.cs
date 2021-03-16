using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONG.BL
{
    public class DesaparecidosBL
    {
        Contexto _contexto;
        public List<Desaparecido> ListadeDesaparecidos { get; set; }

        public DesaparecidosBL()
        {
            _contexto = new Contexto();
            ListadeDesaparecidos = new List<Desaparecido>();

        }

        public List<Desaparecido> ObtenerDesaparecidos()
        {
            ListadeDesaparecidos = _contexto.Desaparecidos
                .Include("Categoria")
                .OrderBy(r => r.Primer_Nombre)
                .ToList();

            return ListadeDesaparecidos;
        }
        public List<Desaparecido> ObtenerDesaparecidosActivos()
        {
            ListadeDesaparecidos = _contexto.Desaparecidos
                .Include("Categoria")
                .Where(r => r.Activo == true )
                .OrderBy(r => r.Primer_Nombre)
                .ToList();

            return ListadeDesaparecidos;
        }

        public void GuardarDesaparecido(Desaparecido desaparecido)
        {
            if(desaparecido.Id == 0)
            {
                _contexto.Desaparecidos.Add(desaparecido);
            }else
            {
                var desaparecidoExistente = _contexto.Desaparecidos.Find(desaparecido.Id);

                desaparecidoExistente.Primer_Nombre = desaparecido.Primer_Nombre;
                desaparecidoExistente.Segundo_Nombre = desaparecido.Segundo_Nombre;
                desaparecidoExistente.Primer_Apellido = desaparecido.Primer_Apellido;
                desaparecidoExistente.Segundo_Apellido = desaparecido.Segundo_Apellido;
                desaparecidoExistente.Residencia = desaparecido.Residencia;
                desaparecidoExistente.Edad = desaparecido.Edad;
                desaparecidoExistente.Sexo = desaparecido.Sexo;
                desaparecidoExistente.CategoriaId = desaparecido.CategoriaId;
                desaparecidoExistente.UrlImagen = desaparecido.UrlImagen;

            }

            _contexto.SaveChanges();
        }

        public Desaparecido ObtenerDesaparecido(int id)
        {
            var desaparecido = _contexto.Desaparecidos
                .Include("Categoria").FirstOrDefault(p => p.Id == id);

            return desaparecido;
        }

        public void EliminarDesaparecido(int id)
        {
            var desaparecido = _contexto.Desaparecidos.Find(id);

            _contexto.Desaparecidos.Remove(desaparecido);
            _contexto.SaveChanges();

        }
    }
}
