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
    /// Lógica de interacción para Registrar_Perdida.xaml
    /// </summary>
    public partial class Registrar_Perdida : MetroWindow
    {

        public List<Clases.habitacionIqware> lhp = new List<Clases.habitacionIqware>();//Lista de habitaciones donde se detectaron pérdidas

        public List<Clases.C_Perdida> lpersumbd = new List<Clases.C_Perdida>();//Lista de pérdidas actuales (Base de Datos)

        public Clases.C_Camarera cam;

        public Clases.C_Usuario user;

        public string hora;

        public int idhact=-1;

        public string txtdescbit = "";
        
        public Registrar_Perdida()
        {
            InitializeComponent();
        }

        #region EVENTO CARGA DE LA PÁGINA

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            List<Clases.C_Camarera> lc = new List<Clases.C_Camarera>();
            lc.Add(cam);
            evt = false;
            dtgrdcam2.ItemsSource = lc;
            dtgrdhabsel2.ItemsSource = lhp;
            dtgrdsumcamb2.ItemsSource = null;
            //DialogResult = false;
        }

        #endregion

        #region EVENTO SELECCIÓN DE FILA EN HABITACIÓN (ACTUALIZACIÓN DE LHP Y CARGA DEL DATAGRID DE CAMBIO)
        private void dtgrdhabsel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            if (dtgrdhabsel2.SelectedIndex != -1)
            {
                Clases.habitacionIqware hbsl = dtgrdhabsel2.SelectedItem as Clases.habitacionIqware;

                if (idhact != -1)
                {
                    actualizar_lhp_cam();
                }
                idhact = hbsl.ID_Room;

                foreach (Clases.habitacionIqware hs in lhp)
                {
                    if (hbsl.ID_Room == hs.ID_Room)
                    {
                        dtgrdsumcamb2.ItemsSource = hs.lsumcamb;

                    }

                }

            }




        }

        #endregion

        #region MÉTODO DE APOYO PARA ACTUALIZAR LISTA DE HABITACIONES DONDE SE DETECTARON PÉRDIDAS (LHP)

        public void actualizar_lhp_cam()
        {
            foreach (Clases.habitacionIqware hs in lhp)
            {
                if (idhact == hs.ID_Room)
                {

                    List<Clases.C_Suministro> list = new List<Clases.C_Suministro>();


                    Clases.C_Suministro smslc = dtgrdsumcamb2.SelectedItem as Clases.C_Suministro;


                    foreach (Clases.C_Suministro ls in dtgrdsumcamb2.ItemsSource)
                    {
                        Clases.C_Suministro nvo = new Clases.C_Suministro();
                        nvo = ls;

                        list.Add(nvo);



                    }
                    hs.lsumcamb = new List<Clases.C_Suministro>();
                    hs.lsumcamb = list;
                    dtgrdsumcamb2.ItemsSource = list;

                }

            }

        }



        public void reload_lhp_cam(string txt)
        {

            if (dtgrdhabsel2.SelectedIndex != -1)
            {
                Clases.habitacionIqware hbsl = dtgrdhabsel2.SelectedItem as Clases.habitacionIqware;

                if (idhact != -1)
                {
                    actualizar_lhp_cam();
                }
                idhact = hbsl.ID_Room;

                foreach (Clases.habitacionIqware hs in lhp)
                {
                    if (hbsl.ID_Room == hs.ID_Room)
                    {
                        dtgrdsumcamb2.ItemsSource = hs.lsumcamb;

                    }

                }

            }
        }

        #endregion

        #region EVENTOS PARA CARGAR DATOS DE CADA TEXTBOX OBSERVACIÓN DE CADA FILA DEL DATAGRID DE CAMBIO

        private void txtObs_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox tb = sender as TextBox;
            Clases.C_Suministro sm = dtgrdsumcamb2.SelectedItem as Clases.C_Suministro;
            sm.observacion = tb.Text;
        }

        #endregion



        #region MÉTODO PARA VERIFICAR EN LHP SI HAY UNA PÉRDIDA DE UN SUMINISTRO CONFIRMADA SIN OBSERVACIÓN

        public bool campos_confirmados_vacios()
        {

            foreach (Clases.habitacionIqware hs in lhp)
            {
                    foreach (Clases.C_Suministro ls in hs.lsumcamb)
                    {
                        
                        if (ls.IsSelected && ls.observacion=="")
                            return true;
                    }

            }
            return false;

        }



        #endregion

        #region MÉTODO PARA ADVERTIR AL USUARIO EN CASO DE DEJAR UNA PÉRDIDA EN LHP SIN CONFIRMAR

        public bool check_confirmar_sin_tildar()
        {

            foreach (Clases.habitacionIqware hs in lhp)
            {
                foreach (Clases.C_Suministro ls in hs.lsumcamb)
                {
                    
                    if (!ls.IsSelected)
                        return true;

                }

            }
            return false;

        }

        #endregion



        #region MÉTODO PARA ELIMINAR LAS PÉRDIDAS VIEJAS QUE ESTÁN EN LA BASE DE DATOS Y NO SE ENCUENTREN EN LAS NUEVAS 

        public void eliminar_perdidas_viejas()
        {

            Clases.C_Perdida per;
            bool encontrado = false;
            foreach (Clases.C_Perdida sper in lpersumbd)//Pérdida de suministros en la base de datos
            {

                encontrado = false;

                foreach (Clases.habitacionIqware hs in lhp)//Pérdida de suministros en la lista (ejecución)
                {
                    
                    foreach (Clases.C_Suministro ns in hs.lsumcamb){

                        if (sper.idHabitacion==hs.ID_Room && sper.idSuministro == ns.idSuministro && ns.IsSelected)
                        {
                            encontrado = true;
                        }

                        


                    }

                }

                if (!encontrado)
                {

                    per = new Clases.C_Perdida();
                    per.idSuministro = sper.idSuministro;
                    per.idHabitacion = sper.idHabitacion;
                    per.cantidad = sper.cantidad;
                    per.fecha = DateTime.Today;
                    per.idUsuario = user.idUsuario;
                    per.fechaModificacion = DateTime.Today;
                    per.observacion = sper.observacion.ToUpper();
                    per.hora = hora;
                    per.idCamarera = cam.idCamarera;
                    if (per.EliminarPerdida(DateTime.Today) == 1)
                    {
                        Console.WriteLine("Se eliminó la pérdida");
                    }

                    //--------- Bitácora ------------------------//
                    
                    txtdescbit = "ELIMINACIÓN DE PÉRDIDA ( NR. HAB='" + sper.nhab + "', SUMINISTRO='" + sper.nomsum + "', CANTIDAD='" + sper.cantidad + "', OBSERVACION='" + sper.observacion + "')";
                    Clases.Bitacora bit = new Clases.Bitacora(3,3,txtdescbit,user.login);
                    if (bit.Guardar() == 1)
                        Console.WriteLine("Eliminación guardada en la bitácora");
                    //-------------------------------------------//

                }

            }
        }

        #endregion

        #region MÉTODO PARA ACTUALIZAR LAS PÉRDIDAS EN LA BASE DE DATOS (SE ACTUALIZAN SI HAY COINCIDENCIA, DE LO CONTRARIO SE INSERTA)

        public void actualizar_perdidas_por_hab(Clases.habitacionIqware hs,List<Clases.C_Suministro>lsum)
        {
            Clases.C_Perdida per;
            
            bool encontrado = false;

             
                 
                 foreach (Clases.C_Suministro ls in lsum)//Pérdida de suministros en la lista (ejecución)
                 {

                     encontrado = false;

                     foreach (Clases.C_Perdida sper in lpersumbd)//Pérdida de suministros en la base de datos
                     {
                         if (sper.idHabitacion == hs.ID_Room && sper.idSuministro == ls.idSuministro && ls.IsSelected)
                         {
                                 encontrado = true;
                                 per = new Clases.C_Perdida();
                                 per.idSuministro = ls.idSuministro;
                                 per.idHabitacion = hs.ID_Room;
                                 per.cantidad = ls.cantidad;
                                 per.fecha = DateTime.Today;
                                 per.idUsuario = user.idUsuario;
                                 per.fechaModificacion = DateTime.Today;
                                 per.observacion = ls.observacion.ToUpper();
                                 per.hora = hora;
                                 per.idCamarera = cam.idCamarera;
                                 per.nhab = hs.RoomNo;
                                 if (per.Editar() == 1)
                                 {
                                     Console.WriteLine("Se modificó la pérdida");
                                 }


                                //----------------------------- Bitácora -------------------------------//
                                if (sper.cantidad != ls.cantidad || sper.observacion != ls.observacion) {

                                    

                                    if (sper.cantidad != ls.cantidad)
                                        txtdescbit = "MODIFICACIÓN DE PÉRDIDA (NR. HAB='" + hs.RoomNo + "', SUMINISTRO='" + ls.descripcion + "', CANTIDAD ANTERIOR='" + sper.cantidad + "', CANTIDAD NUEVA='" + ls.cantidad + "',";
                                    else
                                        txtdescbit = "MODIFICACIÓN DE PÉRDIDA (NR. HAB='" + hs.RoomNo + "', SUMINISTRO='" + ls.descripcion + "', CANTIDAD='" + ls.cantidad + "',";

                                    if (sper.observacion != ls.observacion)
                                        txtdescbit += " OBSERVACIÓN ANTERIOR='" + sper.observacion + "', OBSERVACIÓN NUEVA='" + ls.observacion + "')";
                                    else
                                        txtdescbit += " OBSERVACIÓN='" + ls.observacion + "')";

                                    Clases.Bitacora bit = new Clases.Bitacora(3,2,txtdescbit,user.login);
                                    if (bit.Guardar() == 1)
                                        Console.WriteLine("Modificación guardada en la bitácora");
                                  //----------------------------------------------------------------------//

                                }

                         }
                     }

                     if (!encontrado && ls.IsSelected)
                     {
                         
                         per = new Clases.C_Perdida();
                         per.idSuministro = ls.idSuministro;
                         per.idHabitacion = hs.ID_Room;
                         per.cantidad = ls.cantidad;
                         per.fecha = DateTime.Today;
                         per.idUsuario = user.idUsuario;
                         per.fechaModificacion = DateTime.Today;
                         per.observacion = ls.observacion.ToUpper();
                         per.hora = hora;
                         per.idCamarera = cam.idCamarera;
                         per.nhab = hs.RoomNo;
                         if (per.Guardar() == 1)
                         {
                             Console.WriteLine("Se guardó la pérdida");
                         }

                         //----------------------------- Bitácora -------------------------------//
                         
                         txtdescbit = "INSERCIÓN DE PÉRDIDA ( NR. HAB='" + hs.RoomNo + "', SUMINISTRO='" + ls.descripcion + "', CANTIDAD='" + per.cantidad + "', OBSERVACION='" + per.observacion + "')";
                         Clases.Bitacora bit = new Clases.Bitacora(3,1,txtdescbit,user.login); 
                         if (bit.Guardar() == 1)
                             Console.WriteLine("Inserción guardada en la bitácora");
                         //---------------------------------------------------------------------//


                     }

                 }

                 
                 

            
        }

        #endregion


        

        #region EVENTO BOTÓN GUARDAR

        private void tlGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (dtgrdsumcamb2.ItemsSource != null && campos_confirmados_vacios())
            {

                MessageBox.Show("Por cada pérdida confirmada, se requiere llenar su respectivo campo observación", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }
            if ((dtgrdsumcamb2.ItemsSource != null && check_confirmar_sin_tildar()) || dtgrdsumcamb2.ItemsSource == null)
            {
                if (MessageBox.Show("Se detectaron pérdidas sin confirmar. Desea continuar de todos modos??", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                {
                    return;
                }
            }
            Clases.C_Perdida pr = new Clases.C_Perdida();
            lpersumbd = pr.list_per_sum_cam(DateTime.Today, cam.idCamarera);

            foreach (Clases.habitacionIqware hs in lhp)
            {

                actualizar_perdidas_por_hab(hs, hs.lsumcamb);
            }

            eliminar_perdidas_viejas();

            MessageBox.Show("Pérdida(s) procesada(s) satisfactoriamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            evt = true;
            DialogResult = true;
            Close();
        }

        #endregion

        #region EVENTO BOTÓN CANCELAR

        private void tlCancelar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Al cancelar esta operación, omitirá todas las pérdidas. Desea continuar?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                
                evt = true;
                DialogResult = false;

                Close();
            }
        }

        #endregion

        #region EVENTO CIERRE DE LA VENTANA

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!evt)
            {
                if (MessageBox.Show("Al cancelar esta operación, omitirá todas las pérdidas. Desea continuar?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
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

        public bool evt = false;

        public bool lostfocus = false;

        private void txtObs_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.Text = tb.Text.ToUpper();
            /*
            
            TextBox tb = sender as TextBox;
            if (!lostfocus)
            {
                
                reload_lhp_cam(tb.Text);
                lostfocus = true;

            }
            else
            {

                lostfocus = false;
            }*/
        }

        

        
    }
}
