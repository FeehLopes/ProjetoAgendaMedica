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
    /// Interaction logic for RelatorioCaixa.xaml
    /// </summary>
    public partial class RelatorioCaixa : Window
    {
        public RelatorioCaixa()
        {
            InitializeComponent();
           //LoadRelatorio();
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {
            var lstDadosCaixa = new List<Registro>();
            var lstDadosCaixaRelatorio = new List<Registro>();
            Controle controle = new Controle();

            lstDadosCaixa = controle.SelectAllRegistros();
            

            if (lstDadosCaixa != null && lstDadosCaixa.Count() > 0)
            {
                foreach (var item in lstDadosCaixa)
                {
                    var registro = new Registro();
                    registro.RegistroId = item.RegistroId;
                    registro.TipoDeServico = item.TipoDeServico;
                    registro.ValorServico = item.ValorServico;
                    registro.DataServico = item.DataServico;
                    registro.Cliente = new Cliente();
                    registro.Cliente = controle.PesquisarClientePorID(item.Cliente.ClienteId);

                    lstDadosCaixaRelatorio.Add(registro);
                }
            }

            var dataSource = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", lstDadosCaixaRelatorio);
            ReportViewer.LocalReport.DataSources.Add(dataSource);
            ReportViewer.LocalReport.ReportEmbeddedResource = "WpfApplication1.Views.ListaCaixa.rdlc";

            ReportViewer.RefreshReport();
        }

        private void LoadRelatorio()
        {
            var lstDadosCaixa = new List<Registro>();
            var lstDadosCaixaRelatorio = new List<Registro>();
            Controle controle = new Controle();

            lstDadosCaixa = controle.SelectAllRegistros();

            if (lstDadosCaixa != null && lstDadosCaixa.Count() > 0)
            {
                foreach (var item in lstDadosCaixa)
                {
                    var registro = new Registro();
                    registro.RegistroId = item.RegistroId;
                    registro.TipoDeServico = item.TipoDeServico;
                    registro.ValorServico = item.ValorServico;
                    registro.DataServico = item.DataServico;
                    registro.Cliente = new Cliente();
                    registro.Cliente = controle.PesquisarClientePorID(item.Cliente.ClienteId);

                    lstDadosCaixaRelatorio.Add(registro);
                }
            }

            var dataSource = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", lstDadosCaixaRelatorio);
            ReportViewer.LocalReport.DataSources.Add(dataSource);
            ReportViewer.LocalReport.ReportEmbeddedResource = "WpfApplication1.Views.ListaCaixa.rdlc";

            ReportViewer.RefreshReport();
        }

    }
}
