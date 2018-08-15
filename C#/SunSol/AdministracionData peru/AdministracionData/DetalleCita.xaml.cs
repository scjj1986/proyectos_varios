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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Clases;
using System.Data;
using System.Windows.Forms;

namespace AdministracionData
{
    /// <summary>
    /// Lógica de interacción para DetalleCita.xaml
    /// </summary>
    public partial class DetalleCita : MetroWindow
    {
        public statusCita subStatus;
        public statusPrincipal stsP;
        public C_Status subStt;
        public C_Cliente cli;
        public DetalleCita()
        {
            InitializeComponent();
        }
        private BindingSource llenarCombo()
        {
            Clases.confirmador tele = new Clases.confirmador();
            DataTable table = new DataTable();
            table.Columns.Add("id");
            table.Columns.Add("nomnbre");
            table.Columns.Add("apellido");
            foreach (var item in tele.listarConfirmador())
            {
                DataRow row = table.NewRow();
                row[0] = item.id_confirmador;
                row[1] = item.nombre;
                row[2] = item.apellido;
                table.Rows.Add(row);
            }
            DataRowCollection rows = table.Rows;

            object[] cell;
            Dictionary<int, string> dic = new Dictionary<int, string>();
            BindingSource binding = new BindingSource();

            foreach (DataRow item in rows)
            {
                cell = item.ItemArray;

                dic.Add(Convert.ToInt32(cell[0]), cell[1].ToString() + " " + cell[2].ToString());

                cell = null;
            }

            binding.DataSource = dic;
            return binding;
        }

        private BindingSource llenarComboTO()
        {
            Clases.C_Telemarketing tele = new Clases.C_Telemarketing();
            DataTable table = new DataTable();
            table.Columns.Add("id");
            table.Columns.Add("nomnbre");
            table.Columns.Add("apellido");
            foreach (var item in tele.listarTelemarketing())
            {
                DataRow row = table.NewRow();
                row[0] = item.id_telemarketing;
                row[1] = item.nombre;
                row[2] = item.codigo;
                table.Rows.Add(row);
            }
            DataRowCollection rows = table.Rows;

            object[] cell;
            Dictionary<int, string> dic = new Dictionary<int, string>();
            BindingSource binding = new BindingSource();

            foreach (DataRow item in rows)
            {
                cell = item.ItemArray;

                dic.Add(Convert.ToInt32(cell[0]), cell[2].ToString());

                cell = null;
            }

            binding.DataSource = dic;
            return binding;
        }
        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
           
