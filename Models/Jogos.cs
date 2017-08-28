using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaJogos.ConnectionDB;

namespace SistemaJogos.Models
{
    public class Jogos
    {

        sistemaGamesEntities2 connect = new sistemaGamesEntities2();
        
        public Jogos()
        {

        }
        public jogos SelecionarGamePeloId(int id)
        {
            
            jogos jogo = connect.jogos.First(o => o.idjogos == id);
            return jogo;

        }
        public int idjogos { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public string img { get; set; }
        public Nullable<System.DateTime> dtLancamentos { get; set; }
        public string plataforma { get; set; }
        public Nullable<float> preco { get; set; }
        public Nullable<bool> validacao { get; set; }
        public Nullable<int> quantidade { get; set; }

        public int SelecionarQuant()
        {
            int k = (from mat in connect.jogos
                     select mat.idjogos).Count();

            return k;
        }

        public jogos SelecionarGamePeloNome(string nome)
        {
            jogos game = new jogos();

            int k = (from mat in connect.jogos
                     select mat.idjogos).Count();

            for (int i = 0; i < k; i++)
            {
                game = connect.jogos.First(pk => pk.idjogos == i);

                if ((game.nome.ToLower().Contains(nome.ToLower())) && game.validacao == true)
                {
                    return game;
                }



            }

            return game;
        }
    }
}