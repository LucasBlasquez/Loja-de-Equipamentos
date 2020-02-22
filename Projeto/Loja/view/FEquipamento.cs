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
    public partial class FEquipamento : Form
    {
        public FEquipamento()
        {
            InitializeComponent();
            Equipamento obj = new Equipamento();
            this.dgvEquipamento.DataSource = obj.listar();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Equipamento obj;
            try
            {
                obj = new Equipamento();
                obj.setDescr(this.txtDescricao.Text);
                obj.setPrecodiaria(this.txtPrecoDiaria.Text);
                obj.gravar();

                MessageBox.Show("Equipamento gravado com sucesso!");
                this.dgvEquipamento.DataSource = obj.listar();
                this.txtCodigo.Clear();
                this.txtDescricao.Clear();
                this.txtPrecoDiaria.Clear();
                this.txtDescricao.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex.Message);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            Equipamento obj;
            try
            {
                obj = new Equipamento();
                obj.setCodigo(this.txtCodigo.Text);

                obj.remover();

                MessageBox.Show("Equipamento removido com sucesso!");
                this.dgvEquipamento.DataSource = obj.listar();

                this.txtCodigo.Clear();
                this.txtDescricao.Clear();
                this.txtPrecoDiaria.Clear();
                this.txtCodigo.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao remover: " + ex.Message);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Equipamento obj;
            try
            {
                obj = new Equipamento();
                obj.setCodigo(this.txtCodigo.Text);
                obj.setDescr(this.txtDescricao.Text);
                obj.setPrecodiaria(this.txtPrecoDiaria.Text);

                obj.alterar();

                this.txtCodigo.Clear();
                this.txtDescricao.Clear();
                this.txtPrecoDiaria.Clear();
                MessageBox.Show("Equipamento alterado com sucesso!");
                this.dgvEquipamento.DataSource = obj.listar();
                this.txtCodigo.Focus();
            }
            catch (Exception ex) { MessageBox.Show("Erro ao alterar: " + ex.Message); }
        }

        private void txtConsulta_KeyUp(object sender, KeyEventArgs e)
        {
            Equipamento obj;

            try
            {
                obj = new Equipamento();
                this.dgvEquipamento.DataSource = obj.consultar(this.txtConsulta.Text);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dgvEquipamento_DoubleClick(object sender, EventArgs e)
        {
            int linha;
            linha = this.dgvEquipamento.SelectedRows[0].Index;
            if (linha >= 0)
            {
                this.txtCodigo.Text = this.dgvEquipamento.Rows[linha].Cells[0].Value.ToString();
                this.txtDescricao.Text = this.dgvEquipamento.Rows[linha].Cells[1].Value.ToString();
                this.txtPrecoDiaria.Text = this.dgvEquipamento.Rows[linha].Cells[2].Value.ToString();
                this.dgvEquipamento.Rows.RemoveAt(linha);
            }
        }
    }
}
