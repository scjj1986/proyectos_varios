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
using System.Globalization;
using System.Net;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;

namespace ALegal
{
    /// <summary>
    /// Lógica de interacción para Empresa.xaml
    /// </summary>
    public partial class Empresa : Page
    {

        public _empresa em = new _empresa();
        
        public List<accionista> lacc = new List<accionista>();
        public accionista nacc = new accionista();

        public List<director> ldir = new List<director>();
        public director ndir = new director();

        public List<actreg> lar = new List<actreg>();
        public actreg nar = new actreg();

        public string tcedant = "", cedant = "", trifant = "", rifant = "";
        public string tcedant2 = "", cedant2 = "", trifant2 = "", rifant2 = "";

        public string nr = "", tomo = "";
        
        public Empresa()
        {
            InitializeComponent();
        }

        

        #region MÉTODOS GENERALES

        public void cargar_cmbs()
        {
            cmbNac.Items.Add("V");
            cmbNac.Items.Add("E");
            cmbNac.Items.Add("J");
            
            cmbNacAcc.Items.Add("V");
            cmbNacAcc.Items.Add("E");

            cmbNacRIFAcc.Items.Add("V");
            cmbNacRIFAcc.Items.Add("E");
            cmbNacRIFAcc.Items.Add("J");

            cmbNacDir.Items.Add("V");
            cmbNacDir.Items.Add("E");

            cmbNacRIFDir.Items.Add("V");
            cmbNacRIFDir.Items.Add("E");
            cmbNacRIFDir.Items.Add("J");

            cmbNacCom.Items.Add("V");
            cmbNacCom.Items.Add("E");

            cmbNacRIFCom.Items.Add("V");
            cmbNacRIFCom.Items.Add("E");
            cmbNacRIFCom.Items.Add("J");
        }

        public void limpiar_item_datos_principales(){

            txtNomb.Text = "";
            cmbNac.Text = "";
            txtRif.Text = "";
            txtCapAct.Text = "";
            txtUEEA.Text = "";

            dpFechaRegMerc.Text = "";
            txtNrRegMerc.Text = "";
            txtTomoRegMerc.Text = "";

            txtDomFisc.Text = "";
            txtSuc.Text = "";
            txtAgCom.Text = "";

        }


        public void limpiar_item_comisario(){
            cmbNacCom.Text = "";
            txtCedCom.Text = "";
            cmbNacRIFCom.Text = "";
            txtRIFCom.Text = "";

            txtNomCom.Text = "";

            txtDurCom.Text = "";
            txtCPCCom.Text = "";
        }

        


        public void limpiar_item_permisologias()
        {
            /*
            txtPerms.Text = "";
            txtEntePerm.Text = "";
            dpFechaOtorg.Text = "";
            txtEdoVig.Text = "";*/
            
        }

        public void limpiar_item_seguros()
        {
            /*txtRamPolSeg.Text = "";
            txtAsegSeg.Text = "";
            txtPolCodSeg.Text = "";
            dpFechaCttoAseg.Text = "";
            dpFechaVencAseg.Text = "";

            txtSumAsegSeg.Text = "";
            txtPrimAnuAseg.Text = "";
            txtMtoIniAseg.Text = "";
            txtMtoCuoAseg.Text = "";*/
            
        }

        public void limpiar_item_contratos()
        {
            /*txtTipoContrato.Text = "";
            txtParteContratante.Text = "";
            txtParteContratada.Text = "";
            txtObjeto.Text = "";
            dpFechaInicioCtto.Text = "";
            dpFechaFinCtto.Text = "";
            txtContactoCtto.Text = "";
            txtMontoBs.Text = "";
            txtDeposito.Text = "";
            txtAutProtCtto.Text = "";
            dpFechaAutProt.Text = "";
            txtNrAutProtCtto.Text = "";
            txtTomoAutProtCtto.Text = "";
            txtFoliosAutProtCtto.Text = "";
            txtMatAutProtCtto.Text = "";*/
            
        }

        public void limpiar_item_docpropiedad()
        {

        }

