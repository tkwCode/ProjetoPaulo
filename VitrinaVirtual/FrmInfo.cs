using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VitrinaVirtual
{
    public partial class FrmInfo : Form
    {

        ArquivoBLL arquivoBLL;

        public FrmInfo()
        {
            InitializeComponent();
            arquivoBLL = new ArquivoBLL();
        }

        private void btnArquivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            string user = Environment.UserName;
            opf.Filter = "Documento Word (*.docx)|*.docx";
            opf.InitialDirectory = @"C:\" + user + @"\Documents\";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                txtCaminho.Clear();
                txtCaminho.Text = opf.FileName;
            }

        }

        private void btnImagem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            string user = Environment.UserName;
            //opf.Filter = "Imagens (*.png)|*.png;Imagens (*.jpeg)|*.jpeg";
            opf.InitialDirectory = @"C:\" + user + @"\Images\";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                txtCaminhoImagem.Clear();
                txtCaminhoImagem.Text = opf.FileName;
            }
        }

        private void btnProjetar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
            
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            txtCode.Text = arquivoBLL.PegarCodDisponivel().ToString();
            List<SqlParametros> list = new List<SqlParametros>()
            {
                new SqlParametros{Parametro = "@CodArquivo", Valor = int.Parse(txtCode.Text)},
                new SqlParametros{Parametro = "@Caminho", Valor = txtCaminho.Text},
                new SqlParametros{Parametro = "@CaminhoImagem", Valor = txtCaminhoImagem.Text},
                new SqlParametros{Parametro = "@UltimaData", Valor = calendarData.SelectionEnd.Date},
            };

            arquivoBLL.AdicionarArquivo(list);
            txtCode.Text = arquivoBLL.PegarCodDisponivel().ToString();
            txtCaminho.Clear();
            txtCaminhoImagem.Clear();
        }

        private void FrmInfo_Load(object sender, EventArgs e)
        {
            txtCode.Text = arquivoBLL.PegarCodDisponivel().ToString();
        }
    }
}
