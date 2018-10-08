using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Cadastro_Cliente_Ponto.Models;

namespace Cadastro_Cliente_Ponto.ADO
{
    public class AdoFuncionario
    {
        public void CadastrarFuncionario(Funcionario funcionario)
        {
           
            var conection = new Conexao();

            var con = new SqlConnection(conection.RetornarConexao());
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO FUNCIONARIO(NOME,ENDERECO,CPF,DATA_DE_NASCIMENTO)" +
                " VALUES(@Nome,@Endereco,@CPF,@DATA_DE_NASCIMENTO)";

            cmd.Parameters.AddWithValue("@Nome",funcionario.Nome);
            cmd.Parameters.AddWithValue("@Endereco", funcionario.Endereco);
            cmd.Parameters.AddWithValue("@CPF", funcionario.Cpf);
            cmd.Parameters.AddWithValue("@DATA_DE_NASCIMENTO", funcionario.Data_De_Nascimento);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public List<Funcionario> RetornarTodosFuncionarios() 
        {
            var conection = new Conexao();

            var con = new SqlConnection(conection.RetornarConexao());
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM FUNCIONARIO";
            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            
            List<Funcionario> listaFuncionario = new List<Funcionario>();
            while (reader.Read())
            {
                var func = new Funcionario();
                func.Codigo = Convert.ToInt32(reader["CODIGO"]);
                func.Nome = reader["NOME"].ToString();
                func.Endereco = reader["ENDERECO"].ToString();
                func.Cpf = reader["CPF"].ToString();
                func.Data_De_Nascimento = Convert.ToDateTime(reader["DATA_DE_NASCIMENTO"]);
                listaFuncionario.Add(func);
            }
            reader.Close();
            con.Close();
            return listaFuncionario;
        }

        public void AlterarFuncionario(Funcionario funcionario)
        {
            var conection = new Conexao();

            var con = new SqlConnection(conection.RetornarConexao());
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE FUNCIONARIO SET NOME=@NOME, ENDERECO=@ENDERECO, CPF=@CPF, " +
                "DATA_DE_NASCIMENTO=@DATA_DE_NASCIMENTO WHERE CODIGO=@CODIGO";
            cmd.Parameters.AddWithValue("@NOME", funcionario.Nome);
            cmd.Parameters.AddWithValue("@CODIGO", funcionario.Codigo);
            cmd.Parameters.AddWithValue("@ENDERECO", funcionario.Endereco);
            cmd.Parameters.AddWithValue("@CPF", funcionario.Cpf);
            cmd.Parameters.AddWithValue("@DATA_DE_NASCIMENTO", funcionario.Data_De_Nascimento);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Excluir(Funcionario funcionario)
        {
            var conection = new Conexao();

            var con = new SqlConnection(conection.RetornarConexao());
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "DELETE FROM FUNCIONARIO WHERE CODIGO=@CODIGO";
            cmd.Parameters.AddWithValue("@CODIGO", funcionario.Codigo);
            con.Open();
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public Funcionario RetornarFuncionario(int codigo)
        {
            Funcionario func = null;
            var conection = new Conexao();

            var con = new SqlConnection(conection.RetornarConexao());
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM FUNCIONARIO WHERE CODIGO=@CODIGO";
            cmd.Parameters.AddWithValue("@CODIGO", codigo);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                func = new Funcionario();
                func.Codigo = Convert.ToInt32(reader["CODIGO"]);
                func.Nome = reader["NOME"].ToString();
                func.Endereco = reader["ENDERECO"].ToString();
                func.Cpf = reader["CPF"].ToString();
                func.Data_De_Nascimento = Convert.ToDateTime(reader["DATA_DE_NASCIMENTO"]);
            }
            reader.Close();
            con.Close();
            return func;
        }
    }
}