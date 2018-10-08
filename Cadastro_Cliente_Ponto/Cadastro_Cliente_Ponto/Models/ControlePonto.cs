using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cadastro_Cliente_Ponto.Models
{
    public class ControlePonto
    {
        public int Codigo { get; set; }
        public int CodFunc { get; set; }
        public Funcionario Funcionario { get; set; }
        public DateTime Data { get; set; }
    }
}