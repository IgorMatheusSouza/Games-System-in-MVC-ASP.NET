using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaJogos.ConnectionDB;
namespace SistemaJogos.Models
{
    public class Clientes
    {
        sistemaGamesEntities connect = new sistemaGamesEntities();

        public Clientes()
        {
           
        }
        public int idclientes { get; set; }
        public string nome { get; set; }
        public System.DateTime dtNascimento { get; set; }
        public Nullable<long> cpf { get; set; }
        public float valorGasto { get; set; }


        public clientes SelecionarClientePeloNome(string nomeCliente)
        {
            clientes Model = connect.clientes.First(o => o.nome.Contains(nomeCliente));
            return Model;
        }

    }

}