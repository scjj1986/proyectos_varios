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

using MahApps.Metro.Controls;
using MahApps.Metro.Behaviours;

namespace InventarioToallas
{
    /// <summary>
    /// Lógica de interacción para EditarAsignHab.xaml
    /// </summary>
    public partial class EditarAsignHab : MetroWindow
    {
        public int idcam=0;
        public int idsup=0;

        List<int> habit = new List<int>();//Lista de habitaciones selecciondas (para incluirlas en el filtrado de habitaciones disponibles) 


        public Clases.C_Camarera cm_act = new Clases.C_Camarera();//Datos de la camarera actual (En caso de cambio para la bitácora) 
        public Clases.C_Supervisor sp_act = new Clases.C_Supervisor();//Datos del supervisor actual (En caso de cambio para la bitácora) 
        public List<Clases.habitacionIqware> hb_act = new List<Clases.habitacionIqware>();//Lista de habitaciones asignadas actuales  (En caso de cambio para la bitácora) 


        public List<Clases.habitacionIqware> habaux = new List<Clases.habitacionIqware>();//Lista auxiliar de habitaciones asignadas (si las mismas están en asignación de suministros)
        public Clases.habitacionIqware h2 = new Clases.habitacionIqware();//Instancia auxliar para cargar habaux
        public Clases.C_Usuario user = new Clases.C_Usuario();

        public EditarAsignHab()
        {
            InitializeComponent();
        }


        #region MÉTODO DE APOYO PARA LA CARGA DE HB_ACT (HABITACIONES SELECCIONADAS ACTUALES)
        public void copiar_dghabsel_a_list()
        {

            foreach (Clases.habitacionIqware h in dtgrdhabsel.ItemsSource)
            {
                Clases.habitacionIqware nvo = new Clases.habitacionIqware();
                nvo.ID_Room = h.ID_Room;
                nvo.RoomNo = h.RoomNo;
                hb_act.Add(nvo);

            }


        }

        #endregion

        #region EVENTO CARGA DE LA PÁGINA

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {

            Clases.C_Supervisor sp = new Clases.C_Supervisor();

            if (cm_act.idSupervisor != -1)//Si la asignación actual tiene supervisores
            {
                dtgrdsup.ItemsSource = sp.BuscarSupervisorPorId(Convert.ToInt32(cm_act.idSupervisor));
                dtgrdsup.SelectedIndex = 0;
                sp_act = dtgrdsup.SelectedItem as Clases.C_Supervisor;

            }
            else//Si no tiene supervisor asignado
            {

                sp_act = null;
            }


            habaux = h2.listarhabxcamfecha(cm_act.idCamarera, DateTime.Today);//Listado de habitaciones (De haber asignación de suministros)
            if (habaux.Count>0){//Condición en caso de que las habitaciones tengan asignados suministros (Sólo estará habilitado para editar supervisor)

                dtgrdcam.IsEnabled=false;
                txtBuscarCam.IsEnabled = false;
                dtgrdhab.IsEnabled=false;
                txtBuscarHab.IsEnabled = false;
                dtgrdhabsel.IsEnabled=false;
                cmbModulo.IsEnabled = false;
                cmbPiso.IsEnabled = false;
                btnRst.IsEnabled = false;
                btnSeleccionar.IsEnabled = false;

            }




            dtgrdcam.ItemsSource = cm_act.BuscarCamareraPorId(cm_act.idCamarera);
            dtgrdcam.SelectedIndex = 0;
            Clases.habitacionIqware hb = new Clases.habitacionIqware();

            dtgrdhabsel.ItemsSource = hb.listarhabasigxcamysup(cm_act.idCamarera, Convert.ToInt32(cm_act.idSupervisor), DateTime.Today);

            lblHabSel.Content = "HABITACIONES SELECCIONADAS: " + Convert.ToString(dtgrdhabsel.Items.Count);


            copiar_dghabsel_a_list();//Carga de lista de habitaciones seleccionadas actualmente en hb_act 


            //------------------------ Carga de Hab. (Para anexar las habitaciones asignadas actuales en la búsqueda) ---------------------//
            foreach (Clases.habitacionIqware h in dtgrdhabsel.ItemsSource)
            {
                habit.Add(h.ID_Room);
            }
            //----------------------------------------------------------------------------------------------------------------------------//

            Clases.habitacionIqware hI = new Clases.habitacionIqware();
            cmbModulo.ItemsSource = hI.listarModulos();
            cmbModulo.DisplayMemberPath = "descripcion";
            cmbModulo.SelectedValuePath = "descripcion";
        }

