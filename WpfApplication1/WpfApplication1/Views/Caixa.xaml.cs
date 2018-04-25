using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace WpfApplication1.Views
{
    /// <summary>
    /// Interaction logic for Caixa.xaml
    /// </summary>
    public partial class Caixa : Window
    {
        public Caixa()
        {
            InitializeComponent();
            LoadDados();
            LoadDadosCli();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var erro = String.Empty;

            if (String.IsNullOrEmpty(txtValorServico.Text) && Convert.ToDecimal(txtValorServico.Text) <= 0)
            {
                erro += "Por gentileza digite o valor \r\n";
            }
            if (cbxTipoServico.SelectedIndex == 0)
            {
                erro += "Por gentileza selecione o tipo de serviço \r\n";
            }
            if (cbxCliente.SelectedIndex == 0)
            {
                erro += "Por gentileza digite o cliente \r\n";
            }

            if (erro.Length <= 0)
            {
                Controle controle = new Controle();
                var registro = new Registro();

                registro = new Registro
                {
                    TipoDeServico = cbxTipoServico.Text,
                    DataServico = DateTime.Now.ToString(),
                    ValorServico = Convert.ToDecimal(txtValorServico.Text),
                    Cliente = new Cliente() { ClienteId = Convert.ToInt32(cbxCliente.SelectedValue) }
                };

                if (controle.SalvarCaixa(registro))
                {
                    MessageBox.Show("Registro Salvo com sucesso!", "Caixa",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Não foi possível adicionar o Registro!", "Caixa",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show(erro, "WpfApplication1",
                MessageBoxButton.OK, MessageBoxImage.Error); // retorna menssagem de erro.
            }
        }

        protected void LoadDados()
        {
            Controle controle = new Controle();
            var saldo = controle.SelectSaldoPet();

            lblValorSaldo.Content = saldo.ToString();

            List<string> list = new List<string>();
            list.Add("Selecione");
            list.Add("Banho");
            list.Add("Banho e Tosa");
            this.cbxTipoServico.ItemsSource = list;
            this.cbxTipoServico.SelectedIndex = 0;
        }

        protected void LimparCampos()
        {
            txtValorServico.Text = string.Empty;
            LoadDados();
            LoadDadosCli();
        }

        protected void LoadDadosCli()
        {
            var controle = new Controle();
            var lstCliente = controle.SelectAll();
            List<ComboData> ListData = new List<ComboData>();

            ListData.Add(new ComboData { Id = 0, Value = "Selecione" });

            foreach (var item in lstCliente)
            {
                ListData.Add(new ComboData { Id = item.ClienteId, Value = item.Nome });
            }

            cbxCliente.ItemsSource = ListData;
            cbxCliente.DisplayMemberPath = "Value";
            cbxCliente.SelectedValuePath = "Id";
            cbxCliente.SelectedValue = "0";
        }

        public class ComboData
        {
            public int Id { get; set; }
            public string Value { get; set; }
        }
    }
}

