using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPNT_MVC.Models
{
    public static class Enums
    {

        public enum Estado
        {
            EXITOSO, PENDIENTE, FALTAN_DATOS, SALDO_INSUFICIENTE, FUERA_STOCK, ESTA_CREADO, NO_ENCONTRADO
        }

        public enum TipoUsuario
        {
            ADMIN, USUARIO
        }

    }
}
