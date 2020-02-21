using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Loja
{
    public partial class FGrafico : Form
    {
        public FGrafico()
        {
            InitializeComponent();
            grafico();
        }

        private void grafico()
        {
            Locacao lobj;
            try
            {
                lobj = new Locacao();

                this.chart1.Titles.Clear();
                // adiciona título ao gráfico
                this.chart1.Titles.Add("Locações por dia");
                this.chart1.Series.Clear();
                // adiciona uma série a ele
                this.chart1.Series.Add(new Series());
                // nomeia a primeira série
                this.chart1.Series[0].Name = "Soma das locações";
                // insere o tipo de série (coluna)
                this.chart1.Series[0].ChartType = SeriesChartType.Column;

                // adiciona uma segunda série com índice 1
                this.chart1.Series.Add(new Series());
                this.chart1.Series[1].Name = "Média das locações";
                this.chart1.Series[1].ChartType = SeriesChartType.Column;

                // nomeia os eixos x e y, respectivamente
                chart1.ChartAreas[0].AxisX.Title = "Dias";
                chart1.ChartAreas[0].AxisY.Title = "Valores";

                // se a consulta retornar algum registro
                if (lobj.grafico().Rows != null)
                {
                    // percorrer os registros do DataTable do obj
                    for (int i = 0; i < lobj.grafico().Rows.Count; i++)
                    {
                        // Adicionar pontos referente ao primeiro campo -> sum(total)
                        chart1.Series[0].Points.Add(new DataPoint
                        {
                            YValues = new double[] { Convert.ToDouble(lobj.grafico().Rows[i][0]) },
                        });

                        // Adicionar pontos referentes ao segundo campo -> agv(total)

                        chart1.Series[1].Points.Add(Convert.ToDouble(lobj.grafico().Rows[i][1]));
                    }
                }
            } catch(Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
