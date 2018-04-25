using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApplication1.Model;

namespace WpfApplication1.DAL
{
    class ClienteDAO
    {
        private static Context ctx = Singleton.Instance.Context;
        private static List<Cliente> clientes = new List<Cliente>();

        public bool tem = false;
        public string mensagem = ""; //tudo ok
        SqlCommand cmd = new SqlCommand();
        Conexao con = new Conexao();
        SqlDataReader dr;

        public static bool AdicionarCliente(Cliente cliente)
        {
            try
            {
                ctx.Clientes.Add(cliente);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                //Console.WriteLine(e);
                return false;
            }
        }

        public static bool RemoverCliente(Cliente cliente)
        {
            try
            {
                ctx.Clientes.Remove(cliente);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        //public static bool AlterarCliente(Cliente c)
        //{
        //    try
        //    {
        //        ctx.Entry(c).State = System.Data.Entity.EntityState.Modified;
        //        ctx.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.ToString());
        //        return false;
        //    }
        //}

        //public static Cliente ProcurarClientePorCPF(string cpf)
        //{

        //    //return ctx.Clientes.FirstOrDefault(x => x.CPF.Equals(cliente.CPF));
        //    Context ctx = new Context();

        //    var c = from x in ctx.Clientes
        //            where x.CPF.ToLower().Contains(cpf.Trim().ToLower())
        //            select x;

        //    if (c != null)
        //        return c.FirstOrDefault();
        //    else
        //        return null;

        //}

        public static List<Cliente> RetornarLista()
        {
            return ctx.Clientes.ToList();
        }

        //public static Cliente ProcurarClientePorID(Cliente cliente)
        //{
        //    return ctx.Clientes.FirstOrDefault(x => x.ClienteId.Equals(cliente.ClienteId));
        //}

        public bool Cadastrar(Cliente cliente)
        {
            tem = false;
            // comandos para inserir 
            cmd.CommandText = @"insert into clientes values (@nome,@CPF, @endereco, @numero,@complemento,
                                                    @telefone,@celular,@nomePet,@raca,@idade,@data,@sexo);";
            cmd.Parameters.AddWithValue("@nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@CPF", cliente.CPF);
            cmd.Parameters.AddWithValue("@endereco", cliente.Endereco);
            cmd.Parameters.AddWithValue("@numero", cliente.Numero);
            cmd.Parameters.AddWithValue("@complemento", cliente.Complemento);
            cmd.Parameters.AddWithValue("@telefone", cliente.Telefone);
            cmd.Parameters.AddWithValue("@celular", cliente.Celular);
            cmd.Parameters.AddWithValue("@nomePet", cliente.NomePet);
            cmd.Parameters.AddWithValue("@raca", cliente.Raca);
            cmd.Parameters.AddWithValue("@idade", cliente.Idade);
            cmd.Parameters.AddWithValue("@data", cliente.Data);
            cmd.Parameters.AddWithValue("@sexo", cliente.Sexo);

            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con.conectar();
                cmd.ExecuteNonQuery();
                con.Desconectar();
                this.mensagem = "Cadastrado com Sucesso!!!";
                tem = true;
            }
            catch (SqlException)
            {
                this.mensagem = "Erro com Banco de Dados";
            }

            return tem;
        }

        public List<Cliente> ListaNova()
        {
            List<Cliente> cliente = new List<Cliente>();
            tem = false;
            // comando para mostrar os dados da tabela 
            cmd.CommandText = @"Select * From Clientes";

            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con.conectar();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                { // pega todos os item da tabela
                    var ListaCli = new Cliente();
                    ListaCli.Celular = reader["Celular"].ToString();
                    ListaCli.Idade = reader["Idade"].ToString();
                    ListaCli.Nome = reader["Nome"].ToString();
                    ListaCli.CPF = reader["CPF"].ToString();
                    ListaCli.Endereco = reader["Endereco"].ToString();
                    ListaCli.Numero = reader["Numero"].ToString();
                    ListaCli.Complemento = reader["Complemento"].ToString();
                    ListaCli.Telefone = reader["Telefone"].ToString();
                    ListaCli.NomePet = reader["NomePet"].ToString();
                    ListaCli.Raca = reader["Raca"].ToString();
                    ListaCli.Sexo = reader["Sexo"].ToString();
                    ListaCli.Data = reader["Data"].ToString();

                    cliente.Add(ListaCli);

                }

                //cmd.ExecuteNonQuery();
                con.Desconectar();
                //this.mensagem = "Cadastrado com Sucesso!!!";
                //tem = true;
            }
            catch (SqlException)
            {
                this.mensagem = "Erro com Banco de Dados";
            }

