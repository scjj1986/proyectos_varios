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
using System.Windows.Controls.Primitives;
using System.Drawing;



namespace InventarioToallas
{ 
    
    
    
    public partial class ListAsignHabCamHoy : Page
    {

        public Clases.C_Usuario user = new Clases.C_Usuario();
        List<Clases.C_Camarera> lcam;//Lista de camareras dependiendo de la fecha (Fecha actual por defecto)

        public ListAsignHabCamHoy()
        {
            InitializeComponent();
        }

        #region EVENTO CARGA DE LA PÁGINA

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Clases.C_Camarera cam = new Clases.C_Camarera();
            lcam = cam.ListAsignHabCamHoy();
            dtgrdcam.ItemsSource = lcam;
        }

        #endregion

        #region EVENTO FILTRADO DE CAMARERAS POR CAMPOS DE TEXTO (DATOS DE CAMARERA Y HABITACIONES ASIGNADAS)


        // --------------- TextBox Habitación -----------// 
        private void txtBuscarCamHab_KeyUp(object sender, KeyEventArgs e)
        {
            if (lcam != null)
            {
                dtgrdhabsel.ItemsSource = null;
                List<Clases.C_Camarera> list = new List<Clases.C_Camarera>();
                Clases.C_Camarera nodo=new Clases.C_Camarera();
                if (txtBuscarCamHab.Text == "")
                {
                    dtgrdcam.ItemsSource = lcam;
                    return;
                }
                

                DateTime dt;
                if (dtpFecha.SelectedDate != null)
                    dt = Convert.ToDateTime(dtpFecha.SelectedDate);
                else
                    dt = DateTime.Today;
                

                foreach (Clases.C_Camarera cm in lcam)
                {
                    if (cm.FiltrarAsignHabCamFecha(txtBuscarCamHab.Text, dt)!=null)
                    {
                        nodo = new Clases.C_Camarera();
                        nodo.idCamarera = cm.idCamarera;
                        nodo.nac = cm.nac;
                        nodo.cedula = cm.cedula;
                        nodo.nombre = cm.nombre;
                        nodo.apellido = cm.apellido;
                        nodo.nhab = cm.nhab;
                        nodo.nombresup = cm.nombresup;
                        nodo.idSupervisor = cm.idSupervisor;
                        list.Add(nodo);
                    }

                }

                dtgrdcam.ItemsSource = null;
                if (list.Count > 0)
                    dtgrdcam.ItemsSource = list;

            }
        }


        // ---------------- TextBox Camarera ----------------------------------//
        private void txtBuscarCam_KeyUp(object sender, KeyEventArgs e)
        {
            if (lcam != null)
            {
                List<Clases.C_Camarera> list = new List<Clases.C_Camarera>();
                Clases.C_Camarera nodo;
                if (txtBuscarCam.Text=="")
                {
                    if (lcam!=null)

                        dtgrdcam.ItemsSource = lcam;
                    return;

                }
                foreach (Clases.C_Camarera cm in lcam)
                {
                    if (cm.nombresup.Contains(txtBuscarCam.Text.ToUpper()) || cm.cedula.Contains(txtBuscarCam.Text.ToUpper()) || cm.nombre.Contains(txtBuscarCam.Text.ToUpper()) || cm.apellido.Contains(txtBuscarCam.Text.ToUpper()))
                    {
                        nodo = new Clases.C_Camarera();
                        nodo.idCamarera = cm.idCamarera;
                        nodo.nac = cm.nac;
                        nodo.cedula = cm.cedula;
                        nodo.nombre = cm.nombre;
                        nodo.apellido = cm.apellido;
                        nodo.nhab = cm.nhab;
                        nodo.nombresup = cm.nombresup;
                        nodo.idSupervisor = cm.idSupervisor;
                        list.Add(nodo);
                    }

                }
                dtgrdcam.ItemsSource = null;
                if (list.Count > 0)
                    dtgrdcam.ItemsSource = list;


            }


        }

        #endregion


        #region EVENTO CLICK DERECHO (LLAMADA A EDITAR Y REPORTE DE CAMARERA)


