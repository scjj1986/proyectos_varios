using System;
using System.Collections.Generic;
using MahApps.Metro.Controls;
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
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;


namespace Reservas
{
    /// <summary>
    /// Lógica de interacción para descuento.xaml
    /// </summary>
    public partial class descuento : Page
    {
        public DataTable dtDes;
        public descuento()
        {
            InitializeComponent();
            dtDes = new DataTable();
           
         
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            List<persona> tmp = new List<persona>();
            for (int i = 0; i <= dtDes.Rows.Count - 1; i++)
            {
                tmp.Add(new persona()
                {
                    hotel = dtDes.Rows[i][0].ToString(),
                    habitacion = dtDes.Rows[i][1].ToString(),
                    personas = dtDes.Rows[i][2].ToString(),
                    monto=Convert.ToDouble(dtDes.Rows[i][3].ToString()),
                    descuento=Convert.ToDouble(dtDes.Rows[i][4].ToString()) ,
                    descuentob= Convert.ToDouble(dtDes.Rows[i][5].ToString()),
                    total= Convert.ToDouble(dtDes.Rows[i][6].ToString())
                });
            }                
           
            dtgPersonaDes.ItemsSource = tmp;
            
           
          //  dtgPersonaDes.ItemsSource = dtDes.DefaultView;
        }

        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            dtgPersonaDes.ItemsSource = null;
            dtDes = null;
        }
        
        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           dtgPersonaDes.ItemsSource = null;
           dtDes = null;
        }

        private void chkSelectAll_Checked(object sender, RoutedEventArgs e)
        {
            if (txtdescuento.Text.Equals("") && txtdexcuentobs.Text.Equals(""))
            {
                MessageBox.Show("Debe colocar porcentaje ó monto de descuento", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            txtdescuento.IsEnabled = false;
            foreach (persona p in dtgPersonaDes.ItemsSource)
            {                
                p.IsSelected = true;
                if (!txtdescuento.Text.Equals(""))
                {
                    if (Convert.ToDouble(txtdescuento.Text) > 100)
                    {
                        MessageBox.Show("El porcentaje no puede ser mayor a 100%", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    p.descuento = Convert.ToDouble(txtdescuento.Text);
                    p.descuentob = Math.Round(p.monto * (p.descuento / 100), 2);
                    p.total = p.monto - p.descuentob;

                }
                else
                {
                    if (Convert.ToDouble(txtdexcuentobs.Text) > p.monto)
                    {
                        MessageBox.Show("El monto a descontar no puede ser mayor al monto por persona", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    p.descuentob = Convert.ToDouble(txtdexcuentobs.Text);
                    p.total = p.monto - p.descuentob;
                    p.descuento = Math.Round(p.descuentob * 100 / p.monto, 2);
                }
                dtgPersonaDes.Items.Refresh();
                
            }
        }

        private void chkSelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (persona p in dtgPersonaDes.ItemsSource)
            {
                p.IsSelected = false;
                p.descuento = 0;
                p.total = p.monto;
                p.descuentob = 0;
                dtgPersonaDes.Items.Refresh();
            }
        }
        public class persona : INotifyPropertyChanged
        {
            public string hotel{ get; set; }
            public string habitacion { get; set; }
            public string personas { get; set; }
            public double monto { get; set; }
            public double descuento{ get; set; }
            public double descuentob { get; set; }
            public double total{ get; set; }
            private bool _IsSelected = false;
            public bool IsSelected { get { return _IsSelected; } set { _IsSelected = value; OnChanged("IsSelected"); } }

            #region INotifyPropertyChanged Members

            public event PropertyChangedEventHandler PropertyChanged;
            private void OnChanged(string prop)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }

            #endregion
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            txtdescuento.IsEnabled = true;
            txtdexcuentobs.IsEnabled = true;
            btnGuarda.IsEnabled = false;
        }

        private void btnGuarda_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void dtgPersonaDes_Loaded(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void txtdexcuentobs_KeyUp(object sender, KeyEventArgs e)
        {
            txtdescuento.IsEnabled = false;
            btnGuarda.IsEnabled = true;
        }

        private void txtdescuento_KeyUp(object sender, KeyEventArgs e)
        {
            txtdexcuentobs.IsEnabled = false;
            btnGuarda.IsEnabled = true;
           
        }

        private void dtgPersonaDes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgPersonaDes.SelectedItem != null)
            {
                if (txtdescuento.Text.Equals("") && txtdexcuentobs.Text.Equals(""))
                {
                    MessageBox.Show("Debe colocar porcentaje ó monto de descuento", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                persona p = dtgPersonaDes.SelectedItem as persona;
                if (p.IsSelected)
                {
                    p.IsSelected = false;
                    p.descuento = 0;
                    p.total = p.monto;
                    p.descuentob = 0;
                    dtgPersonaDes.Items.Refresh();
                }
                else
                {
                    p.IsSelected = true;
                    if (!txtdescuento.Text.Equals(""))
                    {
                        if (Convert.ToDouble(txtdescuento.Text) > 100)
                        {
                            MessageBox.Show("El porcentaje no puede ser mayor a 100%", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        p.descuento = Convert.ToDouble(txtdescuento.Text);
                        p.descuentob = Math.Round(p.monto * (p.descuento / 100), 2);
                        p.total = p.monto - p.descuentob;

                    }
                    else
                    {
                        if (Convert.ToDouble(txtdexcuentobs.Text) > p.monto)
                        {
                            MessageBox.Show("El monto a descontar no puede ser mayor al monto por persona", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        p.descuentob = Convert.ToDouble(txtdexcuentobs.Text);
                        p.total = p.monto - p.descuentob;
                        p.descuento = Math.Round(p.descuentob * 100 / p.monto, 2);
                    }
                    dtgPersonaDes.Items.Refresh();

                }
            }
        
        }
        private void OnChecked(object sender, RoutedEventArgs e)
        {
           
        }

        private void txtdescuento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else if (e.Key == Key.OemPeriod)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtdexcuentobs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else if (e.Key == Key.OemPeriod)
                e.Handled = false;
            else
                e.Handled = true;
        }

      
       

    }
   
}
