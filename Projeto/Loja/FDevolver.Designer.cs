namespace Loja
{
    partial class FDevolvercs
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
            this.dgvItensLocados = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.txtCodLocacao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodCliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.dtpDataLocacao = new System.Windows.Forms.DateTimePicker();
            this.dtpDataPrevista = new System.Windows.Forms.DateTimePicker();
            this.dtpDataDevolucao = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNomeCliente = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensLocados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvItensLocados
            // 
            this.dgvItensLocados.AllowUserToAddRows = false;
            this.dgvItensLocados.AllowUserToDeleteRows = false;
            this.dgvItensLocados.AllowUserToResizeColumns = false;
            this.dgvItensLocados.AllowUserToResizeRows = false;
            this.dgvItensLocados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItensLocados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItensLocados.Location = new System.Drawing.Point(-1, 153);
            this.dgvItensLocados.Name = "dgvItensLocados";
            this.dgvItensLocados.ReadOnly = true;
            this.dgvItensLocados.Size = new System.Drawing.Size(497, 158);
            this.dgvItensLocados.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Código da Locação:";
            // 
            // btnDevolver
            // 
            this.btnDevolver.Location = new System.Drawing.Point(398, 320);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(75, 23);
            this.btnDevolver.TabIndex = 4;
            this.btnDevolver.Text = "Devolver";
            this.btnDevolver.UseVisualStyleBackColor = true;
            this.btnDevolver.Click += new System.EventHandler(this.btnDevolver_Click);
            // 
            // txtCodLocacao
            // 
            this.txtCodLocacao.Location = new System.Drawing.Point(115, 32);
            this.txtCodLocacao.Name = "txtCodLocacao";
            this.txtCodLocacao.Size = new System.Drawing.Size(47, 20);
            this.txtCodLocacao.TabIndex = 5;
            this.txtCodLocacao.Leave += new System.EventHandler(this.txtCodLocacao_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Código do Cliente:";
            // 
            // txtCodCliente
            // 
            this.txtCodCliente.Location = new System.Drawing.Point(115, 58);
            this.txtCodCliente.Name = "txtCodCliente";
            this.txtCodCliente.ReadOnly = true;
            this.txtCodCliente.Size = new System.Drawing.Size(37, 20);
            this.txtCodCliente.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 323);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Total da Diária:";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(100, 320);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(52, 20);
            this.txtTotal.TabIndex = 13;
            // 
            // dtpDataLocacao
            // 
            this.dtpDataLocacao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataLocacao.Location = new System.Drawing.Point(373, 25);
            this.dtpDataLocacao.Name = "dtpDataLocacao";
            this.dtpDataLocacao.Size = new System.Drawing.Size(100, 20);
            this.dtpDataLocacao.TabIndex = 17;
            // 
            // dtpDataPrevista
            // 
            this.dtpDataPrevista.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataPrevista.Location = new System.Drawing.Point(373, 54);
            this.dtpDataPrevista.Name = "dtpDataPrevista";
            this.dtpDataPrevista.Size = new System.Drawing.Size(100, 20);
            this.dtpDataPrevista.TabIndex = 18;
            // 
            // dtpDataDevolucao
            // 
            this.dtpDataDevolucao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataDevolucao.Location = new System.Drawing.Point(373, 86);
            this.dtpDataDevolucao.Name = "dtpDataDevolucao";
            this.dtpDataDevolucao.Size = new System.Drawing.Size(100, 20);
            this.dtpDataDevolucao.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(264, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Data de Locação:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(264, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Data Prevista:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(264, 91);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Data de Devolução:";
            // 
            // txtNomeCliente
            // 
            this.txtNomeCliente.Location = new System.Drawing.Point(115, 84);
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.ReadOnly = true;
            this.txtNomeCliente.Size = new System.Drawing.Size(96, 20);
            this.txtNomeCliente.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Nome do Cliente:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "ITENS LOCADOS:";
            // 
            // FDevolvercs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 354);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNomeCliente);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpDataDevolucao);
            this.Controls.Add(this.dtpDataPrevista);
            this.Controls.Add(this.dtpDataLocacao);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCodCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodLocacao);
            this.Controls.Add(this.btnDevolver);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvItensLocados);
            this.Name = "FDevolvercs";
            this.Text = "Devolução";
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensLocados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvItensLocados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDevolver;
        private System.Windows.Forms.TextBox txtCodLocacao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.DateTimePicker dtpDataLocacao;
        private System.Windows.Forms.DateTimePicker dtpDataPrevista;
        private System.Windows.Forms.DateTimePicker dtpDataDevolucao;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNomeCliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}