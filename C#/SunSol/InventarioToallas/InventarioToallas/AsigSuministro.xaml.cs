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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Input;

namespace InventarioToallas
{
    
    public partial class AsigSuministro : Page
    {
        public AsigSuministro()
        {
            InitializeComponent();
        }

        public int idhabact = -1;

        public Clases.C_Usuario user;

        public List<Clases.C_Camarera> lcam = new List<Clases.C_Camarera>();//Lista de camarera

        public List<Clases.habitacionIqware> lhs = null;//Lista de Habitaciones seleccionadas

        public List<Clases.habitacionIqware> lhp = new List<Clases.habitacionIqware>();//LIsta de Pérdidas

        public List<Clases.habitacionIqware> lhi = new List<Clases.habitacionIqware>();//Lista de Incidencias

        public List<Clases.habitacionIqware> lhe = new List<Clases.habitacionIqware>();//Lista de Extras

        public List<Clases.C_Movimiento> lista_mov_sum_cambio = new List<Clases.C_Movimiento>();//Lista de movimiento de suministros de cambio

        public List<Clases.C_Movimiento> lista_mov_sum_rep = new List<Clases.C_Movimiento>();//Lista de movimiento de suministros de reposición

        public string txtdescbit = "";



        #region EVENTO CARGA DE LA PÁGINA

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {


            dtgrdcam.ItemsSource = null;
            dtgrdhabsel.ItemsSource = null;
            dtgrdsumcamb.ItemsSource = null;
            dtgrdsumrep.ItemsSource = null;
            Clases.C_Camarera cam = new Clases.C_Camarera();
            lcam = cam.ListAsignHabCamHoy_AsgSum();
            dtgrdcam.ItemsSource = lcam;

            
        }

        #endregion

        #region BUSCAR CAMARERAS QUE TENGAN HABITACIONES ASIGNADAS Y NO TENGAN SUMINISTROS ASIGNADOS A LA FECHA ACTUAL (FILTRAR POR CAMPO DE TEXTO)

        private void txtBuscarCam_KeyUp(object sender, KeyEventArgs e)
        {
            Clases.C_Camarera cam = new Clases.C_Camarera();
            List<Clases.C_Camarera> aux = new List<Clases.C_Camarera>();
            dtgrdcam.ItemsSource = null;

            if (txtBuscarCam.Text != "")
            {
                aux = cam.Filtrado_ListAsignHabCamHoy_AsgSum(txtBuscarCam.Text);
                if (aux.Count > 0)
                {
                    dtgrdcam.ItemsSource = aux;                  
                   
                }

            }
            else
            {

                dtgrdcam.ItemsSource = lcam;
            }
        }

        #endregion

        #region EVENTO PARA ELEGIR UNA FILA DE CAMARERA EN EL DATAGRID

