﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPNT_MVC.Models
{
    public class Carrito
    {
        public int articuloId { get; set; }

        [Display(Name = "Articulo")]
        public Articulo articulo { get; set; }

        public int usuarioId { get; set; }

        public Usuario usuario{ get; set; }

        [Display(Name = "Cantidad")]
        public int cantArticulos { get; set; }

    }
}
