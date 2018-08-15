using System;
using System.Collections.Generic;
using System.Linq;


namespace Clases
{
    using System.Text;
    using System.Threading.Tasks;
    using System.Data;
    using System.Data.SqlClient;
    using System.ComponentModel;
    using System.Windows;




    using System.Net;
    //using System.DateTime;
    using System.Windows.Forms;
    public partial class Bitacora
    {


        public Bitacora()
        {

        }
        public Bitacora(int mod,int ida,string dsc,string us)
        {
            this.modulo = mod;
            this.idaccion = ida;
            this.descripcion = dsc;
            this.usuario = us;
        }
        
        
        conexion con;

        public DataTable dtt = new DataTable();

        public string usuario { get; set; }


        public string descripcion { get; set; }

        public int idaccion { get; set; }

        public int modulo { get; set; }

        public void cargar_dtt(string txtSQL)
        {
            try
            {
                this.dtt = new DataTable();
                if (con == null)
                    con = new conexion();
                con.conectar();
                SqlCommand cmd = new SqlCommand(txtSQL, con.cnxn);
                SqlDataReader reader = cmd.ExecuteReader();
                this.dtt.Load(reader);
                con.desconectar();

            }
            catch
            {
                con.desconectar();

            }

        }

        
        public int Guardar()
        {
            try
            {
                if (con == null)
                    con = new conexion();
                con.conectar();
                SqlCommand cmd = new SqlCommand("InsertarSuceso", con.cnxn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Fecha", DateTime.Now);
                cmd.Parameters.AddWithValue("@Usuario", usuario);

                cmd.Parameters.AddWithValue("@Host", Convert.ToString(Dns.GetHostName()));
                cmd.Parameters.AddWithValue("@descr", descripcion);
                cmd.Parameters.AddWithValue("@idacc", idaccion);
                cmd.Parameters.AddWithValue("@modulo", modulo);
                cmd.ExecuteNonQuery();
                con.desconectar();
                return 1;

            }
            catch
            {
                con.desconectar();
                return 0;

            }
        }


        





    }
}
