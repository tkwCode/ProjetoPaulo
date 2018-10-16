using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

        public Form1()
        {
            InitializeComponent();
            
            //lblLetreira.UseCompatibleTextRendering = true;
            lblLetreira.Text = "Durante 4 anos de formação, mostramos o que nossos querridos professores nos ensinaram.";
            pctBImagem.Image = Properties.Resources.IMG_20181012_084119;
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

            //CarregarFicheiroDefault();
            //if (CurrentPosition > Width)
            //    CurrentPosition = -Width;
            //else
            //    CurrentPosition += 2;

            //Invalidate();

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
                File.Delete(tempFileName);

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
                if (ac != null)
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
            LoadDocument(System.Windows.Forms.Application.StartupPath + @"\Capa.docx");
            //CarregarFicheiroDefault();
        }
    }
}
