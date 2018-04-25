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
    /// Interaction logic for Listar.xaml
    /// </summary>
    public partial class Listar : Window
    {
        public Listar()
        {
            InitializeComponent();
            ListarCliente();
        }

        public void ListarCliente()
        {
            Controle controle = new Controle();            
            dtCliente.ItemsSource = controle.ListaCliente();
            dtCliente.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = controle.ListaCliente()});       
         }

        public void EditarClick(object sender, RoutedEventArgs e)
        {
            DataGrid dataGrid = dtCliente;
            DataGridRow Row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            DataGridCell RowAndColumn = (DataGridCell)dataGrid.Columns[0].GetCellContent(Row).Parent;
            string nome = ((TextBlock)RowAndColumn.Content).Text;

            DataGridCell RowAndColumn2 = (DataGridCell)dataGrid.Columns[1].GetCellContent(Row).Parent;
            string CPF = ((TextBlock)RowAndColumn2.Content).Text;

            CadastroCliente cliente = new CadastroCliente();
            cliente.LoadEditaCliente(nome, CPF);
            cliente.ShowDialog();
            //int index = dtCliente.SelectedIndex;
        }

        public void ExcluirClick(object sender, RoutedEventArgs e)
        {
            DataGrid dataGrid = dtCliente;
            DataGridRow Row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            DataGridCell RowAndColumn = (DataGridCell)dataGrid.Columns[0].GetCellContent(Row).Parent;
            string nome = ((TextBlock)RowAndColumn.Content).Text;

            DataGridCell RowAndColumn2 = (DataGridCell)dataGrid.Columns[1].GetCellContent(Row).Parent;
            string CPF = ((TextBlock)RowAndColumn2.Content).Text;

            Controle controle = new Controle();
            var cliente = controle.SelectPorNomeCPF(nome, CPF);
            var aux = controle.ExcluirCliente(cliente);
            ListarCliente();
        }
    }
}
