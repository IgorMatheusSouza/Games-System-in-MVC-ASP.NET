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
       private sistemaGamesEntities2 db = new sistemaGamesEntities2();
      
        public ActionResult Index()
        {
            var Model = from mat in db.jogos
                         select mat;
            
            return View(Model);
        }
       

        [HttpPost]
         public ActionResult Index(string nomeJogo){ 
             var Model = from mat in db.jogos
                         where mat.nome.Contains(nomeJogo)
                         select mat;

             return View(Model);
         
         }
       

       
         
         
    }
}