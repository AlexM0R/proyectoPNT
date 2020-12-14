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

    }
}
