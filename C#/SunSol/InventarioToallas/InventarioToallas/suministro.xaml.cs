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
using System.Security.Cryptography;
using System.Configuration;
using System.IO;

namespace InventarioToallas
{
    
    public partial class suministro : Page
    {
        public suministro()
        {
            InitializeComponent();
        }

        public string accion;

        #region CARGA DE LA PÁGINA
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Clases.C_Suministro sum = new Clases.C_Suministro();
            dtgrdsum.ItemsSource = sum.listarSuministro();
            cmbTipSum.Items.Clear();
            cmbTipSum.Items.Add("CAMBIO");
            cmbTipSum.Items.Add("REPOSICION");
        }
        #endregion

        #region MOSTRAR FORMULARIO SUMINISTRO (INSERTAR)

        private void BtnNvSum_Click(object sender, RoutedEventArgs e)
        {
            flNuevoSum.Header = "Nuevo Suministro";
            limpiarform();
            flNuevoSum.IsOpen = true;
            accion = "INSERTAR";
        }

        #endregion

        #region BUSCAR SUMINISTRO EN EL DATAGRID

        private void txtBuscarSum_KeyUp(object sender, KeyEventArgs e)
        {

            Clases.C_Suministro sum = new Clases.C_Suministro();
            dtgrdsum.ItemsSource = null;
            if (sum.BuscarSuministros(txtBuscarSum.Text).Count > 0)
            {
                dtgrdsum.ItemsSource = sum.BuscarSuministros(txtBuscarSum.Text);

            }
        }

        #endregion

        #region ELEGIR UN SUMINISTRO EN EL DATAGRID CON DOBLECLICK (EDITAR)
        private void dtgrdsum_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            if (dtgrdsum.SelectedIndex >= 0)
            {

                Clases.C_Suministro sum = dtgrdsum.SelectedItem as Clases.C_Suministro;
                accion = "EDITAR";
                flNuevoSum.Header = "Editar Suministro";
                llenarform(sum);
                flNuevoSum.IsOpen = true;

            }

        }
        #endregion

        #region PÉRDIDA DE FOCO EN CAMPOS NOMBRE (BUSCAR NOMBRE EN BASE DE DATOS PARA EVITAR REDUNDANCIA Y CONVERTIR A MAYÚSCULA) Y DESCRIPCION (SOLO MAYÚSCULA)
        private void txtNombreSum_LostFocus(object sender, RoutedEventArgs e)
        {

            txtNombreSum.Text = txtNombreSum.Text.ToUpper();
            if (accion == "INSERTAR")
            {
                
                if (txtNombreSum.Text != "")
                {
                    Clases.C_Suministro sm = new Clases.C_Suministro();
                    sm.descripcion = txtNombreSum.Text;
                    if (sm.existeNombre() == 1)
                    {
                        MessageBox.Show("Existe un suministro con esa descripción", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtNombreSum.Text = "";
                        txtNombreSum.Focus();
                        return;
                    }
                }
            }
            else
            {
                if (txtNombreSum.Text != "")
                {
                    Clases.C_Suministro sm = new Clases.C_Suministro();
                    sm.descripcion = txtNombreSum.Text;
                    sm.idSuministro = Convert.ToInt32(txtIdSum.Text);
                    if (sm.existeNombre2() == 1)
                    {
                        MessageBox.Show("Existe otro suministro con esa descripción", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtNombreSum.Text = "";
                        txtNombreSum.Focus();
                        return;
                    }
                }
            }
        }

        private void txtDescSum_LostFocus(object sender, RoutedEventArgs e)
        {
            txtDescSum.Text = txtDescSum.Text.ToUpper();
        }
        #endregion

        #region CLICK AL GUARDAR (INSERTAR Y EDITAR)
        private void tlGuardarSum_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreSum.Text) || string.IsNullOrWhiteSpace(txtCEstSum.Text) || string.IsNullOrWhiteSpace(cmbTipSum.Text))
            {
                MessageBox.Show("Debe completar campos obligatorios", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            

            Clases.C_Suministro newSum = new Clases.C_Suministro();
            newSum.descripcion = txtNombreSum.Text;
            newSum.observacion = txtDescSum.Text;
            newSum.cantidad = Convert.ToInt32(txtCEstSum.Text);
            newSum.tipo = cmbTipSum.Text;
            if (accion == "INSERTAR")
            {
                if (newSum.NuevoSuministro() == 1)
                {
                    MessageBox.Show("Se ha guardado correctamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                    tlCancelarSum_Click(sender, e);
                    Page_Loaded(sender, e);
                }
                else
                {
                    MessageBox.Show("Error al guardar el suministro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                newSum.idSuministro = Convert.ToInt32(txtIdSum.Text);
                if (newSum.EditarSuministro() == 1)
                {
                    MessageBox.Show("Se ha modificado correctamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                    tlCancelarSum_Click(sender, e);
                    Page_Loaded(sender, e);
                }
                else
                {
                    MessageBox.Show("Error al guardar el suministro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        #endregion

        //Carga de datos en el formulario (Para editar)

        public void llenarform(Clases.C_Suministro sum)
        {
            txtIdSum.Text = Convert.ToString(sum.idSuministro);
            txtNombreSum.Text = sum.descripcion;
            txtDescSum.Text = sum.observacion;
            txtCEstSum.Text = Convert.ToString(sum.cantidad);
            cmbTipSum.Text = Convert.ToString(sum.tipo);

        }
        //Método para limpiar el formulario

        public void limpiarform()
        {
            txtIdSum.Text = "";
            txtNombreSum.Text = "";
            txtDescSum.Text = "";
            txtCEstSum.Text = "";
            cmbTipSum.Text = "";
        }

        private void tlCancelarSum_Click(object sender, RoutedEventArgs e)
        {
            limpiarform();
            flNuevoSum.IsOpen = false;
        }

        //Validación en Cantidad por habitación (Valores numéricos)


        private void txtCEstSum_KeyUp(object sender, KeyEventArgs e)
        {
            int i = 0;
            if (!int.TryParse(txtCEstSum.Text, out i))
            {
                txtCEstSum.Text = "";
            }
        }

        private void txtCEstSum_KeyDown(object sender, KeyEventArgs e)
        {

        }

        
    }
}
