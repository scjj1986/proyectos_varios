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
using MahApps.Metro.Controls;
using Clases;
using System.Windows.Controls.DataVisualization.Charting;

namespace AdministracionData
{
    /// <summary>
    /// Lógica de interacción para historial.xaml
    /// </summary>
    public partial class historial : MetroWindow
    {
        public C_Cliente cli;
        public historial()
        {
            InitializeComponent();
            
        }

        private void showColumnChart()
        {
            lineChart.Title = "Historial del prospecto " + cli.nombre + " " + cli.apellido;           

            LineSeries Ncontactado = new LineSeries();
            Ncontactado.SetBinding(LineSeries.ItemsSourceProperty, new Binding());
            Ncontactado.DataContext = cli.historial();            
            Ncontactado.Title = "No Contactado";
            Ncontactado.DependentValueBinding = new Binding("Value");
            Ncontactado.IndependentValueBinding = new Binding("Key");
            lineChart.Series.Add(Ncontactado);
            

            LineSeries contactado = new LineSeries();
            contactado.SetBinding(LineSeries.ItemsSourceProperty, new Binding());
            contactado.DataContext = cli.historialContactado();
            contactado.Title = "Contactado";
            contactado.DependentValueBinding = new Binding("Value");
            contactado.IndependentValueBinding = new Binding("Key");

            lineChart.Series.Add(contactado);

            lineChart.FontSize = 9;
            

            
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            showColumnChart();
        }
    }
}
