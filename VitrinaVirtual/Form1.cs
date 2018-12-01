using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;

namespace VitrinaVirtual
{
    public partial class Form1 : Form
    {
        delegate void ConvertDocumentDelegate(string fileName);
        string tempFileName = null;
        private int CurrentPosition { get; set; }
        List<string> defaultNew = new List<string>();
        ArquivoBLL arquivoBLL;
        System.Data.DataTable tabelaArquivos;

        public Form1()
        {
            InitializeComponent();
            arquivoBLL = new ArquivoBLL();
            //lblLetreira.UseCompatibleTextRendering = true;
            lblLetreira.Text = "                        Durante 4 anos de formação, mostramos o que nossos querridos professores nos ensinaram.";
        }


        /// <summary>
        /// Método que carrega as letreiras padrão.
        /// </summary>
        private void CarregarFicheiroDefault()
        {
            string path = System.Windows.Forms.Application.StartupPath + @"\Default.txt";

            StreamReader strReader = new StreamReader(path);
            string temp = strReader.ReadLine();

            while (temp != null)
            {
                defaultNew.Add(temp);
                temp = strReader.ReadLine();
            }
            
            pctBImagem.Image = Properties.Resources.IMG_20181012_084119;

            foreach(string n in defaultNew)
            {
                Thread.Sleep(10000);
                lblLetreira.Text = "";
                lblLetreira.Text = n;
                
            }
        }

        private void timLetreira_Tick(object sender, EventArgs e)
        {
            Animacao.Efeitos.Letreiro(lblLetreira);
        }

        private void lblLetreira_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.TranslateTransform((float)CurrentPosition, 0);
        }

        private void wbBDocumento_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (tempFileName != string.Empty)
            {
                // delete the temp file we created. 
                //File.Delete(tempFileName);

                // set the tempFileName to an empty string. 
                tempFileName = string.Empty;
            }
        }

        public void LoadDocument(string fileName)
        {
            // Call ConvertDocument asynchronously
            ConvertDocumentDelegate del = new ConvertDocumentDelegate(ConvertDocument);

            // Call DocumentConversionComplete when the method has completed. 
            del.BeginInvoke(fileName, DocumentConversionComplete, null);
        }

        void ConvertDocument(string fileName)
        {
            object m = System.Reflection.Missing.Value;
            object oldFileName = (object)fileName;
            object readOnly = false;
            Microsoft.Office.Interop.Word.Application ac = null;
            
            try
            {
                // First, create a new Microsoft.Office.Interop.Word.ApplicationClass.
                ac = new Microsoft.Office.Interop.Word.Application();
                
                // Now we open the document.
                Document doc = ac.Documents.Open(ref oldFileName, ref m, ref readOnly,
                    ref m, ref m, ref m, ref m, ref m, ref m, ref m,
                     ref m, ref m, ref m, ref m, ref m, ref m);

                // Create a temp file to save the HTML file to. 
                tempFileName = GetTempFile("html");

                // Cast these items to object.  The methods we're calling 
                // only take object types in their method parameters. 
                object newFileName = (object)tempFileName;

                // We will be saving this file as HTML format. 
                object fileType = (object)WdSaveFormat.wdFormatHTML;

                // Save the file. 
                doc.SaveAs(ref newFileName, ref fileType,
                    ref m, ref m, ref m, ref m, ref m, ref m, ref m,
                    ref m, ref m, ref m, ref m, ref m, ref m, ref m);

            }
            finally
            {
                // Make sure we close the application class. 
                ac.Quit(ref readOnly, ref m, ref m);
            }
        }

        void DocumentConversionComplete(IAsyncResult result)
        {
            // navigate to our temp file. 
            wbBDocumento.Navigate(tempFileName);
        }

        string GetTempFile(string extension)
        {
            // Uses the Combine, GetTempPath, ChangeExtension, 
            // and GetRandomFile methods of Path to 
            // create a temp file of the extension we're looking for. 
            return Path.Combine(Path.GetTempPath(),
                Path.ChangeExtension(Path.GetRandomFileName(), extension));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AjustarLocalizacaoUI();
            PegarArquivosAVisualizar();
            //LoadDocument(System.Windows.Forms.Application.StartupPath + @"\CAPA DO PROJECTO.docx");
            ApresentarDocumentos();
        }

        private void PegarArquivosAVisualizar()
        {
            List<SqlParametros> list = new List<SqlParametros>() { new SqlParametros { Parametro = "@Hoje", Valor = DateTime.Now.Date } };
            tabelaArquivos = arquivoBLL.PegarArquivosAVisualizar(list);
        }

        int paginas = 0;

        private void ApresentarDocumentos()
        {
            int row = tabelaArquivos.Rows.Count;
            string pathImage;

            if (paginas < row)
            {
                wbBDocumento.Url = null;
                LoadDocument(tabelaArquivos.Rows[paginas][1].ToString());
                pathImage = tabelaArquivos.Rows[paginas][2].ToString();
                if (pathImage != "")
                    pctBImagem.Image = System.Drawing.Image.FromFile(pathImage);
                else
                    pctBImagem.Image = null;
                paginas++;
            }
            else
                paginas = 0;
        }

        private void AjustarLocalizacaoUI()
        {
            
            panView.Location = new System.Drawing.Point((this.Width - (panImagem.Width - 100)),(this.Height - (panel2.Height + panel3.Height)));
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                System.Windows.Forms.Application.Exit();
        }

        private void sliderArquivos_Tick(object sender, EventArgs e)
        {
            ApresentarDocumentos();
        }
    }
}
