using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaJogos.Models;
using SistemaJogos.ConnectionDB;
using System.Collections;

namespace SistemaJogos.Controllers
{
    public class JogosController : Controller
    {
       private sistemaGamesEntities db = new sistemaGamesEntities();
       private Jogos ClassJogos = new Jogos();


        public ActionResult Index(string plat= null)
        {
            if (plat != null)
            {
                return View(ClassJogos.SelecionarGamePelaPlat(plat));
            }
            return View(ClassJogos.SelecionarTodosGame());
        }

        public ActionResult CadastrarJogo()
        {
            return View();
        }

        //pagina JogoPage
        public ActionResult JogoPage(int Id)
        {
            return View(ClassJogos.SelecionarGamePeloId(Id));
        }

        [HttpPost]
        public ActionResult CadastrarJogo(jogos jogo)
        {
            if (ClassJogos.ValidarjogoParaCadastrar(jogo))
            {  
                jogo.validacao = true;
                
                db.jogos.Add(jogo);
                db.SaveChanges();
 
                return RedirectToAction("Index");
            }

            else
            {
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
         public ActionResult Index(string nomeJogo,string valor,string ano)
         {  
            if (valor == "" && ano == "2")
            {
                return View(ClassJogos.SelecionarGamePeloNome(nomeJogo));
            }
            else {
                
                return View(ClassJogos.SelecionarGamePorVariosFiltros(nomeJogo, valor, ano));
            }
         }

       

        





    }
}