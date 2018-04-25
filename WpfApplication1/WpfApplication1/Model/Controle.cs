using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.DAL;

namespace WpfApplication1.Model
{
    class Controle
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

        public string cadastrar(String nome, String login, String senha, String confSenha)
        {
            LoginDAO loginADM = new LoginDAO();
            this.mensagem = loginADM.cadastrar(nome, login, senha, confSenha);
            if (loginADM.tem)//mensagem de sucesso
            {
                this.tem = true;
            }
            return mensagem;
        }

        public bool cadastrarCliente(Cliente c)
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            var aux = clienteDAO.Cadastrar(c);

            return aux;
        }

        public List<Cliente> ListaCliente()
       {
            ClienteDAO clienteDAO = new ClienteDAO();
            var aux = clienteDAO.ListaNova();

            return aux;
        }

        public Cliente SelectPorNomeCPF(String nome, String CPF)
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            var aux = clienteDAO.SelectPorNomeCPF(nome, CPF);

            return aux;
        }

        public bool alterarCliente(Cliente c)
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            var aux = clienteDAO.Alterar(c);

            return aux;
        }

        public bool ExcluirCliente(Cliente c)
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            var aux = clienteDAO.Excluir(c);

            return aux;
        }

        public bool SalvarCaixa(Registro c)
        {
            RegistroDAO caixaDAO = new RegistroDAO();
            var aux = caixaDAO.SalvarCaixa(c);

            return aux;
        }

        public bool Pesquisar(Cliente c)
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            var aux = clienteDAO.Pesquisar(c);

            return aux;
        }

        public Cliente PesquisarNomeOuCPF(String nomeOuCPF)
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            var aux = clienteDAO.PesquisarNomeOuCPF(nomeOuCPF);

            return aux;
        }

        public List<Cliente> SelectAll()
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            var aux = clienteDAO.SelectAll();

            return aux;
        }

        public Decimal SelectSaldoPet()
        {
            RegistroDAO registroDAO = new RegistroDAO();
            var aux = registroDAO.SelectSaldo();

            return aux;
        }

        public List<Registro> SelectAllRegistros()
        {
            RegistroDAO registroDAO = new RegistroDAO();
            var aux = registroDAO.SelectAll();

            return aux;
        }

        public Cliente PesquisarClientePorID(Int32 Id)
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            var aux = clienteDAO.PesquisarPorID(Id);

            return aux;
        }

        //Controla todas a classes, fazendo a conexão com as DAO(BANCO)
    }
}
