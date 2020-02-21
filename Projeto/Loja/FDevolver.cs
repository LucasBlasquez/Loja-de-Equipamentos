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
    public partial class FDevolvercs : Form
    {
        public FDevolvercs()
        {
            InitializeComponent();
        }

        private void txtCodLocacao_Leave(object sender, EventArgs e)
        {
            Locacao lobj;
            Cliente cobj;
            Item iobj;
            Equipamento eobj;

            try
            {
                // limpa os dados do dgv o qual não possui colunas
                dgvItensLocados.DataSource = null;
                lobj = new Locacao();
                cobj = new Cliente();
                iobj = new Item();
                eobj = new Equipamento();
                
                // se a locação digitada no textbox está ativa
                if (lobj.codLocacaoAtivas(Convert.ToInt32(this.txtCodLocacao.Text)))
                {
                    // preenche os campos com os dados da locação
                    this.txtCodCliente.Text = lobj.codcli.ToString();
                    this.dtpDataLocacao.Value = Convert.ToDateTime(lobj.datalocacao.ToShortDateString());
                    this.dtpDataPrevista.Value = Convert.ToDateTime(lobj.dataprevista.ToShortDateString());
                    this.txtTotal.Text = String.Format("{0:0.00}", lobj.total);

                    // preencher o nome do cliente a partir do codcli da locação
                    if (cobj.nomeCliente(lobj.codcli))
                    {
                        this.txtNomeCliente.Text = cobj.nome;
                    }

                    // preencher o datagridview a partir do DataTable do item que possui o codlocacao do textbox
                    dgvItensLocados.DataSource = iobj.codItemLocacao((Convert.ToInt32(this.txtCodLocacao.Text)));
                }

                // se a locação estiver inativa ou não for encontrada
                else if (!(lobj.codLocacaoAtivas(Convert.ToInt32(this.txtCodLocacao.Text))))
                {
                    MessageBox.Show("Locação inativa ou não encontrada!");
                    this.txtCodLocacao.Clear();
                    this.txtCodCliente.Clear();
                    this.txtNomeCliente.Clear();
                    this.txtTotal.Clear();
                    this.dtpDataLocacao.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    this.dtpDataPrevista.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    this.dtpDataDevolucao.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    this.dgvItensLocados.Rows.Clear();
                    dgvItensLocados.DataSource = null;
                }
                

            }
            catch (Exception ex) { MessageBox.Show("Erro ao preencher: "+ex.Message); }
        }

        public double precoLocacao() // método para calcular o total final da locação a partir de seus dias locados
        {
            // preço de locacao dos equipamentos: diária vezes os dias locados
            // total * diarias

            Locacao lobj = new Locacao();
            TimeSpan diferencaDias;
            double totalPreco;
            int diaslocados;

            diferencaDias = this.dtpDataDevolucao.Value - this.dtpDataLocacao.Value;
            diaslocados = Convert.ToInt32(diferencaDias.Days);

            if (diaslocados > 0) // dias igual a 0 faz com que o total fique igual a 0
            {
                totalPreco = (double)diaslocados * Convert.ToDouble(this.txtTotal.Text);
            }

            else
            {
                totalPreco = Convert.ToDouble(this.txtTotal.Text);
            }

            return (double)totalPreco; // retorna o total
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            // atualizar data devolução e o total
            Locacao lobj;
            Equipamento eobj;

            try
            {
                lobj = new Locacao();
                eobj = new Equipamento();

                lobj.setCodigo(this.txtCodLocacao.Text);
                lobj.setDataDevolucao(this.dtpDataDevolucao.Value);
                lobj.setTotal(precoLocacao());

                lobj.devolucao();

                MessageBox.Show("Devolução realizada com sucesso!" + Environment.NewLine
                        + "Preço total da locação: R$" + precoLocacao().ToString());

                this.txtCodLocacao.Clear();
                this.txtCodCliente.Clear();
                this.txtNomeCliente.Clear();
                this.txtTotal.Clear();
                this.dtpDataLocacao.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                this.dtpDataPrevista.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                this.dtpDataDevolucao.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                this.dgvItensLocados.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao devolver: "+ex.Message);
            }
        }
    }
}
