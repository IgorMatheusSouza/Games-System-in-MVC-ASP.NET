using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaJogos.ConnectionDB;

namespace SistemaJogos.Models
{
    public class Jogos
    {

        sistemaGamesEntities connect = new sistemaGamesEntities();
        
        public Jogos()
        {

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
        public virtual ICollection<Jogos> CollectionJogos { get; set; }



        public jogos SelecionarGamePeloId(int id)
        {
            jogos Model = connect.jogos.First(o => o.idjogos == id);
            return Model;
        }



        public IQueryable<jogos> SelecionarTodosGame()
        {
            IQueryable<jogos> Model = connect.jogos
                     .OrderBy(r => r.nome);
            return Model;
        }



        public IQueryable<jogos> SelecionarGamePeloNome(string nomeJogo)
        {
            IQueryable<jogos> Model = connect.jogos
                     .Where(r => r.nome.Contains(nomeJogo));
            return Model;
        }



        public IQueryable<jogos> SelecionarGamePelaPlat(string plat)
        {
            IQueryable<jogos> Model = connect.jogos
                     .Where(r => r.plataforma.Contains(plat));
            return Model;
        }



        public IQueryable<jogos> SelecionarGamePorVariosFiltros(string nomeJogo,string valor, string ano)
        {
            double  valorInt;
            if (valor == ""){
                valorInt = 99999;
            }
            else{
                valorInt = Convert.ToDouble(valor);
            }

            IQueryable<jogos> Model = connect.jogos
                     .Where(r => r.nome.Contains(nomeJogo) && r.preco <= valorInt &&
                            r.dtLancamentos.ToString().Contains(ano)  );
            return Model;
        }


        public Boolean ValidarjogoParaCadastrar(jogos jogo) {
            if(jogo.nome == null || jogo.img==null || jogo.plataforma==null || jogo.preco==null || jogo.descricao == null)
            {
                return false;
            }
            return true;

        }
    }
}