           /* txtConfirmador.ItemsSource = llenarCombo();
            txtConfirmador.DisplayMemberPath = "Value";
            txtConfirmador.SelectedValuePath = "Key";*/
            txtTeleOperador.ItemsSource = llenarComboTO();
            txtTeleOperador.DisplayMemberPath = "Value";
            txtTeleOperador.SelectedValuePath="Key";
            if (subStatus != null)
            {
                this.Title = Title + " " + subStatus.descripcion + " | " + cli.nombre + " " + cli.apellido;
                txtobservacion.Focus();
                switch (subStatus.idSubStatus)
                {
                    case 1:
                        txtobservacion.IsEnabled = true;
                        dpFechaNac.IsEnabled = true;
                        hora.IsEnabled = true;
                        min.IsEnabled = true;
                       // txtConfirmador.IsEnabled = true;
                        txtVeces.IsEnabled = false;
                        break;
                    case 2:
                        txtobservacion.IsEnabled = true;
                        dpFechaNac.IsEnabled = false;
                        hora.IsEnabled = false;
                        min.IsEnabled = false;
                        //txtConfirmador.IsEnabled = true;
                        txtVeces.IsEnabled = true;
                        break;
                    case 3:
                        txtobservacion.IsEnabled = true;
                        dpFechaNac.IsEnabled = false;
                        hora.IsEnabled = false;
                        min.IsEnabled = false;
                        //txtConfirmador.IsEnabled = true;
                        txtVeces.IsEnabled = false;
                        break;
                    case 4:
                        txtobservacion.IsEnabled = true;
                        dpFechaNac.IsEnabled = true;
                        hora.IsEnabled = true;
                        min.IsEnabled = true;
                        //txtConfirmador.IsEnabled = true;
                        txtVeces.IsEnabled = false;
                        break;
                    case 5:
                        txtobservacion.IsEnabled = true;
                        dpFechaNac.IsEnabled = false;
                        hora.IsEnabled = false;
                        min.IsEnabled = false;
                        //txtConfirmador.IsEnabled = true;
                        txtVeces.IsEnabled = false;
                        break;

                    default:
                        txtobservacion.IsEnabled = true;
                        dpFechaNac.IsEnabled = false;
                        hora.IsEnabled = false;
                        min.IsEnabled = false;
                        //txtConfirmador.IsEnabled = true;
                        txtVeces.IsEnabled = false;
                    break;

                }
            }
            else
            {
                this.Title = Title + " " + subStt.descripcion + " | " + cli.nombre + " " + cli.apellido;
                if (subStt.id_status == 11) 
                {
                    txtobservacion.IsEnabled = true;
                    dpFechaNac.IsEnabled = true;
                    hora.IsEnabled = true;
                    min.IsEnabled = true;
                    //txtConfirmador.IsEnabled = false;
                    txtVeces.IsEnabled = false;
                }
                if (subStt.id_status == 12)
                {
                    txtobservacion.IsEnabled = true;
                    dpFechaNac.IsEnabled = true;
                    hora.IsEnabled = false;
                    min.IsEnabled = false;
                   // txtConfirmador.IsEnabled = false;
                    txtVeces.IsEnabled = true;
                }
                if (subStt.id_status == 2)
                {
                    txtobservacion.IsEnabled = true;
                    dpFechaNac.IsEnabled = true;
                    hora.IsEnabled = true;
                    min.IsEnabled = true;
                    //txtConfirmador.IsEnabled = true;
                    txtVeces.IsEnabled =false;
                }
                if(subStt.id_status != 12&&subStt.id_status != 12&&subStt.id_status != 11&&subStt.id_status != 2)
                {
                    txtobservacion.IsEnabled = true;
                    dpFechaNac.IsEnabled = false;
                    hora.IsEnabled = false;
                    min.IsEnabled = false;
                    //txtConfirmador.IsEnabled = true;
                    txtVeces.IsEnabled = false;
                }

            }
            Clases.historial his = new Clases.historial();
            dtgrdetalle.ItemsSource = his.buscar(cli.id_cliente);
        }

        private void txtobservacion_LostFocus(object sender, RoutedEventArgs e)
        {
            txtobservacion.Text = txtobservacion.Text.ToUpper();
        }
        private void txtVeces_KeyDown(object sender,System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private async void tlGuardar_Click(object sender, RoutedEventArgs e)
        {
            DateTime? f = dpFechaNac.SelectedDate;
            C_detalleCita dc = new C_detalleCita();
            dc.observacion = txtobservacion.Text;
            if (f!=null)
                dc.fecha = dpFechaNac.SelectedDate.Value;
            if (hora.Value!=null &&min.Value!=null)
                dc.hora = hora.Value.ToString() + ":" + min.Value.ToString();
         /*   if (txtConfirmador.SelectedValue!=null)
                dc.confirmador = (int)txtConfirmador.SelectedValue;*/
            if (txtTeleOperador.SelectedValue != null)
                dc.teleoperador = (int)txtTeleOperador.SelectedValue;
            if (!txtVeces.Text.Equals(""))
                dc.veces = Convert.ToInt32(txtVeces.Text);
            dc.id_cliente = cli.id_cliente;
            if (subStatus == null)
                dc.idstatusCita = 0;
            else
                dc.idstatusCita = subStatus.idSubStatus;

            if (dc.agregardetalleCita() == 1)
            {
                await this.ShowMessageAsync("Información", "Se ha guardado correctamente", MessageDialogStyle.Affirmative);
                this.Hide();
               
              
            }
            else
            {
                await this.ShowMessageAsync("Error", "Error al guardar el usuario", MessageDialogStyle.Affirmative);
            }
        }

        private void txtConfirmador_LostFocus(object sender, RoutedEventArgs e)
        {
            //txtConfirmador.Text = txtConfirmador.Text.ToUpper();
        }

       
    }
}
