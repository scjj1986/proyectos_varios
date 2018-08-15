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
using librerias;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Security.Cryptography;
using librerias;

namespace Reservas
{
    /// <summary>
    /// Lógica de interacción para configuracion.xaml
    /// </summary>
    /// 

    
    public partial class configuracion : Page

    {
        public librerias.usuario usrio;

        public List<librerias.usuario> lusu = new List<librerias.usuario>();
        public configuracion()
        {
            InitializeComponent();
        }

        public int codigoFDP = -1;
        public int codigoBnc = -1;
        public int codigoTT = -1;
        public int codigoUsr = -1;

        public string claveactual = "";

        private void btnGuardaTemporada_Click(object sender, RoutedEventArgs e)
        {
            DateTime? fi = dpFechaI.SelectedDate;
            DateTime? ff = dpFechaF.SelectedDate;
            if (txtdescripcionT.Text.Equals("")||fi==null||ff==null||txtmontoInfante.Text.Equals("")||txtmontoninio.Text.Equals("0")||txtmontoadulto.Text.Equals("0")||lstHolel.SelectedIndex<=0){
                MessageBox.Show("Debe completar todos los campos para agregar la temporada", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (MessageBox.Show("¿Seguro desea agregar nuevos montos a temporada de todo incluido?", "Pregunta", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                temporada tem = new temporada();
                tem.descripcion = txtdescripcionT.Text.ToUpper();
                tem.fechaI = dpFechaI.SelectedDate.Value.ToShortDateString();
                tem.fechaF = dpFechaF.SelectedDate.Value.ToShortDateString();
                tem.bsInfante = Convert.ToDouble(txtmontoInfante.Text);
                tem.bsNinio = Convert.ToDouble(txtmontoninio.Text);
                tem.bsAdulto = Convert.ToDouble(txtmontoadulto.Text);
                tem.hotel = lstHolel.SelectedItem.ToString();
                tem.agregar_temporada();
                MessageBox.Show("Se ha agregado la temporada correctamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                limpiar();
                tbConfiguracion_Loaded(sender, e);
            }

        }
        private void limpiar()
        {
            txtdescripcionT.Text = "";
            dpFechaI.SelectedDate = null;
            dpFechaF.SelectedDate = null;
            txtmontoInfante.Text = "";
            txtmontoninio.Text = "";
            txtmontoadulto.Text = "";

        }

        private void dpFechaI_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dpFechaF.DisplayDateStart = dpFechaI.SelectedDate;
        }

        private void btnGuardaCargo_Click(object sender, RoutedEventArgs e)
        {
            if (txtdescripcionC.Text.Equals(""))
            {
                MessageBox.Show("Debe colocar una descripción", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (txtdescripcionC.Text.ToUpper().Equals("PUNTOS ACELERADOS") || txtdescripcionC.Text.ToUpper().Equals("TODO INCLUIDO"))
            {
                MessageBox.Show("Ya existe un cargo con esa descripción", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
           
                
            cargo car = new cargo();
            car.descripcion = txtdescripcionC.Text.ToUpper();
            if (txtobservacion.Text.Equals(""))
                car.observacion = " ";
            else
               car.observacion = txtobservacion.Text.ToUpper();
            if (car.existe())
            {
                MessageBox.Show("Ya existe un cargo con esa descripción", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            car.agregar_cargo();
            MessageBox.Show("Se ha agregado el cargo correctamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            txtdescripcionC.Text="";
            txtobservacion.Text="";
            tbConfiguracion_Loaded(sender, e);

        }

        private void btnGuardaMontoPA_Click(object sender, RoutedEventArgs e)
        {
            DateTime? f=dpFechaIPunto.SelectedDate;
            DateTime? ff=dpFechaFPunto.SelectedDate;
            if (txtmonto.Text.Equals("")||f==null ||ff==null)
            {
                MessageBox.Show("Debe colocar monto y rango de fechas", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (MessageBox.Show("¿Seguro desea actualizar el monto por puntos acelerados?", "Pregunta", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                string[] ini = f.Value.ToShortDateString().Split('/');
                string fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                string[] fin= f.Value.ToShortDateString().Split('/');
                string fechF = fin[2] + "/" + fin[1] + "/" + fin[0];
                montoPA mpa = new montoPA();
                mpa.monto = (Convert.ToDouble(txtmonto.Text));
                mpa.observacion = txtObservacionPA.Text.ToUpper();
                mpa.inicio = fechI;
                mpa.fin = fechF;
                mpa.agregar_montoPA();
                MessageBox.Show("Se ha actualizado el monto por punto acelerado correctamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                txtmonto.Text = "";
                txtObservacionPA.Text = "";
                dpFechaIPunto.SelectedDate = null;
                dpFechaFPunto.SelectedDate = null;
                tbConfiguracion_Loaded(sender, e);
            }
        }

        private void tbConfiguracion_Loaded(object sender, RoutedEventArgs e)
        {
           
            temporada tem = new temporada();
            SqlDataReader sr = tem.listarTemporada();
            DataTable dt = new DataTable();
            dt.Columns.Add("temporada");
            dt.Columns.Add("inicio");
            dt.Columns.Add("fin");
            dt.Columns.Add("infante"); 
            dt.Columns.Add("ninio"); 
            dt.Columns.Add("adulto");
            dt.Columns.Add("hotel");
            if (sr!=null)
            {
                while (sr.Read())
                {
                    DataRow row = dt.NewRow();
                    row[0] = sr.GetString(6).Trim(new char[] { ' ' });
                    row[1] = sr.GetDateTime(1).ToShortDateString();
                    row[2] = sr.GetDateTime(2).ToShortDateString();
                    row[3] = sr.GetDouble(3).ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));
                    row[4] = sr.GetDouble(4).ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));
                    row[5] = sr.GetDouble(5).ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));
                    row[6] = sr.GetString(7);
                    dt.Rows.Add(row);
                }
                dtgCargos.ItemsSource = dt.DefaultView;
                sr.Close();
            }
            cargo car = new cargo();
            DataTable dtcar = new DataTable();
            dtcar.Columns.Add("descripcion");
            dtcar.Columns.Add("observacion");
            sr = car.listar();
            if (sr != null)
            {
                while (sr.Read())
                {
                    DataRow row = dtcar.NewRow();
                    //sr.GetString(2).Trim(new char[] { ' ' })
                    //condicion de validar si es nulo
                    row[0] = sr.IsDBNull(1) ? "" : sr.GetString(1).Trim(new char[] { ' ' });
                    row[1] = sr.IsDBNull(2) ? "" : sr.GetString(1).Trim(new char[] { ' ' });
                    //row[0] = sr.GetString(1).Trim(new char[] { ' ' });
                    //row[1] = sr.GetString(2).Trim(new char[] { ' ' });                
                    dtcar.Rows.Add(row);
                }

                dtgCargos1.ItemsSource = dtcar.DefaultView;
                sr.Close();
            }
            montoPA mpa = new montoPA();
            DataTable dtmon = new DataTable();
            dtmon.Columns.Add("monto");
            dtmon.Columns.Add("inicio");
            dtmon.Columns.Add("fin");
            dtmon.Columns.Add("observacion");
            sr =mpa.buscartodos();
            if (sr != null)
            {
                while (sr.Read())
                {
                    DataRow rowM = dtmon.NewRow();
                    rowM[0] = sr.GetDouble(0).ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));
                    rowM[1] = sr.GetDateTime(2).ToShortDateString();
                    rowM[2] = sr.GetDateTime(3).ToShortDateString();
                    rowM[3] = sr.GetString(1);
                    dtmon.Rows.Add(rowM);
                }
                dtgMontoPA.ItemsSource = dtmon.DefaultView;
                sr.Close();
            }
            DataTable dtmontos = new DataTable();
            dtmontos.Columns.Add("concepto");
            dtmontos.Columns.Add("monto");
            dtmontos.Columns.Add("ref");
            sr = mpa.buscarmontos();
            if (sr != null)
            {
                while (sr.Read())
                {
                    DataRow rowM = dtmontos.NewRow();
                    rowM[0] = sr.GetString(0);
                    rowM[1] = sr.GetDouble(1).ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));
                    rowM[2] = sr.GetInt32(2);
                    dtmontos.Rows.Add(rowM);
                }
                dtgMontos.ItemsSource = dtmontos.DefaultView;
                sr.Close();
            }

            cargar_cmbEstatusFDP();
            formasdepago fdp = new formasdepago();
            dtgFDP.ItemsSource = fdp.listar();

            cargar_cmbEstatusBnc();
            banco bnc = new banco();
            dtgBnc.ItemsSource = bnc.listar();

            
             cargar_cmbEstatusTT();
             tipotarjeta tt = new tipotarjeta();
             dtgTT.ItemsSource = tt.listar();


             cargar_cmbEstatusUsr();

             usuario usr = new usuario();
             cmbPerfilUsr.ItemsSource = usr.listarPerfiles();
             cmbPerfilUsr.DisplayMemberPath = "nombreperfil";
             cmbPerfilUsr.SelectedValuePath = "codigo";
             lusu = usr.listar();
             dtgUsr.ItemsSource = lusu;
             dtgUsr.Items.Refresh();


//cmbPerfilUsr
             
             
        }

        public void cargar_cmbEstatusFDP(){
            cmbEstatusFDP.Items.Add("ACTIVO");
            cmbEstatusFDP.Items.Add("INACTIVO");
            cmbEstatusFDP.SelectedIndex = -1;
        }

        public void cargar_cmbEstatusBnc()
        {
            cmbEstatusBnc.Items.Add("ACTIVO");
            cmbEstatusBnc.Items.Add("INACTIVO");
            cmbEstatusBnc.SelectedIndex = -1;
        }

        
        public void cargar_cmbEstatusTT()
        {

            cmbEstatusTT.Items.Add("ACTIVO");
            cmbEstatusTT.Items.Add("INACTIVO");
            cmbEstatusTT.SelectedIndex = -1;

        }

        public void cargar_cmbEstatusUsr()
        {

            cmbEstatusUsr.Items.Add("ACTIVO");
            cmbEstatusUsr.Items.Add("INACTIVO");
            cmbEstatusUsr.SelectedIndex = -1;

        }
         
         
         


        private void txtmontoInfante_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtmontoninio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtmontoadulto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtmontoInfante_KeyUp(object sender, KeyEventArgs e)
        {
            if (!txtmontoInfante.Text.Equals(""))
            {
                txtmontoInfante.Text = Convert.ToDouble(txtmontoInfante.Text).ToString("N2", CultureInfo.CreateSpecificCulture("es-ES"));
                string[] p = txtmontoInfante.Text.Split(',');
                txtmontoInfante.Select(p[0].Length, 0);
            }
        }

        private void txtmontoninio_KeyUp(object sender, KeyEventArgs e)
        {
            if (!txtmontoninio.Text.Equals(""))
            {
                txtmontoninio.Text = Convert.ToDouble(txtmontoninio.Text).ToString("N2", CultureInfo.CreateSpecificCulture("es-ES"));
                string[] p = txtmontoninio.Text.Split(',');
                txtmontoninio.Select(p[0].Length, 0);
            }
        }

        private void txtmontoadulto_KeyUp(object sender, KeyEventArgs e)
        {
            if (!txtmontoadulto.Text.Equals(""))
            {
                txtmontoadulto.Text = Convert.ToDouble(txtmontoadulto.Text).ToString("N2", CultureInfo.CreateSpecificCulture("es-ES"));
                string[] p = txtmontoadulto.Text.Split(',');
                txtmontoadulto.Select(p[0].Length, 0);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lstHolel.Items.Add("");
            lstHolel.Items.Add("COCHE PUNTA BLANCA");
            lstHolel.Items.Add("ISLA CARIBE");

            if (usrio.codigoPerfil > 1)
                tbItmUsr.IsEnabled = false;

        }

        private void btnGuardaMontos_Click(object sender, RoutedEventArgs e)
        {
            int loc = 0;

            for (int j = 0; j <= dtgMontos.Items.Count - 1; j++)
            {
                if ((dtgMontos.Items[j] as System.Data.DataRowView).Row.ItemArray[1].ToString().Trim(new char[] { ' ' }).Equals(""))
                    loc++;

            }
            if (loc == dtgMontos.Items.Count || loc > 0)
            {
                MessageBox.Show("Debe colocar todos los montos", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            montoPA montos = new montoPA();
            for (int i = 0; i <= dtgMontos.Items.Count - 1; i++)
            {

                montos.actualizar_montos(Convert.ToDouble((dtgMontos.Items[i] as System.Data.DataRowView).Row.ItemArray[1].ToString()),Convert.ToInt32((dtgMontos.Items[i] as System.Data.DataRowView).Row.ItemArray[2].ToString()));

            }
            MessageBox.Show("Se han actualizado los montos correctamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            tbConfiguracion_Loaded(sender, e);
        }




        #region ITEM TRANSACCIONES
        private void btnNuevoFDP_Click(object sender, RoutedEventArgs e)
        {
            codigoFDP = -1;
            txtDescFDP.Text = "";
            cmbEstatusFDP.SelectedIndex = -1;
        }

        private void btnGuardaFDP_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescFDP.Text) || string.IsNullOrWhiteSpace(cmbEstatusFDP.SelectedItem.ToString()) || cmbEstatusFDP.SelectedIndex == -1)
            {

                MessageBox.Show("No debe dejar campos vacíos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            formasdepago fdp = new formasdepago();
            fdp.codigo = codigoFDP;
            fdp.descripcion = txtDescFDP.Text.ToUpper();
            if (!fdp.existeFDP())
            {
                fdp.estatus = cmbEstatusFDP.SelectedItem.ToString();
                if (fdp.guardar_editar() == 1)
                {
                    MessageBox.Show("Datos guardados satisfactoriamente", "Exitoso", MessageBoxButton.OK, MessageBoxImage.Information);
                    btnNuevoFDP_Click(sender, e);
                    //dtgFDP.ItemsSource = null;
                    dtgFDP.ItemsSource = fdp.listar();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el registro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }

            }


        }

        private void txtDescFDP_LostFocus(object sender, RoutedEventArgs e)
        {
            formasdepago fdp = new formasdepago();
            fdp.codigo = codigoFDP;
            fdp.descripcion = txtDescFDP.Text.ToUpper();
            if (fdp.existeFDP())
            {
                MessageBox.Show("Forma de Pago existente en la base de datos. Intente con otra descripción", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                if (codigoFDP == -1)
                    txtDescFDP.Text = "";

            }

        }

        private void dtgFDP_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dtgFDP.SelectedIndex != -1)
            {

                formasdepago item = dtgFDP.SelectedItem as formasdepago;
                codigoFDP = item.codigo;
                txtDescFDP.Text = item.descripcion;
                cmbEstatusFDP.SelectedItem = item.estatus;
            }
        }

        #endregion


        #region ITEM BANCOS

        private void btnNuevoBnc_Click(object sender, RoutedEventArgs e)
        {
            codigoBnc = -1;
            txtDescBnc.Text = "";
            cmbEstatusBnc.SelectedIndex = -1;
        }

        private void btnGuardaBnc_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescBnc.Text) || string.IsNullOrWhiteSpace(cmbEstatusBnc.SelectedItem.ToString()) || cmbEstatusBnc.SelectedIndex == -1)
            {

                MessageBox.Show("No debe dejar campos vacíos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            banco bnc = new banco();
            bnc.codigo = codigoBnc;
            bnc.descripcion = txtDescBnc.Text.ToUpper();
            if (!bnc.existe())
            {
                bnc.estatus = cmbEstatusBnc.SelectedItem.ToString();
                if (bnc.guardar_editar() == 1)
                {
                    MessageBox.Show("Datos guardados satisfactoriamente", "Exitoso", MessageBoxButton.OK, MessageBoxImage.Information);
                    btnNuevoBnc_Click(sender, e);
                    //dtgFDP.ItemsSource = null;
                    dtgBnc.ItemsSource = bnc.listar();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el registro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }

            }
        }

        private void txtDescBnc_LostFocus(object sender, RoutedEventArgs e)
        {
            banco bnc = new banco();
            bnc.codigo = codigoBnc;
            bnc.descripcion = txtDescBnc.Text.ToUpper();
            if (bnc.existe())
            {
                MessageBox.Show("Banco existente en la base de datos. Intente con otra descripción", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                if (codigoBnc == -1)
                    txtDescBnc.Text = "";

            }
        }

        private void dtgBnc_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dtgBnc.SelectedIndex != -1)
            {

                banco item = dtgBnc.SelectedItem as banco;
                codigoBnc = item.codigo;
                txtDescBnc.Text = item.descripcion;
                cmbEstatusBnc.SelectedItem = item.estatus;
            }
        }

        #endregion




        #region ITEM TIPO DE TARJETA
        private void btnNuevoTT_Click(object sender, RoutedEventArgs e)
        {
            codigoTT = -1;
            txtDescTT.Text = "";
            cmbEstatusTT.SelectedIndex = -1;
        }

        private void btnGuardaTT_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescTT.Text) || string.IsNullOrWhiteSpace(cmbEstatusTT.SelectedItem.ToString()) || cmbEstatusTT.SelectedIndex == -1)
            {

                MessageBox.Show("No debe dejar campos vacíos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            tipotarjeta tt = new tipotarjeta();
            tt.codigo = codigoTT;
            tt.descripcion = txtDescTT.Text.ToUpper();
            if (!tt.existe())
            {
                tt.estatus = cmbEstatusTT.SelectedItem.ToString();
                if (tt.guardar_editar() == 1)
                {
                    MessageBox.Show("Datos guardados satisfactoriamente", "Exitoso", MessageBoxButton.OK, MessageBoxImage.Information);
                    btnNuevoTT_Click(sender, e);

                    dtgTT.ItemsSource = tt.listar();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el registro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }

            }
        }

        private void txtDescTT_LostFocus(object sender, RoutedEventArgs e)
        {
            tipotarjeta tt = new tipotarjeta();
            tt.codigo = codigoTT;
            tt.descripcion = txtDescTT.Text.ToUpper();
            if (tt.existe())
            {
                MessageBox.Show("Tarjeta existente en la base de datos. Intente con otra descripción", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                if (codigoTT == -1)
                    txtDescTT.Text = "";

            }
        }

        private void dtgTT_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dtgTT.SelectedIndex != -1)
            {

                tipotarjeta item = dtgTT.SelectedItem as tipotarjeta;
                codigoTT = item.codigo;
                txtDescTT.Text = item.descripcion;
                cmbEstatusTT.SelectedItem = item.estatus;
            }
        }
        #endregion

        private void btnNuevoUsr_Click(object sender, RoutedEventArgs e)
        {
            codigoUsr = -1;
            txtCedUsr.Text = "";
            txtNomUsr.Text = "";
            txtApeUsr.Text = "";
            txtEmailUsr.Text = "";
            txtTlfUsr.Text = "";
            cmbPerfilUsr.SelectedIndex = -1;
            txtLgnUsr.Text = "";
            txtClvUsr.Password = "";
            txtClv2Usr.Password = "";
            cmbEstatusUsr.SelectedIndex = -1;
 

        }

        private void txtCedUsr_LostFocus(object sender, RoutedEventArgs e)
        {
            usuario us = new usuario();
            us.codigo = codigoUsr;
            us.cedula = txtCedUsr.Text;
            if (us.existeCedula()){
                MessageBox.Show("Cédula existente en la base de datos. Intente con otro número", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                if (codigoTT == -1)
                    txtCedUsr.Text = "";

            }

        }

        private void txtLgnUsr_LostFocus(object sender, RoutedEventArgs e)
        {
            usuario us = new usuario();
            us.codigo = codigoUsr;
            us.login = txtLgnUsr.Text.ToUpper();
            if (us.existeLogin())
            {
                MessageBox.Show("Cédula existente en la base de datos. Intente con otro número", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                if (codigoTT == -1)
                    txtLgnUsr.Text = "";

            }
        }

        public string encriptarMD5(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }


        private void btnGuardaUsr_Click(object sender, RoutedEventArgs e)
        {
            if (codigoUsr==-1 && (string.IsNullOrWhiteSpace(txtCedUsr.Text) || string.IsNullOrWhiteSpace(txtNomUsr.Text) || string.IsNullOrWhiteSpace(txtLgnUsr.Text) || string.IsNullOrWhiteSpace(txtClvUsr.Password) || string.IsNullOrWhiteSpace(txtClv2Usr.Password) || cmbPerfilUsr.SelectedIndex == -1 || cmbEstatusUsr.SelectedIndex == -1))
            {

                MessageBox.Show("No debe dejar campos vacíos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (codigoUsr != -1 && (string.IsNullOrWhiteSpace(txtCedUsr.Text) || string.IsNullOrWhiteSpace(txtNomUsr.Text) || string.IsNullOrWhiteSpace(txtLgnUsr.Text)  || cmbPerfilUsr.SelectedIndex == -1 || cmbEstatusUsr.SelectedIndex == -1))
            {

                MessageBox.Show("No debe dejar campos vacíos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if ((txtClvUsr.Password != "" || txtClv2Usr.Password!="") && txtClvUsr.Password != txtClv2Usr.Password)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }

            usuario us = new usuario();
            us.codigo = codigoUsr;
            us.cedula = txtCedUsr.Text;
            us.login = txtLgnUsr.Text.ToUpper();
            if (!us.existeCedula() && !us.existeLogin())
            {

                us.nombres = txtNomUsr.Text.ToUpper();
                us.apellidos = txtApeUsr.Text.ToUpper();
                us.email = txtEmailUsr.Text.ToUpper();
                us.telefono = txtTlfUsr.Text;
                us.codigoPerfil = Convert.ToInt32(cmbPerfilUsr.SelectedValue);
                us.login = txtLgnUsr.Text.ToUpper();

                if (codigoUsr != -1 && txtClvUsr.Password == "" && txtClv2Usr.Password == "")
                    us.clave = claveactual;
                else
                {
                    using (MD5 md5Hash = MD5.Create())//Codificiación MD5 para la contraseña
                    {
                        us.clave = encriptarMD5(md5Hash, txtClvUsr.Password);
                    }


                }

                us.activo = 1;
                if (cmbEstatusUsr.SelectedValue.ToString() == "INACTIVO")
                    us.activo = 0;

                
                if (us.guardar_editar() == 1)
                {
                    MessageBox.Show("Datos guardados satisfactoriamente", "Exitoso", MessageBoxButton.OK, MessageBoxImage.Information);
                    btnNuevoUsr_Click(sender, e);
                    dtgUsr.ItemsSource = us.listar();
                    codigoUsr = -1;
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el registro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }

            }
        }

        private void dtgUsr_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dtgUsr.SelectedIndex != -1)
            {

                usuario item = dtgUsr.SelectedItem as usuario;
                codigoUsr = item.codigo;
                txtCedUsr.Text = item.cedula;
                txtNomUsr.Text = item.nombres;
                txtApeUsr.Text = item.apellidos;
                txtEmailUsr.Text = item.email;
                txtTlfUsr.Text = item.telefono;
                txtLgnUsr.Text = item.login;
                cmbPerfilUsr.SelectedValue = item.codigoPerfil;
                claveactual = item.clave;
                if (item.activo==1)
                    cmbEstatusUsr.SelectedItem = "ACTIVO";
                else
                    cmbEstatusUsr.SelectedItem = "INACTIVO";
            }
        }

        private void txtBsqUsu_KeyUp(object sender, KeyEventArgs e)
        {

            if (txtBsqUsu.Text == "")
                dtgUsr.ItemsSource = lusu;
            else
            {
                librerias.usuario obj_usu = new librerias.usuario();
                dtgUsr.ItemsSource = obj_usu.filtrar(txtBsqUsu.Text);

            }
            

        }





        

        
    }
}