        //Editar
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (dtgrdcam.SelectedIndex >= 0)
            {
                

                DateTime fch= dtpFecha.SelectedDate == null? DateTime.Today : Convert.ToDateTime(dtpFecha.SelectedDate);

                if (user.nivel > 1)
                {
                    MessageBox.Show("No posee los permisos para hacer esta acción", "Denegado", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                else if (fch == DateTime.Today && user.nivel < 2)
                {
                    EditarAsignHab edas = new EditarAsignHab();
                    Clases.C_Camarera cam = dtgrdcam.SelectedItem as Clases.C_Camarera;
                    edas.cm_act = cam;
                    edas.user = user;
                    edas.ShowDialog();
                    if (edas.DialogResult==true)
                    {
                        dtgrdhabsel.ItemsSource = null;
                        Page_Loaded(sender, e);
                    }


                }
                
                
            }
        }


        //Reporte de Camarera
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            reporteCamarera rc = new reporteCamarera();
            Clases.C_Camarera cam = dtgrdcam.SelectedItem as Clases.C_Camarera;
            Clases.C_Supervisor sp = new Clases.C_Supervisor();
            rc.camarera = cam;
            rc.supervisor = sp.SupervisorPorId(Convert.ToInt32(cam.idSupervisor));


            DateTime? f = dtpFecha.SelectedDate;
            if (f != null)
                rc.fecha = Convert.ToDateTime(dtpFecha.SelectedDate);
            else
                rc.fecha = DateTime.Today;


            rc.todos = false;
            rc.ShowDialog();
        }

        #endregion



        #region EVENTO BOTÓN CONSULTAR

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            //fecha = Convert.ToString(dtpFecha.SelectedDate);
            dtgrdhabsel.ItemsSource = null;
            if (Convert.ToString(dtpFecha.SelectedDate) == "")
            {

                MessageBox.Show("Campo fecha vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (dtpFecha.SelectedDate > DateTime.Today)
            {
                MessageBox.Show("La fecha no debe ser mayor que la actual", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            Clases.C_Camarera cam = new Clases.C_Camarera();
            dtgrdcam.ItemsSource = null;
            lcam = new List<Clases.C_Camarera>();
            lcam = cam.ListAsignHabCamFecha(Convert.ToDateTime(dtpFecha.SelectedDate));
            if (lcam.Count > 0)
                dtgrdcam.ItemsSource = lcam;

        }

        #endregion


        #region EVENTO CLICK EN FILA DE CAMARERA EN EL DATAGRID
        private void dtgrdcam_MouseDoubleClick_1(object sender, SelectionChangedEventArgs e)
        {
            if (dtgrdcam.SelectedIndex != -1)
            {
                indice = 0;
                DateTime fch = dtpFecha.SelectedDate == null ? DateTime.Today : Convert.ToDateTime(dtpFecha.SelectedDate);
                Clases.C_Camarera cam = dtgrdcam.SelectedItem as Clases.C_Camarera;
                Clases.habitacionIqware h = new Clases.habitacionIqware();
                dtgrdhabsel.ItemsSource = null;
                dtgrdhabsel.ItemsSource = h.listarhabasigxcam(cam.idCamarera,fch);

            }

        }

        #endregion

        
        

        #region EVENTO CLICK PARA MOSTRAR VENTANA EMERGENTE DE REPORTE CAMARERA

        private void tlGuardar_Click(object sender, RoutedEventArgs e)
        {
            reporteCamarera rc = new reporteCamarera();

            rc.todos = true;
            if (dtgrdcam.SelectedIndex != -1)
            {
                rc.camarera = dtgrdcam.SelectedItem as Clases.C_Camarera;
                rc.todos = false;
            }
                
           
            
            DateTime? f = dtpFecha.SelectedDate;
            if (f != null)
                rc.fecha = Convert.ToDateTime(dtpFecha.SelectedDate);
            else
                rc.fecha = DateTime.Today;
            rc.ShowDialog();
        }

        #endregion

        public int indice = 0;

        

        


    }
}
