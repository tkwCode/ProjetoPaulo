namespace VitrinaVirtual
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panImagem = new System.Windows.Forms.Panel();
            this.pctBImagem = new System.Windows.Forms.PictureBox();
            this.panView = new System.Windows.Forms.Panel();
            this.wbBDocumento = new System.Windows.Forms.WebBrowser();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblLetreira = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblHora = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timLetreira = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.sliderArquivos = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panImagem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBImagem)).BeginInit();
            this.panView.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panImagem);
            this.panel1.Controls.Add(this.panView);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(920, 490);
            this.panel1.TabIndex = 0;
            // 
            // panImagem
            // 
            this.panImagem.Controls.Add(this.pctBImagem);
            this.panImagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panImagem.Location = new System.Drawing.Point(655, 42);
            this.panImagem.Name = "panImagem";
            this.panImagem.Size = new System.Drawing.Size(265, 406);
            this.panImagem.TabIndex = 4;
            // 
            // pctBImagem
            // 
            this.pctBImagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctBImagem.Location = new System.Drawing.Point(0, 0);
            this.pctBImagem.Name = "pctBImagem";
            this.pctBImagem.Size = new System.Drawing.Size(265, 406);
            this.pctBImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctBImagem.TabIndex = 0;
            this.pctBImagem.TabStop = false;
            // 
            // panView
            // 
            this.panView.Controls.Add(this.wbBDocumento);
            this.panView.Dock = System.Windows.Forms.DockStyle.Left;
            this.panView.Location = new System.Drawing.Point(0, 42);
            this.panView.Name = "panView";
            this.panView.Size = new System.Drawing.Size(655, 406);
            this.panView.TabIndex = 2;
            // 
            // wbBDocumento
            // 
            this.wbBDocumento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbBDocumento.Location = new System.Drawing.Point(0, 0);
            this.wbBDocumento.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbBDocumento.Name = "wbBDocumento";
            this.wbBDocumento.Size = new System.Drawing.Size(655, 406);
            this.wbBDocumento.TabIndex = 0;
            this.wbBDocumento.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbBDocumento_DocumentCompleted);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblLetreira);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 448);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(920, 42);
            this.panel3.TabIndex = 1;
            // 
            // lblLetreira
            // 
            this.lblLetreira.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLetreira.Font = new System.Drawing.Font("Cooper Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLetreira.ForeColor = System.Drawing.Color.Maroon;
            this.lblLetreira.Location = new System.Drawing.Point(0, 0);
            this.lblLetreira.Name = "lblLetreira";
            this.lblLetreira.Size = new System.Drawing.Size(920, 42);
            this.lblLetreira.TabIndex = 0;
            this.lblLetreira.Text = "label2";
            this.lblLetreira.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLetreira.Paint += new System.Windows.Forms.PaintEventHandler(this.lblLetreira_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblHora);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(920, 42);
            this.panel2.TabIndex = 0;
            // 
            // lblHora
            // 
            this.lblHora.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.ForeColor = System.Drawing.Color.Navy;
            this.lblHora.Location = new System.Drawing.Point(655, 0);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(265, 42);
            this.lblHora.TabIndex = 0;
            this.lblHora.Text = "label2";
            this.lblHora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(655, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "VITRINA VIRTUAL IMPC - DONDO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timLetreira
            // 
            this.timLetreira.Enabled = true;
            this.timLetreira.Interval = 200;
            this.timLetreira.Tick += new System.EventHandler(this.timLetreira_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // sliderArquivos
            // 
            this.sliderArquivos.Enabled = true;
            this.sliderArquivos.Interval = 10000;
            this.sliderArquivos.Tick += new System.EventHandler(this.sliderArquivos_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 490);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vitrina Informativa Virtual";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panImagem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctBImagem)).EndInit();
            this.panView.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panImagem;
        private System.Windows.Forms.PictureBox pctBImagem;
        private System.Windows.Forms.Panel panView;
        private System.Windows.Forms.WebBrowser wbBDocumento;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblLetreira;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timLetreira;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Timer sliderArquivos;
    }
}

