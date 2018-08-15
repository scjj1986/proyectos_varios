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

namespace InventarioToallas
{
    
    /// <summary>
    /// Lógica de interacción para asignacion.xaml
    /// </summary>

    public partial class asignacion : Page
    {
        public asignacion()
        {
            InitializeComponent();
        }

        public Clases.C_Usuario user = new Clases.C_Usuario();
        public List<Clases.C_Supervisor> lsup=new List<Clases.C_Supervisor>();//Lista de Supervisores (Para cargar el Datagrid respectivo)
        public List<Clases.C_Camarera> lcam = new List<Clases.C_Camarera>();//Lista de Camareras (Para cargar el Datagrid respectivo)

        public bool no_supervisor = false;

        #region EVENTO CARGA DE LA PÁGINA

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Clases.C_Supervisor sp = new Clases.C_Supervisor();
            lsup = sp.listarSupervisores();

            if (!no_supervisor)
                dtgrdsup.ItemsSource = lsup;

            Clases.C_Camarera cam = new Clases.C_Camarera();
            lcam = cam.ListaCamarerasDisp();
            dtgrdcam.ItemsSource = lcam;
            dtgrdhab.ItemsSource = null;
            dtgrdhabsel.ItemsSource = null;
            lblHabSel.Content = "HABITACIONES SELECCIONADAS: 0";
            Clases.habitacionIqware hI = new Clases.habitacionIqware();
            cmbModulo.ItemsSource = hI.listarModulos();
            cmbModulo.DisplayMemberPath = "descripcion";
            cmbModulo.SelectedValuePath = "descripcion";
            cmbPiso.ItemsSource = null;
            no_supervisor = false;

        }


        

        #endregion

        #region EVENTO PARA BÚSQUEDA RÁPIDA DE SUPERVISORES (FILTRADO DE COINCIDENCIAS)


        private void txtBuscarSup_KeyUp(object sender, KeyEventArgs e)
        {
            Clases.C_Supervisor sup = new Clases.C_Supervisor();
            List<Clases.C_Supervisor> aux = new List<Clases.C_Supervisor>();
            dtgrdsup.ItemsSource = null;
            if (txtBuscarSup.Text != "")
            {

                aux = sup.BuscarSupervisores(txtBuscarSup.Text);
                if (aux.Count > 0)
                {
                    dtgrdsup.ItemsSource = aux;
                    txtBuscarCam.IsEnabled = true;
                    dtgrdcam.IsEnabled = true;

                }

            }
            else
            {

                dtgrdsup.ItemsSource = lsup;
            }
        }

        #endregion

        #region  EVENTO PARA BÚSQUEDA RÁPIDA DE CAMARERAS (FILTRADO DE COINCIDENCIAS)

        private void txtBuscarCam_KeyUp(object sender, KeyEventArgs e)
        {
            Clases.C_Camarera cam = new Clases.C_Camarera();
            List<Clases.C_Camarera> aux = new List<Clases.C_Camarera>();
            dtgrdcam.ItemsSource = null;

            if (txtBuscarCam.Text != "")
            {

                aux = cam.BuscarCamarerasDispIns(txtBuscarCam.Text);
                if (aux.Count > 0)
                {
                    dtgrdcam.ItemsSource = aux;
                    txtBuscarHab.IsEnabled = true;
                    dtgrdhab.IsEnabled = true;
                    btnSeleccionar.IsEnabled = true;
                    dtgrdhabsel.IsEnabled = true;

                }

            }
            else
            {
                dtgrdcam.ItemsSource = lcam;

            }


        }

        #endregion



        #region  EVENTOS Y MÉTODO PARA GESTIONAR BÚSQUEDA RÁPIDA DE HABITACIONES Y LIMPIAR CAMPOS (FILTRADO DE COINCIDENCIAS POR CAMPO DE TEXTO Y COMBOBOX'S DE MÓDULO Y PISO).


        //Campo de Texto de Búsqueda
        private void txtBuscarHab_KeyUp(object sender, KeyEventArgs e)
        {
            dtgrdhab.ItemsSource = null;
            filtrado_datagrid_habdisp();
        }