        #endregion

        #region EVENTOS PARA FILTRAR EN LOS DATAGRIDS DE SUPERVISOR, CAMARERA Y HABITACIÓN


        //----------- TextBox Supervisor ----------------------------//
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
                    

                }

            }
        }

        //----------- TextBox Camarera ----------------------------//

        private void txtBuscarCam_KeyUp(object sender, KeyEventArgs e)
        {
            Clases.C_Camarera cam = new Clases.C_Camarera();
            List<Clases.C_Camarera> aux = new List<Clases.C_Camarera>();
            dtgrdcam.ItemsSource = null;

            if (txtBuscarCam.Text != "")
            {
                aux = cam.BuscarCamarerasDispEdi(txtBuscarCam.Text);
                if (aux.Count > 0)
                {
                    dtgrdcam.ItemsSource = aux;
                    txtBuscarHab.IsEnabled = true;
                    dtgrdhab.IsEnabled = true;
                    btnSeleccionar.IsEnabled = true;
                    dtgrdhabsel.IsEnabled = true;

                }

            }
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

        #region EVENTO CLICK EN BOTÓN SELECCIONAR

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

        #region EVENTOS CUANDO ESTÁ O NO TILDADO EL CHECKBOX SELECCIONAR TODO
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

        #region EVENTOS CLICK DERECHO EN DATATABLE DE HABITACIONES SELECCIONADAS (Opciones Eliminar de la Lista y Eliminar Todo )

        //Eliminar de la Lista
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

        //Eliminar todo
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

        #region Método de apoyo para comparar si son diferentes las hab. de la base de datos y las nuevas (Bitácora)
        public bool hab_distintas()
        {
            bool encontrado = false;

            if (hb_act.Count != dtgrdhabsel.Items.Count)
                return true;
            
            foreach (Clases.habitacionIqware h in hb_act)
            {
                encontrado = false;
                foreach (Clases.habitacionIqware h2 in dtgrdhabsel.ItemsSource)
                {

                    if (h.ID_Room==h2.ID_Room)
                        encontrado = true;
                }

                if (!encontrado)
                    return true;
            }

            return false;

        }
        #endregion



        #region EVENTOS BOTONES GUARDAR Y CANCELAR

        private void tlGuardar_Click(object sender, RoutedEventArgs e)
        {
            
            if (dtgrdcam.SelectedIndex < 0)
            {
                MessageBox.Show("Debe elegir una camarera", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            bool hb_ds = false;
            hb_ds = hab_distintas();//Método para corroborar si hay cambios en habitaciones seleccionadas
            Clases.C_Asignacion asg = new Clases.C_Asignacion();
            string txtdescbit = "";

            if (dtgrdhabsel.Items.Count == 0)//Para eliminar todas las habitaciones asignadas a una camarera
            {

                asg.EliminarAsignPorCamarera(cm_act.idCamarera);
                
                
                if (sp_act!=null)
                    txtdescbit = "ELIMINACIÓN (NOMBRE CAM.='" + cm_act.nombre + " " + cm_act.apellido + "', CÉD CAM.='" + cm_act.cedula + "'; NOMBRE SUP.='" + sp_act.nombre + " " + sp_act.apellido + "', CÉD SUP.='" + sp_act.cedula + "'; ";
                else
                    txtdescbit = "ELIMINACIÓN (NOMBRE CAM.='" + cm_act.nombre + " " + cm_act.apellido + "', CÉD CAM.='" + cm_act.cedula + "'; NOMBRE SUP.='-SIN ASIGNAR-'; ";


                txtdescbit += "HABS.=";
                foreach (Clases.habitacionIqware h2 in hb_act)
                    txtdescbit += "'" + h2.RoomNo + "',";
                txtdescbit = txtdescbit.Remove(txtdescbit.Length - 1);
                txtdescbit += ")";


                Clases.Bitacora bitc = new Clases.Bitacora(1, 3, txtdescbit, user.login);    
                if (bitc.Guardar() == 1)
                    Console.WriteLine("Eliminación de asignación guardada en la bitácora");
                //----------------------------------------------------//

                MessageBox.Show("Asignación modificada satisfactoriamente", "Completado", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
                Close();
                return;


            }

            
            Clases.C_Camarera cam = dtgrdcam.SelectedItem as Clases.C_Camarera;
            Clases.C_Supervisor sup = dtgrdsup.SelectedItem as Clases.C_Supervisor;


            //-------------    Bitácora    ------------------------------------------//
            

            txtdescbit = "MODIFICACIÓN (";

            asg.idcamarera = cam.idCamarera;
            asg.idUsuario = user.idUsuario;

            if (dtgrdsup.SelectedIndex < 0)
                asg.idsupervisor = -1;
            else
                asg.idsupervisor = sup.idSupervisor;

            if (habaux.Count > 0)
            {

                if (cm_act.idSupervisor != -1 && dtgrdsup.Items.Count != 0)//Si hay supervisores asignados en la base de datos (Viejo y Nuevo)
                {

                    if (sp_act.idSupervisor != sup.idSupervisor)//Supervisores distinitos (anterior y nuevo)
                        txtdescbit += "NOMBRE SUP. ANT.='" + sp_act.nombre + " " + sp_act.apellido + "', CÉD SUP. ANT.='" + sp_act.cedula + "', NOMBRE SUP. NVO.='" + sup.nombre + " " + sup.apellido + "', CÉD SUP. NVO.='" + sup.cedula + "'; ";
                    else
                        txtdescbit += "NOMBRE SUP.='" + sup.nombre + " " + sup.apellido + "', CÉD SUP.='" + sup.cedula + "'; ";
                }
                else if (cm_act.idSupervisor == -1 && dtgrdsup.SelectedIndex >= 0)
                {//Si no hay en viejo y hay en nuevo

                    txtdescbit += "NOMBRE SUP. ANT.='SIN ASIGNAR', NOMBRE SUP. NVO.='" + sup.nombre + " " + sup.apellido + "', CÉD SUP. NVO.='" + sup.cedula + "'; ";
                }
                else if (cm_act.idSupervisor != -1 && dtgrdsup.Items.Count == 0)//Si hay viejo y no hay en nuevo
                {

                    txtdescbit += "NOMBRE SUP. ANT.='" + sp_act.nombre + " " + sp_act.apellido + "', CÉD SUP. ANT.='" + sp_act.cedula + "', NOMBRE SUP. NVO.='SIN ASIGNAR'; ";
                }

                Clases.C_Movimiento mov = new Clases.C_Movimiento();
                mov.idsupervisor =   dtgrdsup.SelectedIndex!=-1?sup.idSupervisor:-1;
                mov.idCamarera = cam.idCamarera;
                mov.fecha = DateTime.Today;

                if (mov.EditarMovSup() == 1)
                    Console.WriteLine("Se modificó el supervisor");

                
            }
            else
            {
                asg.EliminarAsignPorCamarera(cm_act.idCamarera);
                

                
                if (cm_act.idCamarera != cam.idCamarera)//Camareras distintas (anterior y nueva)
                    txtdescbit += "NOMBRE CAM. ANT.='" + cm_act.nombre + " " + cm_act.apellido + "', CÉD CAM. ANT.='" + cm_act.cedula + "', NOMBRE CAM. NVA.='" + cam.nombre + " " + cam.apellido + "', CÉD CAM. NVA.='" + cam.cedula + "'; ";
                else
                    txtdescbit += "NOMBRE CAM.='" + cam.nombre + " " + cam.apellido + "', CÉD CAM.='" + cam.cedula + "'; ";


                if (cm_act.idSupervisor != -1 && dtgrdsup.Items.Count != 0)//Si hay supervisores asignados en la base de datos (Viejo y Nuevo)
                {

                    if (sp_act.idSupervisor != sup.idSupervisor)//Supervisores distinitos (anterior y nuevo)
                        txtdescbit += "NOMBRE SUP. ANT.='" + sp_act.nombre + " " + sp_act.apellido + "', CÉD SUP. ANT.='" + sp_act.cedula + "', NOMBRE SUP. NVO.='" + sup.nombre + " " + sup.apellido + "', CÉD SUP. NVO.='" + sup.cedula + "'; ";
                    else
                        txtdescbit += "NOMBRE SUP.='" + sup.nombre + " " + sup.apellido + "', CÉD SUP.='" + sup.cedula + "'; ";
                }
                else if (cm_act.idSupervisor == -1 && dtgrdsup.SelectedIndex >= 0)
                {//Si no hay en viejo y hay en nuevo

                    txtdescbit += "NOMBRE SUP. ANT.='SIN ASIGNAR', NOMBRE SUP. NVO.='" + sup.nombre + " " + sup.apellido + "', CÉD SUP. NVO.='" + sup.cedula + "'; ";
                }
                else if (cm_act.idSupervisor != -1 && dtgrdsup.Items.Count == 0)//Si hay viejo y no hay en nuevo
                {

                    txtdescbit += "NOMBRE SUP. ANT.='" + sp_act.nombre + " " + sp_act.apellido + "', CÉD SUP. ANT.='" + sp_act.cedula + "', NOMBRE SUP. NVO.='SIN ASIGNAR'; ";
                }



                if (hb_ds)
                {
                    txtdescbit += "HABS. ANT.=";
                    foreach (Clases.habitacionIqware h2 in hb_act)
                        txtdescbit += "'" + h2.RoomNo + "',";


                    txtdescbit = txtdescbit.Remove(txtdescbit.Length - 1);
                    txtdescbit += "; ";

                }
                //----------------------------------------------------------------------------------//



                txtdescbit += "HABS. NVAS.=";//Bitácora


                foreach (Clases.habitacionIqware h in dtgrdhabsel.ItemsSource)
                {

                    txtdescbit += "'" + h.RoomNo + "',";//Bitácora

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
                    asg.Guardar();

                }
                

            }

            asg.Modificar();

            //---------Bitácora -------------------------------------------//
            txtdescbit = txtdescbit.Remove(txtdescbit.Length - 1);
            txtdescbit += ")";
            if (cm_act.idCamarera != cam.idCamarera || cm_act.idSupervisor != asg.idsupervisor || hb_ds)
            {
                Clases.Bitacora bit = new Clases.Bitacora(1,2,txtdescbit,user.login);
                if (bit.Guardar() == 1)
                    Console.WriteLine("Modificación de asignación guardada en la bitácora");
            }
            //----------------------------------------------------//

            MessageBox.Show("Asignación modificada satisfactoriamente", "Completado", MessageBoxButton.OK, MessageBoxImage.Information);
            DialogResult = true;
            Close();

        }

        private void tlCancelar_Click(object sender, RoutedEventArgs e)
        {
            dtgrdcam.ItemsSource = null;
            dtgrdhab.ItemsSource = null;
            dtgrdsup.ItemsSource = null;
            dtgrdhabsel.ItemsSource = null;
            txtBuscarCam.Text = "";
            txtBuscarHab.Text = "";
            txtBuscarSup.Text = "";
            DialogResult = false;
            this.Close();
        }

        #endregion


        #region EVENTOS Y MÉTODO PARA GESTIONAR BÚSQUEDA DE HABITACIONES Y LIMPIAR CAMPOS DE BÚSQUEDA 

        // Método de apoyo para la búsqueda
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

            aux = hab.filtrarhabitaciones2(txtBuscarHab.Text, habit, md, ps);

            if (aux.Count > 0)
                dtgrdhab.ItemsSource = aux;
            else
                dtgrdhab.ItemsSource = null;

        }


        //----------- TextBox Habitaciones Disponibles ----------------------------//
        private void txtBuscarHab_KeyUp(object sender, KeyEventArgs e)
        {
            dtgrdhab.ItemsSource = null;
            filtrado_datagrid_habdisp();

        }

        


        //Combobox Módulo
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


        //Combobox Piso
        private void cmbPiso_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dtgrdhab.ItemsSource = null;
            if (Convert.ToString(cmbPiso.SelectedItem) != null)
            {
                filtrado_datagrid_habdisp();
            }
        }


        //Limpiar campos de búsqueda
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

    }
}
