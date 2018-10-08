using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Cadastro_Cliente_Ponto.Models;


namespace Cadastro_Cliente_Ponto.ADO
{
    public class AdoPonto
    {
        public void Registrar(ControlePonto controlePonto)
        {
            var conection = new Conexao();

            var con = new SqlConnection(conection.RetornarConexao());
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO CONTROL_PONTO(CODFUNC, DATA) VALUES (@CODFUNC, GETDATE())";
            cmd.Parameters.AddWithValue("@CODFUNC", controlePonto.CodFunc);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

         public List<RelatorioPonto> GerarRelatorioPonto()
        {
            var conection = new Conexao();

            var con = new SqlConnection(conection.RetornarConexao());
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT C.CODIGO AS CODIGOPONTO, F.NOME, C.DATA FROM CONTROL_PONTO C INNER JOIN FUNCIONARIO F ON F.CODIGO=C.CODFUNC";
            con.Open();

            List<RelatorioPonto> GerarRelatorio = new List<RelatorioPonto>();
            SqlDataReader leitor = cmd.ExecuteReader();
            while(leitor.Read())
            {
                var relatorio = new RelatorioPonto();
                relatorio.Nome = leitor["NOME"].ToString();
                relatorio.Codigo = Convert.ToInt32(leitor["CODIGOPONTO"]);
                relatorio.Data = Convert.ToDateTime(leitor["DATA"]);
                GerarRelatorio.Add(relatorio);
            }
            leitor.Close();
            con.Close();
            return GerarRelatorio;
        }
    }
}