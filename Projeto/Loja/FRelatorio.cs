using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loja
{
    public partial class FRelatorio : Form
    {
        private PrintDocument document = new PrintDocument();
        private PrintDialog dialog = new PrintDialog();
        private Font fonte;
        private string texto;

        public FRelatorio()
        {
            InitializeComponent();
            relatorio();

            dialog = new PrintDialog();
            document = new PrintDocument();
            fonte = new Font("Arial", 8, FontStyle.Regular);
            this.txtRelatorio.Font = fonte;
            document.PrintPage += new PrintPageEventHandler(document_PrintPage);
        }

        void document_PrintPage(object sender, PrintPageEventArgs e)
        {
            int caracterPorPagina = 0;
            int linhasPorPagina = 0;

            e.Graphics.MeasureString(texto, fonte, e.MarginBounds.Size, 
                StringFormat.GenericTypographic, out caracterPorPagina, out linhasPorPagina);

            e.Graphics.DrawString(texto, fonte, Brushes.Black,
                e.MarginBounds, StringFormat.GenericTypographic);

            if (caracterPorPagina < texto.Length)
                texto = texto.Substring(caracterPorPagina);
            else
                texto = "";
            e.HasMorePages = (texto.Length > 0);
        }

        public void relatorio()
        {
            Equipamento eobj;
            Item iobj;
            Locacao lobj;

            try
            {
                eobj = new Equipamento();
                iobj = new Item();
                lobj = new Locacao();

                // percorre os equipamentos locados
                for(int i=0; i<eobj.equipamentosLocadosComData().Rows.Count; i++)
                {
                    // preenche o TextBox Multiline com a descrição, data locação e data prevista dos equipamentos locados 
                    // a partir dos registros da tabela retornados pelo método
                    txtRelatorio.Text += "Equipamento: " + eobj.equipamentosLocadosComData().Rows[i][0].ToString() + " | " +
                        "Data Locação: " + Convert.ToDateTime(eobj.equipamentosLocadosComData().Rows[i][1]).ToLongDateString() + " | " +
                        "Data Prevista " + Convert.ToDateTime(eobj.equipamentosLocadosComData().Rows[i][2]).ToLongDateString() +
                        Environment.NewLine + 
                        Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no relatório: "+ex.Message);
            }
        }

        private void btnVisualizarImpressao_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog printDialog = new PrintPreviewDialog();
            texto = this.txtRelatorio.Text;
            printDialog.Document = document;
            printDialog.ShowDialog();
        }

        private void btnFonte_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                fonte = fontDialog1.Font;
                this.txtRelatorio.Font = fontDialog1.Font;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            texto = this.txtRelatorio.Text;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                dialog.Document = document;
                document.Print();
            }
        }
    }
}
