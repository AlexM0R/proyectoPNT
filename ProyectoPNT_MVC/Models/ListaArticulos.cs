﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPNT_MVC.Models
{
    public class ListaArticulos
    {
        public int articuloId { get; set; }
        public Articulo articulo { get; set; }

        public int compraId { get; set; }
        public Compra compra { get; set; }
    }
}