        public void limpiar_item_embarcaciones()
        {

        }

        
        public void limpiar_form()
        {


            #region item datos principales

            limpiar_item_datos_principales();
            limpiar_item_accionistas();
            limpiar_item_directores();
            limpiar_item_comisario();
            limpiar_item_actas_registradas();
            txtBsqAcc.Text = "";
            txtBusqDir.Text = "";
            txtBsqActReg.Text = "";
            lacc = new List<accionista>();
            dtgAcc.ItemsSource = null;
            dtgDir.ItemsSource = null;
            dtgActReg.ItemsSource = null;
            globales.idemp = -1;

            #endregion
            /*
            #region item permisologías

            limpiar_item_permisologias();
            txtBsqPerm.Text = "";
            dtgPerm.ItemsSource = null;


            #endregion

            #region item seguros

            limpiar_item_seguros();
            

            #endregion

            #region item contratos
            limpiar_item_contratos();
            
            #endregion

            #region item doc. propiedad

            limpiar_item_docpropiedad();
            //dtgDocProp.ItemsSource = null;

            #endregion

            #region item embarcaciones

            limpiar_item_embarcaciones();
            //dtgEmbPerm.ItemsSource = null;*/

            //#endregion



        }

        public void copiar_form_datos_principales()
        {
            em = new _empresa();
            em.id = globales.idemp;
            em.nombre = txtNomb.Text.ToUpper();
            em.tiporif = cmbNac.Text.ToUpper();
            em.rif = txtRif.Text;
            em.cap_actual = globales.txt_a_double(txtCapAct.Text);
            em.ueea = txtUEEA.Text;
            em.fecha_rm = Convert.ToDateTime(dpFechaRegMerc.SelectedDate);
            em.nr_rm = txtNrRegMerc.Text.ToUpper();
            em.tomo_rm = txtTomoRegMerc.Text.ToUpper();
            em.dom_fisc = txtDomFisc.Text.ToUpper();
            em.sucursal = txtSuc.Text.ToUpper();
            em.ag_com = txtAgCom.Text.ToUpper();

        }
    
        #endregion

        #region EVENTOS GENERALES

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cargar_cmbs();
            dtgEmp.ItemsSource = globales.lemp;
        }

        private void btnNuevoEmp_Click(object sender, RoutedEventArgs e)
        {
            limpiar_form();
            
        }

        //Validación de números enteros
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        //Validación de números con decimales
        private void DecimalValidationTextBox(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            bool approvedDecimalPoint = false;

            if (e.Text == ".")
            {
                if (!((TextBox)sender).Text.Contains("."))
                    approvedDecimalPoint = true;
            }

            if (!(char.IsDigit(e.Text, e.Text.Length - 1) || approvedDecimalPoint))
                e.Handled = true;
        }

