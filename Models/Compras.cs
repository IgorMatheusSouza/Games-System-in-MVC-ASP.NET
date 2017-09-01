using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaJogos.Models
{
    public class Compras
    {
        public Compras()
        {

        }

        public int idCompra { get; set; }
        public int jogos_idjogos { get; set; }
        public int clientes_idclientes { get; set; }
        public Nullable<System.DateTime> dtCompra { get; set; }
        public Nullable<int> quantidade { get; set; }
        public Nullable<float> valor { get; set; }
    }
}