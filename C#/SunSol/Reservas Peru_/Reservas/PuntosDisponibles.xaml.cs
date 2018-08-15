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
using librerias;
using System.Data;
using System.Data.SqlClient;

namespace Reservas
{
    /// <summary>
    /// Lógica de interacción para PuntosDisponibles.xaml
    /// </summary>
    public partial class PuntosDisponibles : Page
    {
        DataTable dtPuntos;
        int n_contrato=0;
        DataTable dtpunAnio;
        int puntosporannio = 0;
        int disponibles_ant = 0;
        int disponibles_act = 0;
        string anios_mod;
        public usuario us;
        bool actualizo;
        public PuntosDisponibles()
        {
            InitializeComponent();
        }

        private void txtcedula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtcedula_KeyUp(object sender, KeyEventArgs e)
        {
            //******busqueda de contratos segun cedula o rif del cliente
            cliente cli = new cliente();
            if (cli.buscar_cliente(txtcedula.Text,"") == 1)
            {               
                dtgrdContratos.ItemsSource = cli.buscar_contratos(txtcedula.Text, "", "");
                return;
            }
        }

        private void txtnombre_KeyUp(object sender, KeyEventArgs e)
        {
            cliente cli = new cliente();
            dtgrdContratos.ItemsSource = cli.buscar_contratos("", txtnombre.Text, "");
        }

        private void txtcontrato_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtcontrato_KeyUp(object sender, KeyEventArgs e)
        {
            cliente cli = new cliente();
            dtgrdContratos.ItemsSource = cli.buscar_contratos("", "", txtcontrato.Text);
        }

        private void dtgrdContratos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
             //seleccion de un cotrato
            object item = dtgrdContratos.SelectedItem;
            if ((dtgrdContratos.Items.Count > 0) && (item != null))
            {
                try
                {
                    n_contrato = Convert.ToInt32((dtgrdContratos.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                }
                catch
                {
                    MessageBox.Show("Este contrato no es válido", "ADVERTENCIA", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }                
                cliente cli = new cliente();
                int i = dtgrdContratos.SelectedIndex;
                cli.cedula_rif = (dtgrdContratos.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text;
                if (cli.buscar_cliente(cli.cedula_rif,n_contrato.ToString()) == 1)
                {
                   
                    txtcedula.Text = cli.cedula_rif;

                }
                //primeranio = Convert.ToInt32((dtgrdContratos.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text);
                //tipoContrato = (dtgrdContratos.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                lbltitulo.Content = "Contrato N° ** " + n_contrato.ToString() + " ** Cliente: "+cli.nombres+" "+cli.apellidos;
                dtpunAnio = new DataTable();
                try
                {
                    dtpunAnio.Load(cli.buscar_puntos(txtcedula.Text, n_contrato));
                }
                catch
                {
                    MessageBox.Show("Este contrato no tiene relación de puntos por año", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
              
                dtgrdPuntosPorAnio.ItemsSource = dtpunAnio.DefaultView;
                btnGuardar.IsEnabled = true;
                tbprincipal.SelectedIndex = 1;
                tbPuntosAnnio.Focus();
                for (int j = 0; j <= dtpunAnio.Rows.Count - 1; j++)
                {
                  
                        string[] p = dtpunAnio.Rows[j][2].ToString().Split(',');
                        disponibles_ant = disponibles_ant + Convert.ToInt32(p[0]);
                    

                }
            }
        }

       

        

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            actualizo = true;
           String[] p = dtpunAnio.Rows[0][4].ToString().Split(',');
           puntosporannio = Convert.ToInt32(p[0]);
           DataView view = (DataView)dtgrdPuntosPorAnio.ItemsSource;
           dtpunAnio = view.Table.Clone();
           foreach (DataRowView drv in view)
               dtpunAnio.ImportRow(drv.Row);
           int disponibles = 0;
            for (int i = 0; i <= dtpunAnio.Rows.Count - 1; i++)
            {
                try
                {
                   
                    p = dtpunAnio.Rows[i][2].ToString().Split(',');
                    disponibles = Convert.ToInt32(p[0]);
                    //if (Convert.ToInt32(dtpunAnio.Rows[i][1].ToString()) >= 2015)
                         disponibles_act = disponibles_act + disponibles;
                }
                catch
                {
                    MessageBox.Show("Verifique el formato de los puntos", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (Convert.ToInt32(p[0]) > puntosporannio)
                {
                    MessageBox.Show("Los puntos disponibles no pueden ser mayores al máximo del contrato", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
               
                   
                    int consumidos = puntosporannio - disponibles;
                    dtpunAnio.Rows[i][3] = consumidos;
                
            }
            dtgrdPuntosPorAnio.ItemsSource = dtpunAnio.DefaultView;
            btnActualizar.IsEnabled = false;
        }

        private void dtgrdPuntosPorAnio_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            btnActualizar.IsEnabled = true;
            object item = dtgrdPuntosPorAnio.SelectedItem;
              if ((dtgrdPuntosPorAnio.Items.Count > 0) && (item != null))
              {

                  anios_mod = anios_mod + "," + (dtgrdPuntosPorAnio.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;

              }

           
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (btnActualizar.IsEnabled == true)
            {
                MessageBox.Show("Hay cambios sin aplicar", "ADVERTENCIA", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (MessageBox.Show("¿Seguro desea cambiar la relación puntos por año del contrato N° "+n_contrato+"?", "Pregunta", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                reservacion reserva = new reservacion();
                reserva.cliente = txtcedula.Text;
                reserva.n_contrato = n_contrato;
                for (int i = 0; i <= dtpunAnio.Rows.Count - 1; i++)
                {
                    String[] p = dtpunAnio.Rows[i][2].ToString().Split(',');
                    String[] p1 = dtpunAnio.Rows[i][3].ToString().Split(',');
                    reserva.quitar_puntos(Convert.ToInt32(p[0]), Convert.ToInt32(p1[0]), Convert.ToInt32(dtpunAnio.Rows[i][1].ToString()));
                }
                MessageBox.Show("Se ha guardado correctamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                if (actualizo)
                {
                    int mod = disponibles_act - disponibles_ant;
                    anios_mod = anios_mod.TrimStart(',');
                    anios_mod = anios_mod.TrimEnd(',');
                    reserva.log(us.login, n_contrato.ToString(), disponibles_ant, disponibles_act, mod, anios_mod);
                    actualizo = false;
                }
                anios_mod = "";
                disponibles_ant = 0;
                disponibles_act = 0;
                for (int j = 0; j <= dtpunAnio.Rows.Count - 1; j++)
                {

                    string[] p = dtpunAnio.Rows[j][2].ToString().Split(',');
                    disponibles_ant = disponibles_ant + Convert.ToInt32(p[0]);


                }
            }
        }

        private void dtgrdPuntosPorAnio_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            //String[] p = dtpunAnio.Rows[0][4].ToString().Split(',');
            //puntosporannio = Convert.ToInt32(p[0]);
            //int i = dtgrdPuntosPorAnio.SelectedIndex;
            //p=dtpunAnio.Rows[i][2].ToString().Split(',');
            //if (Convert.ToInt32(p[0]) != puntosporannio)
            //{
            //    MessageBox.Show("No se puede modificar puntos ya distribuidos", "ADVERTENCIA", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    dtgrdPuntosPorAnio.SelectedIndex=-1;         
            //    return;
            //}
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dtPuntos = new DataTable();
            dtPuntos.Columns.Add("anterior");
            dtPuntos.Columns.Add("nuevo");
            dtPuntos.Columns.Add("cantidad");
            dtPuntos.Columns.Add("anio");

        }

        

       
    }
}
