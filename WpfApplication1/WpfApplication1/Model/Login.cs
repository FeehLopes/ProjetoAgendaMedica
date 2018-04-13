using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.Controller;

namespace WpfApplication1.Model
{
    class Login
    {
        public bool tem;
        public String mensagem = "";

        public bool acessar(String login, String senha)
        {
            LoginDAO loginADM = new LoginDAO();
            tem = loginADM.VerificarLogin(login, senha);
            if (!loginADM.mensagem.Equals(""))
            {
                this.mensagem = loginADM.mensagem;
            }
            return tem;
        }

       

        public string cadastrar(String nome, string login,String senha, String confSenha)
        {
            LoginDAO loginADM = new LoginDAO();
            this.mensagem = loginADM.cadastrar(nome, login, senha, confSenha);
            if (loginADM.tem)//mensagem de sucesso
            {
                this.tem = true;
            }
            return mensagem;
        }

        internal string cadastrar(string email, string senha, string confSenha)
        {
            throw new NotImplementedException();
        }
    }
}