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
    /// Interaction logic for Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        public Principal()
        {
            InitializeComponent();
            
        }

        private void btnCadastro_Click(object sender, RoutedEventArgs e)
        {
            CadastroCliente frm = new CadastroCliente();
            frm.ShowDialog();
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            

            Listar frm = new Listar();

            frm.ShowDialog();

        }

        private void btnCaixa_Click(object sender, RoutedEventArgs e)
        {
            Caixa frm = new Caixa();

            frm.ShowDialog();
        }

       

        private void btnRetirada_Click(object sender, RoutedEventArgs e)
        {
            RetiradaCaixa frm = new RetiradaCaixa();

            frm.ShowDialog();
        }

        private void btnRelatorioCaixa_Click(object sender, RoutedEventArgs e)
        {
            RelatorioCaixa frm = new RelatorioCaixa();

            frm.ShowDialog();
        }
    }
}
