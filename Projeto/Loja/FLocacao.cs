using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
create table locacao( 
codigo serial primary key,
total float,  
datalocacao date, 
dataprevista date, 
datadevolucao date, 
codcli int not null, 
constraint rv01 foreign key(codcli) references cliente(codigo) on update cascade);  
*/


namespace Loja
{
    public partial class FLocacao : Form
    {
        public FLocacao()
        {
            InitializeComponent();
            // adiciona colunas no DataGridView sem acesso ao banco
            this.dgvItens.Columns.Add("codigo", "Código");
            this.dgvItens.Columns.Add("descr", "Descrição");
            this.dgvItens.Columns.Add("precodiaria", "Diária");
        }

        private void txtCodCliente_Leave(object sender, EventArgs e)
        {
            Cliente obj;
            try
            {
                obj = new Cliente();
                // se o código existe na base de dados Cliente -> preenche o campo nome
                if (obj.nomeCliente(Convert.ToInt32(this.txtCodCliente.Text)))
                {
                    this.txtNomeCliente.Text = obj.nome;
                }

                else
                {
                    MessageBox.Show("Cliente não encontrado");
                    this.txtCodCliente.Clear();
                    this.txtCodCliente.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void total() // função para calcular a soma das diárias dos equipamentos selecionados
        {
            double total = 0.0;
            double diaria = 0.0;

            try
            {
                for (int i = 0; i < this.dgvItens.Rows.Count; i++) // percorrer o DataGridView
                {
                    // se nao conseguir converter a diaria para double -> diaria = 0.0;
                    if (!Double.TryParse(this.dgvItens.Rows[i].Cells[2].Value.ToString(), out diaria))
                        diaria = 0.0;

                    // conseguindo converter ou não, a diaria é somada
                    total = total + (diaria);
                }
                this.txtTotal.Text = String.Format("{0:0.00}", total); // formatando o textbox total com duas casas decimais
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            Equipamento obj;

            try
            {
                obj = new Equipamento();

                // se o campo código não estiver vazio
                if (this.txtCodEquip.Text.Trim().Length > 0) 
                {
                   if (!(this.dgvrun())) // se o equipamento não existe no dgv
                   {
                       int i;
                       this.dgvItens.Rows.Add(); // adiciona uma linha
                       i = this.dgvItens.Rows.Count; // retorna número de linhas. Para dgv vazio -> i = 1
                       // índice começa em zero 
                       this.dgvItens.Rows[i - 1].Cells[0].Value = this.txtCodEquip.Text;
                       this.dgvItens.Rows[i - 1].Cells[1].Value = this.txtDescr.Text;
                       this.dgvItens.Rows[i - 1].Cells[2].Value = this.txtPrecoDiaria.Text;
                       total();
                       this.txtCodEquip.Clear();
                       this.txtDescr.Clear();
                       this.txtPrecoDiaria.Clear();
                   }

                   // se o equipamento já existe no dgv
                   else if (this.dgvrun()) 
                   {
                        MessageBox.Show("A locação não aceita equipamentos repetidos");
                        this.txtDescr.Clear();
                        this.txtPrecoDiaria.Clear();
                   }
                }

                // se o campo código equipamento está vazio
                else if(!(this.txtCodEquip.Text.Trim().Length > 0))
                {
                    MessageBox.Show("Campo código do equipamento não preenchido");
                    this.txtCodEquip.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvItens_DoubleClick(object sender, EventArgs e)
        {
            // preenche os campos text através da linha clicada do datagridview
            int linha;
            linha = this.dgvItens.SelectedRows[0].Index;
            if (linha >= 0)
            {
                // preenchimento
                this.txtCodEquip.Text = this.dgvItens.Rows[linha].Cells[0].Value.ToString();
                this.txtDescr.Text = this.dgvItens.Rows[linha].Cells[1].Value.ToString();
                this.txtPrecoDiaria.Text = this.dgvItens.Rows[linha].Cells[2].Value.ToString();
                this.dgvItens.Rows.RemoveAt(linha); // remove o registro da linha selecionada
                total();
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            Locacao lobj;
            Item iobj;
            Equipamento eobj;

            try
            {
                lobj = new Locacao();
                iobj = new Item();
                eobj = new Equipamento();

                // se houver algum equipamento no datagridview
                if (this.dgvItens.Rows != null)
                {
                    // gravar os dados da locação no banco
                    lobj.setCodCliente(this.txtCodCliente.Text);
                    lobj.setTotal(this.txtTotal.Text);
                    lobj.setDatalocacao(this.dtpLocacao.Value.Date);
                    lobj.setDataprevista(this.dtpPrevista.Value.Date);
                    lobj.gravar();

                    for (int i = 0; i < this.dgvItens.Rows.Count; i++) // percorre o dgv
                    {
                        // insere o codigo do equipamento no atributo codequipamento do item a partir do dgv
                        iobj.setCodequipamento(this.dgvItens.Rows[i].Cells[0].Value.ToString());
                        // insere o código da locação no atributo codlocacao a partir do codigo retornado pelo lobj.gravar()
                        // converte em int para evitar erros de restrição no banco
                        iobj.setCodlocacao(Convert.ToInt32(lobj.codigo));
                        // grava os dados do item no banco
                        iobj.gravar();
                    }

                    MessageBox.Show("Locação realizada com sucesso!");

                    this.txtNomeCliente.Clear();
                    this.txtCodCliente.Clear();
                    this.txtCodEquip.Clear();
                    this.txtDescr.Clear();
                    this.txtPrecoDiaria.Clear();
                    this.txtTotal.Clear();
                    this.dtpLocacao.Value = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                    this.dtpPrevista.Value = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                    this.dgvItens.Rows.Clear();
                }

                else // se o dgv estiver vazio
                {
                    MessageBox.Show("Deve haver equipamentos para realizar a locação!");
                    this.txtCodEquip.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao finalizar locação: " + ex.Message);
            }
        }

        public bool dgvrun() // método para conferir se o codequip repete-se no dgv
        {
            int c;
            bool achou = false;
            try
            {
                for (int i = 0; (i < dgvItens.Rows.Count) && (!achou); i++)
                {
                    c = Convert.ToInt32(this.dgvItens.Rows[i].Cells[0].Value);
                    if(Convert.ToInt32(this.txtCodEquip.Text) == c)
                    {
                        achou = true;
                    }
                }
                return (achou);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return (false);
            }
}

        private void txtCodEquip_Leave(object sender, EventArgs e)
        {
            Equipamento obj;
            try
            {
                obj = new Equipamento();

                // se o código digitado existe na tabela equipamento
                if (obj.getCodEquip(Convert.ToInt32(this.txtCodEquip.Text)))
                {
                    // se o equipamento com o codigo do textbox está disponível
                    if (obj.equipamentoDisponivel(Convert.ToInt32(this.txtCodEquip.Text)))
                    {
                        this.txtDescr.Text = obj.descr;
                        this.txtPrecoDiaria.Text = obj.precodiaria.ToString();
                    }

                    else // senão estiver, mostra a mensagem e limpa os campos
                    {
                        MessageBox.Show("Equipamento indisponível!");
                        this.txtCodEquip.Clear();
                        this.txtDescr.Clear();
                        this.txtPrecoDiaria.Clear();
                    }
                }

                else // senão encontrar o código na tabela equipamento
                {
                    MessageBox.Show("Equipamento não encontrado!");
                    this.txtCodEquip.Clear();
                    this.txtDescr.Clear();
                    this.txtPrecoDiaria.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no código do equipamento: " + ex.Message);
            }
        }
    }
}
