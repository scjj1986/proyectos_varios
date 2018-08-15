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
    /// Lógica de interacción para SuministroExtra.xaml
    /// </summary>
    public partial class SuministroExtra : Page
    {
        public Clases.C_Usuario user;

        public List<Clases.C_Extra> lext;

        public List<Clases.C_Extra> lmot = new List<Clases.C_Extra>();

        public int i = 0;

        public int k = 0;

        public string txtdescbit = "";

        public SuministroExtra()
        {
            InitializeComponent();
        }


        #region EVENTO CARGA DE LA PÁGINA

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dpFecha.DisplayDateStart = DateTime.Today.AddDays(-1);
            dpFecha.DisplayDateEnd = DateTime.Today;
            dpFecha.SelectedDate = DateTime.Today;
            Clases.C_Extra nodo = new Clases.C_Extra();
            lmot = nodo.listarMotivos();
        }

        #endregion

        #region EVENTO EN TEXTBOX DE HABITACIONES PARA FILTRADO Y LLENADO EN DATAGRID DE HABITACIONES
        private void txtBuscarHab_KeyUp(object sender, KeyEventArgs e)
        {
            Clases.habitacionIqware hab = new Clases.habitacionIqware();
            dtgrdhab.ItemsSource = null;
            if (txtBuscarHab.Text != "")
            {

                List<Clases.habitacionIqware> l = new List<Clases.habitacionIqware>();
                if (dpFecha.SelectedDate == DateTime.Today)
                {
                    
                    l=hab.filtrarhabitacionesExtra(txtBuscarHab.Text);
                    
                }
                else
                {
                    l = hab.filtrarhabitacionesExtraAyer(txtBuscarHab.Text);
                }
                if (l.Count > 0)
                {
                    dtgrdhab.ItemsSource = l;
                }
                else
                {
                    dtgrdsumcamb.ItemsSource = null;
                    dtgrdsumrep.ItemsSource = null;
                }
            }
            else
            {
                dtgrdsumcamb.ItemsSource = null;
                dtgrdsumrep.ItemsSource = null;
            }

        }

        #endregion

        #region EVENTO SELECCIÓN DE FILA DEL DATAGRID DE HABITACIONES

        private void dtgrdhab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgrdhab.ItemsSource != null)
            {

                i = 0;
                k = 0;
                Clases.habitacionIqware hab = dtgrdhab.SelectedItem as Clases.habitacionIqware;


                dtgrdsumcamb.ItemsSource = null;
                dtgrdsumrep.ItemsSource = null;
                lext = new List<Clases.C_Extra>();
                cargar_dg_sum_cambio(hab);//Carga del datagrid de cambio (Dependiendo de la habitación seleccionada)
                cargar_dg_sum_rep(hab);



            }
        }

        #endregion

        #region MÉTODOS DE APOYO PARA CARGAR DATAGRID DE SUMINISTROS DE CAMBIO Y REPOSICIÓN


        //Cambio
        public void cargar_dg_sum_cambio(Clases.habitacionIqware hab)
        {
            Clases.C_Suministro sm = new Clases.C_Suministro();
            

            
            List<Clases.C_Suministro> list = new List<Clases.C_Suministro>();
            dtgrdsumcamb.ItemsSource = sm.list_sum_cambio(hab.GuestTotal);
            list = new List<Clases.C_Suministro>();
            Clases.C_Extra next;
            DateTime fch = dpFecha.SelectedDate == null ? DateTime.Today : Convert.ToDateTime(dpFecha.SelectedDate);

                foreach (Clases.C_Suministro ls in dtgrdsumcamb.ItemsSource)//Se recorre el datagrid para verificar si hay extras de suministros sin movimientos de habitación
                {
                    Clases.C_Suministro nvo = new Clases.C_Suministro();
                    nvo = ls;
                    nvo.cantidadSal += nvo.TotalExtraSumFecha(hab.ID_Room,fch);//Se suman los extras en la cantidad real
                    Clases.C_Suministro aux = nvo.inc_sum_id(hab.ID_Room, fch, nvo.idSuministro);

                    if ((nvo.cantidadSal >= 0) && aux == null)
                    {
                        next = new Clases.C_Extra();
                        next.idHabitacion = hab.ID_Room;
                        next.nhab = hab.RoomNo;
                        next.fecha = Convert.ToDateTime(dpFecha.SelectedDate);
                        next.idSuministro = nvo.idSuministro;
                        next.observacion = "";
                        next = next.BuscarSumExtra();  
                        if (next == null)
                        {
                            next = new Clases.C_Extra();
                            next.idHabitacion = hab.ID_Room;
                            next.fecha = Convert.ToDateTime(dpFecha.SelectedDate);
                            next.idSuministro = nvo.idSuministro;
                            next.observacion = "";

                        }
                        else
                        {
                            nvo.observacion = next.observacion;
                        }

                        if (nvo.cantidadSal>0)
                            lext.Add(next);

                        list.Add(nvo);
                    }

                }
                dtgrdsumcamb.ItemsSource = list;


            
        }


        //Reposición
        public void cargar_dg_sum_rep(Clases.habitacionIqware hab)
        {
            Clases.C_Suministro sm = new Clases.C_Suministro();

            
            List<Clases.C_Suministro> list = new List<Clases.C_Suministro>();
            dtgrdsumrep.ItemsSource = sm.list_sum_rep(hab.GuestTotal);//Se inicializan en 0 los valores (excepto la cantidad estimada)
            list = new List<Clases.C_Suministro>();
            Clases.C_Extra next;
            DateTime fch = dpFecha.SelectedDate == null ? DateTime.Today : Convert.ToDateTime(dpFecha.SelectedDate);
            foreach (Clases.C_Suministro ls in dtgrdsumrep.ItemsSource)//Se recorre el datagrid para verificar si hay extras de suministros sin movimientos de habitación
            {
                    Clases.C_Suministro nvo = new Clases.C_Suministro();
                    nvo = ls;
                    nvo.cantidadSal += nvo.TotalExtraSumFecha(hab.ID_Room, fch);//Se suman los extras en la cantidad real
                    Clases.C_Suministro aux = nvo.inc_sum_id(hab.ID_Room, fch, nvo.idSuministro);

                    if ((nvo.cantidadSal >= 0) && aux == null)
                    {
                        next = new Clases.C_Extra();
                        next.idHabitacion = hab.ID_Room;
                        next.nhab = hab.RoomNo;
                        next.fecha = Convert.ToDateTime(dpFecha.SelectedDate);
                        next.idSuministro = nvo.idSuministro;
                        next.observacion = "";
                        next = next.BuscarSumExtra();
                        if (next == null)
                        {
                            next = new Clases.C_Extra();
                            next.idHabitacion = hab.ID_Room;
                            next.fecha = Convert.ToDateTime(dpFecha.SelectedDate);
                            next.idSuministro = nvo.idSuministro;
                            next.observacion = "";

                        }
                        else
                        {
                            nvo.observacion = next.observacion;
                        }

                        if (nvo.cantidadSal > 0)
                            lext.Add(next);

                        list.Add(nvo);
                    }
                    

           }

           dtgrdsumrep.ItemsSource = list;
            

            
        }

        #endregion

        #region EVENTO BOTÓN CANCELAR
        private void tlCancelar_Click(object sender, RoutedEventArgs e)
        {
            dtgrdhab.ItemsSource = null;
            dtgrdsumcamb.ItemsSource = null;
            dtgrdsumrep.ItemsSource = null;
        }

        #endregion

        #region MÉTODO BOOLEANO DE APOYO PARA VERIFICAR SI TODAS LAS CANTIDADES EXTRAS DE LOS DATAGRIDS DE CAMBIO Y REPOSICIÓN ESTÁN EN 0 (EVITAR GUARDADO DE EXTRAS CON TODOS LOS CAMPOS EN 0)

        public bool encero()
        {

            foreach (Clases.C_Suministro sm in dtgrdsumcamb.ItemsSource)
            {

                if (sm.cantidadSal > 0)
                {
                    return false;
                }
            }

            foreach (Clases.C_Suministro sm in dtgrdsumrep.ItemsSource)
            {

                if (sm.cantidadSal > 0)
                {
                    return false;
                }
            }
            
            return true;
        }

        #endregion


        #region MÉTODO BOOLEANO DE APOYO PARA CORROBORAR SI HAY SUMINISTROS EN LOS DATAGRIDS DE CAMBIO Y REPOSICIÓN CON CANTIDAD MAYOR QUE 0 Y NO TIENE OBSERVACIÓN
        public bool obs_vacio()
        {

            foreach (Clases.C_Suministro sm in dtgrdsumcamb.ItemsSource)
            {

                if (sm.cantidadSal > 0 && (sm.observacion=="" || sm.observacion==null))
                {
                    return true;
                }
            }

            foreach (Clases.C_Suministro sm in dtgrdsumrep.ItemsSource)
            {

                if (sm.cantidadSal > 0 && (sm.observacion == "" || sm.observacion == null))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion


        #region MÉTODO PARA ELIMINAR EXTRAS VIEJOS EN LA BASE DE DATOS
        public void eliminar_extras_viejos()
        {
            bool encontrado = false;
            Clases.habitacionIqware hb = dtgrdhab.SelectedItem as Clases.habitacionIqware;
            foreach (Clases.C_Extra item in lext)
            {

                encontrado = false;
                foreach (Clases.C_Suministro sm in dtgrdsumcamb.ItemsSource)
                {
                    if (item.idSuministro == sm.idSuministro && sm.cantidadSal>0)
                        encontrado = true;
                
                }

                foreach (Clases.C_Suministro sm in dtgrdsumrep.ItemsSource)
                {
                    if (item.idSuministro == sm.idSuministro && sm.cantidadSal > 0)
                        encontrado = true;

                }

                if (!encontrado)
                {
                    if (item.EliminarSuministroExtra() == 1)
                        Console.WriteLine("Extra eliminado");

                    if (item.RestarCantidadRealMov() == 1)
                        Console.WriteLine("Se restó la cantidad real del movimiento");

                    if (item.RestarSuciaEstimadaMov() == 1)
                        Console.WriteLine("Se restó la sucia estimada del movimiento");

                    
                    txtdescbit = "ELIMINACIÓN DE SUMINISTRO EXTRA ( NR. HAB='" + hb.RoomNo + "', SUMINISTRO='" + item.descripcion + "', CANTIDAD='" + item.cantidad + "', OBSERVACION='" + item.observacion + "')";
                    Clases.Bitacora bit = new Clases.Bitacora(7,3,txtdescbit,user.login);
                    if (bit.Guardar() == 1)
                        Console.WriteLine("Eliminación guardada en la bitácora");


                }
                
                    

            }    
        }

        #endregion

        #region MÉTODOS DE APOYO PARA ACTUALIZAR (MODIFICAR Y/O INSERTAR) EXTRAS

        public void actualizar_extras_nuevos_cambio()
        {

            Clases.C_Extra ext;
            Clases.habitacionIqware hb = dtgrdhab.SelectedItem as Clases.habitacionIqware;
            bool encontrado = false;
            foreach (Clases.C_Suministro sm in dtgrdsumcamb.ItemsSource)//Recorrido de los nuevos extras en el datagrid
            {

                encontrado = false;
                foreach (Clases.C_Extra item in lext)//Recorrido de los extras viejos
                {
                    if (hb.ID_Room == item.idHabitacion && sm.cantidadSal > 0 && sm.idSuministro == item.idSuministro)//Coincidencia de suministros (Editar)
                    {
                        encontrado = true;


                        if (sm.cantidadSal != item.cantidad || sm.observacion != item.observacion) {

                            ext = new Clases.C_Extra();
                            ext.idSuministro = sm.idSuministro;
                            ext.idHabitacion = hb.ID_Room;
                            ext.fecha = dpFecha.SelectedDate;
                            ext.cantidad = sm.cantidadSal;
                            ext.idUsuario = user.idUsuario;
                            ext.fechaModificacion = dpFecha.SelectedDate;
                            ext.observacion = sm.observacion.ToUpper();
                            ext.hora = DateTime.Now.ToString("HH:mm:ss");
                            ext.idCamarera = -1;
                            ext.nhab = hb.RoomNo;

                            if (ext.Editar2() == 1)
                                Console.WriteLine("Se editó el extra");
                            else
                                Console.WriteLine("Hubo un error");


                            if (item.RestarCantidadRealMov() == 1)//Restar la cantidad vieja del extra en cantidadReal en tabla movimiento
                                Console.WriteLine("Se restó la cantidad real del movimiento");
                            if (ext.SumarCantidadRealMov() == 1)//Sumar cantidad nueva del extra en cantidadReal
                                Console.WriteLine("Se sumó la cantidad real del movimiento");
                            if (ext.SumarSuciaEstimadaMov() == 1)//Sumar cantidad nueva del extra en sucia estimada del otro día (Si el extra es del día anterior)
                                Console.WriteLine("Se sumó la sucia estimada del movimiento");

                            
                            if (sm.cantidadSal != item.cantidad)
                               txtdescbit = "MODIFICACIÓN DE SUMINISTRO EXTRA (NR. HAB='" + ext.nhab + "', SUMINISTRO='" + sm.descripcion + "', CANTIDAD ANTERIOR='" + item.cantidad +"' CANTIDAD NUEVA='" + ext.cantidad + "',";
                            else
                              txtdescbit = "MODIFICACIÓN DE SUMINISTRO EXTRA (NR. HAB='" + ext.nhab + "', SUMINISTRO='" + sm.descripcion + "', CANTIDAD='" + ext.cantidad + "',";

                            if (sm.observacion != item.observacion)
                               txtdescbit += " OBSERVACIÓN ANTERIOR='" + item.observacion + "', OBSERVACIÓN NUEVA='" + sm.observacion + "')";
                            else
                              txtdescbit += " OBSERVACIÓN ='" + sm.observacion + "')";

                            Clases.Bitacora bit = new Clases.Bitacora(7,2,txtdescbit,user.login);
                            if (bit.Guardar() == 1)
                                Console.WriteLine("Modificación de extra guardada en la bitácora");

                        }
                        



                    }

                }

                if (!encontrado && sm.cantidadSal > 0)
                {
                    ext = new Clases.C_Extra();
                    ext.idSuministro = sm.idSuministro;
                    ext.idHabitacion = hb.ID_Room;
                    ext.fecha = dpFecha.SelectedDate;
                    ext.cantidad = sm.cantidadSal;
                    ext.idUsuario = user.idUsuario;
                    ext.fechaModificacion = dpFecha.SelectedDate;
                    ext.observacion = sm.observacion.ToUpper();
                    ext.hora = DateTime.Now.ToString("HH:mm:ss");
                    ext.idCamarera = -1;
                    ext.nhab = hb.RoomNo;
                    if (ext.Guardar() == 1)
                        Console.WriteLine("Se guardó el extra");
                    else
                        Console.WriteLine("Hubo un error");

                    if (ext.SumarCantidadRealMov() == 1)//Sumar cantidad nueva del extra en cantidadReal
                        Console.WriteLine("Se sumó la cantidad estimada del movimiento");
                    if (ext.SumarSuciaEstimadaMov() == 1)//Sumar cantidad nueva del extra en sucia estimada del otro día (Si el extra es del día anterior)
                        Console.WriteLine("Se sumó la sucia estimada del movimiento");

                    
                    txtdescbit = "INSERCIÓN DE SUMINISTRO EXTRA ( NR. HAB='" + ext.nhab + "', SUMINISTRO='" + sm.descripcion + "', CANTIDAD='" + sm.cantidadSal + "', OBSERVACION='" + sm.observacion + "')";
                    Clases.Bitacora bit = new Clases.Bitacora(7,1,txtdescbit,user.login);
                    if (bit.Guardar() == 1)
                        Console.WriteLine("Inserción de extra guardada en la bitácora");
                }

            }
        }

        public void actualizar_extras_nuevos_rep()
        {

            Clases.C_Extra ext;
            Clases.habitacionIqware hb = dtgrdhab.SelectedItem as Clases.habitacionIqware;
            bool encontrado = false;
            foreach (Clases.C_Suministro sm in dtgrdsumrep.ItemsSource)//Recorrido de los nuevos extras en el datagrid
            {

                encontrado = false;
                foreach (Clases.C_Extra item in lext)//Recorrido de los extras viejos
                {
                    if (hb.ID_Room == item.idHabitacion && sm.cantidadSal > 0 && sm.idSuministro == item.idSuministro )//Coincidencia de suministros (Editar)
                    {
                        encontrado = true;
                        

                        if (sm.cantidadSal != item.cantidad || sm.observacion != item.observacion)
                        {

                            ext = new Clases.C_Extra();
                            ext.idSuministro = sm.idSuministro;
                            ext.idHabitacion = hb.ID_Room;
                            ext.fecha = dpFecha.SelectedDate;
                            ext.cantidad = sm.cantidadSal;
                            ext.idUsuario = user.idUsuario;
                            ext.fechaModificacion = dpFecha.SelectedDate;
                            ext.observacion = sm.observacion.ToUpper();
                            ext.hora = DateTime.Now.ToString("HH:mm:ss");
                            ext.idCamarera = -1;
                            ext.nhab = hb.RoomNo;
                            if (ext.Editar2() == 1)
                                Console.WriteLine("Se editó el extra");
                            else
                                Console.WriteLine("Hubo un error");

                            if (item.RestarCantidadRealMov() == 1)//Restar la cantidad vieja del extra en cantidadReal en tabla movimiento
                                Console.WriteLine("Se restó la cantidad real del movimiento");
                            if (ext.SumarCantidadRealMov() == 1)//Sumar cantidad nueva del extra en cantidadReal
                                Console.WriteLine("Se sumó la cantidad real del movimiento");
                            if (ext.SumarSuciaEstimadaMov() == 1)//Sumar cantidad nueva del extra en sucia estimada del otro día (Si el extra es del día anterior)
                                Console.WriteLine("Se sumó la sucia estimada del movimiento");
                            
                            
                            if (sm.cantidadSal != item.cantidad)
                                txtdescbit = "MODIFICACIÓN DE SUMINISTRO EXTRA (NR. HAB='" + ext.nhab + "', SUMINISTRO='" + sm.descripcion + "', CANTIDAD ANTERIOR='" + item.cantidad + "' CANTIDAD NUEVA='" + ext.cantidad + "',";
                            else
                                txtdescbit = "MODIFICACIÓN DE SUMINISTRO EXTRA (NR. HAB='" + ext.nhab + "', SUMINISTRO='" + sm.descripcion + "', CANTIDAD='" + ext.cantidad + "',";

                            if (sm.observacion != item.observacion)
                                txtdescbit += " OBSERVACIÓN ANTERIOR='" + item.observacion + "', OBSERVACIÓN NUEVA='" + sm.observacion + "')";
                            else
                                txtdescbit += " OBSERVACIÓN ='" + sm.observacion + "')";

                            Clases.Bitacora bit = new Clases.Bitacora(7,2,txtdescbit,user.login);
                            if (bit.Guardar() == 1)
                                Console.WriteLine("Modificación de extra guardada en la bitácora");

                        }

                    }

                }

                if (!encontrado && sm.cantidadSal > 0)//Si no encuentra coincidencia, los ingresa
                {
                    ext = new Clases.C_Extra();
                    ext.idSuministro = sm.idSuministro;
                    ext.idHabitacion = hb.ID_Room;
                    ext.fecha = dpFecha.SelectedDate;
                    ext.cantidad = sm.cantidadSal;
                    ext.idUsuario = user.idUsuario;
                    ext.fechaModificacion = dpFecha.SelectedDate;
                    ext.observacion = sm.observacion.ToUpper();
                    ext.hora = DateTime.Now.ToString("HH:mm:ss");
                    ext.idCamarera = -1;
                    ext.nhab = hb.RoomNo;
                    if (ext.Guardar() == 1)
                        Console.WriteLine("Se guardó el extra");

                    if (ext.SumarCantidadRealMov() == 1)//Sumar cantidad nueva del extra en cantidadReal
                        Console.WriteLine("Se sumó la cantidad estimada del movimiento");
                    if (ext.SumarSuciaEstimadaMov() == 1)//Sumar cantidad nueva del extra en sucia estimada del otro día (Si el extra es del día anterior)
                        Console.WriteLine("Se sumó la sucia estimada del movimiento");

                    
                    txtdescbit = "INSERCIÓN DE SUMINISTRO EXTRA ( NR. HAB='" + ext.nhab + "', SUMINISTRO='" + sm.descripcion + "', CANTIDAD='" + sm.cantidadSal + "', OBSERVACION='" + sm.observacion + "')";
                    Clases.Bitacora bit = new Clases.Bitacora(7,1,txtdescbit,user.login); 
                    if (bit.Guardar() == 1)
                        Console.WriteLine("Inserción de extra guardada en la bitácora");
                }

            }
        }

        #endregion

        #region EVENTO CLICK BOTÓN GUARDAR
        private void tlGuardar_Click(object sender, RoutedEventArgs e)
        {


            if (dtgrdsumcamb.ItemsSource == null || dtgrdsumrep.ItemsSource == null)
            {

                MessageBox.Show("Tablas de suministros vacía", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (encero() && lext.Count==0)
            {
                MessageBox.Show("Debe colocar una cantidad mayor que 0 en algún suministro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }
            /*
            if (obs_vacio())
            {
                MessageBox.Show("Por cada suministro extra, debe colocar una observación", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }*/
            if (dpFecha.SelectedDate == null || Convert.ToString(dpFecha.SelectedDate) == "")
            {
                MessageBox.Show("Debe seleccionar la fecha del extra", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            eliminar_extras_viejos();
            actualizar_extras_nuevos_cambio();
            actualizar_extras_nuevos_rep();


            MessageBox.Show("Extra guardado satisfactoriamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            tlCancelar_Click(sender, e);
            
            

        }

        #endregion


        #region EVENTO CAMBIO DE VALOR DE TEXTBOX CANTIDAD DE CADA FILA DE LOS DATAGRID DE CAMBIO Y REPOSICIÓN
        
        private void tBoxValue_LostFocus(object sender, RoutedEventArgs e)
        {

            /*
            TextBox tb = sender as TextBox;
            bool limpia = true;
            if (tb.Name == "tBoxValue1")
                limpia = false;

            if (tb.Text == "")
                tb.Text = "0";*/

        }
        
        
        
        //Cambio
        private void tBoxValue_KeyUp(object sender, RoutedEventArgs e)
        {

            TextBox tb = sender as TextBox;
            int i = 0;           
            Clases.C_Suministro sm = dtgrdsumcamb.SelectedItem as Clases.C_Suministro;
            if (!int.TryParse(Convert.ToString(tb.Text), out i) && tb.Text != "")
            {

                tb.Text = "0";
            }
            else
            {

                sm.cantidadSal = tb.Text!=""? Convert.ToInt32(tb.Text):0;
            }

        }

        //Reposición
        private void tBoxValue2_KeyUp(object sender, KeyEventArgs e)
        {

            TextBox tb = sender as TextBox;
            int i = 0;
            Clases.C_Suministro sm = dtgrdsumrep.SelectedItem as Clases.C_Suministro;
            if (!int.TryParse(Convert.ToString(tb.Text), out i) && tb.Text != "")
            {

                tb.Text = "0";
            }
            else
            {

                sm.cantidadSal = tb.Text != "" ? Convert.ToInt32(tb.Text) : 0;
            }

        }


        #endregion


        #region EVENTO CARGA DE CADA COMBOBOX OBSERVACIÓN CONTENIDOS EN LOS DATAGRIDS DE CAMBIO Y REPOSICIÓN (OBTIENE OBSERVACIÓN COINCIDENTE EN CASO DE ESTAR EN LA BASE DE DATOS)
        
        //Datagrid de Cambio
        private void cmbObs_Loaded(object sender, RoutedEventArgs e)
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


        //Datagrid de Reposición
        private void cmbObs2_Loaded(object sender, RoutedEventArgs e)
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

        #region EVENTO CAMBIO DE VALOR DE COMBOBOXS DE LOS DATAGRIDS DE CAMBIO Y REPOSICIÓN

        //Datagrid Cambio
        private void cmbObs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            Clases.C_Suministro sm = dtgrdsumcamb.SelectedItem as Clases.C_Suministro;
            if (sm != null)
                sm.observacion = Convert.ToString(cmb.SelectedValue);
        }


        //Datagrid Reposición
        private void cmbObs2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            Clases.C_Suministro sm = dtgrdsumrep.SelectedItem as Clases.C_Suministro;
            if (sm != null)
                sm.observacion = Convert.ToString(cmb.SelectedValue);
        }

        #endregion


    }
}
