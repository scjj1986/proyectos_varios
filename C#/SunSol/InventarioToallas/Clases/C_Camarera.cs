

namespace Clases
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Clases;
    using System.ComponentModel;
    
    public partial class C_Camarera
    {
        public C_Camarera()
        {
            this.C_Movimiento = new HashSet<C_Movimiento>();
            this.C_Supervisor = new C_Supervisor();
        }
    
        public int idCamarera { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public Nullable<int> idSupervisor { get; set; }
        public string nac { get; set; }
        public string documento { get; set; }

        public string cedula { get; set; }

        public string nombresup { get; set; }

        public string cedsup { get; set; }

        public string tipomov { get; set; }

        public string horamov { get; set; }

        public int nhab { get; set; }
        public Nullable<int> activo { get; set; }

        conexion con;

        #region LISTADO DE CAMARERAS

        public List<C_Camarera> listarCamareras()
        {
            List<C_Camarera> list = new List<C_Camarera>();
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_listarCamareras", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    C_Camarera nodo = new C_Camarera();
                    nodo.idCamarera = dr.GetInt32(0);
                    nodo.nombre = dr.GetString(1).Trim(new char[] { ' ' }); ;
                    nodo.apellido = dr.GetString(2).Trim(new char[] { ' ' });
                    nodo.idSupervisor = dr.GetInt32(3);
                    nodo.nac = dr.GetString(4).Trim(new char[] { ' ' });
                    nodo.documento = dr.GetString(5).Trim(new char[] { ' ' });
                    nodo.cedula = nodo.nac + "-" + nodo.documento;
                    nodo.activo = dr.GetInt32(6);
                    nodo.nombresup = dr.GetString(7).Trim(new char[] { ' ' });
                    nodo.cedsup = dr.GetString(8).Trim(new char[] { ' ' });
                    list.Add(nodo);
                }
            }
            con.desconectar();
            return list;
        }

        #endregion

        #region CAMARERA POR ID

        public List<C_Camarera> BuscarCamareraPorId(int id)
        {
            List<C_Camarera> list = new List<C_Camarera>();
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_listarCamareras", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    C_Camarera nodo = new C_Camarera();
                    nodo.idCamarera = dr.GetInt32(0);
                    nodo.nombre = dr.GetString(1).Trim(new char[] { ' ' }); ;
                    nodo.apellido = dr.GetString(2).Trim(new char[] { ' ' });
                    nodo.idSupervisor = dr.GetInt32(3);
                    nodo.nac = dr.GetString(4).Trim(new char[] { ' ' });
                    nodo.documento = dr.GetString(5).Trim(new char[] { ' ' });
                    nodo.cedula = nodo.nac + "-" + nodo.documento;
                    nodo.activo = dr.GetInt32(6);
                    nodo.nombresup = dr.GetString(7).Trim(new char[] { ' ' });
                    nodo.cedsup = dr.GetString(8).Trim(new char[] { ' ' });

                    if(id==nodo.idCamarera)
                        list.Add(nodo);
                }
            }
            con.desconectar();
            return list;
        }

        #endregion

        #region FILTRADO DE CAMARERAS

        public List<C_Camarera> BuscarCamareras(string valor)
        {
            List<C_Camarera> list = new List<C_Camarera>();
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_buscarCamareras", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@buscar", valor);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    C_Camarera nodo = new C_Camarera();
                    nodo.idCamarera = dr.GetInt32(0);
                    nodo.nombre = dr.GetString(1).Trim(new char[] { ' ' }); 
                    nodo.apellido = dr.GetString(2).Trim(new char[] { ' ' });
                    nodo.idSupervisor = dr.GetInt32(3);
                    nodo.nac = dr.GetString(4).Trim(new char[] { ' ' });
                    nodo.documento = dr.GetString(5).Trim(new char[] { ' ' });
                    nodo.cedula = nodo.nac + "-" + nodo.documento;
                    nodo.activo = dr.GetInt32(6);
                    nodo.nombresup = dr.GetString(7).Trim(new char[] { ' ' });
                    nodo.cedsup = dr.GetString(8).Trim(new char[] { ' ' });
                    list.Add(nodo);
                }
            }
            con.desconectar();
            return list;
        }

        #endregion

        #region FILTRADO DE CAMARERAS DISPONIBLES PARA ASIGNAR HABITACIÓN EN LA FECHA ACTUAL

        //Para inserción de asignación de habitaciones
        public List<C_Camarera> BuscarCamarerasDispIns(string valor)
        {
            List<C_Camarera> list = new List<C_Camarera>();
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_buscarCamarerasDisponibles", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@buscar", valor);
            cmd.Parameters.AddWithValue("@fecha", DateTime.Today);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    C_Camarera nodo = new C_Camarera();
                    nodo.idCamarera = dr.GetInt32(0);
                    nodo.nombre = dr.GetString(1).Trim(new char[] { ' ' });
                    nodo.apellido = dr.GetString(2).Trim(new char[] { ' ' });
                    nodo.idSupervisor = dr.GetInt32(3);
                    nodo.nac = dr.GetString(4).Trim(new char[] { ' ' });
                    nodo.documento = dr.GetString(5).Trim(new char[] { ' ' });
                    nodo.cedula = nodo.nac + "-" + nodo.documento;
                    nodo.activo = dr.GetInt32(6);
                    nodo.nombresup = dr.GetString(7).Trim(new char[] { ' ' });
                    nodo.cedsup = dr.GetString(8).Trim(new char[] { ' ' });
                    list.Add(nodo);
                }
            }
            con.desconectar();
            return list;
        }

        //Para modificación de asignación de habitaciones
        public List<C_Camarera> BuscarCamarerasDispEdi(string valor)
        {
            List<C_Camarera> list = new List<C_Camarera>();
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_buscarCamarerasDisponiblesEdi", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@buscar", valor);
            cmd.Parameters.AddWithValue("@fecha", DateTime.Today);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    C_Camarera nodo = new C_Camarera();
                    nodo.idCamarera = dr.GetInt32(0);
                    nodo.nombre = dr.GetString(1).Trim(new char[] { ' ' }); 
                    nodo.apellido = dr.GetString(2).Trim(new char[] { ' ' });
                    nodo.idSupervisor = dr.GetInt32(3);
                    nodo.nac = dr.GetString(4).Trim(new char[] { ' ' });
                    nodo.documento = dr.GetString(5).Trim(new char[] { ' ' });
                    nodo.cedula = nodo.nac + "-" + nodo.documento;
                    nodo.activo = dr.GetInt32(6);
                    nodo.nombresup = dr.GetString(7).Trim(new char[] { ' ' });
                    nodo.cedsup = dr.GetString(8).Trim(new char[] { ' ' });
                    list.Add(nodo);
                }
            }
            else
            {
                con.desconectar();
                //return BuscarCamareras(valor);
            }
            con.desconectar();
            return list;
        }


        //Listado por defecto de Camareras Disponibles (Inserción en Asignación de Habitaciones)
        public List<C_Camarera> ListaCamarerasDisp()
        {
            List<C_Camarera> list = new List<C_Camarera>();
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_ListaCamarerasDisponibles", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fecha", DateTime.Today);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    C_Camarera nodo = new C_Camarera();
                    nodo.idCamarera = dr.GetInt32(0);
                    nodo.nombre = dr.GetString(1).Trim(new char[] { ' ' });
                    nodo.apellido = dr.GetString(2).Trim(new char[] { ' ' });
                    nodo.idSupervisor = dr.GetInt32(3);
                    nodo.nac = dr.GetString(4).Trim(new char[] { ' ' });
                    nodo.documento = dr.GetString(5).Trim(new char[] { ' ' });
                    nodo.cedula = nodo.nac + "-" + nodo.documento;
                    nodo.activo = dr.GetInt32(6);
                    //nodo.nombresup = dr.GetString(7).Trim(new char[] { ' ' });
                    //nodo.cedsup = dr.GetString(8).Trim(new char[] { ' ' });
                    list.Add(nodo);
                }
            }
            
            con.desconectar();
            return list;
        }

        #endregion

        #region LISTADO DE MOVIMIENTOS DE HABITACION POR CAMARERA

        //Suministro de habitación por fecha
        public List<C_Camarera> MovCamPorFecha(DateTime fecha)
        {
            List<C_Camarera> list = new List<C_Camarera>();
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_MovCamPorFecha", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fecha", fecha);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    C_Camarera nodo = new C_Camarera();
                    nodo.idCamarera = dr.GetInt32(0);
                    nodo.nac = dr.GetString(1).Trim(new char[] { ' ' });
                    nodo.documento = dr.GetString(2).Trim(new char[] { ' ' });
                    nodo.cedula = nodo.nac + "-" + nodo.documento;


                    nodo.nombre = dr.GetString(3).Trim(new char[] { ' ' });
                    nodo.apellido = dr.GetString(4).Trim(new char[] { ' ' });
                    nodo.nombresup = (dr.IsDBNull(5) || dr.IsDBNull(6)) ? "-SIN ASIGNAR-" : dr.GetString(5).Trim(new char[] { ' ' }) + " " + dr.GetString(6).Trim(new char[] { ' ' });

                    list.Add(nodo);
                }
            }
            con.desconectar();
            return list;
        }


        //Pérdida de suministros por fecha
        public List<C_Camarera> PerCamPorFecha(DateTime fecha)
        {
            List<C_Camarera> list = new List<C_Camarera>();
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_PerPorFecha", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fecha", fecha);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    C_Camarera nodo = new C_Camarera();
                    nodo.idCamarera = dr.GetInt32(0);
                    nodo.nac = dr.GetString(1).Trim(new char[] { ' ' });
                    nodo.documento = dr.GetString(2).Trim(new char[] { ' ' });
                    nodo.cedula = nodo.nac + "-" + nodo.documento;


                    nodo.nombre = dr.GetString(3).Trim(new char[] { ' ' });
                    nodo.apellido = dr.GetString(4).Trim(new char[] { ' ' });
                    nodo.tipomov = dr.GetString(5).Trim(new char[] { ' ' });

                    //nodo.nombresup = dr.GetString(6).Trim(new char[] { ' ' }) + " " + dr.GetString(7).Trim(new char[] { ' ' });
                    nodo.nombresup = (dr.IsDBNull(6) || dr.IsDBNull(7)) ? "-SIN ASIGNAR-" : dr.GetString(6).Trim(new char[] { ' ' }) + " " + dr.GetString(7).Trim(new char[] { ' ' });
                    nodo.horamov = dr.GetString(8).Trim(new char[] { ' ' });
                    list.Add(nodo);
                }
            }
            con.desconectar();
            return list;
        }

        #endregion

        

        #region LISTADO DE CAMARERAS POR SUPERVISOR ENCARGADO

        
        public List<C_Camarera> BuscarCamarerasPorSupervisor(int id)
        {
            List<C_Camarera> list = new List<C_Camarera>();
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_buscarCamarerasPorSupervisor", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idsup", id);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    C_Camarera nodo = new C_Camarera();
                    nodo.nac = dr.GetString(0).Trim(new char[] { ' ' });
                    nodo.documento = dr.GetString(1).Trim(new char[] { ' ' });
                    nodo.cedula = nodo.nac + "-" + nodo.documento;
                    nodo.nombre = dr.GetString(2).Trim(new char[] { ' ' }); ;
                    nodo.apellido = dr.GetString(3).Trim(new char[] { ' ' });
                    list.Add(nodo);
                }
            }
            con.desconectar();
            return list;
        }

        #endregion

        #region MÉTODOS PARA VALIDAR CÉDULA REPETIDA (INSERCIÓN Y MODIFICACIÓN)

        //Para inserción
        public int existeCedula()
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_existeCedulaCamarera", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nac", nac);
            cmd.Parameters.AddWithValue("@documento", documento);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                con.desconectar();
                return 1;
            }
            else
            {
                con.desconectar();
                return 0;
            }
        }


        //Para modificación
        public int existeCedula2()
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_existeCedulaCamarera2", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", idCamarera);
            cmd.Parameters.AddWithValue("@nac", nac);
            cmd.Parameters.AddWithValue("@documento", documento);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                con.desconectar();
                return 1;
            }
            else
            {
                con.desconectar();
                return 0;
            }
        }

        #endregion

        #region AGREGAR/EDITAR CAMARERA

        public int NuevaCamarera()
        {
            try
            {
                if (con == null)
                    con = new conexion();
                con.conectar();
                SqlCommand cmd = new SqlCommand("_sp_nuevaCamarera", con.cnxn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nac", nac);
                cmd.Parameters.AddWithValue("@documento", documento);
                cmd.Parameters.AddWithValue("@nombre", nombre.ToUpper());
                cmd.Parameters.AddWithValue("@apellido", apellido.ToUpper());
                cmd.Parameters.AddWithValue("@estado", activo);
                cmd.Parameters.AddWithValue("@idsup", idSupervisor);
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

        public int EditarCamarera()
        {
            try
            {
                if (con == null)
                    con = new conexion();
                con.conectar();
                SqlCommand cmd = new SqlCommand("sp_mod_Camarera", con.cnxn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", idCamarera);
                cmd.Parameters.AddWithValue("@nac", nac);
                cmd.Parameters.AddWithValue("@documento", documento);
                cmd.Parameters.AddWithValue("@nombre", nombre.ToUpper());
                cmd.Parameters.AddWithValue("@apellido", apellido.ToUpper());
                cmd.Parameters.AddWithValue("@estado", activo);
                cmd.Parameters.AddWithValue("@idsup", idSupervisor);
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

        #endregion

        #region LISTADO DE HABITACIONES ASIGNADAS (MÓDULO DE ASIGNACIÓN DE HABITACIONES POR FECHA)

        public List<C_Camarera> ListAsignHabCamHoy()
        {
            List<C_Camarera> list = new List<C_Camarera>();
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_ListadoAsignCamHabFecha", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fecha", DateTime.Today);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    C_Camarera nodo = new C_Camarera();
                    nodo.idCamarera = dr.GetInt32(0);
                    nodo.nombre = dr.GetString(1).Trim(new char[] { ' ' });
                    nodo.apellido = dr.GetString(2).Trim(new char[] { ' ' });
                    nodo.nhab = dr.GetInt32(5);
                    nodo.cedula = dr.GetString(6).Trim(new char[] { ' ' }) + "-" + dr.GetString(7).Trim(new char[] { ' ' });
                    nodo.idSupervisor = dr.GetInt32(8);
                    if (nodo.idSupervisor != -1)
                        nodo.nombresup = dr.GetString(3).Trim(new char[] { ' ' }) + " " + dr.GetString(4).Trim(new char[] { ' ' });
                    else
                        nodo.nombresup = "-SIN ASIGNAR-";
                    list.Add(nodo);
                }
            }
            con.desconectar();
            return list;
        }

        public C_Camarera FiltrarAsignHabCamFecha(string valor, DateTime fch)
        {
            C_Camarera nodo = null;
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_FiltradoAsignCamHabFecha", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fecha", fch);
            cmd.Parameters.AddWithValue("@numhab", valor);
            cmd.Parameters.AddWithValue("@idc", idCamarera);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    nodo = new C_Camarera();
                    nodo.idCamarera = dr.GetInt32(0);
                }
            }
            con.desconectar();
            return nodo;
        }

        #endregion

        #region LISTADOS DE HABITACIONES ASIGNADAS (MÓDULO DE SUMINISTRO DE HABITACIONES)


        public List<C_Camarera> ListAsignHabCamHoy_AsgSum()
        {
            List<C_Camarera> list = new List<C_Camarera>();
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_ListadoAsignCamHabFecha", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fecha", DateTime.Today);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    C_Camarera nodo = new C_Camarera();
                    nodo.idSupervisor = dr.GetInt32(8);
                    //if (nodo.idSupervisor != -1){
                        nodo.idCamarera = dr.GetInt32(0);
                        nodo.nombre = dr.GetString(1).Trim(new char[] { ' ' });
                        nodo.apellido = dr.GetString(2).Trim(new char[] { ' ' });
                        nodo.nhab = dr.GetInt32(5);
                        nodo.cedula = dr.GetString(6).Trim(new char[] { ' ' }) + "-" + dr.GetString(7).Trim(new char[] { ' ' });
                        if (nodo.idSupervisor != -1)
                            nodo.nombresup = dr.GetString(3).Trim(new char[] { ' ' }) + " " + dr.GetString(4).Trim(new char[] { ' ' });
                        else
                            nodo.nombresup = "-SIN ASIGNAR-";
                        list.Add(nodo);
                    //}
                }
            }
            con.desconectar();
            return list;
        }


        public List<C_Camarera> Filtrado_ListAsignHabCamHoy_AsgSum(string valor)
        {
            List<C_Camarera> list = new List<C_Camarera>();
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_ListadoAsignCamHabFecha", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fecha", DateTime.Today);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    C_Camarera nodo = new C_Camarera();
                    nodo.idSupervisor = dr.GetInt32(8);
                    nodo.cedula = dr.GetString(6).Trim(new char[] { ' ' }) + "-" + dr.GetString(7).Trim(new char[] { ' ' });
                    nodo.nombre = dr.GetString(1).Trim(new char[] { ' ' });
                    nodo.apellido = dr.GetString(2).Trim(new char[] { ' ' });
                    if ((nodo.cedula.Contains(valor) || nodo.nombre.Contains(valor.ToUpper()) || nodo.apellido.Contains(valor.ToUpper())))
                    {
                        nodo.idCamarera = dr.GetInt32(0);
                        
                        nodo.nhab = dr.GetInt32(5);

                        if (nodo.idSupervisor != -1)
                            nodo.nombresup = dr.GetString(3).Trim(new char[] { ' ' }) + " " + dr.GetString(4).Trim(new char[] { ' ' });
                        else
                            nodo.nombresup = "-SIN ASIGNAR-";
                        
                        
                        list.Add(nodo);
                    }
                }
            }
            con.desconectar();
            return list;
        }

        #endregion

        #region LISTADO DE ASIGNACIÓN DE HABITACIONES POR FECHA (AGRUPADO POR CAMARERA)

        public List<C_Camarera> ListAsignHabCamFecha(DateTime fecha)
        {
            List<C_Camarera> list = new List<C_Camarera>();
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_ListadoAsignCamHabFecha", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fecha", fecha);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    C_Camarera nodo = new C_Camarera();
                    nodo.idCamarera = dr.GetInt32(0);
                    nodo.nombre = dr.GetString(1).Trim(new char[] { ' ' });
                    nodo.apellido = dr.GetString(2).Trim(new char[] { ' ' });

                    nodo.nombresup = (dr.IsDBNull(3) || dr.IsDBNull(4)) ? "-SIN ASIGNAR-" : dr.GetString(3).Trim(new char[] { ' ' }) + " " + dr.GetString(4).Trim(new char[] { ' ' });

                    //nodo.nombresup = dr.GetString(3).Trim(new char[] { ' ' }) + " " + dr.GetString(4).Trim(new char[] { ' ' });
                    nodo.nhab = dr.GetInt32(5);
                    nodo.cedula = dr.GetString(6).Trim(new char[] { ' ' }) + "-" + dr.GetString(7).Trim(new char[] { ' ' });
                    nodo.idSupervisor = dr.GetInt32(8);

                    list.Add(nodo);

                }
            }
            con.desconectar();
            return list;
        }

        #endregion

        public virtual C_Supervisor C_Supervisor { get; set; }
        public virtual ICollection<C_Movimiento> C_Movimiento { get; set; }
    }
}
