using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace ProyectoPNT_MVC.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [Display(Name = "Nombre de Usuario")]
        public string nombreUsuario { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre Completo")]
        public string nombreCompleto { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string contraseña { get; set; }

        [Required]
        [Display(Name = "Direccion")]
        public string direccion { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string mail { get; set; }

        [ForeignKey("CarritoId")]
        public int carritoId { get; set; }
        public IList<Carrito> carrito { get; set; }

        [ForeignKey("DeseadosId")]
        public int deseadosId { get; set; }
        public IList<ListaDeseados> deseados { get; set; }

        [ForeignKey("ComprasId")]
        public int comprasId { get; set; }
        public IList<ListaCompras> compras { get; set; }

        [EnumDataType(typeof(Enums.TipoUsuario))]
        [Display(Name = "Tipo de Usuario")]
        public Enums.TipoUsuario tipoUsuario { get; set; }


        public Enums.Estado actualizarDatos(string nombreUsuario, string nombreCompleto, string contraseña, string direccion, string mail)
        {
            return Enums.Estado.EXITOSO;
        }

        public Enums.Estado inicioSesion(string nombreUsuario, string contraseña)
        {
            return Enums.Estado.EXITOSO;
        }

        public Enums.Estado añadirAlCarro(Articulo articulo)
        {

            return Enums.Estado.EXITOSO;
        }

        public Enums.Estado añadirArticuloADeseados(Articulo articulo)
        {
            return Enums.Estado.EXITOSO;
        }

        public Enums.Estado eliminarArtCarro(Articulo articulo)
        {
            return Enums.Estado.EXITOSO;
        }

        public Enums.Estado eliminarArtDeseado(Articulo articulo)
        {
            return Enums.Estado.EXITOSO;
        }

        public Enums.Estado realizarCompra()
        {
            return Enums.Estado.EXITOSO;
        }
    }
}
