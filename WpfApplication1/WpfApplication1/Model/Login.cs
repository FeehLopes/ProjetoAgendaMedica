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
            LoginController loginADM = new LoginController();
            tem = loginADM.VerificarLogin(login, senha);
            if (!loginADM.mensagem.Equals(""))
            {
                this.mensagem = loginADM.mensagem;
            }
            return tem;
        }

       

        public string cadastrar(String email, String senha, String confSenha)
        {
            Login loginADM = new Login();
            this.mensagem = loginADM.cadastrar(email, senha, confSenha);
            if (loginADM.tem)//mensagem de sucesso
            {
                this.tem = true;
            }
            return mensagem;
        }
    }
}