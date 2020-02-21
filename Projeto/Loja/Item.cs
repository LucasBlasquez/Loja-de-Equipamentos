using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja
{
    /*
    create table item ( 
    codigo serial primary key, 
    codequipamento int not null, 
    codlocacao int not null, 
    constraint ri01 foreign key(codequipamento) references equipamento(codigo) on update cascade, 
    constraint ri02 foreign key(codlocacao) references locacao(codigo) on update cascade); 
    */

    public class Item
    {
        public int codigo { get; private set; }
        public int codequipamento { get; private set; }
        public int codlocacao { get; private set; }

        public void setCodigo(string c)
        {
            try
            {
                this.codigo = Convert.ToInt32(c);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no código do item: " + ex.Message);
            }
        }

        public void setCodigo(int c)
        {
            this.codigo = c;
        }

        public void setCodequipamento(string ce)
        {
            try
            {
                this.codequipamento = Convert.ToInt32(ce);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no código do equipamento do item: " + ex.Message);
            }
        }

        public void setCodequipamento(int ce)
        {
            this.codequipamento = ce;
        }

        public void setCodlocacao(string cl)
        {
            try
            {
                this.codequipamento = Convert.ToInt32(cl);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no código da locação item: " + ex.Message);
            }
        }

        public void setCodlocacao(int cl)
        {
            this.codlocacao = cl;
        }

        public void gravar()
        {
            Banco bb;
            try
            {
                bb = new Banco();

                bb.comando.CommandText = "insert into item(codequipamento, codlocacao) values (@ce,@cl)";
                bb.comando.Parameters.Add("@ce", NpgsqlTypes.NpgsqlDbType.Integer).Value = this.codequipamento;
                bb.comando.Parameters.Add("@cl", NpgsqlTypes.NpgsqlDbType.Integer).Value = this.codlocacao;

                bb.comando.Prepare();
                bb.comando.ExecuteNonQuery();
                Banco.conexao.Close();
            }
            catch (Exception ex) { throw new Exception("Erro ao gravar item: " + ex.Message); }
        }

        public DataTable codItemLocacao(int cod) // retorna um DataTable para ser preencher o DataGridView do Form Devolver
        {
            Banco bb;
            try
            {
                bb = new Banco();
                bb.comando.CommandText = "select codigo,codequipamento,codlocacao from item where codlocacao = @cl";
                bb.comando.Parameters.Add("@cl", NpgsqlTypes.NpgsqlDbType.Integer).Value = cod;

                bb.dreader = bb.comando.ExecuteReader();

                bb.tabela = new DataTable();
                bb.tabela.Load(bb.dreader);
                bb.dreader.Close();

                Banco.conexao.Close();

                return (bb.tabela);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar item: "+ex.Message);
            }
        }
    }
}
