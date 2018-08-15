using System;
using System.Collections.Generic;
using System.Data;
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

namespace InventarioToallas
{
    /// <summary>
    /// Lógica de interacción para MovHabPorFecha.xaml
    /// </summary>
    public partial class MovHabPorFecha : Page
    {

        public Clases.C_Usuario user;

        string fecha;
        public MovHabPorFecha()
        {
            InitializeComponent();
        }

        public List<Clases.C_Camarera> lcam = new List<Clases.C_Camarera>();

        #region EVENTO CARGAR DE LA PÁGINA

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            DateTime fch = dtpFecha.SelectedDate == null ? DateTime.Today : Convert.ToDateTime(dtpFecha.SelectedDate);
            Clases.C_Camarera cam = new Clases.C_Camarera();

            lcam = cam.MovCamPorFecha(fch);
            dtgrdcam.ItemsSource = lcam;
        }

        #endregion

        #region EVENTO CLICK BOTÓN "CONSULTAR"

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {

            

            if (Convert.ToString(dtpFecha.SelectedDate) == "")
            {

                MessageBox.Show("Campo fecha vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (dtpFecha.SelectedDate > DateTime.Today)
            {
                MessageBox.Show("La fecha no debe ser mayor a la actual", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DateTime fch = dtpFecha.SelectedDate == null ? DateTime.Today : Convert.ToDateTime(dtpFecha.SelectedDate);
            Clases.C_Camarera cm = new Clases.C_Camarera();
            dtgrdcam.ItemsSource = null;
            dtgrdhabsel.ItemsSource = null;
            dtgrdsumcamb.ItemsSource = null;
            dtgrdsumrep.ItemsSource = null;
            lcam = new List<Clases.C_Camarera>();
            lcam = cm.MovCamPorFecha(fch);
            dtgrdcam.ItemsSource = lcam;

        }

        #endregion

        #region EVENTO KEYUP PARA FILTRADO DEL DATAGRID DE MOVIMIENTO DE CAMARERAS

        private void txtBuscarCam_KeyUp_1(object sender, KeyEventArgs e)
        {

            if (txtBuscarCam.Text != "")
            {

                List<Clases.C_Camarera> list = new List<Clases.C_Camarera>();
                Clases.C_Camarera nodo;
                if (dtgrdcam.ItemsSource != null)
                {
                    
                    foreach (Clases.C_Camarera cm in dtgrdcam.ItemsSource)
                    {
                        if (cm.cedula.Contains(txtBuscarCam.Text.ToUpper()) || cm.nombre.Contains(txtBuscarCam.Text.ToUpper()) || cm.apellido.Contains(txtBuscarCam.Text.ToUpper()))
                        {
                            nodo = new Clases.C_Camarera();
                            nodo.idCamarera = cm.idCamarera;
                            nodo.nac = cm.nac;
                            nodo.cedula = cm.cedula;
                            nodo.nombre = cm.nombre;
                            nodo.apellido = cm.apellido;
                            nodo.tipomov = cm.tipomov;
                            nodo.nombresup = cm.nombresup;
                            nodo.horamov = cm.horamov;
                            list.Add(nodo);
                        }

                    }
                    
                }
                else
                {
                    foreach (Clases.C_Camarera cm in lcam)
                    {
                        if (cm.cedula.Contains(txtBuscarCam.Text.ToUpper()) || cm.nombre.Contains(txtBuscarCam.Text.ToUpper()) || cm.apellido.Contains(txtBuscarCam.Text.ToUpper()))
                        {
                            nodo = new Clases.C_Camarera();
                            nodo.idCamarera = cm.idCamarera;
                            nodo.nac = cm.nac;
                            nodo.cedula = cm.cedula;
                            nodo.nombre = cm.nombre;
                            nodo.apellido = cm.apellido;
                            nodo.tipomov = cm.tipomov;
                            nodo.nombresup = cm.nombresup;
                            nodo.horamov = cm.horamov;
                            list.Add(nodo);
                        }

                    }
                    
                }
                dtgrdcam.ItemsSource = null;
                if (list.Count > 0)
                    dtgrdcam.ItemsSource = list;
            }
            else
            {
                dtgrdcam.ItemsSource = lcam;
            }
            
            
        }

        #endregion


        #region EVENTO CLICK EN FILA PARA ELEGIR UNA HABITACIÓN DE UN MOVIMIENTO ESPECÍFICO

        private void dtgrdhabsel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (dtgrdhabsel.ItemsSource != null)
            {

                Clases.C_Suministro sm = new Clases.C_Suministro();
                Clases.C_Camarera cam = dtgrdcam.SelectedItem as Clases.C_Camarera;
                Clases.habitacionIqware hab = dtgrdhabsel.SelectedItem as Clases.habitacionIqware;
                dtgrdsumcamb.ItemsSource = null;
                dtgrdsumrep.ItemsSource = null;
                DateTime fch = dtpFecha.SelectedDate == null ? DateTime.Today : Convert.ToDateTime(dtpFecha.SelectedDate);

                dtgrdsumcamb.ItemsSource = sm.list_mov_sum_tipo(hab.ID_Room, fch, "", "CAMBIO");//Carga del datagrid de suministros de cambio, dependiendo de la habitación seleccionada
                dtgrdsumrep.ItemsSource = sm.list_mov_sum_tipo(hab.ID_Room, fch, "", "REPOSICION");//Carga del datagrid de suministros de reposición, dependiendo de la habitación seleccionada

            }

        }

        #endregion

        #region EVENTO PARA ELEGIR UNA FILA DE CAMARERA DE SU DATAGRID

        private void dtgrdcam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgrdcam.SelectedIndex != -1)
            {

                dtgrdhabsel.ItemsSource = null;
                dtgrdsumcamb.ItemsSource = null;
                dtgrdsumrep.ItemsSource = null;
                Clases.C_Camarera cam = dtgrdcam.SelectedItem as Clases.C_Camarera;
                Clases.habitacionIqware h = new Clases.habitacionIqware();

                
                DateTime fch = dtpFecha.SelectedDate == null ? DateTime.Today : Convert.ToDateTime(dtpFecha.SelectedDate);
                dtgrdhabsel.ItemsSource = h.listarhabasigxcam(cam.idCamarera, fch);


            }
        }

        #endregion

        #region EVENTOS PARA CARGAR CADA FILA DE LOS DATAGRIDS DE CAMBIO Y REPOSICIÓN (RESALTAR COLORES DE FILA EN CASO DE PÉRDIDAS, INCIDENCIAS Y EXTRAS)


        //Cambio
        private void dtgrdsumcamb_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            Clases.C_Suministro item = e.Row.Item as Clases.C_Suministro;
            if (item != null)
            {

                Clases.C_Suministro sum = new Clases.C_Suministro();
                sum.idSuministro = item.idSuministro;
                Clases.habitacionIqware hb = dtgrdhabsel.SelectedItem as Clases.habitacionIqware;

                

                DateTime fch = dtpFecha.SelectedDate == null ? DateTime.Today : Convert.ToDateTime(dtpFecha.SelectedDate);
                

                if (item.cantidadEstimada > item.cantidadReal && sum.inc_sum_id(hb.ID_Room, fch, sum.idSuministro) != null)
                {//Cambias el color
                    e.Row.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EEE8AA"));//Incidencia (Amarillo)
                }



                if (item.suciaEstimada > item.suciaReal && sum.per_sum_id(hb.ID_Room, fch, sum.idSuministro)!=null )
                {//Cambias el color
                    e.Row.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF0000"));//Pérdida (Rojo)
                }
                int tot=sum.TotalExtraSumFecha(hb.ID_Room, fch);

                if (tot>0 && item.cantidadEstimada<item.cantidadReal)
                {
                    e.Row.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#AFEEEE"));//Extra (Verde)

                }

                if (item.suciaEstimada > item.suciaReal && sum.per_sum_id(hb.ID_Room, fch, sum.idSuministro) != null && tot > 0 && item.cantidadEstimada < item.cantidadReal)
                {

                    e.Row.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B8B8B8"));//Pérdida y Extra (gris)
                }

            }
            
        }

        //Reposición
        private void dtgrdsumrep_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            Clases.C_Suministro item = e.Row.Item as Clases.C_Suministro;
            if (item != null)
            {

                Clases.C_Suministro sum = new Clases.C_Suministro();
                sum.idSuministro = item.idSuministro;
                Clases.habitacionIqware hb = dtgrdhabsel.SelectedItem as Clases.habitacionIqware;
                DateTime fch = dtpFecha.SelectedDate == null ? DateTime.Today : Convert.ToDateTime(dtpFecha.SelectedDate);

                

                if (item.cantidadEstimada > item.cantidadReal && sum.inc_sum_id(hb.ID_Room, fch, sum.idSuministro) != null)
                {//Cambias el color
                    e.Row.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EEE8AA"));//Incidencia (Amarillo)
                }
                
                
                
                int tot = sum.TotalExtraSumFecha(hb.ID_Room, fch);
                if (tot > 0 && item.cantidadEstimada < item.cantidadReal)
                {
                    e.Row.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#AFEEEE"));//Extra (Verde)

                }

                

            }
        }

        #endregion


        














    }
}
