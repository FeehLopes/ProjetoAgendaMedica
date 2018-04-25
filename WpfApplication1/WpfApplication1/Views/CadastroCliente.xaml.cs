using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApplication1.DAL;
using WpfApplication1.Model;
using WpfApplication1.Views;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for CadastroCliente.xaml
    /// </summary>
    public partial class CadastroCliente : Window
    {
        private Cliente c;

        public CadastroCliente()
        {
            InitializeComponent();
            LoadSexo();
            btnAlterar.Visibility = Visibility.Hidden;
            btnCadastrar.Visibility = Visibility.Visible;
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidaDados())
            {
                Controle controle = new Controle();

                c = new Cliente
                {
                    Nome = txtNome.Text,
                    CPF = txtCPF.Text,
                    Endereco = txtEnd.Text,
                    Numero = txtNum.Text,
                    Complemento = txtComplemento.Text,
                    Telefone = txtTelefone.Text,
                    Celular = txtCelular.Text,
                    NomePet = txtPet.Text,
                    Raca = txtRaca.Text,
                    Idade = txtIdade.Text,
                    Data = dtpNascimento.Text,
                    Sexo = cboSexo.Text,
                };

                if (controle.cadastrarCliente(c))
                {
                    MessageBox.Show("Cliente cadastrado com sucesso!", "Cliente",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Não foi possível adicionar o cliente!", "Cliente",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        public void LimparCampos()
        {
            txtIdCliente.Text = txtNome.Text = txtCPF.Text = txtEnd.Text
                = txtNum.Text = txtComplemento.Text = txtTelefone.Text = txtCelular.Text
                 = txtPet.Text = txtRaca.Text = txtIdade.Text = dtpNascimento.Text = cboSexo.Text = string.Empty;
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidaDados())
            {
                Controle controle = new Controle();
                var cliente = new Cliente();

                cliente.ClienteId = Convert.ToInt32(txtIdCliente.Text);
                cliente.Nome = txtNome.Text;
                cliente.CPF = txtCPF.Text;
                cliente.Endereco = txtEnd.Text;
                cliente.Numero = txtNum.Text;
                cliente.Complemento = txtComplemento.Text;
                cliente.Telefone = txtTelefone.Text;
                cliente.Celular = txtCelular.Text;
                cliente.NomePet = txtPet.Text;
                cliente.Raca = txtRaca.Text;
                cliente.Idade = txtIdade.Text;
                cliente.Data = dtpNascimento.Text;
                cliente.Sexo = cboSexo.Text;

                if (controle.alterarCliente(cliente))
                {
                    MessageBox.Show("Cliente alterado com sucesso!", "WpfApplication1",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Não foi possivel alterar o cliente!", "WpfApplication1",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CboSexo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<string> list = new List<string>();
            list.Add("Selecione");
            list.Add("Fêmea");
            list.Add("Macho");
            this.cboSexo.ItemsSource = list;
        }

        private void LoadSexo()
        {
            List<string> list = new List<string>();
            list.Add("Selecione");
            list.Add("Fêmea");
            list.Add("Macho");
            this.cboSexo.ItemsSource = list;
            this.cboSexo.SelectedIndex = 0;
        }

        public bool ValidaDados()
        {
            var erro = string.Empty;
            bool validar = true; // tipo de variavel + o nome = recebe.

            if (String.IsNullOrEmpty(txtNome.Text))
            {
                erro += "Por gentileza preencha o nome. \r\n";
            }
            if (String.IsNullOrEmpty(txtCPF.Text))
            {
                erro += "Por gentileza preencha o CPF. \r\n";
            }
            if (String.IsNullOrEmpty(txtEnd.Text))
            {
                erro += "Por gentileza preencha o endereço. \r\n";
            }
            if (String.IsNullOrEmpty(txtComplemento.Text))
            {
                erro += "Por gentileza preencha o complemento. \r\n";
            }
            if (String.IsNullOrEmpty(txtTelefone.Text))
            {
                erro += "Por gentileza preencha o telefone. \r\n";
            }
            if (String.IsNullOrEmpty(txtCelular.Text))
            {
                erro += "Por gentileza preencha o celular. \r\n";
            }
            if (String.IsNullOrEmpty(txtPet.Text))
            {
                erro += "Por gentileza preencha o nome do pet. \r\n";
            }
            if (String.IsNullOrEmpty(txtRaca.Text))
            {
                erro += "Por gentileza preencha o raça do pet. \r\n";
            }
            if (String.IsNullOrEmpty(txtIdade.Text))
            {
                erro += "Por gentileza preencha o idade do pet. \r\n";
            }
            if (String.IsNullOrEmpty(dtpNascimento.Text))
            {
                erro += "Por gentileza preencha a data de nascimento do pet. \r\n";
            }
            if (String.IsNullOrEmpty(cboSexo.Text))
            {
                erro += "Por gentileza selecione o sexo do pet. \r\n";
            }
            if (erro.Length > 0)
            {
                validar = false;
                MessageBox.Show(erro, "WpfApplication1",
               MessageBoxButton.OK, MessageBoxImage.Error); // retorna menssagem de erro.

            }


            return validar;
        }

        public void LoadEditaCliente(String NomeCliente, String CPF)
        {
            Controle controle = new Controle();

            var cliente = controle.SelectPorNomeCPF(NomeCliente, CPF);
            txtIdCliente.Text = cliente.ClienteId.ToString();
            txtNome.Text = cliente.Nome;
            txtCPF.Text = cliente.CPF;
            txtEnd.Text = cliente.Endereco;
            txtNum.Text = cliente.Numero;
            txtComplemento.Text = cliente.Complemento;
            txtTelefone.Text = cliente.Telefone;
            txtCelular.Text = cliente.Celular;
            txtPet.Text = cliente.NomePet;
            txtRaca.Text = cliente.Raca;
            txtIdade.Text = cliente.Idade;
            dtpNascimento.Text = cliente.Data;
            cboSexo.Text = cliente.Sexo;

            this.cboSexo.SelectedValue = cliente.Sexo;

            btnCadastrar.Visibility = Visibility.Hidden;
            btnAlterar.Visibility = Visibility.Visible;
            //teste.ShowDialog();
        }

        private void btnPesquisarCliente_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(txtNomeCPF.Text))
            {
                Controle controle = new Controle();

                var cliente = controle.PesquisarNomeOuCPF(txtNomeCPF.Text);
                if(cliente != null && cliente.ClienteId > 0)
                {
                    txtIdCliente.Text = cliente.ClienteId.ToString();
                    txtNome.Text = cliente.Nome;
                    txtCPF.Text = cliente.CPF;
                    txtEnd.Text = cliente.Endereco;
                    txtNum.Text = cliente.Numero;
                    txtComplemento.Text = cliente.Complemento;
                    txtTelefone.Text = cliente.Telefone;
                    txtCelular.Text = cliente.Celular;
                    txtPet.Text = cliente.NomePet;
                    txtRaca.Text = cliente.Raca;
                    txtIdade.Text = cliente.Idade;
                    dtpNascimento.Text = cliente.Data;
                    cboSexo.Text = cliente.Sexo;

                    this.cboSexo.SelectedValue = cliente.Sexo;

                    btnCadastrar.Visibility = Visibility.Hidden;
                    btnAlterar.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("Cliente não encontrado.", "WpfApplication1",
                    MessageBoxButton.OK, MessageBoxImage.Error); // retorna menssagem de erro.
                }
            }
            else
            {
                MessageBox.Show("Por gentileza digitar o nome ou CPF do cliente.", "WpfApplication1",
                MessageBoxButton.OK, MessageBoxImage.Error); // retorna menssagem de erro.
            }
        }
    }
}
    











