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
    public partial class FCliente : Form
    {
        public FCliente()
        {
            InitializeComponent();
            Cliente obj = new Cliente();

            // preencher o dgv com os registros do cliente
            this.dgvCliente.DataSource = obj.listar();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Cliente obj;
            try
            {
                // insere o nome e codigo do cliente nos seus atributos para serem gravados
                obj = new Cliente();
                obj.setNome(this.txtNome.Text);
                obj.setFone(this.txtFone.Text);

                obj.gravar();

                this.txtNome.Clear();
                this.txtFone.Clear();
                MessageBox.Show("Cliente cadastrado com sucesso!");
                this.dgvCliente.DataSource = obj.listar();
                this.txtCodigo.Clear();
                this.txtNome.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar" + ex.Message);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            Cliente obj;
            try
            {
                obj = new Cliente();
                obj.setCodigo(this.txtCodigo.Text);
                // remove o cliente a partir do parâmetro txtCodigo.Text
                obj.remover();

                this.txtCodigo.Clear();
                this.txtNome.Clear();
                this.txtFone.Clear();
                MessageBox.Show("Cliente removido com sucesso!");
                this.dgvCliente.DataSource = obj.listar();
                this.txtCodigo.Focus();
            }
            catch (Exception ex) { MessageBox.Show("Erro ao remover: " + ex.Message); }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Cliente obj;
            try
            {
                obj = new Cliente();
                obj.setCodigo(this.txtCodigo.Text);
                obj.setNome(this.txtNome.Text);
                obj.setFone(this.txtFone.Text);

                // altera os dados do cliente através do código

                obj.alterar();

                this.txtCodigo.Clear();
                this.txtNome.Clear();
                this.txtFone.Clear();
                MessageBox.Show("Cliente alterado com sucesso!");
                this.dgvCliente.DataSource = obj.listar();
                this.txtCodigo.Focus();
            }
            catch (Exception ex) { MessageBox.Show("Erro ao alterar: " + ex.Message); }
        }

        private void txtConsulta_KeyUp(object sender, KeyEventArgs e)
        {
            Cliente obj;

            try
            {
                obj = new Cliente();
                // pesquisa na tabela parte da descrição
                this.dgvCliente.DataSource = obj.consultar(this.txtConsulta.Text);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dgvCliente_DoubleClick(object sender, EventArgs e) // preenche os campos do formulario a partir do dgv
        {
            int linha;
            linha = this.dgvCliente.SelectedRows[0].Index;
            if (linha >= 0)
            {
                this.txtCodigo.Text = this.dgvCliente.Rows[linha].Cells[0].Value.ToString();
                this.txtNome.Text = this.dgvCliente.Rows[linha].Cells[1].Value.ToString();
                this.txtFone.Text = this.dgvCliente.Rows[linha].Cells[2].Value.ToString();
                this.dgvCliente.Rows.RemoveAt(linha);
            }
        }
    }
}
