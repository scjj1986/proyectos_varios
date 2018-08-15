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
    /// Lógica de interacción para Registrar_Incidencia.xaml
    /// </summary>
    public partial class Registrar_Incidencia : MetroWindow
    {

        public List<Clases.habitacionIqware> lhi = new List<Clases.habitacionIqware>();//Lista de habitaciones con incidencia

        public List<Clases.C_Incidencia> lbdinc = new List<Clases.C_Incidencia>();

        public List<Clases.C_Incidencia> lmot = new List<Clases.C_Incidencia>();// Lista de motivos (para la carga de opciones de cada combobox de los datagrids de cambio y reposición)

        public Clases.C_Camarera cam;

        public Clases.C_Usuario user;

        public string hora;

        public int idhact = -1;

        public int evt = 0;

        public int i = 0;
        public int k = 0;

        public string txtdescbit = "";
        
        
        public Registrar_Incidencia()
        {
            InitializeComponent();
        }

        #region EVENTO CARGA DE LA PÁGINA
        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            List<Clases.C_Camarera> lc = new List<Clases.C_Camarera>();
            lc.Add(cam);

            Clases.C_Incidencia nodo = new Clases.C_Incidencia();
            nodo.idCamarera = cam.idCamarera;
            nodo.fecha= DateTime.Today;
            lbdinc = nodo.listarIncCamFecha();

            Clases.C_Incidencia nd = new Clases.C_Incidencia();
            lmot = nd.listarMotivos();


            cmbObsCamb.ItemsSource = lmot;
            cmbObsCamb.DisplayMemberPath = "observacion";
            cmbObsCamb.SelectedValuePath = "observacion";

            cmbObsRep.ItemsSource = lmot;
            cmbObsRep.DisplayMemberPath = "observacion";
            cmbObsRep.SelectedValuePath = "observacion";

            //evt = false;
            dtgrdcam2.ItemsSource = lc;
            dtgrdhabsel2.ItemsSource = lhi;
            dtgrdsumcamb.ItemsSource = null;
            dtgrdsumrep.ItemsSource = null;
            cmbObsCamb.IsEnabled = false;
            cmbObsRep.IsEnabled = false;
            cmbSelTodoCamb.IsEnabled = false;
            cmbSelTodoRep.IsEnabled = false;

        }

        #endregion

        #region EVENTO SELECCIÓN DE FILA EN HABITACIÓN (ACTUALIZACIÓN DE LHI Y CARGA DE LOS DATAGRIDS DE SUMINISTROS DE CAMBIO Y REPOSICIÓN)

        private void dtgrdhabsel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgrdhabsel2.SelectedIndex != -1)
            {

                cmbObsCamb.IsEnabled = true;
                cmbObsRep.IsEnabled = true;
                cmbSelTodoCamb.IsEnabled = true;
                cmbSelTodoRep.IsEnabled = true;
                
                Clases.habitacionIqware hbsl = dtgrdhabsel2.SelectedItem as Clases.habitacionIqware;
                i = 0;
                k = 0;

                if (idhact != -1)
                {
                    actualizar_lhi();
                }
                idhact = hbsl.ID_Room;

                foreach (Clases.habitacionIqware hs in lhi)
                {
                    if (hbsl.ID_Room == hs.ID_Room)
                    {
                        dtgrdsumcamb.ItemsSource = hs.lsumcamb;
                        dtgrdsumrep.ItemsSource = hs.lsumrep;

                    }

                }

            }
        }

        #endregion

        #region MÉTODO DE APOYO PARA ACTUALIZAR LISTA DE HABITACIONES DONDE SE DETECTARON INCIDENCIAS (LHI)

        public void actualizar_lhi()
        {
            foreach (Clases.habitacionIqware hs in lhi)
            {
                if (idhact == hs.ID_Room)
                {

                    if (hs.lsumcamb != null)
                    {
                        List<Clases.C_Suministro> list = new List<Clases.C_Suministro>();
                        foreach (Clases.C_Suministro ls in dtgrdsumcamb.ItemsSource)
                        {
                            Clases.C_Suministro nvo = new Clases.C_Suministro();
                            nvo = ls;
                            list.Add(nvo);
                        }
                        hs.lsumcamb = new List<Clases.C_Suministro>();
                        hs.lsumcamb = list;
                        dtgrdsumcamb.ItemsSource = list;
                    }


                    if (hs.lsumrep != null)
                    {
                        List<Clases.C_Suministro> list2 = new List<Clases.C_Suministro>();
                        foreach (Clases.C_Suministro ls in dtgrdsumrep.ItemsSource)
                        {
                            Clases.C_Suministro nvo = new Clases.C_Suministro();
                            nvo = ls;
                            list2.Add(nvo);
                        }
                        hs.lsumrep = new List<Clases.C_Suministro>();
                        hs.lsumrep = list2;
                        dtgrdsumrep.ItemsSource = list2;
                    }

                }

            }

        }

        #endregion

        #region EVENTOS PARA CARGAR DATOS DEL COMBOBOX OBSERVACIÓN DE CADA FILA DE LOS DATAGRIDS DE CAMBIO Y REPOSICIÓN
        private void cmbObs_Loaded(object sender, RoutedEventArgs e)//Cambio
        {

          

                ComboBox cmb = sender as ComboBox;
                cmb.ItemsSource = lmot;
                cmb.DisplayMemberPath = "observacion";
                cmb.SelectedValuePath = "observacion";
                int j = 0;


                foreach (Clases.C_Suministro sm in dtgrdsumcamb.ItemsSource)
                {


                    if (i == j)
                        cmb.SelectedValue = sm.observacion;


                    j++;
                }

                i++;

         
            

        }

        private void cmbObs2_Loaded(object sender, RoutedEventArgs e)//Reposición
        {

            

                ComboBox cmb = sender as ComboBox;
                cmb.ItemsSource = lmot;
                cmb.DisplayMemberPath = "observacion";
                cmb.SelectedValuePath = "observacion";
                int l = 0;
                foreach (Clases.C_Suministro sm in dtgrdsumrep.ItemsSource)
                {
                    if (k == l)
                        cmb.SelectedValue = sm.observacion;
                    l++;
                }
                k++;
            
            

        }

        #endregion

        #region EVENTOS CAMBIO DE VALOR EN CADA COMBOBOX DE LOS DATAGRIDS DE CAMBIO Y REPOSICIÓN PARA ACTUALIZAR


        public void actualizar_chk_fila_dtgrsumcamb(int nr)
        {
            List<Clases.C_Suministro> list = new List<Clases.C_Suministro>();
            int indx=0;
            foreach (Clases.C_Suministro s in dtgrdsumcamb.ItemsSource)
            {
                
                
                Clases.C_Suministro nvo = new Clases.C_Suministro();
                nvo = s;
                if (indx==nr)
                    nvo.IsSelected = true;
                list.Add(nvo);
                indx++;

            }

            dtgrdsumcamb.ItemsSource = null;
            dtgrdsumcamb.ItemsSource = list;
            i = 0;

        }

        

        public void actualizar_chk_fila_dtgrsumrep(int nr)
        {
            List<Clases.C_Suministro> list = new List<Clases.C_Suministro>();
            int indx = 0;
            foreach (Clases.C_Suministro s in dtgrdsumrep.ItemsSource)
            {


                Clases.C_Suministro nvo = new Clases.C_Suministro();
                nvo = s;
                if (indx == nr)
                    nvo.IsSelected = true;
                list.Add(nvo);
                indx++;

            }

            dtgrdsumrep.ItemsSource = null;
            dtgrdsumrep.ItemsSource = list;
            k = 0;

        }

        

        private void cmbObs_SelectionChanged(object sender, SelectionChangedEventArgs e)//Cambio
        {
            ComboBox cmb = sender as ComboBox;
            Clases.C_Suministro sm = dtgrdsumcamb.SelectedItem as Clases.C_Suministro;

            if (sm != null && dtgrdsumcamb.ItemsSource!=null)
            {
                sm.observacion = Convert.ToString(cmb.SelectedValue);
                actualizar_chk_fila_dtgrsumcamb(dtgrdsumcamb.SelectedIndex);
            }
                
        }

        private void cmbObs2_SelectionChanged(object sender, SelectionChangedEventArgs e)//Reposición
        {
            ComboBox cmb = sender as ComboBox;
            Clases.C_Suministro sm = dtgrdsumrep.SelectedItem as Clases.C_Suministro;
            if (sm != null && dtgrdsumrep.ItemsSource != null)
            {
                sm.observacion = Convert.ToString(cmb.SelectedValue);
                actualizar_chk_fila_dtgrsumrep(dtgrdsumrep.SelectedIndex);
            }
        }

        #endregion

        #region EVENTOS CHECKBOX "SELECCIONAR TODO" FUERA DEL DATAGRID DE CAMBIO (cmbSelTodoCamb)

        //Evento si está checkado el checkbox
        private void cmbSelTodoCamb_Checked(object sender, RoutedEventArgs e)
        {

            if (dtgrdsumcamb.Items.Count > 0)
            {
                if (cmbObsCamb.SelectedIndex != -1)
                {
                    List<Clases.C_Suministro> list = new List<Clases.C_Suministro>();
                    foreach (Clases.C_Suministro s in dtgrdsumcamb.ItemsSource)
                    {
                        Clases.C_Suministro nvo = new Clases.C_Suministro();
                        nvo = s;
                        nvo.IsSelected = true;
                        nvo.observacion = Convert.ToString(cmbObsCamb.SelectedValue);
                        list.Add(nvo);

                    }

                    dtgrdsumcamb.ItemsSource = null;
                    dtgrdsumcamb.ItemsSource = list;
                    i = 0;

                }
            }

        }

        //Evento si no está checkado el checkbox
        private void cmbSelTodoCamb_Unchecked(object sender, RoutedEventArgs e)
        {

            if (dtgrdsumcamb.Items.Count > 0)
            {

                List<Clases.C_Suministro> list = new List<Clases.C_Suministro>();
                cmbObsCamb.SelectedIndex = -1;
                foreach (Clases.C_Suministro s in dtgrdsumcamb.ItemsSource)
                {
                    Clases.C_Suministro nvo = new Clases.C_Suministro();
                    nvo = s;
                    nvo.IsSelected = false;
                    nvo.observacion = "";
                    list.Add(nvo);

                }
                dtgrdsumcamb.ItemsSource = null;
                dtgrdsumcamb.ItemsSource = list;
                i = 0;


            }

        }




        #endregion
        #region EVENTO Y MÉTODO RELACIONADO CON CHECKBOX "CONFIRMAR" (chkConf) DEL DATAGRID DE CAMBIO

        //Evento si no está checkado checkbox confirmar (observación vacío)
        private void chkConf_Unchecked(object sender, RoutedEventArgs e)
        {
            Clases.C_Suministro sm = dtgrdsumcamb.SelectedItem as Clases.C_Suministro;
            if (sm != null && dtgrdsumcamb.ItemsSource != null)
            {
                sm.observacion = "";
                actualizar_unchk_fila_dtgrsumcamb(dtgrdsumcamb.SelectedIndex);
            }
        }

        //Método de apoyo para actualizar el unchecked del chkConf de una fila específica, en su binding relacionado (IsSelected)
        public void actualizar_unchk_fila_dtgrsumcamb(int nr)
        {
            List<Clases.C_Suministro> list = new List<Clases.C_Suministro>();
            int indx = 0;
            foreach (Clases.C_Suministro s in dtgrdsumcamb.ItemsSource)
            {


                Clases.C_Suministro nvo = new Clases.C_Suministro();
                nvo = s;
                if (indx == nr)
                    nvo.IsSelected = false;
                list.Add(nvo);
                indx++;

            }

            dtgrdsumcamb.ItemsSource = null;
            dtgrdsumcamb.ItemsSource = list;
            i = 0;

        }



        #endregion



        #region EVENTOS CHECKBOX "SELECCIONAR TODO" FUERA DEL DATAGRID DE REPOSICIÓN (cmbSelTodoRep)

        //Evento si está checkado el checkbox
        private void cmbSelTodoRep_Checked(object sender, RoutedEventArgs e)
        {
            if (dtgrdsumrep.Items.Count > 0)
            {
                if (cmbObsRep.SelectedIndex != -1)
                {
                    List<Clases.C_Suministro> list = new List<Clases.C_Suministro>();
                    foreach (Clases.C_Suministro s in dtgrdsumrep.ItemsSource)
                    {
                        Clases.C_Suministro nvo = new Clases.C_Suministro();
                        nvo = s;
                        nvo.IsSelected = true;
                        nvo.observacion = Convert.ToString(cmbObsRep.SelectedValue);
                        list.Add(nvo);

                    }

                    dtgrdsumrep.ItemsSource = null;
                    dtgrdsumrep.ItemsSource = list;
                    k = 0;

                }
            }

        }

        //Cuando no está checkado
        private void cmbSelTodoRep_Unchecked(object sender, RoutedEventArgs e)
        {
            if (dtgrdsumrep.Items.Count > 0)
            {

                List<Clases.C_Suministro> list = new List<Clases.C_Suministro>();
                cmbObsRep.SelectedIndex = -1;
                foreach (Clases.C_Suministro s in dtgrdsumrep.ItemsSource)
                {
                    Clases.C_Suministro nvo = new Clases.C_Suministro();
                    nvo = s;
                    nvo.IsSelected = false;
                    nvo.observacion = "";
                    list.Add(nvo);

                }
                dtgrdsumrep.ItemsSource = null;
                dtgrdsumrep.ItemsSource = list;
                k = 0;


            }
        }

        #endregion
        #region EVENTO Y MÉTODO RELACIONADO CON CHECKBOX "CONFIRMAR" (chkConf) DEL DATAGRID DE REPOSICIÓN

        private void chkConf2_Unchecked(object sender, RoutedEventArgs e)
        {
            Clases.C_Suministro sm = dtgrdsumrep.SelectedItem as Clases.C_Suministro;
            if (sm != null && dtgrdsumrep.ItemsSource != null)
            {
                sm.observacion = "";
                sm.IsSelected = false;
                actualizar_unchk_fila_dtgrsumrep(dtgrdsumrep.SelectedIndex);
            }
        }

        public void actualizar_unchk_fila_dtgrsumrep(int nr)
        {
            List<Clases.C_Suministro> list = new List<Clases.C_Suministro>();
            int indx = 0;
            foreach (Clases.C_Suministro s in dtgrdsumrep.ItemsSource)
            {


                Clases.C_Suministro nvo = new Clases.C_Suministro();
                nvo = s;
                if (indx == nr)
                    nvo.IsSelected = false;
                list.Add(nvo);
                indx++;

            }

            dtgrdsumrep.ItemsSource = null;
            dtgrdsumrep.ItemsSource = list;
            k = 0;

        }

        #endregion


        #region MÉTODO PARA VERIFICAR EN LHI SI HAY UNA INCIDENCIA DE UN SUMINISTRO CONFIRMADA SIN OBSERVACIÓN

        public bool campos_confirmados_vacios()
        {

            foreach (Clases.habitacionIqware hs in lhi)
            {

                if (hs.lsumcamb != null)
                {
                    foreach (Clases.C_Suministro ls in hs.lsumcamb)
                    {

                        if (ls.IsSelected && ls.observacion == "")
                            return true;
                    }
                }

                if (hs.lsumrep != null)
                {
                    foreach (Clases.C_Suministro ls in hs.lsumrep)
                    {

                        if (ls.IsSelected && ls.observacion == "")
                            return true;
                    }
                }

            }
            return false;

        }

        #endregion


        #region MÉTODO PARA ADVERTIR AL USUARIO EN CASO DE DEJAR UNA INCIDENCIA EN LHI
        public bool check_confirmar_sin_tildar()
        {

            foreach (Clases.habitacionIqware hs in lhi)
            {

                if (hs.lsumcamb != null)
                {
                    foreach (Clases.C_Suministro ls in hs.lsumcamb)
                    {

                        if (!ls.IsSelected)
                            return true;

                    }
                }

                if (hs.lsumrep != null)
                {
                    foreach (Clases.C_Suministro ls in hs.lsumrep)
                    {

                        if (!ls.IsSelected)
                            return true;

                    }
                }

            }
            return false;

        }

        #endregion

        #region MÉTODO PARA ELIMINAR INCIDENCIAS ACTUALES

        public void eliminar_incidencias_viejas()//Método para eliminar incidencias viejas
        {
            bool encontrado = false;
            if (lbdinc.Count > 0 && lbdinc != null)
            {
                
                foreach (Clases.C_Incidencia auxl in lbdinc) {
                    encontrado = false;

                    foreach (Clases.habitacionIqware hb in lhi)
                    {

                        if (hb.lsumcamb != null)
                        {
                            foreach (Clases.C_Suministro sm in hb.lsumcamb)
                            {
                                if (sm.IsSelected && hb.ID_Room == auxl.idHabitacion && sm.idSuministro == auxl.idSuministro)
                                    encontrado = true;

                            }

                        }

                        if (hb.lsumrep != null)
                        {
                            foreach (Clases.C_Suministro sm in hb.lsumrep)
                            {
                                if (sm.IsSelected && hb.ID_Room == auxl.idHabitacion && sm.idSuministro == auxl.idSuministro)
                                    encontrado = true;

                            }

                        }

                    }

                    if (!encontrado)
                    {
                        Clases.C_Incidencia inc = new Clases.C_Incidencia();
                        inc.idHabitacion = auxl.idHabitacion;
                        inc.idSuministro = auxl.idSuministro;
                        inc.fecha = DateTime.Today;
                        if (inc.EliminarPorSumHabFecha() == 1)
                        {
                            Console.WriteLine("Se eliminaron las incidencias satisfactoriamente");

                            //----------------------------- Bitácora -------------------------------//
                            
                            txtdescbit = "ELIMINACIÓN DE INCIDENCIA ( NR. HAB='" + auxl.nhab + "', SUMINISTRO='" + auxl.nomsum + "', CANTIDAD='" + auxl.cantidad + "', OBSERVACION='" + auxl.observacion + "')";
                            Clases.Bitacora bit = new Clases.Bitacora(4,3,txtdescbit,user.login);
                            if (bit.Guardar() == 1)
                                Console.WriteLine("Eliminación guardada en la bitácora");
                            //----------------------------------------------------------------------//

                        }
                            

                    }

                
                }


            }
            
            
            
            
            
        }

        #endregion

        #region MÉTODO PARA GUARDAR LAS NUEVAS INCIDENCIAS

        public void guardar_incidencias_nuevas()
        {

            bool encontrado = false;
            foreach (Clases.habitacionIqware hb in lhi)
            {

                if (hb.lsumcamb != null)//Suministros de Cambio
                {
                    

                    foreach (Clases.C_Suministro sm in hb.lsumcamb)
                    {

                        encontrado = false;
                        Clases.C_Incidencia inc = new Clases.C_Incidencia();
                        inc.idHabitacion = hb.ID_Room;
                        inc.idCamarera = cam.idCamarera;
                        inc.fecha = DateTime.Today;
                        inc.hora = hora;
                        inc.nhab = hb.RoomNo;
                        inc.idUsuario = user.idUsuario;
                        inc.fechaModificacion = DateTime.Today;
                        inc.idSuministro = sm.idSuministro;
                        inc.cantidad = sm.cantidad;
                        inc.observacion = sm.observacion;
                        encontrado = false;
                        

                        if (lbdinc.Count > 0 && lbdinc != null)
                        {
                            foreach (Clases.C_Incidencia auxl in lbdinc){

                                if (sm.IsSelected && hb.ID_Room == auxl.idHabitacion && sm.idSuministro == auxl.idSuministro)
                                {

                                    encontrado = true;
                                    if (inc.Editar() == 1)
                                        Console.WriteLine("Incidencia Editada");


                                    //--------------------------------- Bitácora ------------------------------------//
                                    if (auxl.cantidad != sm.cantidad || auxl.observacion != sm.observacion)
                                    {
                                        

                                        if (auxl.cantidad != sm.cantidad)
                                            txtdescbit = "MODIFICACIÓN DE INCIDENCIA (NR. HAB='" + inc.nhab + "', SUMINISTRO='" + sm.descripcion + "', CANTIDAD ANTERIOR='" + auxl.cantidad + "' CANTIDAD NUEVA='" + sm.cantidad + "',";
                                        else
                                           txtdescbit = "MODIFICACIÓN DE INCIDENCIA (NR. HAB='" + inc.nhab + "', SUMINISTRO='" + sm.descripcion + "', CANTIDAD='" + sm.cantidad + "',";

                                        if (auxl.observacion != sm.observacion)
                                            txtdescbit += " OBSERVACIÓN ANTERIOR='" + auxl.observacion + "', OBSERVACIÓN NUEVA='" + sm.observacion + "')";
                                        else
                                            txtdescbit += " OBSERVACIÓN ='" + sm.observacion + "')";

                                        Clases.Bitacora bit = new Clases.Bitacora(4,2,txtdescbit,user.login);
                                        if (bit.Guardar() == 1)
                                            Console.WriteLine("Modificación de incidencia guardada en la bitácora");
                                        //-----------------------------------------------------------------------------//

                                    }

                                }

                            }

                        }


                        if (sm.IsSelected && !encontrado)
                        {
                            
                            if (inc.Guardar() == 1)
                                Console.WriteLine("Incidencia Guardada");


                            //----------------------------- Bitácora -------------------------------//
                            txtdescbit = "INSERCIÓN DE INCIDENCIA ( NR. HAB='" + inc.nhab + "', SUMINISTRO='" + sm.descripcion + "', CANTIDAD='" + sm.cantidad + "', OBSERVACION='" + sm.observacion + "')";
                            Clases.Bitacora bit = new Clases.Bitacora(4,1,txtdescbit,user.login);
                            if (bit.Guardar() == 1)
                                Console.WriteLine("Inserción de incidencia guardada en la bitácora");
                            //----------------------------------------------------------------------//
                        }
                    }

                }

                if (hb.lsumrep != null)//Suministros de Reposición
                {
                    

                    foreach (Clases.C_Suministro sm in hb.lsumrep)
                    {
                        encontrado = false;
                        Clases.C_Incidencia inc = new Clases.C_Incidencia();
                        inc.idHabitacion = hb.ID_Room;
                        inc.idCamarera = cam.idCamarera;
                        inc.fecha = DateTime.Today;
                        inc.hora = hora;
                        inc.nhab = hb.RoomNo;
                        inc.idUsuario = user.idUsuario;
                        inc.fechaModificacion = DateTime.Today;
                        inc.idSuministro = sm.idSuministro;
                        inc.cantidad = sm.cantidad;
                        inc.observacion = sm.observacion;
                        encontrado = false;

                        if (lbdinc.Count > 0 && lbdinc != null)
                        {
                            foreach (Clases.C_Incidencia auxl in lbdinc)
                            {

                                if (sm.IsSelected && hb.ID_Room == auxl.idHabitacion && sm.idSuministro == auxl.idSuministro)
                                {

                                    encontrado = true;
                                    if (inc.Editar() == 1)
                                        Console.WriteLine("Incidencia Editada");

                                    if (auxl.cantidad != sm.cantidad || auxl.observacion != sm.observacion)
                                    {
                                        

                                        if (auxl.cantidad != sm.cantidad)
                                            txtdescbit = "MODIFICACIÓN DE INCIDENCIA (NR. HAB='" + inc.nhab + "', SUMINISTRO='" + sm.descripcion + "', CANTIDAD ANTERIOR='" + auxl.cantidad + "' CANTIDAD NUEVA='" + sm.cantidad + "',";
                                        else
                                            txtdescbit = "MODIFICACIÓN DE INCIDENCIA (NR. HAB='" + inc.nhab + "', SUMINISTRO='" + sm.descripcion + "', CANTIDAD='" + sm.cantidad + "',";

                                        if (auxl.observacion != sm.observacion)
                                            txtdescbit += " OBSERVACIÓN ANTERIOR='" + auxl.observacion + "', OBSERVACIÓN NUEVA='" + sm.observacion + "')";
                                        else
                                            txtdescbit += " OBSERVACIÓN ='" + sm.observacion + "')";

                                        Clases.Bitacora bit = new Clases.Bitacora(4,2,txtdescbit,user.login);
                                        if (bit.Guardar() == 1)
                                            Console.WriteLine("Modificación de incidencia guardada en la bitácora");

                                    }

                                }

                            }

                        }


                        if (sm.IsSelected && !encontrado)
                        {

                            if (inc.Guardar() == 1)
                                Console.WriteLine("Incidencia Guardada");

                            
                            txtdescbit = "INSERCIÓN DE INCIDENCIA ( NR. HAB='" + inc.nhab + "', SUMINISTRO='" + sm.descripcion + "', CANTIDAD='" + sm.cantidad + "', OBSERVACION='" + sm.observacion + "')";
                            Clases.Bitacora bit = new Clases.Bitacora(4,1,txtdescbit,user.login);
                            if (bit.Guardar() == 1)
                                Console.WriteLine("Inserción de incidencia guardada en la bitácora");
                        }
                    }

                }
            }
        }//Guardar incidencias nuevas


        #endregion

        #region EVENTO BOTÓN GUARDAR
        private void tlGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (dtgrdsumcamb.ItemsSource != null && campos_confirmados_vacios())
            {

                MessageBox.Show("Por cada incidencia confirmada, se requiere llenar su respectivo campo observación", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }

            if (check_confirmar_sin_tildar())
            {
                if (MessageBox.Show("Se detectaron incidencias sin confirmar. Desea continuar de todos modos??", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                {
                    return;
                }
            }


            eliminar_incidencias_viejas();
            guardar_incidencias_nuevas();

            MessageBox.Show("Incidencia(s) procesada(s) satisfactoriamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            evt = 1;
            DialogResult = true;
            
            Close();

        }

        #endregion

        #region EVENTO BOTÓN CANCELAR

        private void tlCancelar_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Al cancelar esta operación, omitirá todas las incidencias. Desea continuar?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

                evt = 1;
                DialogResult = false;

                Close();
            }
        }

        #endregion

        #region EVENTO CIERRE DE LA VENTANA

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (evt==0)
            {
                if (MessageBox.Show("Al cancelar esta operación, omitirá todas las incidencias. Desea continuar?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    DialogResult = false;

                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        #endregion

        

        




        

        


    }
}
