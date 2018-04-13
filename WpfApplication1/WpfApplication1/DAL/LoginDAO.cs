using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Controller
{
    class LoginDAO    {
        public bool tem = false;
        public string mensagem = ""; //tudo ok
        SqlCommand cmd = new SqlCommand();
        Conexao con = new Conexao();
        SqlDataReader dr;

        public bool VerificarLogin(string login, string senha)
        {
            //comando SQL vai no BD verifica se tem login e a senha e retorna true ou false
            cmd.CommandText = "select * from logins where email = @login and senha = @senha";
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);

            try
            {
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

        public string cadastrar(string nome,string login, string senha, string confSenha)
        {
            tem = false;
            // comandos para inserir 
            if (senha.Equals(confSenha))
            {
                cmd.CommandText = "insert into logins values (@e,@s);";
                cmd.Parameters.AddWithValue("@n", nome);
                cmd.Parameters.AddWithValue("@",login);
                cmd.Parameters.AddWithValue("@s", senha);
                cmd.Parameters.AddWithValue("@c", confSenha);

                try
                {
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
            }
            else
            {
                this.mensagem = "Senhas não correspondem!!";
            }

            return mensagem;
        }
    }
}