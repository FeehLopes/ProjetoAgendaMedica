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
using WpfApplication1.Model;

namespace WpfApplication1.Views
{
    /// <summary>
    /// Interaction logic for RetiradaCaixa.xaml
    /// </summary>
    public partial class RetiradaCaixa : Window
    {
        public RetiradaCaixa()
        {
            InitializeComponent();
            LoadDados();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var erro = String.Empty;

            if (String.IsNullOrEmpty(txtValorServico.Text) && Convert.ToDecimal(txtValorServico.Text) <= 0)
            {
                erro += "Por gentileza digite o valor \r\n";
            }          

            if (erro.Length <= 0)
            {
                Controle controle = new Controle();
                var registro = new Registro();

                registro = new Registro
                {
                    TipoDeServico = "Retirada Caixa",
                    DataServico = DateTime.Now.ToString(),
                    ValorServico = - Convert.ToDecimal(txtValorServico.Text),
                    Cliente = new Cliente() { ClienteId = 3 } //Cliente PETSHOP (Apenas para retiradas)
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
        }

        protected void LimparCampos()
        {
            txtValorServico.Text = string.Empty;
            LoadDados();
        }
    }
}
