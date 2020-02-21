using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja
{

/*
create table equipamento(
codigo serial primary key,
descr varchar(50), 
precodiaria float);  
*/
    public class Equipamento
    {
        public int codigo { get; private set; }
        public string descr { get; private set; }
        public double precodiaria { get; private set; }

        public void setCodigo(string c)
        {
            try
            {
                this.codigo = Convert.ToInt32(c);
            }
            catch (Exception ex)
            { 
                throw new Exception("Erro no codigo equipamento: " + ex.Message);
            }
        }

        public void setCodigo(int c)
        {
            this.codigo = c;
        }

        public void setDescr(string d)
        {
            this.descr = d;
        }

        public void setPrecodiaria(string p)
        {
            try
            {
                this.precodiaria = Convert.ToDouble(p);
            }
            catch (Exception ex)
            { 
                throw new Exception("Erro no preço equipamento: " + ex.Message);
            }
        }

        public void setPrecodiario(double p)
        {
            this.precodiaria = p;
        }

        public void gravar()
        {
            Banco bb;
            try
            {
                bb = new Banco();

                bb.comando.CommandText = "insert into equipamento(descr,precodiaria) values (@d,@p)";
                bb.comando.Parameters.Add("@d", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.descr;
                bb.comando.Parameters.Add("@p", NpgsqlTypes.NpgsqlDbType.Real).Value = this.precodiaria;

                bb.comando.Prepare();
                bb.comando.ExecuteNonQuery();
                Banco.conexao.Close();
            }
            catch (Exception ex) { throw new Exception("Erro ao gravar equipamento: " + ex.Message); }
        }

        public void remover()
        {
            Banco bb;
            try
            {
                bb = new Banco();
                bb.comando.CommandText = "delete from equipamento where codigo = @c";
                bb.comando.Parameters.Add("@c", NpgsqlTypes.NpgsqlDbType.Integer).Value = this.codigo;

                bb.comando.Prepare();
                bb.comando.ExecuteNonQuery();
                Banco.conexao.Close();
            }
            catch (Exception ex) { throw new Exception("Erro ao remover equipamento: " + ex.Message); }

        }

        public void alterar()
        {
            Banco bb;
            try
            {
                bb = new Banco();
                bb.comando.CommandText = "update equipamento set descr=@d, precodiaria=@p where codigo=@c";
                bb.comando.Parameters.Add("@c", NpgsqlTypes.NpgsqlDbType.Integer).Value = this.codigo;
                bb.comando.Parameters.Add("@d", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.descr;
                bb.comando.Parameters.Add("@p", NpgsqlTypes.NpgsqlDbType.Real).Value = this.precodiaria;
                bb.comando.Prepare();
                bb.comando.ExecuteNonQuery();
            }
            catch (Exception ex) { throw new Exception("Erro ao alterar equipamento: " + ex.Message); }
        }

        public DataTable consultar(string parteDescr) // consultar por parte da descrição
        {
            Banco bb;
            try
            {
                bb = new Banco();
                bb.comando.CommandText = "select codigo,descr,precodiaria from equipamento where descr ilike @d";
                bb.comando.Parameters.Add("@d", NpgsqlTypes.NpgsqlDbType.Varchar).Value = "%" + parteDescr + "%";
                bb.comando.Prepare();
                bb.dreader = bb.comando.ExecuteReader();
                bb.tabela = new DataTable();
                bb.tabela.Load(bb.dreader);
                Banco.conexao.Close();
                return (bb.tabela);
            }

            catch (Exception ex)
            {
                throw new Exception("Erro ao listar equipamento: " + ex.Message);
            }
        }

        public DataTable listar() // listar todos os equipamentos
        {
            Banco bb;
            try
            {
                bb = new Banco();
                bb.comando.CommandText = "select codigo, descr, precodiaria from equipamento";
                bb.comando.Prepare();
                bb.dreader = bb.comando.ExecuteReader();
                bb.tabela = new DataTable();
                bb.tabela.Load(bb.dreader);
                Banco.conexao.Close();
                return (bb.tabela);
            }

            catch (Exception ex)
            {
                throw new Exception("Erro ao listar: " + ex.Message);
            }
        }

        public bool equipamentoDisponivel(int cod) // equipamentos que estão locados!
        {
            Banco bb;
            try
            {
                bb = new Banco();
                // seleciona o codigo, a descricao e o preço dos equipamentos onde a data de devolução não é nula, ou seja, que estão locados
                bb.comando.CommandText = "select codigo, descr, precodiaria from equipamento where codigo=@c and codigo not in (select i.codequipamento from item i, locacao l where i.codlocacao = l.codigo and (l.datadevolucao = '0001-01-01') or (l.datadevolucao is null))";
                bb.comando.Parameters.Add("@c", NpgsqlTypes.NpgsqlDbType.Integer).Value = cod;
                bb.comando.Prepare();
                bb.dreader = bb.comando.ExecuteReader();

                if (bb.dreader.Read())
                {
                    this.codigo = (int)bb.dreader[0];
                    this.descr = bb.dreader[1].ToString();
                    this.precodiaria = (double)bb.dreader[2];
                    bb.dreader.Close();
                    Banco.conexao.Close();
                    return (true);
                }
                else
                {
                    bb.dreader.Close();
                    Banco.conexao.Close();
                    return (false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool getCodEquip(int cod) // consulta que mostra o parâmetro cod existente na base
        {
            Banco bb;
            try
            {
                bb = new Banco();
                bb.comando.CommandText = "select codigo,descr,precodiaria from equipamento " +
                "where codigo = @c";
                bb.comando.Parameters.Add("@c", NpgsqlTypes.NpgsqlDbType.Integer).Value = cod;
                bb.comando.Prepare();
                bb.dreader = bb.comando.ExecuteReader();

                if (bb.dreader.Read())
                {
                    // retorna os seus dados
                    this.codigo = (int)bb.dreader[0];
                    this.descr = bb.dreader[1].ToString();
                    this.precodiaria = (double)bb.dreader[2];
                    bb.dreader.Close();
                    Banco.conexao.Close();
                    return (true);
                }
                else
                {
                    bb.dreader.Close();
                    Banco.conexao.Close();
                    return (false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // método que mostrar a descr, datalocacao e dataprevista dos equipamentos locados
        public DataTable equipamentosLocadosComData() 
        {
            Banco bb;
            try
            {
                bb = new Banco();
                bb.comando.CommandText = "select e.descr, l.datalocacao, l.dataprevista " +
                    "from equipamento e, item i, locacao l " +
                    "where e.codigo = i.codequipamento and i.codlocacao = l.codigo and " +
                    "l.codigo in (select codigo from locacao " +
                    "where (datadevolucao = '0001-01-01') or (datadevolucao is null))";

                bb.dreader = bb.comando.ExecuteReader();
                bb.tabela = new DataTable();
                bb.tabela.Load(bb.dreader);
                bb.dreader.Close();

                Banco.conexao.Close();

                return (bb.tabela); // retorna uma tabela com todos os equipamentos locados

            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao consultar equipamentos com data: " + ex.Message);
            }
        }
    }
}
