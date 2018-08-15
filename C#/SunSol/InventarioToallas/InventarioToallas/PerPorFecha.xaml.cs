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
    /// Lógica de interacción para PerPorFecha.xaml
    /// </summary>
    public partial class PerPorFecha : Page
    {
        public PerPorFecha()
        {
            InitializeComponent();
        }

        public Clases.C_Usuario user;

        public List<Clases.C_Camarera> lcam = new List<Clases.C_Camarera>();

        public string txtdescbit = "";


        #region EVENTO BOTÓN CONSULTAR
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

            
            Clases.C_Camarera cm = new Clases.C_Camarera();

            DateTime fch = dtpFecha.SelectedDate == null ? DateTime.Today : Convert.ToDateTime(dtpFecha.SelectedDate);
            dtgrdcam.ItemsSource = null;
            dtgrdhabsel.ItemsSource = null;
            dtgrdsumcamb.ItemsSource = null;
            lcam = new List<Clases.C_Camarera>();
            lcam = cm.PerCamPorFecha(fch);
            dtgrdcam.ItemsSource = lcam;//Carga del datagrid de camareras en donde hubo pérdidas en una fecha específica
        }

        #endregion

        #region EVENTO SELECCIONAR FILA DE CAMARERA
        private void dtgrdcam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgrdcam.SelectedIndex != -1)
            {

                dtgrdhabsel.ItemsSource = null;
                dtgrdsumcamb.ItemsSource = null;
                DateTime fch = dtpFecha.SelectedDate == null ? DateTime.Today : Convert.ToDateTime(dtpFecha.SelectedDate);
                Clases.C_Camarera cam = dtgrdcam.SelectedItem as Clases.C_Camarera;
                Clases.habitacionIqware h = new Clases.habitacionIqware();
                dtgrdhabsel.ItemsSource = h.listarperhabxcamfecha(cam.idCamarera, fch);


            }
        }

        #endregion

        #region EVENTO SELECCIONAR FILA DE HABITACIÓN SELECCIONADA (CARGA DEL DATAGRID DE CAMBIO) 

        private void dtgrdhabsel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgrdhabsel.ItemsSource != null)
            {

                Clases.C_Suministro sm = new Clases.C_Suministro();
                Clases.C_Camarera cam = dtgrdcam.SelectedItem as Clases.C_Camarera;
                Clases.habitacionIqware hab = dtgrdhabsel.SelectedItem as Clases.habitacionIqware;
                dtgrdsumcamb.ItemsSource = null;
                DateTime fch = dtpFecha.SelectedDate == null ? DateTime.Today : Convert.ToDateTime(dtpFecha.SelectedDate);
                dtgrdsumcamb.ItemsSource = sm.list_per_sum(hab.ID_Room, fch, cam.horamov);//Carga de suministros de cambio en donde se presentó pérdida (Dependiendo de la habitación y la fecha)
            }
        }

        #endregion

        #region EVENTO CLICK DERECHO PARA ELIMINAR UNA FILA DEL DATAGRID DE CAMBIO

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (dtgrdsumcamb.SelectedIndex != -1)
            {
                Clases.habitacionIqware hb = dtgrdhabsel.SelectedItem as Clases.habitacionIqware;
                Clases.C_Camarera ca = dtgrdcam.SelectedItem as Clases.C_Camarera;
                Clases.C_Suministro sm = dtgrdsumcamb.SelectedItem as Clases.C_Suministro;


                if (user.nivel != 0 && user.nivel != 1)
                {
                    MessageBox.Show("No poseen lo permisos para hacer esta acción", "Denegado", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;

                }
                    


                if (MessageBox.Show("Desea eliminar la pérdida de " + sm.descripcion + " de la lista?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    string texto = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la observación","Observación","");//Modal pequeño para recopilar la observación


                    if (texto == "")
                    {
                        MessageBox.Show("Eliminación cancelada: Presionó botón 'Cancelar' o campo observación vacío", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;

                    }



                    Clases.C_Perdida per = new Clases.C_Perdida();
                    per.idHabitacion = hb.ID_Room;
                    per.idCamarera = ca.idCamarera;
                    per.idSuministro = sm.idSuministro;
                    per.hora = ca.horamov;

                    Clases.C_Movimiento mov = new Clases.C_Movimiento();
                    mov.idSuministro = sm.idSuministro;
                    mov.idHabitacion = hb.ID_Room;
                    mov.fecha = dtpFecha.SelectedDate;
                    mov.idCamarera = ca.idCamarera;
                    mov.observacion = texto;

                    if (mov.EditarMovPerdida() == 1)
                    {
                        Console.WriteLine("Modificada la observación en el movimiento");

                        
                        //--------- Bitácora ------------------------//
                        txtdescbit = "ELIMINACIÓN DE PÉRDIDA ( FECHA='" + Convert.ToString(dtpFecha.SelectedDate).Replace(" 12:00:00 a.m.", "") + "' NR. HAB='" + hb.RoomNo + "', SUMINISTRO='" + sm.descripcion + "', CANTIDAD='" + sm.cantidad + "', OBSERVACION='" + texto.ToUpper() + "')";
                        Clases.Bitacora bit = new Clases.Bitacora(6, 3, txtdescbit, user.login);
                        if (bit.Guardar() == 1)
                            Console.WriteLine("Eliminación guardada en la bitácora");
                        //-------------------------------------------//


                    }



                    if (per.EliminarPerdida(Convert.ToDateTime(dtpFecha.SelectedDate)) == 1)//Si la eliminación fue satisfactoria...
                    {
                        actualizar_dtgr_sum();//Se actualiza el datagrid de suministros (excluyendo el suministro que se caba de eliminar)
                        if (dtgrdsumcamb.ItemsSource == null && dtgrdhabsel.Items.Count>1)//Si se eliminaron todos los suministros de una habitación, y queda más de una habitación
                        {
                            actualizar_dtgr_habsel();//Se actualiza el datagrid de habitaciones

                        }
                        else if (dtgrdsumcamb.ItemsSource == null && dtgrdhabsel.Items.Count == 1)//Si se eliminaron todos los suministros de una habitación, la cual es la que queda en el datagrid
                        {
                            dtgrdhabsel.ItemsSource = null;//Se vacía el datagrid de habitaciones
                            actualizar_dtgr_cam();//y se actualiza el datagrid de camareras (excluyendo la fila de la camarera seleccionada, ya que no tiene pérdidas)
                        }
                        MessageBox.Show("Pérdida eliminada satisfactoriamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                        Clases.C_Camarera cm = new Clases.C_Camarera();
                        DateTime fch = dtpFecha.SelectedDate == null ? DateTime.Today : Convert.ToDateTime(dtpFecha.SelectedDate);
                        lcam = new List<Clases.C_Camarera>();
                        lcam = cm.PerCamPorFecha(fch);
                        
                        
                    }



                }
            }
        }

        #endregion

        #region MÉTODOS DE APOYO PARA LA ACTUALIZACIÓN DE LOS DATAGRID'S DE SUMINISTROS, HABITACIÓN Y CAMARERA EN CASO DE ELIMINACIÓN DE PÉRDIDA

        public void actualizar_dtgr_sum()//actualizar datagrid de suministros
        {
            Clases.C_Suministro sm = dtgrdsumcamb.SelectedItem as Clases.C_Suministro;
            List<Clases.C_Suministro> list = new List<Clases.C_Suministro>();
            Clases.C_Suministro nvo;
            foreach (Clases.C_Suministro ls in dtgrdsumcamb.ItemsSource)
            {

                nvo = new Clases.C_Suministro();
                if (ls.idSuministro != sm.idSuministro)
                {
                    nvo=ls;
                    list.Add(nvo);
                }
            }
            dtgrdsumcamb.ItemsSource = null;
            if (list.Count > 0)
                dtgrdsumcamb.ItemsSource = list;

        }


        public void actualizar_dtgr_habsel() //actualizar datagrid de habitaciones
        {
            Clases.habitacionIqware hb = dtgrdhabsel.SelectedItem as Clases.habitacionIqware;
            List<Clases.habitacionIqware> list = new List<Clases.habitacionIqware>();
            Clases.habitacionIqware nvo;
            foreach (Clases.habitacionIqware lh in dtgrdhabsel.ItemsSource)
            {

                nvo = new Clases.habitacionIqware();
                if (lh.ID_Room != hb.ID_Room)
                {
                    nvo = lh;
                    list.Add(nvo);
                }
            }
            dtgrdhabsel.ItemsSource = null;
            if (list.Count > 0)
                dtgrdhabsel.ItemsSource = list;

        }

        public void actualizar_dtgr_cam() //actualizar datagrid de camareras
        {
            Clases.C_Camarera cmr = dtgrdcam.SelectedItem as Clases.C_Camarera;
            List<Clases.C_Camarera> list = new List<Clases.C_Camarera>();
            Clases.C_Camarera nvo;
            foreach (Clases.C_Camarera lc in dtgrdcam.ItemsSource)
            {

                nvo = new Clases.C_Camarera();
                if (lc.idCamarera != cmr.idCamarera)
                {
                    nvo = lc;
                    list.Add(nvo);
                }
            }
            dtgrdcam.ItemsSource = null;
            if (list.Count > 0)
                dtgrdcam.ItemsSource = list;

        }

        #endregion

        private void txtBuscarCam_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBuscarCam.Text != "")
            {
                
                    List<Clases.C_Camarera> list = new List<Clases.C_Camarera>();
                    Clases.C_Camarera nodo;
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
                    dtgrdcam.ItemsSource = null;
                    if (list.Count > 0)
                        dtgrdcam.ItemsSource = list;
            }
            else
            {
                dtgrdcam.ItemsSource = lcam;
            }
        }
    }
}
