namespace Loja
{
    partial class FRelatorio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtRelatorio = new System.Windows.Forms.TextBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnVisualizarImpressao = new System.Windows.Forms.Button();
            this.btnFonte = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.SuspendLayout();
            // 
            // txtRelatorio
            // 
            this.txtRelatorio.Location = new System.Drawing.Point(34, 67);
            this.txtRelatorio.Multiline = true;
            this.txtRelatorio.Name = "txtRelatorio";
            this.txtRelatorio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRelatorio.Size = new System.Drawing.Size(310, 248);
            this.txtRelatorio.TabIndex = 0;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(154, 327);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 1;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnVisualizarImpressao
            // 
            this.btnVisualizarImpressao.Location = new System.Drawing.Point(104, 12);
            this.btnVisualizarImpressao.Name = "btnVisualizarImpressao";
            this.btnVisualizarImpressao.Size = new System.Drawing.Size(75, 39);
            this.btnVisualizarImpressao.TabIndex = 2;
            this.btnVisualizarImpressao.Text = "Visualizar Impressão";
            this.btnVisualizarImpressao.UseVisualStyleBackColor = true;
            this.btnVisualizarImpressao.Click += new System.EventHandler(this.btnVisualizarImpressao_Click);
            // 
            // btnFonte
            // 
            this.btnFonte.Location = new System.Drawing.Point(207, 20);
            this.btnFonte.Name = "btnFonte";
            this.btnFonte.Size = new System.Drawing.Size(75, 23);
            this.btnFonte.TabIndex = 3;
            this.btnFonte.Text = "Fonte";
            this.btnFonte.UseVisualStyleBackColor = true;
            this.btnFonte.Click += new System.EventHandler(this.btnFonte_Click);
            // 
            // FRelatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 362);
            this.Controls.Add(this.btnFonte);
            this.Controls.Add(this.btnVisualizarImpressao);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.txtRelatorio);
            this.Name = "FRelatorio";
            this.Text = "Relatorio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRelatorio;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnVisualizarImpressao;
        private System.Windows.Forms.Button btnFonte;
        private System.Windows.Forms.FontDialog fontDialog1;
    }
}