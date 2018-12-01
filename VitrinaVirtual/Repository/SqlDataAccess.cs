using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlServerCe;
using System.Windows.Forms;

namespace VitrinaVirtual
{
    public class SqlDataAccess : IDisposable
    {
        private readonly SqlCeConnection conexaoSql;

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public SqlDataAccess()
        {
            try
            {
                string pathApp = Application.StartupPath;
                //var conexao = @"Data Source=c:\DbSino.sdf";
                var conexao = "Data Source=" + pathApp + @"\BdArquivo.sdf";
                conexaoSql = new SqlCeConnection(conexao);
                conexaoSql.Open();
            }
            catch (ConfigurationErrorsException ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Este método é usado para  executar commandos do sql como : Insert,Update e Delete.
        /// </summary>
        /// <param name="sqlQuery">O comando sql a ser executado.</param>
        public void ExecutarComando(string sqlQuery, List<SqlParametros> parametros = null)
        {
            SqlCeCommand comando = new SqlCeCommand
            {
                CommandText = sqlQuery,
                CommandType = CommandType.Text,
                Connection = conexaoSql
            };

            comando.Parameters.Clear();

            if (parametros != null)
            {
                foreach (SqlParametros p in parametros)
                    comando.Parameters.AddWithValue(p.Parametro, p.Valor);
            }
            comando.ExecuteNonQuery();
        }

        /// <summary>
        /// Este método é usado para  executar commandos sql de letura de dados como : Select.
        /// </summary>
        /// <param name="sqlQuery">O comando sql a ser executado.</param>
        /// <returns>Retorna uma DataReader.</returns>
        public SqlCeDataReader ExecutarComandoReader(string sqlQuery, List<SqlParametros> parametros = null)
        {
            SqlCeCommand comando = new SqlCeCommand
            {
                CommandText = sqlQuery,
                CommandType = CommandType.Text,
                Connection = conexaoSql
            };

            comando.Parameters.Clear();

            if (parametros != null)
            {
                foreach (SqlParametros p in parametros)
                    comando.Parameters.AddWithValue(p.Parametro, p.Valor);
            }

            return comando.ExecuteReader();
        }

        /// <summary>
        /// Este método é usado para  executar commandos sql que retorna apenas um valor como : Select.
        /// </summary>
        /// <param name="sqlQuery">O comando sql a ser executado.</param>
        /// <returns>Retorna um valor de tipo string.</returns>
        public string ExecutarComandoEscalar(string sqlQuery, List<SqlParametros> parametros = null)
        {
            SqlCeCommand comando = new SqlCeCommand
            {
                CommandText = sqlQuery,
                CommandType = CommandType.Text,
                Connection = conexaoSql
            };

            comando.Parameters.Clear();

            if (parametros != null)
            {
                foreach (SqlParametros p in parametros)
                    comando.Parameters.AddWithValue(p.Parametro, p.Valor);
            }

            var valor = comando.ExecuteScalar();

            return valor.ToString();
        }

        /// <summary>
        /// Este método é usado para  executar commandos sql que retorna uma DataTable como : Select, select...Inner join.
        /// </summary>
        /// <param name="sqlQuery">O comando sql a ser executado.</param>
        /// <returns>Retorna uma DataTable.</returns>
        public DataTable ExecutarComandoAdapter(string sqlQuery, List<SqlParametros> parametros = null)
        {
            var comando = new SqlCeCommand(sqlQuery, conexaoSql);
            var adaptador = new SqlCeDataAdapter(comando);
            var dados = new DataTable();

            adaptador.SelectCommand.Parameters.Clear();

            if (parametros != null)
            {
                foreach (SqlParametros p in parametros)
                    adaptador.SelectCommand.Parameters.AddWithValue(p.Parametro, p.Valor);
            }

            adaptador.Fill(dados);

            return dados;
        }

        /// <summary>
        /// Metodo que finaliza a conexão depois de fechar a classe.
        /// </summary>
        public void Dispose()
        {
            if (conexaoSql.State == ConnectionState.Open)
                conexaoSql.Close();
        }
    }
}
