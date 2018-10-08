using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cadastro_Cliente_Ponto.Models;
using Cadastro_Cliente_Ponto.ADO;
using FastReport;


namespace Cadastro_Cliente_Ponto.Controllers
{
    public class FuncionariosController : Controller
    {
        // GET: Funcionarios
        public ActionResult Index()
        {
            var buscar = new AdoFuncionario();
            return View(buscar.RetornarTodosFuncionarios());   
        }
        public ActionResult Cadastrar() {
            return View();
        }

        public ActionResult Alterar(int codigo)
        {
            var funcionario = new AdoFuncionario().RetornarFuncionario(codigo); 
            return View(funcionario);
        }

        [HttpPost]
        public ActionResult Alterar(Funcionario funcionario)
        {
            try
            {
                var adoPonto = new AdoFuncionario();
                adoPonto.AlterarFuncionario(funcionario);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return RedirectToAction("TratacaoDeErro");
            }
            
        }

        [HttpPost]
        public ActionResult Cadastrar(Funcionario func)
        {
            try
            {
                var cadastrar = new AdoFuncionario();

                cadastrar.CadastrarFuncionario(func);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                ViewBag.erro = e.Message;
                return View();
            }
            
        }

        public ActionResult Excluir(int codigo)
        {
            var funcionario = new AdoFuncionario().RetornarFuncionario(codigo);
            return View(funcionario);
        }

        [HttpPost]
        public ActionResult Excluir(Funcionario func)
        {

            try
            {
                var excluir = new AdoFuncionario();
                excluir.Excluir(func);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.erro = e.Message;
                return View();
                
            }

       
        }

        public ActionResult TratacaoDeErro()
        {
            return View();
        }

        public ActionResult Relatorio()
        {
            var listarRelatorio = new AdoPonto();
            return View(listarRelatorio.GerarRelatorioPonto());
        }

        [HttpPost]
        public ActionResult Relatorios()
        {

            var relatorio = new List<RelatorioPonto>();

            var relatorioTeste = new Cadastro_Cliente_Ponto.Models.ControlePonto();

            var ado = new AdoPonto();

            ado.GerarRelatorioPonto();

            

           

            GerarRelatorio<RelatorioPonto>(relatorio, "Dados");
          
            
            ado.GerarRelatorioPonto();


            //dados.Add();

            //GerarRelatorio<Cadastro_Cliente_Ponto.Models.RelatorioPonto>(dados, "Dados");
            return View();
        }

        public void GerarRelatorio<T>(List<T> fonteDeDados, string nomeFonteDados)
        {
            using (var relatorio = new Report())
            {
                relatorio.Load(@"C:\Relatorios\RelatorioPonto.frx");
                relatorio.RegisterData(fonteDeDados, nomeFonteDados);
                relatorio.Show();
            }
        }
    }
}