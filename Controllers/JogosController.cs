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
       private Jogos game = new Jogos();


        public ActionResult Index(string plat= null, string valor= null)
        {
            if (plat != null)
            {
                return View(game.SelecionarGamePelaPlat(plat));
            }
            return View(game.SelecionarTodosGame());
        }

        public ActionResult CadastrarJogo()
        {
            return View();
        }
        public ActionResult JogoPage(int Id)
        {

            return View(game.SelecionarGamePeloId(Id));
        }
        public ActionResult platforma(string plat)
        {

            return View(game.SelecionarTodosGame());
        }

        [HttpPost]
         public ActionResult Index(string nomeJogo,double? valor)
         {
            return View(game.SelecionarGamePeloNome(nomeJogo));
         }

        



    }
}