        private void dtgrdcam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgrdcam.SelectedIndex != -1)
            {

                update = false;
                dtgrdsumcamb.ItemsSource = null;
                dtgrdsumrep.ItemsSource = null;
                Clases.C_Camarera cam = dtgrdcam.SelectedItem as Clases.C_Camarera;
                Clases.habitacionIqware h = new Clases.habitacionIqware();

                Clases.C_Movimiento mv = new Clases.C_Movimiento();

                mv.idCamarera = cam.idCamarera;
                mv.fecha = DateTime.Today;

                lista_mov_sum_cambio = mv.lista_estimados_cambio_cam(cam.idCamarera, DateTime.Today);//Carga de los últimos movimientos de los suministros de cambio
                lista_mov_sum_rep = mv.lista_estimados_rep_cam(cam.idCamarera, DateTime.Today);//Carga de los últimos movimientos de los suministros de reposición

                

                if (mv.BuscarMovCamFecha() != null)//Si hay movimiento de esa camarera a la fecha actual
                    update = true;


                dtgrdhabsel.ItemsSource = h.listarhabasigxcam(cam.idCamarera, DateTime.Today);//Cargar las habitaciones asignadas a la camarera en el datagrid de habitaciones

                lhs = new List<Clases.habitacionIqware>();//Lista de Habitaciones seleccionadas (Lista multiligada en donde cada nodo contiene una habitación y a su vez su lista de suministros de cambio y reposicion)
                idhabact = -1;

                foreach (Clases.habitacionIqware hs in dtgrdhabsel.ItemsSource)//Recorrido de las habitaciones seleccionadas y carga de lhs (Lista de habitaciones y en cada nodo contiene listado de suministros de cambio y reposición)
                {
                    Clases.habitacionIqware nvo = new Clases.habitacionIqware();//Instancia de cada nodo de lhs
                    nvo = hs;

                    cargar_lista_cambio_hab(nvo);//Carga de lsumcamb(Lista de suministros de cambio) en nodo nuevo (nvo)
                    cargar_lista_rep_hab(nvo);//Carga de lsumrep(Lista de suministros de reposición) en nodo nuevo (nvo)


                    nvo.cargar_list_ext_tipo(cam.idCamarera);//Carga de extras (de tenerlos) en cada habitación
                    lhs.Add(nvo);//Anexo del nodo nuevo a lhs

                }


            }
        }

        #endregion

       

        #region EVENTOS CLICK EN CHECKBOX SELECCIONAR TODO DE DATAGRIDS DE SUMINISTROS (CAMBIO Y REPOSICIÓN)

            #region CAMBIO
        //----------------Cambio (Sucia Real) si está tildado----------------------------------//

        private void chkSelectAll1_Checked(object sender, RoutedEventArgs e)
        {
            if (!evt)
            {

                if (dtgrdsumcamb.Items.Count > 0)
                {
                    List<Clases.C_Suministro> list = new List<Clases.C_Suministro>();
                    foreach (Clases.C_Suministro s in dtgrdsumcamb.ItemsSource)
                    {
                        Clases.C_Suministro nvo = new Clases.C_Suministro();
                        nvo = s;
                        nvo.suciaReal = nvo.suciaEstimada;
                        nvo.IsSelected2 = true;
                        list.Add(nvo);

                    }
                    dtgrdsumcamb.ItemsSource = null;
                    dtgrdsumcamb.ItemsSource = list;

                    Clases.habitacionIqware hbt = dtgrdhabsel.SelectedItem as Clases.habitacionIqware;


                    foreach (Clases.habitacionIqware hs in lhs)
                    {
                        if (hbt.ID_Room == hs.ID_Room)
                        {

                            hs.lsumcamb = list;
                        }

                    }
                }

            }

        }


        //----------------Cambio (Sucia Real) si no está tildado----------------------------------//
        private void chkSelectAll1_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!evt)
            {
                if (dtgrdsumcamb.Items.Count > 0)
                {
                    List<Clases.C_Suministro> list = new List<Clases.C_Suministro>();
                    foreach (Clases.C_Suministro s in dtgrdsumcamb.ItemsSource)
                    {
                        Clases.C_Suministro nvo = new Clases.C_Suministro();
                        nvo = s;
                        nvo.suciaReal = 0;
                        nvo.IsSelected2 = false;
                        list.Add(nvo);

                    }
                    dtgrdsumcamb.ItemsSource = null;
                    dtgrdsumcamb.ItemsSource = list;

                    Clases.habitacionIqware hbt = dtgrdhabsel.SelectedItem as Clases.habitacionIqware;


                    foreach (Clases.habitacionIqware hs in lhs)
                    {
                        if (hbt.ID_Room == hs.ID_Room)
                        {

                            hs.lsumcamb = list;
                        }

                    }
                }
            }

        }

        public bool evt = false;



        //----------------Cambio (Cantidad Entrante Real) si está tildado----------------------------------//
        private void chkSelectAll_Checked(object sender, RoutedEventArgs e)
        {

            if (!evt)
            {
                if (dtgrdsumcamb.Items.Count > 0)
                {
                    List<Clases.C_Suministro> list = new List<Clases.C_Suministro>();
                    foreach (Clases.C_Suministro s in dtgrdsumcamb.ItemsSource)
                    {
                        Clases.C_Suministro nvo = new Clases.C_Suministro();
                        nvo = s;
                        nvo.cantidadSal = nvo.cantidadEstimada;
                        nvo.IsSelected = true;
                        list.Add(nvo);

                    }
                    dtgrdsumcamb.ItemsSource = null;
                    dtgrdsumcamb.ItemsSource = list;

                    Clases.habitacionIqware hbt = dtgrdhabsel.SelectedItem as Clases.habitacionIqware;


                    foreach (Clases.habitacionIqware hs in lhs)
                    {
                        if (hbt.ID_Room == hs.ID_Room)
                        {

                            hs.lsumcamb = list;
                        }

                    }
                }
            }

        }


        //----------------Cambio (Cantidad Entrante Real) si no está tildado----------------------------------//
        private void chkSelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!evt)
            {

                if (dtgrdsumcamb.Items.Count > 0)
                {
                    List<Clases.C_Suministro> list = new List<Clases.C_Suministro>();
                    foreach (Clases.C_Suministro s in dtgrdsumcamb.ItemsSource)
                    {
                        Clases.C_Suministro nvo = new Clases.C_Suministro();
                        nvo = s;
                        nvo.cantidadSal = 0;
                        nvo.IsSelected = false;
                        list.Add(nvo);

                    }
                    dtgrdsumcamb.ItemsSource = null;
                    if (list.Count > 0)
                    {

                        dtgrdsumcamb.ItemsSource = list;
                    }
                }
            }
        }

        #endregion

            #region REPOSICIÓN
        //----------------Reposición (Cantidad Entrante Real) si está tildado----------------------------------//

        private void chkSelectAll2_Checked(object sender, RoutedEventArgs e)
        {
            if (!evt)
            {

                if (dtgrdsumrep.Items.Count > 0)
                {
                    List<Clases.C_Suministro> list = new List<Clases.C_Suministro>();
                    foreach (Clases.C_Suministro s in dtgrdsumrep.ItemsSource)
                    {
                        Clases.C_Suministro nvo = new Clases.C_Suministro();
                        nvo = s;
                        nvo.cantidadSal = nvo.cantidadEstimada;
                        nvo.IsSelected = true;
                        list.Add(nvo);

                    }
                    dtgrdsumrep.ItemsSource = null;
                    dtgrdsumrep.ItemsSource = list;
                    Clases.habitacionIqware hbt = dtgrdhabsel.SelectedItem as Clases.habitacionIqware;
                    foreach (Clases.habitacionIqware hs in lhs)
                    {
                        if (hbt.ID_Room == hs.ID_Room)
                        {

                            hs.lsumrep = list;
                        }

                    }
                }
            }
        }


        //----------------Reposición (Cantidad Entrante Real) si no está tildado----------------------------------//
        private void chkSelectAll2_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!evt)
            {

                if (dtgrdsumrep.Items.Count > 0)
                {
                    List<Clases.C_Suministro> list = new List<Clases.C_Suministro>();
                    foreach (Clases.C_Suministro s in dtgrdsumrep.ItemsSource)
                    {
                        Clases.C_Suministro nvo = new Clases.C_Suministro();
                        nvo = s;
                        nvo.cantidadSal = 0;
                        nvo.IsSelected = false;
                        list.Add(nvo);

                    }
                    dtgrdsumrep.ItemsSource = null;
                    if (list.Count > 0)
                    {

                        dtgrdsumrep.ItemsSource = list;
                    }
                }
            }
        }

        //--------------------------------------------------------//
        #endregion

        #endregion

        #region EVENTOS CLICK EN LOS CHECKBOXS DE CADA FILA DE LOS DATAGRIDS DE CAMBIO Y REPOSICIÓN

            #region CAMBIO

        //--------- Cambio (Sucia Real) -------------------------------//
        private void chkSucCamb_Click(object sender, RoutedEventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            Clases.C_Suministro sm = dtgrdsumcamb.SelectedItem as Clases.C_Suministro;
            if (dtgrdsumcamb.Items.Count > 0)
            {
                List<Clases.C_Suministro> list = new List<Clases.C_Suministro>();
                foreach (Clases.C_Suministro s in dtgrdsumcamb.ItemsSource)
                {
                    Clases.C_Suministro nvo = new Clases.C_Suministro();
                    nvo = s;

                    if (s.idSuministro == sm.idSuministro)
                    {
                        if ((bool)chk.IsChecked)
                            nvo.suciaReal = s.suciaEstimada;
                        else
                            nvo.suciaReal = 0;
                    }
                    list.Add(nvo);

                }
                dtgrdsumcamb.ItemsSource = null;
                dtgrdsumcamb.ItemsSource = list;

                Clases.habitacionIqware hbt = dtgrdhabsel.SelectedItem as Clases.habitacionIqware;


                foreach (Clases.habitacionIqware hs in lhs)
                {
                    if (hbt.ID_Room == hs.ID_Room)
                    {

                        hs.lsumcamb = list;
                    }

                }
            }
        }


        //---------- Cambio (Cantidad Entrante Real) ----------------//
        private void chkEntrCamb_Click(object sender, RoutedEventArgs e)
        {


            CheckBox chk = sender as CheckBox;
            Clases.C_Suministro sm = dtgrdsumcamb.SelectedItem as Clases.C_Suministro;
            if (dtgrdsumcamb.Items.Count > 0)
            {
                List<Clases.C_Suministro> list = new List<Clases.C_Suministro>();
                foreach (Clases.C_Suministro s in dtgrdsumcamb.ItemsSource)
                {
                    Clases.C_Suministro nvo = new Clases.C_Suministro();
                    nvo = s;

                    if (s.idSuministro == sm.idSuministro)
                    {
                        if ((bool)chk.IsChecked)
                            nvo.cantidadSal = s.cantidadEstimada;
                        else

                            nvo.cantidadSal = 0;
                    }
                    list.Add(nvo);

                }
                dtgrdsumcamb.ItemsSource = null;
                dtgrdsumcamb.ItemsSource = list;

                Clases.habitacionIqware hbt = dtgrdhabsel.SelectedItem as Clases.habitacionIqware;


                foreach (Clases.habitacionIqware hs in lhs)
                {
                    if (hbt.ID_Room == hs.ID_Room)
                    {

                        hs.lsumcamb = list;
                    }

                }
            }






        }


        #endregion

            #region REPOSICIÓN

        //---------- Reposición (Cantidad Entrante Real) ----------------//
        private void chkEntrRep_Click(object sender, RoutedEventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            Clases.C_Suministro sm = dtgrdsumrep.SelectedItem as Clases.C_Suministro;
            if (dtgrdsumrep.Items.Count > 0)
            {
                List<Clases.C_Suministro> list = new List<Clases.C_Suministro>();
                foreach (Clases.C_Suministro s in dtgrdsumrep.ItemsSource)
                {
                    Clases.C_Suministro nvo = new Clases.C_Suministro();
                    nvo = s;
                    if (s.idSuministro == sm.idSuministro)
                    {
                        if ((bool)chk.IsChecked)
                            nvo.cantidadSal = s.cantidadEstimada;
                        else
                            nvo.cantidadSal = 0;
                    }
                    list.Add(nvo);

                }
                dtgrdsumrep.ItemsSource = null;
                dtgrdsumrep.ItemsSource = list;
                Clases.habitacionIqware hbt = dtgrdhabsel.SelectedItem as Clases.habitacionIqware;
                foreach (Clases.habitacionIqware hs in lhs)
                {
                    if (hbt.ID_Room == hs.ID_Room)
                    {

                        hs.lsumrep = list;
                    }

                }
            }

        }

        #endregion

        #endregion



        public bool lostfocus = false;//Variable booleana para evitar múltiples ejecuciones de la pérdida de foco

        #region Métodos para guardar y actualizar datos de las habitaciones y sus suministros


        #region MÉTODOS PARA RECARGAR EL DATAGRID DE SUMINISTROS DE CAMBIO DEPENDIENDO DE LA HABITACIÓN SELECCIONADA Y ACTUALIZAR LHS (DATA DE HABITACIONES CON SUS RESPECTIVOS SUMINISTROS)

        public void actualizar_lhs_cam(string txt,bool limpia)
        {
            foreach (Clases.habitacionIqware hs in lhs)
            {
                if (idhabact == hs.ID_Room)
                {
                    
                    List<Clases.C_Suministro> list = new List<Clases.C_Suministro>();


                    Clases.C_Suministro smslc = dtgrdsumcamb.SelectedItem as Clases.C_Suministro;


                    foreach (Clases.C_Suministro ls in dtgrdsumcamb.ItemsSource)
                    {
                        Clases.C_Suministro nvo = new Clases.C_Suministro();
                        nvo = ls;
                        if (smslc.idSuministro==ls.idSuministro)
                            if (limpia)
                                nvo.cantidadSal = Convert.ToInt32(txt);
                            else
                                nvo.suciaReal = Convert.ToInt32(txt);

                        list.Add(nvo);

                    }


                    hs.lsumcamb = new List<Clases.C_Suministro>();
                    hs.lsumcamb = list;
                    dtgrdsumcamb.ItemsSource = list;

                }

            }

        }

        public void reload_lhs_cam(string txt,bool limpia)
        {

            if (dtgrdhabsel.SelectedIndex != -1)
            {



                Clases.habitacionIqware hbsl = dtgrdhabsel.SelectedItem as Clases.habitacionIqware;

                if (idhabact != -1 && txt!="")
                {
                    actualizar_lhs_cam(txt,limpia);
                }

                idhabact = hbsl.ID_Room;


                foreach (Clases.habitacionIqware hs in lhs)
                {
                    if (hbsl.ID_Room == hs.ID_Room)
                    {
                        dtgrdsumcamb.ItemsSource = hs.lsumcamb;

                    }

                }

            }
        }


        #endregion


        #region MÉTODOS PARA RECARGAR EL DATAGRID DE SUMINISTROS DE REPOSICIÓN DEPENDIENDO DE LA HABITACIÓN SELECCIONADA Y ACTUALIZAR LHS (DATA DE HABITACIONES CON SUS RESPECTIVOS SUMINISTROS)

        public void actualizar_lhs_rep(string txt)
        {
            foreach (Clases.habitacionIqware hs in lhs)
            {
                if (idhabact == hs.ID_Room)
                {

                    List<Clases.C_Suministro> list = new List<Clases.C_Suministro>();


                    Clases.C_Suministro smslc = dtgrdsumrep.SelectedItem as Clases.C_Suministro;


                    foreach (Clases.C_Suministro ls in dtgrdsumrep.ItemsSource)
                    {
                        Clases.C_Suministro nvo = new Clases.C_Suministro();
                        nvo = ls;
                        if (smslc.idSuministro == ls.idSuministro)
                            nvo.cantidadSal = Convert.ToInt32(txt);

                        list.Add(nvo);

                    }
                    hs.lsumrep = new List<Clases.C_Suministro>();
                    hs.lsumrep = list;
                    dtgrdsumrep.ItemsSource = list;

                }

            }

        }

        public void reload_lhs_rep(string txt)
        {

            if (dtgrdhabsel.SelectedIndex != -1)
            {

                Clases.habitacionIqware hbsl = dtgrdhabsel.SelectedItem as Clases.habitacionIqware;
                if (idhabact != -1 && txt != "")
                {
                    actualizar_lhs_rep(txt);
                }

                idhabact = hbsl.ID_Room;
                foreach (Clases.habitacionIqware hs in lhs)
                {
                    if (hbsl.ID_Room == hs.ID_Room)
                    {
                        dtgrdsumrep.ItemsSource = hs.lsumrep;

                    }

                }

            }
        }

        

        #endregion

        #endregion



        #region EVENTO PARA VALIDACIÓN NUMÉRICA EN CADA CAMPO DE TEXTO DE LOS DATAGRIDS DE SUMINISTROS (CAMBIO Y REPOSICIÓN)

        //TextBox en Datagrid de suministros de Cambio...
        private void tBoxValue_KeyUp(object sender, RoutedEventArgs e)
        {
            
            TextBox tb = sender as TextBox;
            int i = 0;
            lostfocus = false;
            Clases.C_Suministro sm = dtgrdsumcamb.SelectedItem as Clases.C_Suministro;
            if (!int.TryParse(Convert.ToString(tb.Text), out i) && tb.Text!="")
            {
                
                tb.Text = "0";
            }
            
          


        }


        //TextBox en Datagrid de suministros de Reposición...
        private void tBoxValue2_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox tb = sender as TextBox;
            int i = 0;
            lostfocus = false;
            if (!int.TryParse(Convert.ToString(tb.Text), out i) && tb.Text != "")
            {

                tb.Text = "0";
            }
        }

        #endregion


        #region PÉRDIDA DE FOCO EN CADA CAMPO DE TEXTO DE LOS DATAGRID SUMINISTROS (CAMBIO Y REPOSICIÓN)
        private void tBoxValue_LostFocus(object sender, RoutedEventArgs e)
        {

            TextBox tb = sender as TextBox;
            bool limpia=true;
            if (tb.Name == "tBoxValue1")
                limpia = false;

            if (tb.Text == "")
                tb.Text = "0";

                if (!lostfocus)//Evitar pérdida de foco varias veces
                {

                    reload_lhs_cam(tb.Text,limpia);
                    lostfocus = true;

                }
                else
                {

                    lostfocus = false;
                }

        }

        private void tBoxValue2_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Text == "")
                tb.Text = "0";

            

                if (!lostfocus)
                {

                    reload_lhs_rep(tb.Text);
                    lostfocus = true;

                }
                else
                {

                    lostfocus = false;
                }

           
        }


       

        #endregion

        #region MÉTODOS PARA MANIPULACIÓN DE EXTRAS

        public void cargar_extras()//Método para recopilar extras (cambio y reposición en lhs)
        {

            lhe = new List<Clases.habitacionIqware>();
            



            Clases.C_Suministro nex;
            List<Clases.C_Suministro> lex = new List<Clases.C_Suministro>();//Listado de Extras de Cambio
            List<Clases.C_Suministro> lex2 = new List<Clases.C_Suministro>();//Listado de Extras de Reposición
            Clases.habitacionIqware nodohab;
            foreach (Clases.habitacionIqware hb in lhs)//Recorrido de las habitaciones
            {

                nodohab = new Clases.habitacionIqware();//Instancia de la habitación...
                lex = new List<Clases.C_Suministro>();
                foreach (Clases.C_Suministro sum in hb.lsumcamb)//Recorrido de los suministros de cambio por habitación
                {


                    if (sum.cantidadEstimada < sum.cantidadSal)//Condición para filtrar extras
                    {
                        nex = new Clases.C_Suministro();
                        nex = sum;
                        nex.cantidad = sum.cantidadSal - sum.cantidadEstimada;
                        nex.IsSelected = false;
                        nex.observacion = "";
                        Clases.C_Suministro nodo = nex.ext_sum_id(hb.ID_Room, DateTime.Today, sum.idSuministro);
                        if (nodo != null)
                        {
                            nex.observacion = nodo.observacion;
                            nex.IsSelected = true;
                        }

                        lex.Add(nex);
                    }
                }

                lex2 = new List<Clases.C_Suministro>();
                foreach (Clases.C_Suministro sum in hb.lsumrep)//Recorrido de los suministros de reposición por habitación
                {


                    if (sum.cantidadEstimada < sum.cantidadSal)//Condición para filtrar extras
                    {
                        nex = new Clases.C_Suministro();
                        nex = sum;
                        nex.cantidad = sum.cantidadSal - sum.cantidadEstimada;
                        nex.IsSelected = false;
                        nex.observacion = "";
                        Clases.C_Suministro nodo = nex.ext_sum_id(hb.ID_Room, DateTime.Today, sum.idSuministro);
                        if (nodo != null)
                        {
                            nex.observacion = nodo.observacion;
                            nex.IsSelected = true;
                        }

                        lex2.Add(nex);
                    }
                }

                if (lex.Count > 0)
                    nodohab.lsumcamb = lex;

                if (lex2.Count > 0)
                    nodohab.lsumrep = lex2;

                if (lex.Count > 0 || lex2.Count>0)//Cuando hay suministros con supuesto extra..
                {

                    nodohab.ID_Room = hb.ID_Room;
                    nodohab.RoomNo = hb.RoomNo;
                    nodohab.RoomTypeName = hb.RoomTypeName;
                    nodohab.HSKGSName = hb.HSKGSName;
                    nodohab.Building = hb.Building;
                    nodohab.GuestTotal = hb.GuestTotal;
                    nodohab.status = hb.status;
                    lhe.Add(nodohab);//Se agrega la nueva instancia en el listado de habitaciones con extras
                }

            }

        }

        public void procesar_extras()//Método para levantar modal de extras (en caso de detectarse)
        {

            bool elim_pend = false;
            string hora = DateTime.Now.ToString("HH:mm:ss");
            Clases.C_Camarera cam = dtgrdcam.SelectedItem as Clases.C_Camarera;
            if (lhe.Count > 0)//Si hay extras detectados
            {


                    if (MessageBox.Show("Se detectaron suministros extras en las habitaciones. Presione 'Sí' para confirmar o 'No' para omitir", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {

                        Registrar_Extra re = new Registrar_Extra();//Levantamiento del modal para los extras
                        re.lhe = lhe;
                        re.lhs = lhs;
                        re.cam = dtgrdcam.SelectedItem as Clases.C_Camarera;
                        re.cam.nhab = lhe.Count;
                        re.hora = hora;
                        re.user = user;
                        re.ShowDialog();
                        if (re.DialogResult == false)
                        {

                            elim_pend = true;
                        }

                    }
                    else
                    {
                        elim_pend = true;
                    }
            }
            if (lhe.Count == 0)
            {
                
                
                foreach (Clases.habitacionIqware hb in lhs)//Recorrido por cada habitación
                {


                    if (hb.lextcamb.Count > 0)
                    {

                        foreach (Clases.C_Extra extc in hb.lextcamb){

                            txtdescbit = "ELIMINACIÓN DE SUMINISTRO EXTRA ( NR. HAB='" + extc.nhab + "', SUMINISTRO='" + extc.descripcion + "', CANTIDAD='" + extc.cantidad + "', OBSERVACION='" + extc.observacion + "')";
                            
                            Clases.Bitacora bit = new Clases.Bitacora(2,3,txtdescbit,user.login);
                            if (bit.Guardar() == 1)
                                Console.WriteLine("Eliminación guardada en la bitácora");


                        } 


                        Clases.C_Extra ext = new Clases.C_Extra();
                        ext.idHabitacion = hb.ID_Room;
                        ext.fecha = DateTime.Today;
                        if (ext.EliminarExtraHabFecha() == 1)
                            Console.WriteLine("Extra Eliminado");

                    }

                }
                
                
            }


        }

        #endregion

        #region MÉTODOS PARA MANIPULACIÓN DE PÉRDIDAS
        public void cargar_perdidas()//Carga en lhp, presuntas pérdidas (de detectarse)
        {

            lhp = new List<Clases.habitacionIqware>();

            



            Clases.C_Suministro nper;//Nodo de pérdida
            List<Clases.C_Suministro> lper = new List<Clases.C_Suministro>();//Lista de pérdida
            Clases.habitacionIqware nodohab;
            foreach (Clases.habitacionIqware hb in lhs)//Recorrido de las habitaciones
            {

                lper = new List<Clases.C_Suministro>();
                foreach (Clases.C_Suministro sum in hb.lsumcamb)//Recorrido de los suministros de cambio por habitación
                {

                    if (sum.suciaEstimada > sum.suciaReal)//Condición para filtrar las presuntas pérdidas
                    {
                        nper = new Clases.C_Suministro();
                        nper = sum;
                        nper.cantidad = sum.suciaEstimada - sum.suciaReal;
                        nper.IsSelected = false;
                        nper.observacion = "";
                        Clases.C_Suministro nodo = nper.per_sum_id(hb.ID_Room, DateTime.Today, sum.idSuministro);
                        if (nodo != null)
                        {
                            nper.observacion = nodo.observacion;
                            nper.IsSelected = true;
                        }

                        lper.Add(nper);
                    }
                }

                if (lper.Count > 0)//Cuando hay suministros con supuesta pérdida..
                {

                    nodohab = new Clases.habitacionIqware();//Instancia de la habitación...

                    nodohab.ID_Room = hb.ID_Room;
                    nodohab.RoomNo = hb.RoomNo;
                    nodohab.RoomTypeName = hb.RoomTypeName;
                    nodohab.HSKGSName = hb.HSKGSName;
                    nodohab.Building = hb.Building;
                    nodohab.GuestTotal = hb.GuestTotal;
                    nodohab.status = hb.status;



                    nodohab.lsumcamb = lper;//Se carga el listado de suministros en esa nueva instancia
                    lhp.Add(nodohab);//Se agrega la nueva instancia en el listado de habitaciones con presuntas pérdidas
                }

            }

        }
        public void procesar_perdidas()//Levantamiento de modal para almacenar pérdidas (de detectarse)
        {
            bool elim_pend = false;
            string hora = DateTime.Now.ToString("HH:mm:ss");
            Clases.C_Camarera cam = dtgrdcam.SelectedItem as Clases.C_Camarera;
            if (lhp.Count > 0)//Si hay pérdidas
            {
                if (MessageBox.Show("Se detectaron presuntas pérdidas de suministros. Presione 'Sí' para confirmarlas o 'No' para omitir", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
               // MessageBox.Show("Se detectaron presuntas pérdidas de suministros. Presione 'Aceptar' para continuar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Registrar_Perdida rp = new Registrar_Perdida();
                    rp.lhp = lhp;
                    rp.cam = dtgrdcam.SelectedItem as Clases.C_Camarera;
                    rp.cam.nhab = lhp.Count;
                    rp.hora = hora;
                    rp.user = user;
                    rp.ShowDialog();

                    if (rp.DialogResult == false)
                    {

                        elim_pend = true;
                    }

                
                }
                else
                {
                    elim_pend = true;
                }
            }



            if (lhp.Count == 0)//Condicion si hay que eliminar pérdidas por omisión o modificación en las asiganciones de suministros
            {
                Clases.C_Perdida per = new Clases.C_Perdida();
                per.idCamarera = cam.idCamarera;
                per.fecha = DateTime.Today;
                
                

                if (per.list_per_sum_cam(DateTime.Today,cam.idCamarera).Count > 0)//Si hay pérdidas relacionadas en la base de datos...
                {
                    
                    
                    //------------------------ Bitácora ---------------------------------------------------------------------------------------------------------//
                    
                    txtdescbit = "ELIMINACIÓN DE PÉRDIDAS OMITIDAS ( NOMBRE CAMARERA='" + cam.nombre + " " + cam.apellido + "', CÉDULA='" + cam.cedula + "')";
                    Clases.Bitacora bit = new Clases.Bitacora(3,3,txtdescbit,user.login);
                    if (bit.Guardar() == 1)
                        Console.WriteLine("Eliminación guardada en la bitácora");
                    //-------------------------------------------------------------------------------------------------------------------------------------------//

                    if (per.EliminarPorCamyFecha() == 1)//Consulta para eliminar
                    {
                        Console.WriteLine("Se eliminaron las pérdidas pendientes");
                    }


                }

                

                
            }

        }

        #endregion

        #region MÉTODOS PARA MANIPULACIÓN DE INCIDENCIAS

        public void procesar_incidencias()//Levantamiento del modal de registro de incidencia (de detectarse)
        {
            bool elim_pend = false;
            string hora = DateTime.Now.ToString("HH:mm:ss");
            Clases.C_Camarera cam = dtgrdcam.SelectedItem as Clases.C_Camarera;
            if (lhi.Count > 0)//Si hay incidencias
            {

                if (MessageBox.Show("Se detectaron suministros con cantidad entrante menor a la estimada en las habitaciones. Presione 'Sí' para confirmar o 'No' para omitir", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                //MessageBox.Show("Se detectaron suministros con cantidad entrante menor a la estimada en las habitaciones. Presione 'Aceptar' para continuar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Registrar_Incidencia ri = new Registrar_Incidencia();
                    ri.lhi = lhi;
                    ri.cam = dtgrdcam.SelectedItem as Clases.C_Camarera;
                    ri.cam.nhab = lhi.Count;
                    ri.hora = hora;
                    ri.user = user;
                    ri.ShowDialog();
                    if (ri.DialogResult == false)
                    {

                        elim_pend = true;
                    }

                
                }
                else
                {
                    elim_pend = true;
                }



            }

            if (lhi.Count == 0)
            {
                Clases.C_Incidencia inc = new Clases.C_Incidencia();
                inc.idCamarera = cam.idCamarera;
                inc.fecha = DateTime.Today;
                
                if (inc.EliminarPorCamyFecha() == 1)
                {
                    Console.WriteLine("Se eliminaron las incidencias pendientes");
                }
            }
        }

        public void cargar_incidencias()//Carga en lhi, presuntas incidencias (de detectarse)
        {

            lhi = new List<Clases.habitacionIqware>();
            
            Clases.C_Suministro ndi;
            List<Clases.C_Suministro> li;//
            List<Clases.C_Suministro> li2;//
            Clases.habitacionIqware nodohab;

            foreach (Clases.habitacionIqware hs in lhs)
            {

                nodohab = new Clases.habitacionIqware();
                li = new List<Clases.C_Suministro>();
                li2 = new List<Clases.C_Suministro>();
                foreach (Clases.C_Suministro sum in hs.lsumcamb)//Recorrido de suministro de cambio por cada habitación (lhs) 
                {
                    if (sum.cantidadSal < sum.cantidadEstimada)
                    {
                        ndi = new Clases.C_Suministro();
                        ndi.idSuministro = sum.idSuministro;
                        ndi.descripcion = sum.descripcion;
                        ndi.cantidad = sum.cantidadEstimada - sum.cantidadSal;
                        ndi.IsSelected = false;
                        ndi.observacion = "";
                        Clases.C_Suministro nodo = ndi.inc_sum_id(hs.ID_Room, DateTime.Today, sum.idSuministro);
                        if (nodo != null)
                        {
                            ndi.observacion = nodo.observacion;
                            ndi.IsSelected = true;
                        }
                        li.Add(ndi);
                    }
                }
                if (li.Count > 0)
                    nodohab.lsumcamb = li;

                foreach (Clases.C_Suministro sum in hs.lsumrep)//Recorrido de suministro de reposición por cada habitación (lhs) 
                {

                    if (sum.cantidadSal < sum.cantidadEstimada)
                    {
                        ndi = new Clases.C_Suministro();
                        ndi.idSuministro = sum.idSuministro;
                        ndi.descripcion = sum.descripcion;
                        ndi.cantidad = sum.cantidadEstimada - sum.cantidadSal;
                        ndi.IsSelected = false;
                        ndi.observacion = "";
                        Clases.C_Suministro nodo = ndi.inc_sum_id(hs.ID_Room, DateTime.Today, sum.idSuministro);
                        if (nodo != null)
                        {
                            ndi.observacion = nodo.observacion;
                            ndi.IsSelected = true;
                        }
                        li2.Add(ndi);
                    }

                }

                if (li2.Count > 0)
                    nodohab.lsumrep = li2;


                if (li.Count > 0 || li2.Count > 0)
                {
                    nodohab.ID_Room = hs.ID_Room;
                    nodohab.RoomNo = hs.RoomNo;
                    nodohab.RoomTypeName = hs.RoomTypeName;
                    nodohab.HSKGSName = hs.HSKGSName;
                    nodohab.Building = hs.Building;
                    nodohab.GuestTotal = hs.GuestTotal;
                    nodohab.status = hs.status;
                    lhi.Add(nodohab);
                }


            }


        }

        #endregion



        #region MÉTODO DE APOYO PARA GUARDAR/MODIFICAR MOVIMIENTOS DE HABITACIONES
        public void procesar_sumininistros_movimiento(Clases.habitacionIqware hb, Clases.C_Suministro sum)
        {
            Clases.C_Movimiento mov = new Clases.C_Movimiento();
            string hora = DateTime.Now.ToString("HH:mm:ss");
            Clases.C_Camarera cam = dtgrdcam.SelectedItem as Clases.C_Camarera;
            mov.tipo = "ENTRADA";
            
            mov.idSuministro = sum.idSuministro;
            mov.idHabitacion = hb.ID_Room;
            mov.fecha = DateTime.Today;
            mov.suciaEstimada = sum.suciaEstimada;
            mov.suciaReal = sum.suciaReal;
            mov.cantidadEstimada = sum.cantidadEstimada;
            mov.cantidadReal = sum.cantidadSal;
            mov.idUsuario = user.idUsuario;
            mov.fechaModificacion = DateTime.Today;
            mov.idCamarera = cam.idCamarera;
            mov.idsupervisor = cam.idSupervisor;
            mov.hora = hora;
            mov.nhab = hb.RoomNo;
            mov.mod_hab = hb.Section;
            mov.piso_hab = hb.ID_Floor;

            

            if (!update)//Si no hay movimientos registrado en la base de datos en la habitación
            {
                if (mov.Guardar() == 1)
                {
                    Console.WriteLine("Guardado");
                    //-------- Bitácora ------------------------------------------------//
                    txtdescbit = "INSERCIÓN ( NR. HAB='" + mov.nhab + "', SUMINISTRO='" + sum.descripcion + "', SUCIA REAL='" + mov.suciaReal + "', CANTIDAD ENTRANTE='" + mov.cantidadReal + "')";
                    Clases.Bitacora bit = new Clases.Bitacora(2,1,txtdescbit,user.login); 
                    if (bit.Guardar() == 1)
                        Console.WriteLine("Inserción guardada en la bitácora");
                    //------------------------------------------------------------------//

                }
                else
                {
                    Console.WriteLine("No se guardo");
                }
            }
            else
            {
                if (mov.Editar() == 1)
                {

                    //-------- Bitácora ----------------------------------------------------------------//
                    if (sum.suciaRealVieja != mov.suciaReal || sum.cantidadRealVieja != mov.cantidadReal)
                    {

                        
                        if (sum.suciaRealVieja != mov.suciaReal)
                            txtdescbit = "MODIFICACIÓN ( NR. HAB='" + mov.nhab + "', SUMINISTRO='" + sum.descripcion + "', SUCIA REAL ANTERIOR='" + sum.suciaRealVieja + "', SUCIA REAL NUEVA='" + mov.suciaReal + "', ";
                        else
                            txtdescbit = "MODIFICACIÓN ( NR. HAB='" + mov.nhab + "', SUMINISTRO='" + sum.descripcion + "', SUCIA REAL='" + mov.suciaReal + "', ";



                        if (sum.cantidadRealVieja != mov.cantidadReal)
                           txtdescbit += "CANT. ENTR. ANTERIOR='" + sum.cantidadRealVieja + "', CANT. ENTR. NUEVA='" + mov.cantidadReal + "')";
                        else
                            txtdescbit += "CANT. ENTR.='" + mov.cantidadReal + "')";

                        Clases.Bitacora bit = new Clases.Bitacora(2,2,txtdescbit,user.login);
                        if (bit.Guardar() == 1)
                            Console.WriteLine("Modificación guardada en la bitácora");
                    }
                    //---------------------------------------------------------------------------------//
                    
                    
                    
                }
                else
                {
                    Console.WriteLine("No se editó");
                }
            }

        }

        #endregion


        #region EVENTO BOTÓN GUARDAR

        private void tlGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (dtgrdcam.SelectedIndex==-1){

                MessageBox.Show("Debe elegir una camarera", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (dtgrdsumcamb.ItemsSource==null || dtgrdsumrep.ItemsSource==null){

                MessageBox.Show("No se le ha asignado suministros a las habitaciones ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            

            cargar_perdidas();//Se verifica si hay pérdidas (Carga en lhp)
            procesar_perdidas();//Levantamiento de ventana modal de pérdida  (De ser necesario) y actualización en la base de datos de las pérdidas

            cargar_incidencias();//Se verifica si hay incidencias (Carga en lhi)
            procesar_incidencias();//Levantamiento de ventana modal de incidencias  (De ser necesario) y actualización en la base de datos de las incidencias

            cargar_extras();//Se verifica si hay extras (Carga en lhe)
            procesar_extras();//Levantamiento de ventana modal de extras  (De ser necesario) y actualización en la base de datos de los extras

            
            

            foreach (Clases.habitacionIqware hb in lhs)//Recorrido por cada habitación
            {

                foreach (Clases.C_Suministro sum in hb.lsumcamb)//Recorrido en los suministros de cambio de cada habitación
                {
                    procesar_sumininistros_movimiento(hb, sum);//Proceso de inserción o modificación de cada suministro
                }



                foreach (Clases.C_Suministro sum in hb.lsumrep)//Recorrido en los suministros de reposicion de cada habitación
                {
                    procesar_sumininistros_movimiento(hb, sum);//Proceso de inserción o modificación de cada suministro
                }


                
            }

            MessageBox.Show("Movimiento guardado satisfactoriamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            Page_Loaded(sender, e);
        }

        #endregion

        #region EVENTO PARA SELECCIONAR UNA FILA DE UNA HABITACIÓN

        private void dtgrdhabsel_MouseDoubleClick(object sender, SelectionChangedEventArgs e)
        {
            evt = true;
            chkSelectAll.IsChecked=false;
            chkSelectAll2.IsChecked = false;
            chkSelectAll1.IsChecked = false;
            reload_lhs_cam("",false);//Actualización de lhs y carga de datagrid de suministros de cambio vinculado con la habitación seleccionada en su datagrid
            reload_lhs_rep("");//Actualización de lhs y carga de datagrid de suministros de reposición vinculado con la habitación seleccionada en su datagrid
            evt = false;

        }

        #endregion


        #region EVENTO BOTÓN CANCELAR

        private void tlCancelar_Click(object sender, RoutedEventArgs e)
        {
            dtgrdcam.ItemsSource = null;
            dtgrdhabsel.ItemsSource = null;
            dtgrdsumcamb.ItemsSource = null;
            dtgrdsumrep.ItemsSource = null;
        }

        #endregion

        #region MÉTODOS PARA LA CARGA DE LOS MOVIMIENTOS DE SUMINISTROS DE CAMBIO Y REPOSICIÓN EN LHS (Al elegir una fila de camarera en su datagrid respectivo)



        //Suministros de Cambio
        public void cargar_lista_cambio_hab(Clases.habitacionIqware nvo)
        {
            List<Clases.C_Suministro> list = new List<Clases.C_Suministro>();
            Clases.C_Suministro nvosum = new Clases.C_Suministro();
            foreach (Clases.C_Movimiento nodo in lista_mov_sum_cambio)
            {
                if (nodo.idHabitacion == nvo.ID_Room)
                {
                    nvosum = new Clases.C_Suministro();
                    nvosum.idSuministro = Convert.ToInt32(nodo.idSuministro);
                    nvosum.descripcion = nodo.nomsum;


                    
                    //----------- Bitácora (En caso de modificación en sucia real y cantidad real) -------------------------//
                    nvosum.suciaRealVieja = Convert.ToInt32(nodo.suciaReal);
                    nvosum.cantidadRealVieja = Convert.ToInt32(nodo.cantidadReal);
                    //-------------- Bitácora ------------------------------------------------------------------------------//




                    nvosum.suciaEstimada = Convert.ToInt32(nodo.suciaEstimada);
                    nvosum.suciaReal = Convert.ToInt32(nodo.suciaReal);

                    if (nvosum.suciaEstimada == nvosum.suciaReal && nvosum.suciaReal > 0)
                    {
                        nvosum.IsSelected2 = true;
                    }




                    nvosum.cantidadEstimada = Convert.ToInt32(nodo.cantidadEstimada);
                    nvosum.cantidadSal = Convert.ToInt32(nodo.cantidadReal);

                    if (nvosum.cantidadEstimada == nvosum.cantidadSal && nvosum.cantidadSal > 0)
                    {
                        nvosum.IsSelected = true;
                    }

                    list.Add(nvosum);


                }
            }
            nvo.lsumcamb = list;
        }


        //Suministros de Reposición
        public void cargar_lista_rep_hab(Clases.habitacionIqware nvo)
        {
            List<Clases.C_Suministro> list = new List<Clases.C_Suministro>();
            Clases.C_Suministro nvosum = new Clases.C_Suministro();
            foreach (Clases.C_Movimiento nodo in lista_mov_sum_rep)
            {
                if (nodo.idHabitacion == nvo.ID_Room)
                {
                    nvosum = new Clases.C_Suministro();
                    nvosum.idSuministro = Convert.ToInt32(nodo.idSuministro);
                    nvosum.descripcion = nodo.nomsum;

                    //-----------    Bitácora    ---------------------------------//
                    nvosum.suciaRealVieja = Convert.ToInt32(nodo.suciaReal);
                    nvosum.cantidadRealVieja = Convert.ToInt32(nodo.cantidadReal);
                    //-------------- Bitácora ------------------------------------//



                    nvosum.cantidadEstimada = Convert.ToInt32(nodo.cantidadEstimada);
                    nvosum.cantidadSal = Convert.ToInt32(nodo.cantidadReal);

                    if (nvosum.cantidadEstimada == nvosum.cantidadSal && nvosum.cantidadSal > 0)
                    {
                        nvosum.IsSelected = true;
                    }

                    list.Add(nvosum);


                }
            }
            nvo.lsumrep = list;
        }


        #endregion


        public bool update = false;




        




        
    }
}