            return cliente;
        }

        public Cliente SelectPorNomeCPF(String nome, String CPF)
        {   // esses campos devem ficar diferente de usuarios usuarios
            Cliente cliente = new Cliente();
            tem = false;
            // comando para mostrar os dados da tabela 
            cmd.CommandText = @"Select top 1 * From Clientes where nome = '" + nome + "' and CPF = '" + CPF + "'";

            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con.conectar();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                { // pega todos os item da tabela
                    cliente.ClienteId = Convert.ToInt32(reader["ClienteId"]);
                    cliente.Celular = reader["Celular"].ToString();
                    cliente.Idade = reader["Idade"].ToString();
                    cliente.Nome = reader["Nome"].ToString();
                    cliente.CPF = reader["CPF"].ToString();
                    cliente.Endereco = reader["Endereco"].ToString();
                    cliente.Numero = reader["Numero"].ToString();
                    cliente.Complemento = reader["Complemento"].ToString();
                    cliente.Telefone = reader["Telefone"].ToString();
                    cliente.NomePet = reader["NomePet"].ToString();
                    cliente.Raca = reader["Raca"].ToString();
                    cliente.Sexo = reader["Sexo"].ToString();
                    cliente.Data = reader["Data"].ToString();
                }

                //cmd.ExecuteNonQuery();
                con.Desconectar();
                //this.mensagem = "Cadastrado com Sucesso!!!";
                //tem = true;
            }
            catch (SqlException)
            {
                this.mensagem = "Erro com Banco de Dados";
            }

