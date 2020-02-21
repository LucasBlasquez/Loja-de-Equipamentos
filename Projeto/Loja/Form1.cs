using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loja
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FCliente f = new FCliente();
            f.Show();
        }

        private void cadastrarEquipamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FEquipamento f = new FEquipamento();
            f.Show();
        }

        private void devolverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FLocacao f = new FLocacao();
            f.Show();
        }

        private void devolverToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FDevolvercs f = new FDevolvercs();
            f.Show();
        }

        private void relatórioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRelatorio f = new FRelatorio();
            f.Show();
        }

        private void gráficoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FGrafico f = new FGrafico();
            f.Show();
        }
    }
}
