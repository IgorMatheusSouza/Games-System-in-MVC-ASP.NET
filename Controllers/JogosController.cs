using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaJogos.Models;
using SistemaJogos.ConnectionDB;
using System.Collections;
using System.Web.Services;
using System.Web.Script.Services;


namespace SistemaJogos.Controllers
{
    public class JogosController : Controller
    {
        public sistemaGamesEntities db = new sistemaGamesEntities();
        private Jogos ClassJogos = new Jogos();
        private Clientes ClassClientes = new Clientes();
        private Compras ClassCompras = new Compras();


        public ActionResult Index(string plat = null)
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
        public ActionResult Index(string nomeJogo, string valor, string ano)
        {
            if (valor == "" && ano == "2")
            {
                return View(ClassJogos.SelecionarGamePeloNome(nomeJogo));
            }
            else
            {

                return View(ClassJogos.SelecionarGamePorVariosFiltros(nomeJogo, valor, ano));
            }
        }

        [HttpPost]
        public ActionResult JogoPage(string nomeCliente, int? quant, string nomeJogo, int jogoId)
        {
            jogos jogoComprado = ClassJogos.SelecionarGamePeloId(jogoId);
            clientes cliente = ClassClientes.SelecionarClientePeloNome(nomeCliente);
            compra novaCompra = new compra();

            float valorCompra = Convert.ToSingle(jogoComprado.preco * quant);

            jogoComprado.quantidade -= quant;
            cliente.valorGasto += valorCompra;
           
            novaCompra.jogos_idjogos = jogoComprado.idjogos;
            novaCompra.quantidade = quant;
            novaCompra.valor = valorCompra;
            novaCompra.clientes_idclientes = cliente.idclientes;
            novaCompra.dtCompra = Convert.ToDateTime(System.DateTime.Now);

            db.compra.Add(novaCompra);
            db.SaveChanges();
            db.Dispose();

            return RedirectToAction("Index");
        }

       
    }



}