using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

using WpfApplication1.DAL;
using WpfApplication1.Model;

namespace WpfApplication1.DAL
{
    class LoginDAO
    {
        private static Context ctx = Singleton.Instance.Context;
        private static List<Login> Logins = new List<Login>();


        public bool tem = false;
        public string mensagem = ""; //tudo ok
        SqlCommand cmd = new SqlCommand();
        Conexao con = new Conexao();
        SqlDataReader dr;

        public bool VerificarLogin(string login, string senha)
        {
            //comando SQL vai no BD verifica se tem login e a senha e retorna true ou false
            cmd.CommandText = "select * from usuarios where loginU = @login and senhaU = @senha";
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);

            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con.conectar();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)//se foi encontrado
                {
                    tem = true;
                }
                con.Desconectar();
                dr.Close();
            }
            catch (SqlException)
            {
                this.mensagem = "Erro com Banco de Dados!";
            }
            return tem;
        }

        public string cadastrar(string nome, string login, string senha, string confSenha)
        {
            tem = false;
            // comandos para inserir 
            if (senha.Equals(confSenha))
            {
                try
                {
                    cmd.CommandText = "insert into Usuarios values (@nome,@login, @senha);";
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@senha", senha);


                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con.conectar();
                    cmd.ExecuteNonQuery();
                    con.Desconectar();
                    this.mensagem = "Cadastrado com Sucesso!!!";
                    tem = true;
                }
                catch (SqlException ex)
                {
                    this.mensagem = "Erro com Banco de Dados (ex: " + ex.Message + ")";
                }
            }
            else
            {
                this.mensagem = "Senhas não correspondem!!";
            }

            return mensagem;
        }
    }
}
