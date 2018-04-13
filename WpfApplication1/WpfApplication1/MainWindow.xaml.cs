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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplication1.Model;
using WpfApplication1.Views;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            CadastroLogin frm = new CadastroLogin();
            frm.ShowDialog();

        }

        private void btnEntrar_Click(object sender, RoutedEventArgs e)
        {
          
            Controle controle = new Controle();
            controle.acessar(txtUsuario.Text, pwdSenha.Password);

            if (controle.mensagem.Equals(""))
            {

                if (controle.tem)
                {
                    MessageBox.Show("Logado com Sucesso!!!", "Entrando", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                }
                else
                {
                    MessageBox.Show("Login não Encontrado, verifique login e senha", "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show(controle.mensagem);
            }
        }

       
    }
}
