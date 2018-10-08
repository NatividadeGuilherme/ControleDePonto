using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cadastro_Cliente_Ponto.Models;
using Cadastro_Cliente_Ponto.ADO;

namespace Cadastro_Cliente_Ponto.Controllers
{
    public class PontoController : Controller
    {
        // GET: Ponto
        public ActionResult Index()
        {
            var buscar = new AdoFuncionario();
            return View(buscar.RetornarTodosFuncionarios());
        }
        [HttpPost]
        public ActionResult Index(int funcionarioID)
        {
            var ponto = new AdoPonto();
            ponto.Registrar(new ControlePonto() { CodFunc = funcionarioID });
            return RedirectToAction("Index");
        }
    }
}