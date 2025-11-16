using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LumixEnterprises.Services
{
    internal class DataBaseServices
    {
        private SqlConnection GetConnection()
        {
            //Variavel q ira armazenar a conexão
            SqlConnection connection = new SqlConnection();

            string nomeComputador = System.Environment.MachineName;

            connection.ConnectionString =
            "Data Source=.\\SQLEXPRESS;" +
            "Initial Catalog=LumixDBO;" +
            "Integrated Security=SSPI;";

            //Método para abrir a conexão
            connection.Open();

            //Retornando a conexão aberta
            return connection;
        }

        //Método pulico que executa comandos
        //INSERT, UPDATE e DELETE
        public int ExecuteSQL(SqlCommand command)
        {
            command.Connection = GetConnection();
            //command.CommandType = System.Data.CommandType.Text;
            return command.ExecuteNonQuery();
        }

        //Método publico que executa comando SELECT no banco de dados
        public object ExecuteScalar(SqlCommand command)
        {
            command.Connection = GetConnection();
            return command.ExecuteScalar();
        }

        //Método publico que executa comando SQL 
        public DataTable GetDataTable(SqlCommand command)
        {
            // Criando o objeto DataTable
            DataTable dataTable = new DataTable();

            // Definindo a conexão do comando SQL
            command.Connection = GetConnection();
            // Criando o objeto SqlDataAdapter e vinculando o comando
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);

            // Preenchendo o DataTable com os dados do banco
            sqlDataAdapter.Fill(dataTable);

            // Retornando o DataTable preenchido
            return dataTable;
        }
    }
}
