using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace ProyectoPNT_MVC.Models
{
    public class Articulo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public int numeroArticulo { get; set; }

        [Required]
        public double precio { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public String descripcion { get; set; }

        [Required]
        public String nombre { get; set; }

        [Required]
        public String imagen { get; set; }

        [Required]
        public int stock { get; set; }

        [Required]
        public String talle { get; set; }


        public void modificarArticulo(double precio, String desc, String nombre, String img, int stock, String talle)
        {
        }
    }
}
