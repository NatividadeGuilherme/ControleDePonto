using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cadastro_Cliente_Ponto.ADO
{
    public class Conexao
    {
        public string Conection { get; set; }

        public string RetornarConexao()
        {
            this.Conection = @"Data Source=RIFT-DES-06\DEV_DB;Initial Catalog=CONTROLE_PONTO;Integrated Security=True;Pooling=False";
            return Conection;
            
        }
    }
}