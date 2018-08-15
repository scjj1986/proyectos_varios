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
    /// Lógica de interacción para Registrar_Extra.xaml
    /// </summary>
    public partial class Registrar_Extra : MetroWindow
    {

        public List<Clases.habitacionIqware> lhe = new List<Clases.habitacionIqware>();//Lista de habitaciones donde se detectaron los extras
        public List<Clases.habitacionIqware> lhs = new List<Clases.habitacionIqware>();

        public List<Clases.C_Extra> lmot = new List<Clases.C_Extra>();// Lista de motivos (para la carga de opciones de cada combobox de los datagrids de cambio y reposición)

        public Clases.C_Camarera cam;//Datos de la camarera

        public Clases.C_Usuario user;

        public string hora;

        public int idhact = -1;

        public bool evt = false;

        public int i = 0;

        public int k = 0;
        public string txtdescbit = "";
    
        public Registrar_Extra()
        {
            InitializeComponent();
        }

        #region EVENTO CARGA DE LA PÁGINA

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            List<Clases.C_Camarera> lc = new List<Clases.C_Camarera>();
            lc.Add(cam);

            Clases.C_Extra nodo = new Clases.C_Extra();
            lmot=nodo.listarMotivos();

            evt = false;
            dtgrdcam2.ItemsSource = lc;
            dtgrdhabsel2.ItemsSource = lhe;
            dtgrdsumcamb.ItemsSource = null;
            dtgrdsumrep.ItemsSource = null;
        }

        #endregion


        #region EVENTO SELECCIÓN DE FILA EN HABITACIÓN (ACTUALIZACIÓN DE LHE Y CARGA DE LOS DATAGRIDS DE SUMINISTROS DE CAMBIO Y REPOSICIÓN)
        private void dtgrdhabsel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgrdhabsel2.SelectedIndex != -1)
            {
                Clases.habitacionIqware hbsl = dtgrdhabsel2.SelectedItem as Clases.habitacionIqware;
                i = 0;
                k = 0;

                if (idhact != -1)
                {
                    actualizar_lhe();
                }
                idhact = hbsl.ID_Room;

                foreach (Clases.habitacionIqware hs in lhe)
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

        #region MÉTODO DE APOYO PARA ACTUALIZAR LISTA DE HABITACIONES DONDE SE DETECTARON EXTRAS (LHE)

        public void actualizar_lhe()
        {
            foreach (Clases.habitacionIqware hs in lhe)
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
        private void cmbObs_Loaded(object sender, RoutedEventArgs e)//Combobox Cambio
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

        private void cmbObs2_Loaded(object sender, RoutedEventArgs e)//Combobox Reposición
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
        private void cmbObs_SelectionChanged(object sender, SelectionChangedEventArgs e)//Combobox Cambio
        {
            ComboBox cmb = sender as ComboBox;
            Clases.C_Suministro sm = dtgrdsumcamb.SelectedItem as Clases.C_Suministro;
            if (sm!=null)
                sm.observacion = Convert.ToString(cmb.SelectedValue);
        }

        private void cmbObs2_SelectionChanged(object sender, SelectionChangedEventArgs e)//Combobox Reposición
        {
            ComboBox cmb = sender as ComboBox;
            Clases.C_Suministro sm = dtgrdsumrep.SelectedItem as Clases.C_Suministro;
            if (sm != null)
                sm.observacion = Convert.ToString(cmb.SelectedValue);
        }

        #endregion

        #region MÉTODO PARA RECORRER LHS Y VERIFICAR SI HAY ALGUNA OBSERVACIÓN EN VACÍO 
        public bool obs_vacio()
        {

            foreach (Clases.habitacionIqware hs in lhe)
            {

                if (hs.lsumcamb != null)
                {
                    foreach (Clases.C_Suministro ls in hs.lsumcamb)
                    {

                        if (ls.observacion == "")
                            return true;
                    }
                }

                if (hs.lsumrep != null)
                {
                    foreach (Clases.C_Suministro ls in hs.lsumrep)
                    {

                        if (ls.observacion == "")
                            return true;
                    }
                }

            }
            return false;

        }

        #endregion


        #region MÉTODOS PARA ELIMINAR EXTRAS VIEJOS (DE EXISTIR) DE CAMBIO Y REPOSICIÓN (EXTRAS ACTUALES DE LA BASE DE DATOS QUE NO SE ENCUENTRAN EN LOS NUEVOS)


        public void eliminar_extras_viejos()//Método matriz
        {
            List<Clases.C_Extra> lext = new List<Clases.C_Extra>();

            foreach (Clases.habitacionIqware hb in lhs)//Recorrido por cada habitación (Extras en base de datos)
            {

                lext = hb.lextsumtipo(hb.ID_Room, -1, "CAMBIO", DateTime.Today);//Suministro extra de cambio de cada habitación (Base de Datos)

                eliminar_extras_viejos_cambio(lext);

                lext = hb.lextsumtipo(hb.ID_Room, -1, "REPOSICION", DateTime.Today);//Suministro extra de cambio de cada habitación (Base de Datos)

                eliminar_extras_viejos_rep(lext);
            }

        }
        public void eliminar_extras_viejos_cambio( List<Clases.C_Extra> lext)//Cambio
        {

            bool encontrado = false;
            if (lext!=null && lext.Count>0){
                string nomsum="";

                foreach (Clases.C_Extra sm in lext)//Lista de extras viejos (Base de Datos)
                {

                    encontrado = false;
                    nomsum="";

                    foreach (Clases.habitacionIqware hb2 in lhe)//Recorrido de los nuevos extras en cada habitación
                    {
                        if (hb2.lsumcamb != null && hb2.lsumcamb.Count>0)//Si hay extras de cambio en una habitación específica
                        {

                            foreach (Clases.C_Suministro sm2 in hb2.lsumcamb)///Recorrido del nuevo extra
                            {
                                if (sm2.IsSelected && sm.idHabitacion==hb2.ID_Room && sm2.idSuministro == sm.idSuministro)
                                    encontrado = true;

                                if (sm2.idSuministro == sm.idSuministro)
                                    nomsum=sm2.descripcion;

                            }

                        }

                    }

                    if (!encontrado)
                    {

                        if (sm.EliminarSuministroExtra() == 1)
                        {

                            Console.WriteLine("Extra de cambio eliminado");

                            //----------------------------- Bitácora -------------------------------//
                            txtdescbit = "ELIMINACIÓN DE SUMINISTRO EXTRA ( NR. HAB='" + sm.nhab + "', SUMINISTRO='" + sm.descripcion + "', CANTIDAD='" + sm.cantidad + "', OBSERVACION='" + sm.observacion + "')";
                            Clases.Bitacora bit = new Clases.Bitacora(5, 3, txtdescbit, user.login);
                            if (bit.Guardar()==1)
                                Console.WriteLine("Eliminación guardada en la bitácora");
                            //----------------------------------------------------------------------//



                        }
                            
                    }
                    

                }

            }

         }

        public void eliminar_extras_viejos_rep(List<Clases.C_Extra> lext)//Reposición
        {

            bool encontrado = false;
            string nomsum = "";
            if (lext != null && lext.Count > 0)
            {

                foreach (Clases.C_Extra sm in lext)//Lista de extras viejos (Base de Datos)
                {

                    encontrado = false;
                    nomsum = "";
                    foreach (Clases.habitacionIqware hb2 in lhe)//Recorrido de los nuevos extras en cada habitación
                    {
                        if (hb2.lsumrep != null && hb2.lsumrep.Count > 0)//Si hay extras de cambio en una habitación específica
                        {

                            foreach (Clases.C_Suministro sm2 in hb2.lsumrep)///Recorrido del nuevo extra
                            {
                                if (sm2.IsSelected && sm.idHabitacion == hb2.ID_Room && sm2.idSuministro == sm.idSuministro)
                                    encontrado = true;

                                if (sm2.idSuministro == sm.idSuministro)
                                    nomsum = sm2.descripcion;

                            }

                        }

                    }

                    if (!encontrado)
                    {

                        if (sm.EliminarSuministroExtra() == 1)
                        {
                            Console.WriteLine("Extra de reposición eliminado");

                            //----------------------------- Bitácora -------------------------------//
                            txtdescbit = "ELIMINACIÓN DE SUMINISTRO EXTRA ( NR. HAB='" + sm.nhab + "', SUMINISTRO='" + nomsum + "', CANTIDAD='" + sm.cantidad + "', OBSERVACION='" + sm.observacion + "')";
                            Clases.Bitacora bit = new Clases.Bitacora(5, 3, txtdescbit, user.login);
                            if (bit.Guardar() == 1)
                                Console.WriteLine("Eliminación guardada en la bitácora");
                            //----------------------------------------------------------------------//

                        }
                    }


                }

            }



        }

        #endregion


        #region MÉTODOS PARA ACTUALIZAR LOS EXTRAS NUEVOS EN FUNCIÓN A LOS EXTRAS VIEJOS (DE EXISTIR), SI HAY COINCIDENCIA EN LA BD, SE ACTUALIZA, DE LOS CONTRARIO, SE AGREGA

        public void actualizar_extras_nuevos()//Método matriz
        {

            foreach (Clases.habitacionIqware hb in lhe)
            {

                actualizar_extras_nuevos_cambio(hb, hb.lsumcamb);
                actualizar_extras_nuevos_rep(hb, hb.lsumrep);

            }

        }
        public void actualizar_extras_nuevos_cambio(Clases.habitacionIqware hb,List<Clases.C_Suministro> lext)//Cambio
        {

            bool encontrado = false;
            Clases.C_Extra ext;
            if (lext != null && lext.Count > 0)
            {

                foreach (Clases.C_Suministro sm in lext)//Lista de extras nuevos
                {

                    encontrado = false;

                    ext = new Clases.C_Extra();
                    foreach (Clases.habitacionIqware hb2 in lhs)//Recorrido de los extras viejos en cada habitación
                    {
                        if (hb2.lextcamb != null && hb2.lextcamb.Count > 0)//Si hay extras de cambio en una habitación específica
                        {

                            foreach (Clases.C_Extra sm2 in hb2.lextcamb)///Recorrido de extras viejos (por suministro)
                            {
                                if (sm.IsSelected && hb.ID_Room == hb2.ID_Room && sm2.idSuministro == sm.idSuministro)
                                {
                                    encontrado = true;
                                    //-------- Bitácora ------------------------------------------------//
                                    if (sm2.cantidad != sm.cantidad || sm2.observacion != sm.observacion)
                                    {
                                        ext.idSuministro = sm.idSuministro;
                                        ext.idHabitacion = hb.ID_Room;
                                        ext.fecha = DateTime.Now;
                                        ext.cantidad = sm.cantidad;
                                        ext.idUsuario = user.idUsuario;
                                        ext.fechaModificacion = DateTime.Now;
                                        ext.observacion = sm.observacion.ToUpper();
                                        ext.hora = DateTime.Now.ToString("HH:mm:ss");
                                        ext.idCamarera = cam.idCamarera;
                                        ext.nhab = hb.RoomNo;

                                        if (ext.Editar2() == 1)
                                            Console.WriteLine("");
                                        
                                        
                                        if (sm2.cantidad != sm.cantidad)
                                            txtdescbit = "MODIFICACIÓN DE SUMINISTRO EXTRA (NR. HAB='" + ext.nhab + "', SUMINISTRO='" + sm.descripcion + "', CANTIDAD ANTERIOR='" + sm2.cantidad +"' CANTIDAD NUEVA='" + ext.cantidad + "',";
                                        else
                                            txtdescbit = "MODIFICACIÓN DE SUMINISTRO EXTRA (NR. HAB='" + ext.nhab + "', SUMINISTRO='" + sm.descripcion + "', CANTIDAD='" + ext.cantidad + "',";

                                        if (sm2.observacion != sm.observacion)
                                            txtdescbit += " OBSERVACIÓN ANTERIOR='" + sm2.observacion + "', OBSERVACIÓN NUEVA='" + sm.observacion + "')";
                                        else
                                            txtdescbit += " OBSERVACIÓN ='" + sm.observacion + "')";

                                        Clases.Bitacora bit = new Clases.Bitacora(5,2,txtdescbit,user.login);
                                        if (bit.Guardar() == 1)
                                            Console.WriteLine("Modificación de extra guardada en la bitácora");
                                    }
                                    // --------------------------------------------------------------------//

                                }

                                

                            }

                        }

                    }

                    

                    if (!encontrado && sm.IsSelected)
                    {

                        ext.idSuministro = sm.idSuministro;
                        ext.idHabitacion = hb.ID_Room;
                        ext.fecha = DateTime.Now;
                        ext.cantidad = sm.cantidad;
                        ext.idUsuario = user.idUsuario;
                        ext.fechaModificacion = DateTime.Now;
                        ext.observacion = sm.observacion.ToUpper();
                        ext.hora = DateTime.Now.ToString("HH:mm:ss");
                        ext.idCamarera = cam.idCamarera;
                        ext.nhab = hb.RoomNo;
                        if (ext.Guardar() == 1)
                            Console.WriteLine("");

                        //----------------------------- Bitácora -------------------------------//
                        txtdescbit = "INSERCIÓN DE SUMINISTRO EXTRA ( NR. HAB='" + ext.nhab + "', SUMINISTRO='" + sm.descripcion + "', CANTIDAD='" + sm.cantidad + "', OBSERVACION='" + sm.observacion + "')";
                        Clases.Bitacora bit = new Clases.Bitacora(5,1,txtdescbit,user.login);
                        if (bit.Guardar() == 1)
                            Console.WriteLine("Inserción de extra guardada en la bitácora");
                        //---------------------------------------------------------------------//

                    }


                }

            }

        }
        public void actualizar_extras_nuevos_rep(Clases.habitacionIqware hb, List<Clases.C_Suministro> lext)//Reposición
        {

            bool encontrado = false;
            Clases.C_Extra ext;
            if (lext != null && lext.Count>0)
            {

                foreach (Clases.C_Suministro sm in lext)//Lista de extras nuevos
                {
                    encontrado = false;
                    ext = new Clases.C_Extra();

                    foreach (Clases.habitacionIqware hb2 in lhs)//Recorrido de los extras viejos
                    {
                        if (hb2.lextrep != null && hb2.lextrep.Count>0)//Si hay extras de cambio en una habitación específica
                        {

                            foreach (Clases.C_Extra sm2 in hb2.lextrep)///Recorrido de extra viejo de reposición
                            {
                                if (sm.IsSelected && hb.ID_Room == hb2.ID_Room && sm2.idSuministro == sm.idSuministro )
                                {
                                    encontrado = true;

                                    //-------- Bitácora ------------------------------------------------//
                                    if (sm2.cantidad != sm.cantidad || sm2.observacion != sm.observacion)
                                    {
                                        ext.idSuministro = sm.idSuministro;
                                        ext.idHabitacion = hb.ID_Room;
                                        ext.fecha = DateTime.Now;
                                        ext.cantidad = sm.cantidad;
                                        ext.idUsuario = user.idUsuario;
                                        ext.fechaModificacion = DateTime.Now;
                                        ext.observacion = sm.observacion.ToUpper();
                                        ext.hora = DateTime.Now.ToString("HH:mm:ss");
                                        ext.idCamarera = cam.idCamarera;
                                        ext.nhab = hb.RoomNo;

                                        if (ext.Editar2() == 1)
                                            Console.WriteLine("");
                                        
                                        
                                        

                                        if (sm2.cantidad != sm.cantidad)
                                            txtdescbit = "MODIFICACIÓN DE SUMINISTRO EXTRA (NR. HAB='" + ext.nhab + "', SUMINISTRO='" + sm.descripcion + "', CANTIDAD ANTERIOR='" + sm2.cantidad + "' CANTIDAD NUEVA='" + ext.cantidad + "',";
                                        else
                                            txtdescbit = "MODIFICACIÓN DE SUMINISTRO EXTRA (NR. HAB='" + ext.nhab + "', SUMINISTRO='" + sm.descripcion + "', CANTIDAD='" + ext.cantidad + "',";

                                        if (sm2.observacion != sm.observacion)
                                            txtdescbit += " OBSERVACIÓN ANTERIOR='" + sm2.observacion + "', OBSERVACIÓN NUEVA='" + sm.observacion + "')";
                                        else
                                            txtdescbit += " OBSERVACIÓN ='" + sm.observacion + "')";

                                        Clases.Bitacora bit = new Clases.Bitacora(5,2,txtdescbit,user.login);
                                        if (bit.Guardar() == 1)
                                            Console.WriteLine("Modificación de extra guardada en la bitácora");
                                    }
                                    //---------------------------------------------------------------//

                                }
                            }

                        }

                    }



                    if (!encontrado && sm.IsSelected)
                    {

                        ext.idSuministro = sm.idSuministro;
                        ext.idHabitacion = hb.ID_Room;
                        ext.fecha = DateTime.Now;
                        ext.cantidad = sm.cantidad;
                        ext.idUsuario = user.idUsuario;
                        ext.fechaModificacion = DateTime.Now;
                        ext.observacion = sm.observacion.ToUpper();
                        ext.hora = DateTime.Now.ToString("HH:mm:ss");
                        ext.idCamarera = cam.idCamarera;
                        ext.nhab = hb.RoomNo;
                        if (ext.Guardar() == 1)
                            Console.WriteLine("");

                        //----------------------------- Bitácora -------------------------------//
                        
                        txtdescbit = "INSERCIÓN DE SUMINISTRO EXTRA ( NR. HAB='" + ext.nhab + "', SUMINISTRO='" + sm.descripcion + "', CANTIDAD='" + sm.cantidad + "', OBSERVACION='" + sm.observacion + "')";
                        Clases.Bitacora bit = new Clases.Bitacora(5,1,txtdescbit,user.login);
                        if (bit.Guardar() == 1)
                            Console.WriteLine("Inserción de extra guardada en la bitácora");
                        //----------------------------------------------------------------------//
                    }


                }

            }

        }


        #endregion


        #region EVENTO GUARDAR 
        private void tlGuardar_Click(object sender, RoutedEventArgs e)
        {
            
            /*
            if (obs_vacio()){

                MessageBox.Show("Debe elegir una observación en todos los extras detectados", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }*/

            eliminar_extras_viejos();
            actualizar_extras_nuevos();

            MessageBox.Show("Extra(s) procesado(s) satisfactoriamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            evt = true;
            DialogResult = true;
            Close();
        }

        #endregion

        #region EVENTO CANCELAR

        private void tlCancelar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Desea cancelar esta operación?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                evt = true;
                DialogResult = false;
                Close();
            }

        }

        #endregion

        
    }
}
