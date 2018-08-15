using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Contratos
{
    public class conexionBD
    {

        public SqlConnection con;

        public DataTable dtt = new DataTable();

        public DataTable dtt_aux = new DataTable();

        public DataSet dsGlobal = new DataSet();

        public DataSet dsContratos = new DataSet();

        public conexionBD()
        {

            
        }

        public void conectar()
        {
            this.con = new SqlConnection();
            this.con.ConnectionString = Globales.emp.conexion;
            this.con.Open();
        }
        public void cerrar() {

            this.con.Close();
        
        }

        public void ejecutar_consulta(string qr_sp, CommandType tipoconsulta, List<Clases.Parameters> Parametros)
        {
            this.conectar();
            SqlCommand cmd = new SqlCommand(qr_sp, con);
            cmd.CommandType = tipoconsulta;
            cmd.CommandText = qr_sp;

            foreach (Clases.Parameters Param in Parametros)
                cmd.Parameters.AddWithValue(Param.nameValue, Param.Valor);

            cmd.ExecuteNonQuery();
            this.cerrar();
        }

        public DataTable generar_datatable(string sql_sp, CommandType tipoconsulta, List<Clases.Parameters> Parametros)
        {
            DataTable result = new DataTable();
            conectar();
            SqlCommand cmd = new SqlCommand(sql_sp, con);
            cmd.CommandType = tipoconsulta;
            cmd.CommandTimeout = 10000;

            foreach (Clases.Parameters Param in Parametros)
                cmd.Parameters.AddWithValue(Param.nameValue, Param.Valor);

            SqlDataReader dr = cmd.ExecuteReader();
            result.Load(dr);
            cerrar();
            return result;
        }


        


        public int nregistros(string txtSQL)
        {
             this.conectar(); 
             SqlCommand cmd = new SqlCommand(txtSQL, con);
             SqlDataReader reader = cmd.ExecuteReader();
             int i = 0;
             while (reader.Read()) {i++;}
             reader.Close();
             this.cerrar();
             return i;
        }

        
        

        




        #region métodos para invocar los sp de opc,liner y closer

        public void sp_reporte_porc_closer_liner(bool closer, DateTime fini, DateTime ffin)
        {

            conectar();

            string sp = closer ? "_SP_volumen_closer" : "_SP_volumen_liner";
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 10000;
            cmd.Parameters.Add("@fechadesde", SqlDbType.DateTime2);
            cmd.Parameters.Add("@fechahasta", SqlDbType.DateTime2);
            cmd.Parameters["@fechadesde"].Value = Globales.yyyy_mm_dd_hhmmss_otra(fini, " 00:00");
            cmd.Parameters["@fechahasta"].Value = Globales.yyyy_mm_dd_hhmmss_otra(ffin, " 23:59");
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                //------ Creación manual de las columnas del datatable para el reporte -------// 
                dtt = new DataTable();
                dtt.Columns.Add("codigo", typeof(String));
                dtt.Columns.Add("nombre", typeof(String));
                dtt.Columns.Add("q", typeof(Int32));
                dtt.Columns.Add("nq", typeof(Int32));
                dtt.Columns.Add("nt", typeof(Int32));
                dtt.Columns.Add("total", typeof(Int32));
                dtt.Columns.Add("procs", typeof(Int32));
                dtt.Columns.Add("pend", typeof(Int32));
                DataColumn colDecimal = new DataColumn("volumen");
                colDecimal.DataType = System.Type.GetType("System.Double");
                dtt.Columns.Add(colDecimal);

                //------ Creación manual de las columnas del datatable de totales para el reporte -------// 
                dtt_aux = new DataTable();
                dtt_aux.Columns.Add("q", typeof(Int32));
                dtt_aux.Columns.Add("nq", typeof(Int32));
                dtt_aux.Columns.Add("nt", typeof(Int32));
                dtt_aux.Columns.Add("total", typeof(Int32));
                DataColumn colDecimal2 = new DataColumn("volumen");
                colDecimal2.DataType = System.Type.GetType("System.Double");
                dtt_aux.Columns.Add(colDecimal2);
                int q, nq, nt, total;
                decimal volumen;
                q = nq = nt = total = 0;
                volumen = 0;
                while (dr.Read())
                {

                    DataRow rw = dtt.NewRow();
                    rw["codigo"] = dr.GetString(0).Trim(new char[] { ' ' });
                    rw["nombre"] = dr.GetString(1).Trim(new char[] { ' ' });
                    rw["q"] = dr.GetInt32(2);
                    rw["nq"] = dr.GetInt32(3);
                    rw["nt"] = dr.GetInt32(4);
                    rw["total"] = dr.GetInt32(5);
                    rw["procs"] = dr.GetInt32(8);
                    rw["pend"] = dr.GetInt32(9);
                    rw["volumen"] = dr.GetDecimal(10);
                    q += dr.GetInt32(2);
                    nq += dr.GetInt32(3);
                    nt += dr.GetInt32(4);
                    total += dr.GetInt32(4) + dr.GetInt32(5);
                    volumen += dr.GetDecimal(10);
                    dtt.Rows.Add(rw);
                }

                DataRow sum = dtt_aux.NewRow();
                sum["q"] = q;
                sum["nq"] = nq;
                sum["nt"] = nt;
                sum["total"] = total;
                sum["volumen"] = volumen;
                dtt_aux.Rows.Add(sum);
            }
            cerrar();

        }

        public void sp_reporte_vol_opc(DateTime fini, DateTime ffin, int prog, string cadprog, int loc)
        {
            conectar();
            SqlCommand cmd = new SqlCommand("_SP_volumen_opc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 10000;
            cmd.Parameters.Add("@fechadesde", SqlDbType.DateTime2);
            cmd.Parameters.Add("@fechahasta", SqlDbType.DateTime2);
            cmd.Parameters.Add("@codprogd", SqlDbType.Int);
            cmd.Parameters.Add("@codprogh", SqlDbType.Int);
            cmd.Parameters.Add("@progd", SqlDbType.Char, 20);
            cmd.Parameters.Add("@progh", SqlDbType.Char, 20);
            cmd.Parameters.Add("@locd", SqlDbType.Int);
            cmd.Parameters.Add("@loch", SqlDbType.Int);
            cmd.Parameters["@fechadesde"].Value = Globales.yyyy_mm_dd_hhmmss_otra(fini, " 00:00");
            cmd.Parameters["@fechahasta"].Value = Globales.yyyy_mm_dd_hhmmss_otra(ffin, " 23:59");
            cmd.Parameters["@codprogd"].Value = prog;
            cmd.Parameters["@codprogh"].Value = prog;
            cmd.Parameters["@progd"].Value = cadprog;
            cmd.Parameters["@progh"].Value = cadprog;
            cmd.Parameters["@locd"].Value = loc;
            cmd.Parameters["@loch"].Value = loc;

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                //------ Creación manual de las columnas del datatable para el reporte -------// 
                dtt = new DataTable();
                dtt.Columns.Add("codigo", typeof(String));
                dtt.Columns.Add("nombre", typeof(String));
                dtt.Columns.Add("q", typeof(Int32));
                dtt.Columns.Add("nq", typeof(Int32));
                dtt.Columns.Add("nt", typeof(Int32));
                dtt.Columns.Add("total", typeof(Int32));
                dtt.Columns.Add("procs", typeof(Int32));
                dtt.Columns.Add("pend", typeof(Int32));
                DataColumn colDecimal = new DataColumn("volumen");
                colDecimal.DataType = System.Type.GetType("System.Double");
                dtt.Columns.Add(colDecimal);

                //------ Creación manual de las columnas del datatable de totales para el reporte -------// 
                dtt_aux = new DataTable();
                dtt_aux.Columns.Add("q", typeof(Int32));
                dtt_aux.Columns.Add("nq", typeof(Int32));
                dtt_aux.Columns.Add("nt", typeof(Int32));
                dtt_aux.Columns.Add("total", typeof(Int32));
                DataColumn colDecimal2 = new DataColumn("volumen");
                colDecimal2.DataType = System.Type.GetType("System.Double");
                dtt_aux.Columns.Add(colDecimal2);
                int q, nq, nt, total;
                decimal volumen;
                q = nq = nt = total = 0;
                volumen = 0;
                while (dr.Read())
                {

                    DataRow vopc = dtt.NewRow();
                    vopc["codigo"] = dr.GetString(0).Trim(new char[] { ' ' });
                    vopc["nombre"] = dr.GetString(1).Trim(new char[] { ' ' });
                    vopc["q"] = dr.GetInt32(2);
                    vopc["nq"] = dr.GetInt32(3);
                    vopc["nt"] = dr.GetInt32(4);
                    vopc["total"] = dr.GetInt32(5);
                    vopc["procs"] = dr.GetInt32(8);
                    vopc["pend"] = dr.GetInt32(9);
                    vopc["volumen"] = dr.GetDecimal(10);
                    q += dr.GetInt32(2);
                    nq += dr.GetInt32(3);
                    nt += dr.GetInt32(4);
                    total += dr.GetInt32(4) + dr.GetInt32(5);
                    volumen += dr.GetDecimal(10);
                    dtt.Rows.Add(vopc);
                }

                DataRow sum = dtt_aux.NewRow();
                sum["q"] = q;
                sum["nq"] = nq;
                sum["nt"] = nt;
                sum["total"] = total;
                sum["volumen"] = volumen;
                dtt_aux.Rows.Add(sum);
            }
            cerrar();

        }


        #endregion




        public void llenardsglobal(string txtSQL, string NombreTabla)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(txtSQL, Globales.emp.conexion);
            SqlConnection _cnx = new SqlConnection();
            SqlCommand _comando = new SqlCommand();
            _cnx.ConnectionString = Globales.emp.conexion;
            _comando.Connection = _cnx;
            _comando.CommandTimeout = 0;
            _comando.CommandText = txtSQL;
            adapter.SelectCommand = _comando;
            

            adapter.Fill(this.dsGlobal, NombreTabla);
        }

        public void eliminartabladsglobal(string NombreTabla)
        {
            this.dsGlobal.Tables.Remove(this.dsGlobal.Tables[NombreTabla]);
        }


        public void llenardscontratos(string txtSQL, string NombreTabla)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(txtSQL, Globales.emp.conexion);
            adapter.Fill(this.dsContratos, NombreTabla);
        }

        public void eliminartabladscontratos(string NombreTabla)
        {
            if (this.dsContratos.Tables.CanRemove(this.dsContratos.Tables[NombreTabla]))
            {
                this.dsContratos.Tables.Remove(this.dsContratos.Tables[NombreTabla]);
            }
        }
    }
}
