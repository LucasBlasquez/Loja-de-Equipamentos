using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja
{
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

    public class Locacao
    {
        public int codigo { get; private set; }
        public double total { get; private set; }
        public DateTime datalocacao { get; private set; }
        public DateTime dataprevista { get; private set; }
        public DateTime datadevolucao { get; private set; }
        public int codcli { get; private set; }

        public Locacao()
        {
            // instanciando os DateTimes
            datalocacao = new DateTime();
            dataprevista = new DateTime();
            datadevolucao = new DateTime();
        }

        public void setCodigo(string c)
        {
            try
            {
                this.codigo = Convert.ToInt32(c);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no codigo locação: "+ex.Message);
            }
        }

        public void setCodigo(int c)
        {
            this.codigo = c;
        }

        public void setTotal(string t)
        {
            try
            {
                this.total = Convert.ToDouble(t);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no total da locação: " + ex.Message);
            }
        }

        public void setTotal(double t)
        {
            this.total = t;
        }

        public void setDatalocacao(string dl)
        {
            try
            {
                this.datalocacao = Convert.ToDateTime(dl);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na data de locação: " + ex.Message);
            }
        }

        public void setDatalocacao(DateTime dl)
        {
            this.datalocacao = dl;
        }

        public void setDataprevista(string dp)
        {
            try
            {
                this.dataprevista = Convert.ToDateTime(dp);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na data prevista: " + ex.Message);
            }
        }

        public void setDataprevista (DateTime dp)
        {
            this.dataprevista = dp;
        }

        public void setDataDevolucao(string dp)
        {
            try
            {
                this.datadevolucao = Convert.ToDateTime(dp);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na data prevista: " + ex.Message);
            }
        }

        public void setDataDevolucao(DateTime dp)
        {
            this.datadevolucao = dp;
        }

        public void setCodCliente(string cc)
        {
            try
            {
                this.codcli = Convert.ToInt32(cc);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void setCodCliente(int cc)
        {
            this.codcli = cc;
        }

        public void gravar()
        {
            Banco bb;
            try
            {
                bb = new Banco();

                // grava normalmente retornando o seu código para ser utilizado no gravar do item
                bb.comando.CommandText = "insert into locacao(total,datalocacao, dataprevista, datadevolucao, codcli) " +
                    "values (@t,@dl,@dp,@dd,@cc) returning codigo";
                bb.comando.Parameters.Add("@t", NpgsqlTypes.NpgsqlDbType.Real).Value = this.total;
                bb.comando.Parameters.Add("@dl", NpgsqlTypes.NpgsqlDbType.Date).Value = this.datalocacao;
                bb.comando.Parameters.Add("@dp", NpgsqlTypes.NpgsqlDbType.Date).Value = this.dataprevista;
                bb.comando.Parameters.Add("@dd", NpgsqlTypes.NpgsqlDbType.Date).Value = this.datadevolucao;
                bb.comando.Parameters.Add("@cc", NpgsqlTypes.NpgsqlDbType.Integer).Value = this.codcli;

                bb.comando.Prepare();
                //executa a consulta e retorna a primeira coluna da primeira linha do conjunto de resultados retornado pela consulta.
                this.codigo = (int)bb.comando.ExecuteScalar(); 
                Banco.conexao.Close();
            }
            catch (Exception ex) { throw new Exception("Erro ao gravar locação: " + ex.Message); }
        }

        public bool codLocacaoAtivas(int cod) // consulta das locações ativas com o código de parâmetro cod
        {
            Banco bb;
            try
            {
                bb = new Banco();
                bb.comando.CommandText = "select codigo,total,datalocacao,dataprevista,codcli " +
                    "from locacao where codigo = @c and (datadevolucao = '0001-01-01')" +
                    "or (datadevolucao is null)";
                bb.comando.Parameters.Add("@c", NpgsqlTypes.NpgsqlDbType.Integer).Value = cod;
                bb.comando.Prepare();
                bb.dreader = bb.comando.ExecuteReader();

                if (bb.dreader.Read())
                {
                    // se a locação estiver ativa, preenche o objeto com suas informações
                    this.codigo = (int)bb.dreader[0];
                    this.total = (double)bb.dreader[1];
                    this.datalocacao = (DateTime)bb.dreader[2];
                    this.dataprevista = (DateTime)bb.dreader[3];
                    this.codcli = (int)bb.dreader[4];
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

        public void devolucao() // atualizar datadevolucao e o total da locação
        {
            Banco bb;
            try
            {
                bb = new Banco();
                bb.comando.CommandText = "update locacao set datadevolucao=@dd, total=@t where codigo=@c";
                bb.comando.Parameters.Add("@c", NpgsqlTypes.NpgsqlDbType.Integer).Value = this.codigo;
                bb.comando.Parameters.Add("@t", NpgsqlTypes.NpgsqlDbType.Integer).Value = this.total;
                bb.comando.Parameters.Add("@dd", NpgsqlTypes.NpgsqlDbType.Date).Value = this.datadevolucao;
                bb.comando.Prepare();
                bb.comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao alterar locação: " + ex.Message);
            }
        }

        public DataTable grafico() 
        {
            // consulta a soma e a média do total de locações agrupadas por dia da datalocacao
            Banco bb;
            try
            {
                bb = new Banco();
                bb.comando.CommandText = "select sum(total),avg(total), datalocacao " +
                    "from locacao group by datalocacao order by datalocacao";

                bb.dreader = bb.comando.ExecuteReader();
                bb.tabela = new DataTable();
                bb.tabela.Load(bb.dreader);
                bb.dreader.Close();

                Banco.conexao.Close();
                return (bb.tabela); // retornam uma tabela
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar soma e médias das locações por dia: " + ex.Message);
            }
        }
    }
}