        private void btnGuardarEmp_Click(object sender, RoutedEventArgs e)
        {

            #region Validación Item Datos Principales
            if (string.IsNullOrWhiteSpace(txtNomb.Text))
            {
                MessageBox.Show("Item Datos Personales: Campo Nombre vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (cmbNac.Text == "" || string.IsNullOrWhiteSpace(txtRif.Text))
            {
                MessageBox.Show("Item Datos Personales: Campo R.I.F. vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCapAct.Text))
            {
                MessageBox.Show("Item Datos Personales: Campo Capital Actual vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtUEEA.Text))
            {
                MessageBox.Show("Item Datos Personales: Campo Últ. Ejerc. Econ. Aprobado vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (dpFechaRegMerc.Text == "")
            {
                MessageBox.Show("Item Datos Personales: Campo Fecha Registro Mercantil vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNrRegMerc.Text))
            {
                MessageBox.Show("Item Datos Personales: Campo N° Registro Mercantil vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTomoRegMerc.Text))
            {
                MessageBox.Show("Item Datos Personales: Campo Tomo Registro Mercantil vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDomFisc.Text))
            {
                MessageBox.Show("Item Datos Personales: Campo Domicilio Fiscal vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSuc.Text))
            {
                MessageBox.Show("Item Datos Personales: Campo Sucursal vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAgCom.Text))
            {
                MessageBox.Show("Item Datos Personales: Campo Agencia Comercial vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            #endregion

            /*
            #region Validación Item Comisario
            if (cmbNacCom.Text == "" || string.IsNullOrWhiteSpace(txtCedCom.Text))
            {
                MessageBox.Show("Item Comisario: Campo Cédula vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (cmbNacRIFCom.Text == "" || string.IsNullOrWhiteSpace(txtRIFCom.Text))
            {
                MessageBox.Show("Item Comisario: Campo R.I.F. vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNomCom.Text))
            {
                MessageBox.Show("Item Comisario: Campo Nombre vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDurCom.Text))
            {
                MessageBox.Show("Item Comisario: Campo Duración vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCPCCom.Text))
            {
                MessageBox.Show("Item Comisario: Campo Duración vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            
            #endregion*/

            copiar_form_datos_principales();

            em.guardar_editar();

            MessageBox.Show("Datos Guardados satisfactoriamente", "Completado", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        #endregion

        #region PESTAÑA ACCIONISTAS

        #region Métodos
        public void limpiar_item_accionistas()
        {

            cmbNacAcc.Text = "";
            txtCedAcc.Text = "";

            cmbNacRIFAcc.Text = "";
            txtRIFAcc.Text = "";

            txtNomAcc.Text = "";
            txtDurAcc.Text = "";
            txtFacAcc.Text = "";

            tcedant="";
            cedant="";
            trifant = "";
            rifant = "";

            

        }

        public void filtrar_coincidencias_dtgAcc(string valor)
        {
            List<accionista> laux = new List<accionista>();
            accionista nacc;
            foreach (accionista item in lacc){
                if (item.cedulacompleta.Contains(valor) || item.rifcompleto.Contains(valor) || item.nombre.Contains(valor) || item.duracion.Contains(valor) || item.facultades.Contains(valor))
                {
                    nacc = new accionista();
                    nacc.tced = item.tced;
                    nacc.cedula = item.cedula;
                    nacc.cedulacompleta = item.tced + "-" + item.cedula;
                    nacc.trif = item.trif;
                    nacc.rif = item.rif;
                    nacc.rifcompleto = item.trif + "-" + item.rif;
                    nacc.nombre = item.nombre;
                    nacc.duracion = item.duracion;
                    nacc.facultades = item.facultades;
                    laux.Add(nacc);
                }
            }
            dtgAcc.ItemsSource = laux;
            
        }
        #endregion

        #region Eventos

        private void btnNuevoAcc_Click(object sender, RoutedEventArgs e)
        {
            limpiar_item_accionistas();
        }

        private void btnGuardarAcc_Click(object sender, RoutedEventArgs e)
        {
            if (cmbNacAcc.Text=="" || string.IsNullOrWhiteSpace(txtCedAcc.Text))
            {
                MessageBox.Show("Campo Cédula vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (cmbNacRIFAcc.Text == "" || string.IsNullOrWhiteSpace(txtRIFAcc.Text))
            {
                MessageBox.Show("Campo RIF vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNomAcc.Text))
            {
                MessageBox.Show("Campo Nombre vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDurAcc.Text))
            {
                MessageBox.Show("Campo Duración vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtFacAcc.Text))
            {
                MessageBox.Show("Campo Nombre vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            nacc = new accionista();
            nacc.tced= cmbNacAcc.Text;
            nacc.cedula = txtCedAcc.Text;
            nacc.cedulacompleta = nacc.tced + "-" + nacc.cedula;
            nacc.trif = cmbNacRIFAcc.Text;
            nacc.rif = txtRIFAcc.Text;
            nacc.rifcompleto = nacc.trif + "-" + nacc.rif;
            nacc.nombre = txtNomAcc.Text.ToUpper();
            nacc.duracion = txtDurAcc.Text.ToUpper();
            nacc.facultades = txtFacAcc.Text.ToUpper();
            if (tcedant == "")
                lacc.Add(nacc);
            else
            {
                foreach (accionista acc in lacc)
                {
                    if (tcedant == acc.tced && cedant == acc.cedula && trifant == acc.trif && rifant == acc.rif)
                    {
                        acc.tced = nacc.tced;
                        
                        acc.cedula = nacc.cedula;
                        acc.cedulacompleta = nacc.cedulacompleta;
                        acc.trif = nacc.trif;
                        acc.rif = nacc.rif;
                        acc.rifcompleto = nacc.rifcompleto;
                        acc.nombre = nacc.nombre;
                        acc.duracion = nacc.duracion;
                        acc.facultades = nacc.facultades;
                    }

                }
            }
            dtgAcc.ItemsSource = lacc;
            dtgAcc.Items.Refresh();
            limpiar_item_accionistas();
            txtBsqAcc_KeyUp(sender, null);
        }

        private void txtBsqAcc_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBsqAcc.Text != "")
                filtrar_coincidencias_dtgAcc(txtBsqAcc.Text.ToUpper());
            else
                dtgAcc.ItemsSource = lacc;

            dtgAcc.Items.Refresh();
        }

        private void txtCedAcc_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCedAcc.Text) && cmbNacAcc.Text != "")
            {
                cmbNacRIFAcc.Text = cmbNacAcc.Text;
                txtRIFAcc.Text = txtCedAcc.Text;
            }
        }

        private void ElimFildtgAcc_Click(object sender, RoutedEventArgs e)
        {
            if (dtgAcc.SelectedIndex >= 0)
            {
                if (MessageBox.Show("Desea eliminar la fila seleccionada?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    int j = 0;
                    if (txtBsqAcc.Text == "")
                        j = dtgAcc.SelectedIndex;
                    else
                    {
                        accionista ac = dtgAcc.SelectedItem as accionista;
                        int i = 0;
                        foreach (accionista item in lacc)
                        {
                            if (item.cedulacompleta == ac.cedulacompleta && item.rifcompleto == ac.rifcompleto)
                                j = i;

                            i++;
                        }
                    }
                    lacc.RemoveAt(j);
                    txtBsqAcc_KeyUp(sender, null);
                }

            }
        }

        private void ElimTododtgAcc_Click(object sender, RoutedEventArgs e)
        {
            if (dtgAcc.SelectedIndex >= 0)
            {
                if (MessageBox.Show("Desea eliminar todo?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    lacc = new List<accionista>();
                    txtBsqAcc_KeyUp(sender, null);

                }

            }
        }

        private void dtgAcc_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dtgAcc.SelectedIndex >= 0)
            {
                accionista ac = dtgAcc.SelectedItem as accionista;

                cmbNacAcc.Text = ac.tced;
                txtCedAcc.Text = ac.cedula;
                cmbNacRIFAcc.Text = ac.trif;
                txtRIFAcc.Text = ac.rif;


                //
                tcedant = ac.tced;
                cedant = ac.cedula;
                trifant = ac.trif;
                rifant = ac.rif;
                //


                txtNomAcc.Text = ac.nombre;
                txtDurAcc.Text = ac.duracion;
                txtFacAcc.Text = ac.facultades;

            }
        }

        #endregion

        


        #endregion

        #region PESTAÑA DIRECTORES

        #region Métodos

        public void filtrar_coincidencias_dtgDir(string valor)
        {
            List<director> laux = new List<director>();
            director ndr;
            foreach (director item in ldir)
            {
                if (item.cedulacompleta.Contains(valor) || item.rifcompleto.Contains(valor) || item.nombre.Contains(valor))
                {
                    ndr = new director();
                    ndr.tced = item.tced;
                    ndr.cedula = item.cedula;
                    ndr.cedulacompleta = item.tced + "-" + item.cedula;
                    ndr.trif = item.trif;
                    ndr.rif = item.rif;
                    ndr.rifcompleto = item.trif + "-" + item.rif;
                    ndr.nombre = item.nombre;
                    ndr.acciones = item.acciones;
                    ndr.valornominal = item.valornominal;
                    ndr.porcaporte = item.porcaporte;
                    ndr.porcacc = item.porcacc;
                    laux.Add(ndr);
                }
            }
            dtgDir.ItemsSource = laux;

        }

        public void limpiar_item_directores()
        {

            cmbNacDir.Text = "";
            txtCedDir.Text = "";

            cmbNacRIFDir.Text = "";
            txtRIFDir.Text = "";
            txtNomDir.Text = "";
            txtAccDir.Text = "";
            txtValNomDir.Text = "";
            txtAporteBsDir.Text = "";
            txtAportePorc.Text = "";
            txtAccPorc.Text = "";
            tcedant2 = "";
            cedant2 = "";
            trifant2 = "";
            rifant2 = "";
        }

        #endregion

        #region Eventos

        private void btnNuevoDir_Click(object sender, RoutedEventArgs e)
        {
            limpiar_item_directores();
        }

        private void txtCedDir_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCedDir.Text) && cmbNacDir.Text != "")
            {
                cmbNacRIFDir.Text = cmbNacDir.Text;
                txtRIFDir.Text = txtCedDir.Text;
            }
        }

        private void btnGuardarDir_Click(object sender, RoutedEventArgs e)
        {
            if (cmbNacDir.Text == "" || string.IsNullOrWhiteSpace(txtCedDir.Text))
            {
                MessageBox.Show("Campo Cédula vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (cmbNacRIFDir.Text == "" || string.IsNullOrWhiteSpace(txtRIFDir.Text))
            {
                MessageBox.Show("Campo RIF vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNomDir.Text))
            {
                MessageBox.Show("Campo Nombre vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAccDir.Text))
            {
                MessageBox.Show("Campo Acciones vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtValNomDir.Text))
            {
                MessageBox.Show("Campo Valor Nominal vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAporteBsDir.Text))
            {
                MessageBox.Show("Campo Aporte Bs. vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAportePorc.Text))
            {
                MessageBox.Show("Campo % Aporte vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAccPorc.Text))
            {
                MessageBox.Show("Campo % Accionario vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            ndir = new director();
            ndir.tced = cmbNacDir.Text;
            ndir.cedula = txtCedDir.Text;
            ndir.cedulacompleta = ndir.tced + "-" + ndir.cedula;
            ndir.trif = cmbNacRIFDir.Text;
            ndir.rif = txtRIFDir.Text;
            ndir.rifcompleto = ndir.trif + "-" + ndir.rif;
            ndir.nombre = txtNomDir.Text.ToUpper();
            ndir.acciones = txtAccDir.Text.ToUpper();
            ndir.valornominal = globales.txt_a_double(txtValNomDir.Text);
            ndir.aportebs = globales.txt_a_double(txtAporteBsDir.Text);
            ndir.porcaporte = globales.txt_a_double(txtAportePorc.Text);
            ndir.porcacc = globales.txt_a_double(txtAccPorc.Text);
            if (tcedant2 == "")
                ldir.Add(ndir);
            else
            {
                foreach (director dir in ldir)
                {
                    if (tcedant2 == dir.tced && cedant2 == dir.cedula && trifant2 == dir.trif && rifant2 == dir.rif)
                    {
                        dir.tced = ndir.tced;

                        dir.cedula = ndir.cedula;
                        dir.cedulacompleta = ndir.cedulacompleta;
                        dir.trif = ndir.trif;
                        dir.rif = ndir.rif;
                        dir.rifcompleto = ndir.rifcompleto;
                        dir.nombre = ndir.nombre;
                        dir.acciones = ndir.acciones;
                        dir.valornominal = ndir.valornominal;
                        dir.aportebs = ndir.aportebs;
                        dir.porcaporte = ndir.porcaporte;
                        dir.porcacc = ndir.porcacc;
                    }

                }
            }
            dtgDir.ItemsSource = ldir;
            dtgDir.Items.Refresh();
            limpiar_item_directores();


            txtBusqDir_KeyUp(sender, null);
        }

        private void txtBusqDir_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBusqDir.Text != "")
                filtrar_coincidencias_dtgDir(txtBusqDir.Text.ToUpper());
            else
                dtgDir.ItemsSource = ldir;

            dtgDir.Items.Refresh();
        }

        private void ElimFildtgDir_Click(object sender, RoutedEventArgs e)
        {
            if (dtgDir.SelectedIndex >= 0)
            {
                if (MessageBox.Show("Desea eliminar la fila seleccionada?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    int j = 0;
                    if (txtBusqDir.Text == "")
                        j = dtgDir.SelectedIndex;
                    else
                    {
                        director dr = dtgDir.SelectedItem as director;
                        int i = 0;
                        foreach (director item in ldir)
                        {
                            if (item.cedulacompleta == dr.cedulacompleta && item.rifcompleto == dr.rifcompleto)
                                j = i;

                            i++;
                        }
                    }
                    ldir.RemoveAt(j);
                    txtBusqDir_KeyUp(sender, null);
                }

            }
        }

        private void ElimTododtgDir_Click(object sender, RoutedEventArgs e)
        {
            if (dtgDir.SelectedIndex >= 0)
            {
                if (MessageBox.Show("Desea eliminar todo?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    ldir = new List<director>();
                    txtBusqDir_KeyUp(sender, null);

                }

            }
        }

        private void dtgDir_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dtgDir.SelectedIndex >= 0)
            {
                director dr = dtgDir.SelectedItem as director;

                cmbNacDir.Text = dr.tced;
                txtCedDir.Text = dr.cedula;
                cmbNacRIFDir.Text = dr.trif;
                txtRIFDir.Text = dr.rif;


                //
                tcedant2 = dr.tced;
                cedant2 = dr.cedula;
                trifant2 = dr.trif;
                rifant2 = dr.rif;
                //


                txtNomDir.Text = dr.nombre;
                txtAccDir.Text = dr.acciones;
                txtAporteBsDir.Text = String.Format("{0:N}", decimal.Parse(Convert.ToString(dr.aportebs))).Replace(',','.');
                txtValNomDir.Text = String.Format("{0:N}", decimal.Parse(Convert.ToString(dr.valornominal))).Replace(',', '.');
                txtAportePorc.Text = String.Format("{0:N}", decimal.Parse(Convert.ToString(dr.porcaporte))).Replace(',', '.');
                txtAccPorc.Text = String.Format("{0:N}", decimal.Parse(Convert.ToString(dr.porcacc))).Replace(',', '.');
            }
        }


        #endregion


        
        #endregion

        #region PESTAÑA COMISARIO

        #region Eventos
        private void txtCedCom_LostFocus(object sender, RoutedEventArgs e)
        {
            if (cmbNacCom.Text != "" && txtCedCom.Text != "")
            {
                cmbNacRIFCom.Text = cmbNacCom.Text;
                txtRIFCom.Text = txtCedCom.Text;
            }
        }
        #endregion

        #endregion

        #region PESTAÑA ACTAS REGISTRADAS

        #region Métodos

        public void limpiar_item_actas_registradas()
        {
            dpFechaCelebActReg.Text = "";
            dpFechaProtActReg.Text = "";
            txtPtosATratActReg.Text = "";
            txtNrActReg.Text = "";
            txtTomoActReg.Text = "";
            nr = "";
            tomo = "";
        }

        public void filtrar_coincidencias_dtgActReg(string valor)
        {
            List<actreg> laux = new List<actreg>();
            actreg ar;
            foreach (actreg item in lar)
            {
                if (item.nr.Contains(valor) || item.tomo.Contains(valor))
                {
                    ar = new actreg();
                    ar = new actreg();
                    ar.fcel = item.fcel;
                    ar.fprot = item.fprot;
                    ar.nr = item.nr;
                    ar.tomo = item.tomo;
                    ar.ptosatratar = item.ptosatratar;
                    ar.string_fcel = item.string_fcel;
                    ar.string_fprot = item.string_fprot;
                    laux.Add(ar);
                }
            }
            dtgActReg.ItemsSource = laux;

        }

        #endregion

        

        #region Eventos

        private void btnNuevoActReg_Click(object sender, RoutedEventArgs e)
        {
            limpiar_item_actas_registradas();
        }

        private void btnGuardarActReg_Click(object sender, RoutedEventArgs e)
        {
            if (dpFechaCelebActReg.Text == "")
            {
                MessageBox.Show("Campo Fecha Celebración vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (dpFechaProtActReg.Text == "")
            {
                MessageBox.Show("Campo Fecha Protocolización vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNrActReg.Text))
            {
                MessageBox.Show("Campo N° vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTomoActReg.Text))
            {
                MessageBox.Show("Campo Tomo vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPtosATratActReg.Text))
            {
                MessageBox.Show("Campo Puntos a Tratar vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            


            nar = new actreg();
            nar.fcel = Convert.ToDateTime(dpFechaCelebActReg.SelectedDate);
            nar.fprot = Convert.ToDateTime(dpFechaProtActReg.SelectedDate);
            nar.nr = txtNrActReg.Text.ToUpper();
            nar.tomo = txtTomoActReg.Text.ToUpper();
            nar.ptosatratar = txtPtosATratActReg.Text.ToUpper();
            nar.string_fcel = nar.fcel.ToShortDateString();
            nar.string_fprot = nar.fprot.ToShortDateString();

            
            if (nr == "")
                lar.Add(nar);
            else
            {
                foreach (actreg ar in lar)
                {
                    if (nr == ar.nr && tomo == ar.tomo)
                    {
                        ar.fcel = nar.fcel;
                        ar.fprot = nar.fprot;
                        ar.nr = nar.nr;
                        ar.tomo = nar.tomo;
                        ar.ptosatratar = nar.ptosatratar;
                        ar.string_fcel = nar.string_fcel;
                        ar.string_fprot = nar.string_fprot;
                    }

                }
            }
            dtgActReg.ItemsSource = lar;
            dtgActReg.Items.Refresh();
            limpiar_item_actas_registradas();


            txtBsqActReg_KeyUp(sender, null);
        }

        private void txtBsqActReg_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBsqActReg.Text != "")
                filtrar_coincidencias_dtgActReg(txtBsqActReg.Text.ToUpper());
            else
                dtgActReg.ItemsSource = lar;

            dtgActReg.Items.Refresh();
        }

        private void dtgActReg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dtgActReg.SelectedIndex >= 0)
            {
                actreg ar = dtgActReg.SelectedItem as actreg;

                dpFechaCelebActReg.SelectedDate = ar.fcel;
                dpFechaProtActReg.SelectedDate = ar.fprot;
                txtNrActReg.Text = ar.nr;
                txtTomoActReg.Text = ar.tomo;
                txtPtosATratActReg.Text = ar.ptosatratar;

                //
                nr= ar.nr;
                tomo = ar.tomo;
                //

            }
        }

        private void ElimFildtgActReg_Click(object sender, RoutedEventArgs e)
        {
            if (dtgActReg.SelectedIndex >= 0)
            {
                if (MessageBox.Show("Desea eliminar la fila seleccionada?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    int j = 0;
                    if (txtBsqActReg.Text == "")
                        j = dtgActReg.SelectedIndex;
                    else
                    {
                        actreg ar = dtgActReg.SelectedItem as actreg;
                        int i = 0;
                        foreach (actreg item in lar)
                        {
                            if (item.nr == ar.nr && item.tomo == ar.tomo)
                                j = i;

                            i++;
                        }
                    }
                    lar.RemoveAt(j);
                    txtBsqActReg_KeyUp(sender, null);
                }

            }
        }

        private void ElimTododtgActReg_Click(object sender, RoutedEventArgs e)
        {
            if (dtgActReg.SelectedIndex >= 0)
            {
                if (MessageBox.Show("Desea eliminar todo?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    lar = new List<actreg>();
                    txtBsqActReg_KeyUp(sender, null);

                }

            }
        }




        

        #endregion

        

        







        #endregion






    }
}