        //Módulo
        private void cmbModulo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbModulo.SelectedValue != null)
            {
                Clases.habitacionIqware hI = new Clases.habitacionIqware();
                cmbPiso.ItemsSource = hI.listarPisos(cmbModulo.SelectedValue.ToString());
                cmbPiso.DisplayMemberPath = "descripcion";
                cmbPiso.SelectedValuePath = "idModulo";
                if (cmbModulo.SelectedValue.ToString().Equals("Tropical"))
                {
                    List<Clases.modulo> lis = new List<Clases.modulo>();
                    foreach (Clases.modulo m in cmbPiso.ItemsSource)
                    {
                        if (m.idModulo != 186)
                            lis.Add(m);
                    }

                    cmbPiso.ItemsSource = lis;
                    cmbPiso.DisplayMemberPath = "descripcion";
                    cmbPiso.SelectedValuePath = "idModulo";


                }

                filtrado_datagrid_habdisp();

            }
        }

        //Piso
        private void cmbPiso_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dtgrdhab.ItemsSource = null;
            if (Convert.ToString(cmbPiso.SelectedItem) != null)
            {



                filtrado_datagrid_habdisp();
            }
        }


        //Método de apoyo
        public void filtrado_datagrid_habdisp()
        {

            Clases.habitacionIqware hab = new Clases.habitacionIqware();
            List<Clases.habitacionIqware> aux = new List<Clases.habitacionIqware>();
            string md = "";
            string ps = "";
            if (cmbModulo.SelectedIndex != -1)
                md = cmbModulo.SelectedValue.ToString();

            if (cmbPiso.SelectedItem != null)
            {
                Clases.modulo mdl = cmbPiso.SelectedItem as Clases.modulo;
                ps = mdl.descripcion;

            }
            //ps = cmbPiso.SelectedItem.ToString();

            aux = hab.filtrarhabitaciones(txtBuscarHab.Text, md, ps);

            if (aux.Count > 0)
                dtgrdhab.ItemsSource = aux;
            else
                dtgrdhab.ItemsSource = null;

        }

        //Resetear Campos para buscar habitaciones
        private void btnRst_Click(object sender, RoutedEventArgs e)
        {
            chkSelectAll.IsChecked = false;
            Clases.habitacionIqware hI = new Clases.habitacionIqware();
            cmbModulo.ItemsSource = hI.listarModulos();
            cmbModulo.DisplayMemberPath = "descripcion";
            cmbModulo.SelectedValuePath = "descripcion";
            cmbPiso.ItemsSource = null;
            dtgrdhab.ItemsSource = null;
            txtBuscarHab.Text = "";

        }

        #endregion


        #region MÉTODO PARA COMPARAR ID (EVITAR REPETICIÓN DE HABITACIONES EN SELECCIONADAS)

        public bool id_hab_repetida(int id)
        {

            if (dtgrdhabsel.Items.Count > 0)
            {

                foreach (Clases.habitacionIqware h in dtgrdhabsel.ItemsSource)
                {

                    if (h.ID_Room == id)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion

        #region EVENTO BOTON SELECCIONAR (COPIAR FILAS DE CHECKBOX'S SELECCIONADO EN EL DATAGRID DE HABITACIONES SELECCIONADAS)

        private void btnSeleccionar_Click(object sender, RoutedEventArgs e)
        {
            int cont = 0;
            List<Clases.habitacionIqware> list = dtgrdhabsel.ItemsSource as List<Clases.habitacionIqware>;
            if (list == null) list = new List<Clases.habitacionIqware>();
            if (dtgrdhab.ItemsSource != null)
            {

                foreach (Clases.habitacionIqware h in dtgrdhab.ItemsSource)
                {
                    Clases.habitacionIqware nvo = new Clases.habitacionIqware();
                    if (h.IsSelected && !id_hab_repetida(h.ID_Room))
                    {
                        cont++;
                        nvo.ID_Room = h.ID_Room;//id
                        nvo.RoomNo = h.RoomNo;//nr. hab.
                        nvo.RoomTypeShortName = h.RoomTypeShortName;//tipo
                        nvo.HSKGSName = h.HSKGSName;//módulo
                        nvo.Building = h.Building;//Edificio
                        nvo.status = h.status;//status
                        nvo.GuestTotal = h.GuestTotal;//pax
                        nvo.modulo = h.modulo;
                        nvo.llegada = h.llegada;
                        nvo.salida = h.salida;
                        nvo.Section = h.Section;
                        nvo.ID_Floor = h.ID_Floor;
                        list.Add(nvo);
                    }
                }
            }
            if (cont == 0)
            {
                MessageBox.Show("Debe tildar por lo menos una habitación y que no se encuentre en la lista de habitaciones seleccionadas", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                dtgrdhabsel.ItemsSource = null;
                dtgrdhabsel.ItemsSource = list;
                lblHabSel.Content = "HABITACIONES SELECCIONADAS: " + Convert.ToString(dtgrdhabsel.Items.Count);
            }


        }

        #endregion

       

        #region  EVENTOS EN CHECKBOX SELECCIONAR TODO

        //Si está tildado (Marcar Todos)
        private void chkSelectAll_Checked(object sender, RoutedEventArgs e)
         {

            if (dtgrdhab.Items.Count > 0)
            {
                List<Clases.habitacionIqware> list = new List<Clases.habitacionIqware>();
                foreach (Clases.habitacionIqware h in dtgrdhab.ItemsSource)
                {
                    Clases.habitacionIqware nvo = new Clases.habitacionIqware();
                    nvo = h;
                    nvo.IsSelected = true;
                    list.Add(nvo);

                }
                dtgrdhab.ItemsSource = null;
                if (list.Count > 0)
                {

                    dtgrdhab.ItemsSource = list;
                }
            }
        }

        //Si no está tildado (Desmarcar Todos)
        private void chkSelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            if (dtgrdhab.Items.Count > 0)
            {
                List<Clases.habitacionIqware> list = new List<Clases.habitacionIqware>();
                foreach (Clases.habitacionIqware h in dtgrdhab.ItemsSource)
                {
                    Clases.habitacionIqware nvo = new Clases.habitacionIqware();
                    nvo = h;
                    nvo.IsSelected = false;
                    list.Add(nvo);

                }
                dtgrdhab.ItemsSource = null;
                if (list.Count > 0)
                {

                    dtgrdhab.ItemsSource = list;
                }
            }
        }

        #endregion


        #region EVENTO BOTÓN CANCELAR

        private void tlCancelar_Click(object sender, RoutedEventArgs e)
        {
            dtgrdhab.ItemsSource = null;
            dtgrdhabsel.ItemsSource = null;
            txtBuscarCam.Text = "";
            txtBuscarHab.Text = "";
            txtBuscarSup.Text = "";
        }

        #endregion

        #region EVENTO PARA GUARDAR ASIGNACIÓN DE HABITACIÓN
        private void tlGuardar_Click(object sender, RoutedEventArgs e)
        {
            
            

            if (dtgrdcam.SelectedIndex < 0)
            {
                MessageBox.Show("Debe elegir una camarera", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (dtgrdhabsel.Items.Count == 0)
            {
                MessageBox.Show("Debe asignar por lo menos una habitación", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Clases.C_Asignacion asg = new Clases.C_Asignacion();
            Clases.C_Camarera cam = dtgrdcam.SelectedItem as Clases.C_Camarera;
            Clases.C_Supervisor sup = dtgrdsup.SelectedItem as Clases.C_Supervisor;

            asg.idcamarera = cam.idCamarera;


            if (dtgrdsup.SelectedIndex < 0)
                asg.idsupervisor = -1;
            else
                asg.idsupervisor = sup.idSupervisor;



            #region Bitácora

            string txtdescbit = "";

            if (dtgrdsup.SelectedIndex >= 0)
                txtdescbit = "INSERCIÓN (NOM. CAM.='" + cam.nombre + " " + cam.apellido + "', CÉD. CAM.='" + cam.cedula + "'; NOM. SUP.='" + sup.nombre + " " + sup.apellido + "', CÉD. SUP.='" + sup.cedula + "';  HABS.=";
            else
                txtdescbit = "INSERCIÓN (NOM. CAM.='" + cam.nombre + " " + cam.apellido + "', CÉD. CAM.='" + cam.cedula + "'; -SUPERVISOR SIN ASIGNAR-;  HABS.=";
            
            foreach (Clases.habitacionIqware h in dtgrdhabsel.ItemsSource)
            {

                txtdescbit += "'" + h.RoomNo + "',";
                asg.idhabitacion = h.ID_Room;
                asg.num_hab = h.RoomNo;
                asg.status_hab = h.status;
                asg.num_pax = h.GuestTotal;
                asg.modulo_hab = h.modulo;
                asg.tipo_hab = h.RoomTypeShortName;
                asg.idUsuario = user.idUsuario;
                asg.llegada = h.llegada;
                asg.salida = h.salida;
                asg.piso = h.ID_Floor;
                asg.Section = h.Section;

                if (asg.Guardar() == 1)
                {

                    Console.WriteLine("Guardado");
                }

            }
            
            txtdescbit=txtdescbit.Remove(txtdescbit.Length - 1);
            txtdescbit += ")";
            Clases.Bitacora bit = new Clases.Bitacora(1, 1, txtdescbit, user.login);
            if (bit.Guardar() == 1)
                Console.WriteLine("Inserción de asignación guardada en la bitácora");
            #endregion





            if (MessageBox.Show("Asignación guardada satisfactoriamente, ¿Desea imprimir el reporte de camarera?", "Confirmación", MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                reporteCamarera rc = new reporteCamarera();
                rc.camarera = cam;
                rc.supervisor = sup;
                rc.todos = false;
                rc.fecha = DateTime.Today;
                rc.ShowDialog();
            }
            no_supervisor = true;
            Page_Loaded(sender, e);

        }

        #endregion

        #region EVENTOS CLICK DERECHO AL DATAGRID DE HABITACIONES SELECCIONADAS (ELIMINAR UNA FILA SELECCIONADA Y ELIMINAR TODO)
        //Una fila
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (dtgrdhabsel.SelectedIndex >= 0)
            {

                Clases.habitacionIqware hb = dtgrdhabsel.SelectedItem as Clases.habitacionIqware;
                List<Clases.habitacionIqware> list = new List<Clases.habitacionIqware>();
                if (MessageBox.Show("Desea eliminar la habitación " + hb.RoomNo + " de la lista?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    foreach (Clases.habitacionIqware h in dtgrdhabsel.ItemsSource)
                    {
                        Clases.habitacionIqware nvo = new Clases.habitacionIqware();
                        if (h.ID_Room != hb.ID_Room)
                        {
                            nvo.ID_Room = h.ID_Room;//id
                            nvo.RoomNo = h.RoomNo;//nr. hab.
                            nvo.RoomTypeShortName = h.RoomTypeShortName;//tipo
                            nvo.HSKGSName = h.HSKGSName;//módulo
                            nvo.Building = h.Building;//Edificio
                            nvo.status = h.status;//status
                            nvo.GuestTotal = h.GuestTotal;//pax
                            nvo.modulo = h.modulo;
                            nvo.llegada = h.llegada;
                            nvo.salida = h.salida;
                            nvo.Section = h.Section;
                            nvo.ID_Floor = h.ID_Floor; 
                            list.Add(nvo);
                        }
                    }

                    dtgrdhabsel.ItemsSource = null;

                    if (list.Count > 0)
                    {

                        dtgrdhabsel.ItemsSource = list;
                    }

                    lblHabSel.Content = "HABITACIONES SELECCIONADAS: " + Convert.ToString(dtgrdhabsel.Items.Count);
                }
            }
        }
        //Todo
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if (dtgrdhabsel.SelectedIndex >= 0)
            { 
                if (MessageBox.Show("Desea eliminar todas las habitaciones seleccionadas?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    dtgrdhabsel.ItemsSource = null;
                    lblHabSel.Content = "HABITACIONES SELECCIONADAS: " + Convert.ToString(dtgrdhabsel.Items.Count);
                }
            }

        }

        #endregion


        #region EVENTOS PARA HABILITAR ELEMENTOS DE LA PÁGINA (DATAGRID'S, TEXTBOX, BOTONES, ETC)

        private void dtgrdsup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgrdsup.ItemsSource != null)
            {

                txtBuscarCam.IsEnabled = true;
                dtgrdcam.IsEnabled = true;
            }
        }

        private void dtgrdcam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgrdcam.ItemsSource != null)
            {
                cmbModulo.IsEnabled = true;
                cmbPiso.IsEnabled = true;
                txtBuscarHab.IsEnabled = true;
                dtgrdhab.IsEnabled = true;
                btnSeleccionar.IsEnabled = true;
                dtgrdhabsel.IsEnabled = true;
            }
        }

        #endregion


        


        

        

        





    }
}
