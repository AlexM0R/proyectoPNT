using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace ProyectoPNT_MVC.Models
{
    public class Compra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public int nroPedido { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime fechaCompra { get; set; }

        [ForeignKey("ArticuloId")]
        public int articuloId { get; set; }
        public IList<ListaArticulos> listaArticulos { get; set; }

        [Required]
        public double precioTotal { get; set; }

        private void setPrecioTotal(Array listaCompra)
        {

        }
    }
}
