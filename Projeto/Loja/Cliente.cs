using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja
{
    /*
    create table cliente ( 
    codigo serial primary key, 
    nome varchar(50) not null, 
    fone varchar(20));  
    */

    public class Cliente
    {
        public int codigo { get; private set; }
        public string nome { get; private set; }
        public string fone { get; private set; }

        // métodos polimórficos

        public void setCodigo (string c)
        {
            try
            {
                this.codigo = Convert.ToInt32(c);
            }
            catch (Exception ex)
            { 
                throw new Exception("Erro no codigo cliente: " + ex.Message);
            }
        }

        public void setCodigo(int c)
        {
            this.codigo = c;
        }

        public void setNome (string n)
        {
            this.nome = n;
        }

        public void setFone(string f)
        {
            this.fone = f;
        }

        public void gravar() // gravar o cliente na base de dados
        {
            Banco bb;
            try
            {
                bb = new Banco();

                bb.comando.CommandText = "insert into cliente(nome,fone) values (@n,@f)";
                bb.comando.Parameters.Add("@n", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.nome;
                bb.comando.Parameters.Add("@f", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.fone;

                bb.comando.Prepare();
                bb.comando.ExecuteNonQuery();
                Banco.conexao.Close();
            }
            catch (Exception ex) { throw new Exception("Erro ao gravar cliente: " + ex.Message); }
        }

        public void remover() // remover o cliente do banco
        {
            Banco bb;
            try
            {
                bb = new Banco();
                bb.comando.CommandText = "delete from cliente where codigo = @c";
                bb.comando.Parameters.Add("@c", NpgsqlTypes.NpgsqlDbType.Integer).Value = this.codigo;

                bb.comando.Prepare();
                bb.comando.ExecuteNonQuery();
                Banco.conexao.Close();
            }
            catch (Exception ex) { throw new Exception("Erro ao remover cliente: " + ex.Message); }

        }

        public void alterar() // altera o registro do cliente
        {
            Banco bb;
            try
            {
                bb = new Banco();
                bb.comando.CommandText = "update cliente set nome=@n, fone=@f where codigo=@c";
                bb.comando.Parameters.Add("@c", NpgsqlTypes.NpgsqlDbType.Integer).Value = this.codigo;
                bb.comando.Parameters.Add("@n", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.nome;
                bb.comando.Parameters.Add("@f", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.fone;
                bb.comando.Prepare();
                bb.comando.ExecuteNonQuery();

            }
            catch (Exception ex) { throw new Exception("Erro ao alterar cliente: " + ex.Message); }
        }

        public DataTable consultar(string parteNome) // consultar para do nome do cliente
        {
            Banco bb;
            try
            {
                bb = new Banco();
                bb.comando.CommandText = "select codigo,nome,fone from cliente where nome ilike @n";
                bb.comando.Parameters.Add("@n", NpgsqlTypes.NpgsqlDbType.Varchar).Value = "%" + parteNome + "%";
                bb.comando.Prepare();
                // executa a consulta e retorna uma tabela(formator postgre)
                bb.dreader = bb.comando.ExecuteReader();
                bb.tabela = new DataTable();
                bb.tabela.Load(bb.dreader);
                Banco.conexao.Close();
                return (bb.tabela);
            }

            catch (Exception ex)
            {
                throw new Exception("Erro ao listar cliente: " + ex.Message);
            }
        }

        public bool nomeCliente(int cod) // preencher o nome do cliente com o codigo recebido
        {
            Banco bb;
            try
            {
                bb = new Banco();
                bb.comando.CommandText = "select codigo,nome from cliente where codigo = @c";
                bb.comando.Parameters.Add("@c", NpgsqlTypes.NpgsqlDbType.Integer).Value = cod;
                bb.comando.Prepare(); // executa o sql
                bb.dreader = bb.comando.ExecuteReader();

                if (bb.dreader.Read())
                {
                    this.codigo = (int)bb.dreader[0];
                    this.nome = bb.dreader[1].ToString(); // retorna o nome
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

        public DataTable listar() // listar os registros do cliente através do DataSource do DataGridView
        {
                Banco bb;
                try
                {
                    bb = new Banco();
                    bb.comando.CommandText = "select codigo,nome,fone from cliente";
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

    }
}
