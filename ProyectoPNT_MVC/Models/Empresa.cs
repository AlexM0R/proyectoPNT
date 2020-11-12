using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace ProyectoPNT_MVC.Models
{
    public class Empresa
    {
        public String nombre { get; set; }

        public Enums.Estado agregarArticulo(int numeroArticulo, double precio, String desc, String nombre, String img, int stock, String talle)
        {
            return Enums.Estado.EXITOSO;
        }

        public Enums.Estado eliminarArticulo(int id)
        {
            return Enums.Estado.EXITOSO;
        }

        public Enums.Estado agregarUsuario(String nombreU, String nombreC, String contraseña, String direccion, String email, Enums.TipoUsuario tipoUsuario)
        {
            return Enums.Estado.EXITOSO;
        }
    }
}