            return cliente;
        } // esse select foi criado para edital o cliente

        public bool Alterar(Cliente cliente)
        {
            tem = false;
            // comandos para inserir 
            cmd.CommandText = @"update clientes set nome = @nome, CPF = @CPF, endereco = @endereco, numero = @numero, complemento = @complemento,
                                                    telefone = @telefone, celular = @celular, NomePet = @nomePet, raca = @raca, idade = @idade,
                                                    data = @data, sexo = @sexo where ClienteId = @ClienteID";
            cmd.Parameters.AddWithValue("@nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@CPF", cliente.CPF);
            cmd.Parameters.AddWithValue("@endereco", cliente.Endereco);
            cmd.Parameters.AddWithValue("@numero", cliente.Numero);
            cmd.Parameters.AddWithValue("@complemento", cliente.Complemento);
            cmd.Parameters.AddWithValue("@telefone", cliente.Telefone);
            cmd.Parameters.AddWithValue("@celular", cliente.Celular);
            cmd.Parameters.AddWithValue("@nomePet", cliente.NomePet);
            cmd.Parameters.AddWithValue("@raca", cliente.Raca);
            cmd.Parameters.AddWithValue("@idade", cliente.Idade);
            cmd.Parameters.AddWithValue("@data", cliente.Data);
            cmd.Parameters.AddWithValue("@sexo", cliente.Sexo);

            cmd.Parameters.AddWithValue("@ClienteID", cliente.ClienteId);

            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con.conectar();
                cmd.ExecuteNonQuery();
                con.Desconectar();
                tem = true;
            }
            catch (SqlException)
            {
                this.mensagem = "Erro com Banco de Dados";
            }

            return tem;
        }

        public bool Excluir(Cliente cliente)
        {
            tem = false;
            // comandos para inserir 
            cmd.CommandText = @"delete from clientes where ClienteId = @ClienteID";
            cmd.Parameters.AddWithValue("@ClienteID", cliente.ClienteId);

            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con.conectar();
                cmd.ExecuteNonQuery();
                con.Desconectar();
                tem = true;
            }
            catch (SqlException)
            {
                this.mensagem = "Erro com Banco de Dados";
            }

            return tem;
        }

        public bool Pesquisar(Cliente cliente)
        {
            tem = false;
            // comandos para inserir 
            cmd.CommandText = @"SELECT * FROM CLIENTE = @nome, CPF = @CPF, endereco = @endereco, numero = @numero, complemento = @complemento,
                                                    telefone = @telefone, celular = @celular, NomePet = @nomePet, raca = @raca, idade = @idade,
                                                    data = @data, sexo = @sexo where ClienteId = @ClienteID";
            cmd.Parameters.AddWithValue("@nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@CPF", cliente.CPF);
            cmd.Parameters.AddWithValue("@endereco", cliente.Endereco);
            cmd.Parameters.AddWithValue("@numero", cliente.Numero);
            cmd.Parameters.AddWithValue("@complemento", cliente.Complemento);
            cmd.Parameters.AddWithValue("@telefone", cliente.Telefone);
            cmd.Parameters.AddWithValue("@celular", cliente.Celular);
            cmd.Parameters.AddWithValue("@nomePet", cliente.NomePet);
            cmd.Parameters.AddWithValue("@raca", cliente.Raca);
            cmd.Parameters.AddWithValue("@idade", cliente.Idade);
            cmd.Parameters.AddWithValue("@data", cliente.Data);
            cmd.Parameters.AddWithValue("@sexo", cliente.Sexo);

            cmd.Parameters.AddWithValue("@ClienteID", cliente.ClienteId);

            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con.conectar();
                cmd.ExecuteNonQuery();
                con.Desconectar();
                tem = true;
            }
            catch (SqlException)
            {
                this.mensagem = "Erro com Banco de Dados";
            }

            return tem;
        }

        public Cliente PesquisarNomeOuCPF(String nomeOuCPF)
        {
            Cliente cliente = new Cliente();
            tem = false;
            // comando para mostrar os dados da tabela 
            cmd.CommandText = @"Select top 1 * From Clientes where nome = '" + nomeOuCPF + "' or CPF = '" + nomeOuCPF + "'";

            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con.conectar();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                { // pega todos os item da tabela
                    cliente.ClienteId = Convert.ToInt32(reader["ClienteId"]);
                    cliente.Celular = reader["Celular"].ToString();
                    cliente.Idade = reader["Idade"].ToString();
                    cliente.Nome = reader["Nome"].ToString();
                    cliente.CPF = reader["CPF"].ToString();
                    cliente.Endereco = reader["Endereco"].ToString();
                    cliente.Numero = reader["Numero"].ToString();
                    cliente.Complemento = reader["Complemento"].ToString();
                    cliente.Telefone = reader["Telefone"].ToString();
                    cliente.NomePet = reader["NomePet"].ToString();
                    cliente.Raca = reader["Raca"].ToString();
                    cliente.Sexo = reader["Sexo"].ToString();
                    cliente.Data = reader["Data"].ToString();
                }
                con.Desconectar();
            }
            catch (SqlException)
            {
                this.mensagem = "Erro com Banco de Dados";
            }

            return cliente;
        }

        public Cliente PesquisarPorID(Int32 Id)
        {
            Cliente cliente = new Cliente();
            tem = false;
            // comando para mostrar os dados da tabela 
            cmd.CommandText = @"Select * From Clientes where ClienteId = " + Id;

            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con.conectar();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                { // pega todos os item da tabela
                    cliente.ClienteId = Convert.ToInt32(reader["ClienteId"]);
                    cliente.Celular = reader["Celular"].ToString();
                    cliente.Idade = reader["Idade"].ToString();
                    cliente.Nome = reader["Nome"].ToString();
                    cliente.CPF = reader["CPF"].ToString();
                    cliente.Endereco = reader["Endereco"].ToString();
                    cliente.Numero = reader["Numero"].ToString();
                    cliente.Complemento = reader["Complemento"].ToString();
                    cliente.Telefone = reader["Telefone"].ToString();
                    cliente.NomePet = reader["NomePet"].ToString();
                    cliente.Raca = reader["Raca"].ToString();
                    cliente.Sexo = reader["Sexo"].ToString();
                    cliente.Data = reader["Data"].ToString();
                }
                con.Desconectar();
            }
            catch (SqlException)
            {
                this.mensagem = "Erro com Banco de Dados";
            }

            return cliente;
        }

        public List<Cliente> SelectAll()
        {
            List<Cliente> lstCliente = new List<Cliente>();
            tem = false;
            // comando para mostrar os dados da tabela 
            cmd.CommandText = @"Select  * From Clientes";

            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con.conectar();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                { // pega todos os item da tabela
                    var cliente = new Cliente();
                    cliente.ClienteId = Convert.ToInt32(reader["ClienteId"]);
                    cliente.Nome = reader["Nome"].ToString();

                    lstCliente.Add(cliente);
                }
                con.Desconectar();
            }
            catch (SqlException)
            {
                this.mensagem = "Erro com Banco de Dados";
            }

            return lstCliente;
        }
    }
}