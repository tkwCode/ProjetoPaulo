using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace VitrinaVirtual
{
    public class ArquivoBLL
    {

        SqlDataAccess sqlManagement;

        /// <summary>
        /// Construtor padrão da classe.
        /// </summary>
        public ArquivoBLL()
        {

        }

        /// <summary>
        /// /Método de inserção de dados.
        /// </summary>
        /// <param name="configInicial">Classe ConfigInicial a inserrir novo registro.</param>
        public void AdicionarArquivo(List<SqlParametros> param)
        {
            string query = "";
            query += "INSERT INTO Arquivos(CodArquivo,Caminho,CaminhoImagem,UltimaData)";
            query += " VALUES (@CodArquivo, @Caminho, @CaminhoImagem, @UltimaData)";

            using (sqlManagement = new SqlDataAccess())
            {
                sqlManagement.ExecutarComando(query, param);
                MessageBox.Show("Dados inseridos com sucesso!");
            }
        }

        /// <summary>
        /// /Método de inserção de dados.
        /// </summary>
        /// <param name="configInicial">Classe ConfigInicial a inserrir novo registro.</param>
        public void AtualizarDataArquivo(List<SqlParametros> param)
        {
            string query = "";
            query += "UPDATE Arquivos SET UltimaData=@UltimaData WHERE Caminho=@Caminho";

            using (sqlManagement = new SqlDataAccess())
            {
                sqlManagement.ExecutarComando(query, param);
                MessageBox.Show("Dados inseridos com sucesso!");
            }
        }

        /// <summary>
        /// /Método de inserção de dados.
        /// </summary>
        /// <param name="configInicial">Classe ConfigInicial a inserrir novo registro.</param>
        public void AtualizarImagemrquivo(List<SqlParametros> param)
        {
            string query = "";
            query += "UPDATE Arquivos SET CaminhoImagem=@CaminhoImagem WHERE Caminho=@Caminho";

            using (sqlManagement = new SqlDataAccess())
            {
                sqlManagement.ExecutarComando(query, param);
                MessageBox.Show("Dados inseridos com sucesso!");
            }
        }

        /// <summary>
        /// Método que retorna os periodos que uma escola tem.
        /// </summary>
        /// <returns>Retorna uma lista com periodos.</returns>
        public DataTable PegarArquivosAVisualizar(List<SqlParametros> param)
        {
            DataTable dt = new DataTable();

            string query = "";
            query = "SELECT *FROM Arquivos WHERE UltimaData >= @Hoje";

            using (sqlManagement = new SqlDataAccess())
            {
                dt = sqlManagement.ExecutarComandoAdapter(query,param);
            }

            return dt;
        }

        /// <summary>
        /// Método que devolve ao usuário o código disponível para o novo cadastro.
        /// </summary>
        /// <returns>O novo código a usar.</returns>
        public int PegarCodDisponivel()
        {
            int idFree;
            try
            {

                string query = "SELECT MAX(CodArquivo) FROM Arquivos";

                using (sqlManagement = new SqlDataAccess())
                {
                    int.TryParse(sqlManagement.ExecutarComandoEscalar(query), out idFree);
                    idFree = (idFree > 0) ? (idFree + 1) : (idFree = 1);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return 0;
            }

            return idFree;
        }
    }
}
