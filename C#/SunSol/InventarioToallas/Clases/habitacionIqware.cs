using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

//using System.Drawing.Color;
using System.Windows.Input;





using System.Windows;


namespace Clases
{
    public partial class habitacionIqware
    {
        conexion con,con2;
        public int ID_Room { get; set; }
        public string RoomNo { get; set; }
        public int IsHSKRoomOccupied{ get; set; }
        public int HSKRoomStatusType{ get; set; }
        public int HSKRoomInspectionType{ get; set; }
        public int ID_RoomType{ get; set; }
        public string RoomTypeShortName{ get; set; }
        public string RoomTypeName{ get; set; }
        public int HSKSection{ get; set; }
        public string HSKGShortName{ get; set; }
        public string HSKGSName{ get; set; }
        public int ID_Floor{ get; set; }
        public string FloorShortName { get; set; }
        public string FloorName{ get; set; }

        public int ID_Building{ get; set; }
        public string Building{ get; set; }
        public string status { get; set; }
        public string nameBuilding{ get; set; }

        public string Section { get; set; }

        public int GuestTotal { get; set; }

        public int llegada { get; set; }

        public int salida { get; set; }

        public bool Selec { get; set; }

        private bool _IsSelected = false;
        public bool IsSelected { get { return _IsSelected; } set { _IsSelected = value; OnChanged("IsSelected"); } }

        public string modulo { get; set; }

        public string Color { get; set; }

        public bool update = false;

        

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        #endregion

        #region MÉTODOS PARA PROCESAR EXTRAS EN HABITACIONES

        public List<C_Extra> lextsumtipo(int idh, int idc, string tipsum, DateTime fch)
        {
            List<C_Extra> list = new List<C_Extra>();
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_listarExtSum", con.cnxn);
            cmd.Parameters.AddWithValue("@idh", idh);
            cmd.Parameters.AddWithValue("@fecha", fch);
            cmd.Parameters.AddWithValue("@idc", idc);
            cmd.Parameters.AddWithValue("@tipo", tipsum);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    C_Extra nodo = new C_Extra();
                    nodo.idSuministro = dr.GetInt32(0);
                    nodo.tipo = dr.GetString(1).Trim(new char[] { ' ' });
                    nodo.descripcion = dr.GetString(2).Trim(new char[] { ' ' });
                    nodo.idHabitacion = idh;
                    nodo.cantidad = dr.GetInt32(4);
                    nodo.fecha = dr.GetDateTime(5);
                    nodo.idUsuario = dr.GetInt32(6);
                    nodo.fechaModificacion = dr.GetDateTime(7);
                    nodo.observacion = dr.GetString(8).Trim(new char[] { ' ' });
                    nodo.hora = dr.GetString(9).Trim(new char[] { ' ' });
                    nodo.idCamarera = dr.GetInt32(10);
                    nodo.nhab = dr.GetString(11).Trim(new char[] { ' ' });
                    list.Add(nodo);
                }
            }
            con.desconectar();
            return list;
        }

        public void cargar_list_ext_tipo(int idc)
        {


            lextcamb = new List<C_Extra>();
            lextcamb = lextsumtipo(ID_Room, idc, "CAMBIO", DateTime.Today);//Listado de Extras de suministros (CAMBIO) de una habitación específica
            lextrep = new List<C_Extra>();
            lextrep = lextsumtipo(ID_Room, idc, "REPOSICION", DateTime.Today);//Listado de Extras de suministros (CAMBIO) de una habitación específica


        }



        #endregion
        

        public List<C_Suministro> lsumcamb { get; set; }

        public List<C_Suministro> lsumrep { get; set; }

        public List<C_Extra> lextcamb { get; set; }

        public List<C_Extra> lextrep { get; set; }

        public List<C_Extra> lnvoextcamb { get; set; }

        public List<C_Extra> lnvoextrep { get; set; }

        #region LISTA DE PÉRDIDA POR FECHA (POR CADA CAMARERA)

        public List<habitacionIqware> listarperhabxcamfecha(int id, DateTime fecha)
        {
            List<habitacionIqware> list = new List<habitacionIqware>();
            if (con == null)
            {
                con = new conexion();
                con.conexionIqware();
            }
            con.conectarIqware();
            SqlCommand cmd = new SqlCommand("_listarHabitacionesToallas", con.cnxnIq);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    habitacionIqware hab = new habitacionIqware();
                    hab.status = "";
                    hab.ID_Room = Convert.ToInt32(dr["ID_Room"]);
                    hab.RoomNo = Convert.ToString(dr["RoomNo"]);
                    hab.HSKGSName = Convert.ToString(dr["HSKGSName"]);
                    hab.GuestTotal = Convert.ToInt32(dr["GuestTotal"]);
                    hab.IsHSKRoomOccupied = Convert.ToInt32(dr["IsHSKRoomOccupied"]);
                    hab.HSKRoomStatusType = Convert.ToInt32(dr["HSKRoomStatusType"]);
                    hab.HSKRoomInspectionType = Convert.ToInt32(dr["HSKRoomInspectionType"]);
                    if (hab.IsHSKRoomOccupied == 1)
                        hab.status = hab.status + "O";
                    else
                        hab.status = hab.status + "V";

                    if (hab.HSKRoomStatusType == 0)
                        hab.status = hab.status + "L";
                    else
                        hab.status = hab.status + "S";

                    if (hab.HSKRoomInspectionType == 0)
                        hab.status = hab.status + "I";
                    else
                        hab.status = hab.status + "N";


                    hab.ID_RoomType = dr.GetInt32(2);
                    hab.RoomTypeShortName = dr.GetString(3).Trim(new char[] { ' ' });
                    hab.RoomTypeName = dr.GetString(4).Trim(new char[] { ' ' });
                    hab.HSKSection = Convert.ToInt32(dr["HSKSection"]);
                    hab.HSKGShortName = dr.GetString(6).Trim(new char[] { ' ' });
                    hab.HSKGSName = dr.GetString(7).Trim(new char[] { ' ' });
                    hab.ID_Floor = dr.GetInt32(8);
                    hab.FloorShortName = dr.GetString(9).Trim(new char[] { ' ' });
                    hab.FloorName = dr.GetString(10).Trim(new char[] { ' ' });
                    hab.ID_Building = dr.GetInt32(11);
                    hab.Building = dr.GetString(12).Trim(new char[] { ' ' });
                    hab.nameBuilding = dr.GetString(13).Trim(new char[] { ' ' });

                    hab.RoomNo = hab.RoomNo.ToUpper();
                    hab.RoomTypeName = hab.RoomTypeName.ToUpper();
                    hab.HSKGSName = hab.HSKGSName.ToUpper();

                    if (perhabxcam(id, hab.ID_Room, fecha))
                    {
                        list.Add(hab);
                    }

                }
            }
            con.desconectaIqware();
            return list;
        }

        public bool perhabxcam(int idc, int idh, DateTime fecha)
        {

            if (con2 == null)
                con2 = new conexion();
            con2.conectar();

            SqlCommand cmd = new SqlCommand("_sp_PerMovCamFecha", con2.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idh", idh);
            cmd.Parameters.AddWithValue("@idc", idc);
            cmd.Parameters.AddWithValue("@fecha", fecha);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                con2.desconectar();
                return true;
            }
            con2.desconectar();
            return false;

        }

        #endregion


        #region LISTADO DE HABITACIONES ASIGNADAS (MODIFICACIÓN)
        public List<habitacionIqware> listarhabxcamfecha(int id, DateTime fecha)
        {
            List<habitacionIqware> list = new List<habitacionIqware>();
            if (con == null)
            {
                con = new conexion();
                con.conexionIqware();
            }
            con.conectarIqware();
            SqlCommand cmd = new SqlCommand("_listarHabitacionesToallas", con.cnxnIq);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    habitacionIqware hab = new habitacionIqware();
                    hab.status = "";
                    hab.ID_Room = Convert.ToInt32(dr["ID_Room"]);
                    hab.RoomNo = Convert.ToString(dr["RoomNo"]);
                    hab.HSKGSName = Convert.ToString(dr["HSKGSName"]);
                    hab.GuestTotal = Convert.ToInt32(dr["GuestTotal"]);
                    hab.IsHSKRoomOccupied = Convert.ToInt32(dr["IsHSKRoomOccupied"]);
                    hab.HSKRoomStatusType = Convert.ToInt32(dr["HSKRoomStatusType"]);
                    hab.HSKRoomInspectionType = Convert.ToInt32(dr["HSKRoomInspectionType"]);
                    if (hab.IsHSKRoomOccupied == 1)
                        hab.status = hab.status + "O";
                    else
                        hab.status = hab.status + "V";

                    if (hab.HSKRoomStatusType == 0)
                        hab.status = hab.status + "L";
                    else
                        hab.status = hab.status + "S";

                    if (hab.HSKRoomInspectionType == 0)
                        hab.status = hab.status + "I";
                    else
                        hab.status = hab.status + "N";


                    hab.ID_RoomType = dr.GetInt32(2);
                    hab.RoomTypeShortName = dr.GetString(3).Trim(new char[] { ' ' });
                    hab.RoomTypeName = dr.GetString(4).Trim(new char[] { ' ' });
                    hab.HSKSection = Convert.ToInt32(dr["HSKSection"]);
                    hab.HSKGShortName = dr.GetString(6).Trim(new char[] { ' ' });
                    hab.HSKGSName = dr.GetString(7).Trim(new char[] { ' ' });
                    hab.ID_Floor = dr.GetInt32(8);
                    hab.FloorShortName = dr.GetString(9).Trim(new char[] { ' ' });
                    hab.FloorName = dr.GetString(10).Trim(new char[] { ' ' });
                    hab.ID_Building = dr.GetInt32(11);
                    hab.Building = dr.GetString(12).Trim(new char[] { ' ' });
                    hab.nameBuilding = dr.GetString(13).Trim(new char[] { ' ' });

                    hab.RoomNo = hab.RoomNo.ToUpper();
                    hab.RoomTypeName = hab.RoomTypeName.ToUpper();
                    hab.HSKGSName = hab.HSKGSName.ToUpper();

                    if (habxcam(id, hab.ID_Room, fecha))
                        list.Add(hab);
                    

                }
            }
            con.desconectaIqware();
            return list;
        }

        public bool habxcam(int idc, int idh, DateTime fecha)
        {

            if (con2 == null)
                con2 = new conexion();
            con2.conectar();

            SqlCommand cmd = new SqlCommand("_sp_MovHabCamFecha", con2.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idh", idh);
            cmd.Parameters.AddWithValue("@idc", idc);
            cmd.Parameters.AddWithValue("@fecha", fecha);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                con2.desconectar();
                return true;

            }
            con2.desconectar();
            return false;

        }

        public List<habitacionIqware> listarhabasigxcamysup(int idc, int ids, DateTime fecha)
        {
            List<habitacionIqware> list = new List<habitacionIqware>();
            if (con == null)
            {
                con = new conexion();
                con.conexionIqware();
            }
            con.conectarIqware();
            SqlCommand cmd = new SqlCommand("_listarHabitacionesToallas", con.cnxnIq);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    habitacionIqware hab = new habitacionIqware();
                    hab.status = "";
                    hab.ID_Room = Convert.ToInt32(dr["ID_Room"]);
                    hab.RoomNo = Convert.ToString(dr["RoomNo"]);
                    hab.HSKGSName = Convert.ToString(dr["HSKGSName"]);//Módulo
                    hab.GuestTotal = Convert.ToInt32(dr["GuestTotal"]);//pax
                    hab.IsHSKRoomOccupied = Convert.ToInt32(dr["IsHSKRoomOccupied"]);
                    hab.HSKRoomStatusType = Convert.ToInt32(dr["HSKRoomStatusType"]);
                    hab.HSKRoomInspectionType = Convert.ToInt32(dr["HSKRoomInspectionType"]);
                    hab.llegada = Convert.ToInt32(dr["llegada"]);
                    hab.Section = Convert.ToString(dr["Section"]).Trim(new char[] { ' ' });

                    if (hab.IsHSKRoomOccupied == 1)
                        hab.status = hab.status + "O";
                    else
                        hab.status = hab.status + "V";

                    if (hab.HSKRoomStatusType == 0)
                        hab.status = hab.status + "L";
                    else
                        hab.status = hab.status + "S";

                    if (hab.HSKRoomInspectionType == 0)
                        hab.status = hab.status + "I";
                    else
                        hab.status = hab.status + "N";



                    hab.ID_RoomType = dr.GetInt32(2);
                    hab.RoomTypeShortName = dr.GetString(3).Trim(new char[] { ' ' });//Tipo (abreviado)
                    hab.RoomTypeName = dr.GetString(4).Trim(new char[] { ' ' });
                    hab.HSKSection = Convert.ToInt32(dr["HSKSection"]);
                    hab.HSKGShortName = dr.GetString(6).Trim(new char[] { ' ' });
                    hab.HSKGSName = dr.GetString(7).Trim(new char[] { ' ' });
                    hab.ID_Floor = dr.GetInt32(8);
                    hab.FloorShortName = dr.GetString(9).Trim(new char[] { ' ' });
                    hab.FloorName = dr.GetString(10).Trim(new char[] { ' ' });
                    hab.ID_Building = dr.GetInt32(11);
                    hab.Building = dr.GetString(12).Trim(new char[] { ' ' });
                    hab.nameBuilding = dr.GetString(13).Trim(new char[] { ' ' });

                    hab.RoomNo = hab.RoomNo.ToUpper();
                    hab.RoomTypeName = hab.RoomTypeName.ToUpper();
                    hab.HSKGSName = hab.HSKGSName.ToUpper();

                    if (hab.HSKGShortName.ToUpper() == "CABAÑAS")
                        hab.modulo = "CABAÑAS";
                    else if (hab.HSKGShortName.ToUpper() == "P2RM5" || hab.HSKGShortName.ToUpper() == "P1RM5")
                        hab.modulo = "MODULO5";
                    else if (hab.RoomNo.ToUpper() == "201" || hab.RoomNo.ToUpper() == "217")
                        hab.modulo = "TSUIJKI";
                    else if (hab.RoomNo.ToUpper() == "302" || hab.RoomNo.ToUpper() == "322" || hab.RoomNo.ToUpper() == "419")
                        hab.modulo = "TSUIJQ";
                    else if (hab.RoomNo.ToUpper() == "403" || hab.RoomNo.ToUpper() == "505")
                        hab.modulo = "TSUIJK";
                    else
                        hab.modulo = hab.Building;

                    if (camysuphab(idc, hab.ID_Room, ids, fecha))
                    {
                        list.Add(hab);
                    }

                }
            }
            con.desconectaIqware();
            return list;
        }

        public bool camysuphab(int idc, int idh, int ids, DateTime fecha)
        {


            if (con2 == null)
                con2 = new conexion();
            con2.conectar();

            SqlCommand cmd = new SqlCommand("_sp_CamYSupHabFecha", con2.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idc", idc);
            cmd.Parameters.AddWithValue("@idh", idh);
            cmd.Parameters.AddWithValue("@ids", ids);
            cmd.Parameters.AddWithValue("@fecha", fecha);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                con2.desconectar();
                return true;

            }
            con2.desconectar();
            return false;

        }

        #endregion




        #region LISTADO DE HABITACIONES ASIGNADAS A UNA CAMARERA(POR ID) POR FECHA


        public List<habitacionIqware> listarhabasigxcam(int id, DateTime fecha)
        {
            List<habitacionIqware> list = new List<habitacionIqware>();
            if (con == null)
            {
                con = new conexion();
                con.conexionIqware();
            }
            con.conectarIqware();
            SqlCommand cmd = new SqlCommand("_listarHabitacionesToallas", con.cnxnIq);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    habitacionIqware hab = new habitacionIqware();
                    hab.status = "";
                    hab.ID_Room = Convert.ToInt32(dr["ID_Room"]);
                    hab.RoomNo = Convert.ToString(dr["RoomNo"]);
                    hab.HSKGSName = Convert.ToString(dr["HSKGSName"]);//Módulo
                    hab.GuestTotal = Convert.ToInt32(dr["GuestTotal"]);//pax
                    hab.IsHSKRoomOccupied = Convert.ToInt32(dr["IsHSKRoomOccupied"]);
                    hab.HSKRoomStatusType = Convert.ToInt32(dr["HSKRoomStatusType"]);
                    hab.HSKRoomInspectionType = Convert.ToInt32(dr["HSKRoomInspectionType"]);
                    hab.Section = Convert.ToString(dr["Section"]).Trim(new char[] { ' ' });
                    //hab.llegada = Convert.ToInt32(dr["llegada"]);
                    //hab.salida = Convert.ToInt32(dr["salida"]);




                    if (hab.IsHSKRoomOccupied == 1)
                        hab.status = hab.status + "O";
                    else
                        hab.status = hab.status + "V";

                    if (hab.HSKRoomStatusType == 0)
                        hab.status = hab.status + "L";
                    else
                        hab.status = hab.status + "S";

                    if (hab.HSKRoomInspectionType == 0)
                        hab.status = hab.status + "I";
                    else
                        hab.status = hab.status + "N";



                    hab.ID_RoomType = dr.GetInt32(2);
                    hab.RoomTypeShortName = dr.GetString(3).Trim(new char[] { ' ' });//Tipo (abreviado)
                    hab.RoomTypeName = dr.GetString(4).Trim(new char[] { ' ' });
                    hab.HSKSection = Convert.ToInt32(dr["HSKSection"]);
                    hab.HSKGShortName = dr.GetString(6).Trim(new char[] { ' ' });
                    hab.HSKGSName = dr.GetString(7).Trim(new char[] { ' ' });
                    hab.ID_Floor = dr.GetInt32(8);
                    hab.FloorShortName = dr.GetString(9).Trim(new char[] { ' ' });
                    hab.FloorName = dr.GetString(10).Trim(new char[] { ' ' });
                    hab.ID_Building = dr.GetInt32(11);
                    hab.Building = dr.GetString(12).Trim(new char[] { ' ' });
                    hab.nameBuilding = dr.GetString(13).Trim(new char[] { ' ' });

                    hab.RoomNo = hab.RoomNo.ToUpper();
                    hab.RoomTypeName = hab.RoomTypeName.ToUpper();
                    hab.HSKGSName = hab.HSKGSName.ToUpper();

                    if (hab.HSKGShortName.ToUpper() == "CABAÑAS")
                        hab.modulo = "CABAÑAS";
                    else if (hab.HSKGShortName.ToUpper() == "P2RM5" || hab.HSKGShortName.ToUpper() == "P1RM5")
                        hab.modulo = "MODULO5";
                    else if (hab.RoomNo.ToUpper() == "201" || hab.RoomNo.ToUpper() == "217")
                        hab.modulo = "TSUIJKI";
                    else if (hab.RoomNo.ToUpper() == "302" || hab.RoomNo.ToUpper() == "322" || hab.RoomNo.ToUpper() == "419")
                        hab.modulo = "TSUIJQ";
                    else if (hab.RoomNo.ToUpper() == "403" || hab.RoomNo.ToUpper() == "505")
                        hab.modulo = "TSUIJK";
                    else
                        hab.modulo = hab.Building;


                    habitacionIqware aux = camdisp(id, hab.ID_Room, fecha);


                    if (aux != null)
                    {

                        hab.llegada = aux.llegada;
                        hab.salida = aux.salida;
                        list.Add(hab);
                    }

                }
            }
            con.desconectaIqware();
            return list;
        }

        public habitacionIqware camdisp(int idc, int idh, DateTime fecha)
        {


            if (con2 == null)
                con2 = new conexion();
            con2.conectar();


            habitacionIqware hab = null;
            SqlCommand cmd = new SqlCommand("_sp_CamHabFecha", con2.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idc", idc);
            cmd.Parameters.AddWithValue("@idh", idh);
            cmd.Parameters.AddWithValue("@fecha", fecha);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                while (dr.Read())
                {
                    hab = new habitacionIqware();
                    hab.llegada = Convert.ToInt32(dr["llegada"]);
                    hab.salida = Convert.ToInt32(dr["salida"]);

                }

                //con2.desconectar();
                //return true;

            }
            con2.desconectar();
            return hab;

        }


        #endregion



        #region 
        #endregion

        #region
        #endregion


        #region MÉTODO PARA FILTRAR HABITACIONES DISPONIBLES DE IQWARE A LA FECHA ACTUAL A PARTIR DEL CAMPO DE TEXTO DE BÚSQUEDA (inserción y Modificación)

        public List<habitacionIqware> filtrarhabitaciones(string valor,string md, string ps)
        {
            List<habitacionIqware> list = new List<habitacionIqware>();
            if (con == null)
            {
                con = new conexion();
                con.conexionIqware();
            }
            con.conectarIqware();
            SqlCommand cmd = new SqlCommand("_listarHabitacionesToallas", con.cnxnIq);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    
                    habitacionIqware hab = new habitacionIqware();
                    hab.status = "";
                    hab.ID_Room = Convert.ToInt32(dr["ID_Room"]);
                    hab.RoomNo = Convert.ToString(dr["RoomNo"]);
                    hab.HSKGSName = Convert.ToString(dr["HSKGSName"]);//Módulo
                    hab.GuestTotal = Convert.ToInt32(dr["GuestTotal"]);//pax
                    hab.IsHSKRoomOccupied = Convert.ToInt32(dr["IsHSKRoomOccupied"]);
                    hab.HSKRoomStatusType = Convert.ToInt32(dr["HSKRoomStatusType"]);
                    hab.HSKRoomInspectionType = Convert.ToInt32(dr["HSKRoomInspectionType"]);
                    hab.llegada = Convert.ToInt32(dr["llegada"]);
                    hab.salida = Convert.ToInt32(dr["salida"]);
                    hab.Section = Convert.ToString(dr["Section"]).Trim(new char[] { ' ' });


                    if (hab.IsHSKRoomOccupied == 1)
                        hab.status = hab.status + "O";
                    else
                        hab.status = hab.status + "V";
                  
                    if (hab.HSKRoomStatusType == 0)
                        hab.status = hab.status + "L";
                    else
                        hab.status = hab.status + "S";
                   
                    if (hab.HSKRoomInspectionType == 0)
                        hab.status = hab.status + "I";
                    else
                        hab.status = hab.status + "N";

                    
                    
                    hab.ID_RoomType = dr.GetInt32(2);
                    hab.RoomTypeShortName = dr.GetString(3).Trim(new char[] { ' ' });//Tipo (abreviado)
                    hab.RoomTypeName = dr.GetString(4).Trim(new char[] { ' ' });
                    hab.HSKSection = Convert.ToInt32(dr["HSKSection"]);
                    hab.HSKGShortName = dr.GetString(6).Trim(new char[] { ' ' });
                    hab.HSKGSName = dr.GetString(7).Trim(new char[] { ' ' });
                    hab.ID_Floor = dr.GetInt32(8);
                    hab.FloorShortName = dr.GetString(9).Trim(new char[] { ' ' });
                    hab.FloorName = dr.GetString(10).Trim(new char[] { ' ' });
                    hab.ID_Building = dr.GetInt32(11);
                    hab.Building = dr.GetString(12).Trim(new char[] { ' ' });
                    hab.nameBuilding = dr.GetString(13).Trim(new char[] { ' ' });

                    hab.RoomNo = hab.RoomNo.ToUpper();
                    hab.RoomTypeName = hab.RoomTypeName.ToUpper();
                    hab.HSKGSName = hab.HSKGSName.ToUpper();

                    if (hab.HSKGShortName.ToUpper() == "CABAÑAS")
                        hab.modulo = "CABAÑAS";
                    else if (hab.HSKGShortName.ToUpper() == "P2RM5" || hab.HSKGShortName.ToUpper() == "P1RM5")
                        hab.modulo = "MODULO5";
                    else if (hab.RoomNo.ToUpper() == "201" || hab.RoomNo.ToUpper() == "217")
                        hab.modulo = "TSUIJKI";
                    else if (hab.RoomNo.ToUpper() == "302" || hab.RoomNo.ToUpper() == "322" || hab.RoomNo.ToUpper() == "419")
                        hab.modulo = "TSUIJQ";
                    else if (hab.RoomNo.ToUpper() == "403" || hab.RoomNo.ToUpper() == "505")
                        hab.modulo = "TSUIJK";
                    else
                        hab.modulo = hab.Building;

                    
                    //----- Condiciones para filtrar habitaciones (Nr, Módulo y Piso) --------------------------//
                    if (valor != "")//Campo de texto habitación no está vacío
                    {

                        if (md == "" && ps == "")//Vacío módulo y piso (sólo n. hab.)
                        {
                            if ((hab.RoomNo.Contains(valor.ToUpper()) || hab.HSKGSName.Contains(valor.ToUpper()) || hab.Building.Contains(valor.ToUpper()) || hab.RoomTypeName.Contains(valor.ToUpper())) && !habdispfecha(hab.ID_Room, DateTime.Today))
                            {

                                list.Add(hab);
                            }

                        }

                        if (md != "" && ps != "")//Con módulo y piso
                        {
                            if (md == hab.Section && ps == hab.FloorName && (hab.RoomNo.Contains(valor.ToUpper()) || hab.HSKGSName.Contains(valor.ToUpper()) || hab.Building.Contains(valor.ToUpper()) || hab.RoomTypeName.Contains(valor.ToUpper())) && !habdispfecha(hab.ID_Room, DateTime.Today))
                            {

                                list.Add(hab);
                            }


                        }
                        else if (md != "")//No vacío módulo (n. hab. y módulo)
                        {
                            if (  md==hab.Section &&  (hab.RoomNo.Contains(valor.ToUpper()) || hab.HSKGSName.Contains(valor.ToUpper()) || hab.Building.Contains(valor.ToUpper()) || hab.RoomTypeName.Contains(valor.ToUpper())) && !habdispfecha(hab.ID_Room, DateTime.Today))
                            {

                                list.Add(hab);
                            }

                        }
                        else//No vacío piso (n. hab. y piso)
                        {
                            if (ps == hab.FloorName && (hab.RoomNo.Contains(valor.ToUpper()) || hab.HSKGSName.Contains(valor.ToUpper()) || hab.Building.Contains(valor.ToUpper()) || hab.RoomTypeName.Contains(valor.ToUpper())) && !habdispfecha(hab.ID_Room, DateTime.Today))
                            {

                                list.Add(hab);
                            }

                        }
                    }
                    else//Si está vacío n. hab.
                    {
                        if (md != "" && ps != "")//Por módulo y piso
                        {
                            if (md == hab.Section && ps == hab.FloorName && !habdispfecha(hab.ID_Room, DateTime.Today))
                                list.Add(hab);

                        }
                        else if (md != "")//Por módulo
                        {
                            if (md == hab.Section && !habdispfecha(hab.ID_Room, DateTime.Today))
                                list.Add(hab);

                        }
                        else if (ps != "")//Por piso
                        {
                            if (ps == hab.FloorName && !habdispfecha(hab.ID_Room, DateTime.Today))
                                list.Add(hab);

                        }
                    }
                    // ----------------------------------------------------------------------------------



                    
                    
                }
            }
            con.desconectaIqware();
            return list;
        }

        public List<habitacionIqware> filtrarhabitaciones2(string valor, List<int> hb, string md, string ps)
        {
            List<habitacionIqware> list = new List<habitacionIqware>();
            if (con == null)
            {
                con = new conexion();
                con.conexionIqware();
            }
            con.conectarIqware();
            SqlCommand cmd = new SqlCommand("_listarHabitacionesToallas", con.cnxnIq);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    habitacionIqware hab = new habitacionIqware();
                    hab.status = "";
                    hab.ID_Room = Convert.ToInt32(dr["ID_Room"]);
                    hab.RoomNo = Convert.ToString(dr["RoomNo"]);
                    hab.HSKGSName = Convert.ToString(dr["HSKGSName"]);
                    hab.GuestTotal = Convert.ToInt32(dr["GuestTotal"]);
                    hab.IsHSKRoomOccupied = Convert.ToInt32(dr["IsHSKRoomOccupied"]);
                    hab.HSKRoomStatusType = Convert.ToInt32(dr["HSKRoomStatusType"]);
                    hab.HSKRoomInspectionType = Convert.ToInt32(dr["HSKRoomInspectionType"]);
                    hab.llegada = Convert.ToInt32(dr["llegada"]);
                    hab.salida = Convert.ToInt32(dr["salida"]);
                    hab.Section = Convert.ToString(dr["Section"]).Trim(new char[] { ' ' });



                    if (hab.IsHSKRoomOccupied == 1)
                        hab.status = hab.status + "O";
                    else
                        hab.status = hab.status + "V";

                    if (hab.HSKRoomStatusType == 0)
                        hab.status = hab.status + "L";
                    else
                        hab.status = hab.status + "S";

                    if (hab.HSKRoomInspectionType == 0)
                        hab.status = hab.status + "I";
                    else
                        hab.status = hab.status + "N";


                    hab.ID_RoomType = dr.GetInt32(2);
                    hab.RoomTypeShortName = dr.GetString(3).Trim(new char[] { ' ' });
                    hab.RoomTypeName = dr.GetString(4).Trim(new char[] { ' ' });
                    hab.HSKSection = Convert.ToInt32(dr["HSKSection"]);
                    hab.HSKGShortName = dr.GetString(6).Trim(new char[] { ' ' });
                    hab.HSKGSName = dr.GetString(7).Trim(new char[] { ' ' });
                    hab.ID_Floor = dr.GetInt32(8);
                    hab.FloorShortName = dr.GetString(9).Trim(new char[] { ' ' });
                    hab.FloorName = dr.GetString(10).Trim(new char[] { ' ' });
                    hab.ID_Building = dr.GetInt32(11);
                    hab.Building = dr.GetString(12).Trim(new char[] { ' ' });
                    hab.nameBuilding = dr.GetString(13).Trim(new char[] { ' ' });

                    hab.RoomNo = hab.RoomNo.ToUpper();
                    hab.RoomTypeName = hab.RoomTypeName.ToUpper();
                    hab.HSKGSName = hab.HSKGSName.ToUpper();

                    if (hab.HSKGShortName.ToUpper() == "CABAÑAS")
                        hab.modulo = "CABAÑAS";
                    else if (hab.HSKGShortName.ToUpper() == "P2RM5" || hab.HSKGShortName.ToUpper() == "P1RM5")
                        hab.modulo = "MODULO5";
                    else if (hab.RoomNo.ToUpper() == "201" || hab.RoomNo.ToUpper() == "217")
                        hab.modulo = "TSUIJKI";
                    else if (hab.RoomNo.ToUpper() == "302" || hab.RoomNo.ToUpper() == "322" || hab.RoomNo.ToUpper() == "419")
                        hab.modulo = "TSUIJQ";
                    else if (hab.RoomNo.ToUpper() == "403" || hab.RoomNo.ToUpper() == "505")
                        hab.modulo = "TSUIJK";
                    else
                        hab.modulo = hab.Building;

                    bool encontrado = false;

                    foreach (int i in hb)
                    {

                        if (i == hab.ID_Room) encontrado = true;
                    }




                    //----- Condiciones para filtrar habitaciones (Nr, Módulo y Piso) --------------------------//
                    if (valor != "")
                    {

                        if (md == "" && ps == "")
                        {
                            if ((hab.RoomNo.Contains(valor.ToUpper()) || hab.HSKGSName.Contains(valor.ToUpper()) || hab.Building.Contains(valor.ToUpper()) || hab.RoomTypeName.Contains(valor.ToUpper())) && (!habdispfecha(hab.ID_Room, DateTime.Today) || encontrado))
                            {

                                list.Add(hab);
                            }

                        }
                        else if (md != "" && ps != "")
                        {
                            if (md == hab.Section && ps == hab.FloorName && (hab.RoomNo.Contains(valor.ToUpper()) || hab.HSKGSName.Contains(valor.ToUpper()) || hab.Building.Contains(valor.ToUpper()) || hab.RoomTypeName.Contains(valor.ToUpper())) && (!habdispfecha(hab.ID_Room, DateTime.Today) || encontrado))
                            {

                                list.Add(hab);
                            }

                        }
                        else if (md != "")
                        {
                            if (md == hab.Section && (hab.RoomNo.Contains(valor.ToUpper()) || hab.HSKGSName.Contains(valor.ToUpper()) || hab.Building.Contains(valor.ToUpper()) || hab.RoomTypeName.Contains(valor.ToUpper())) && (!habdispfecha(hab.ID_Room, DateTime.Today) || encontrado))
                            {

                                list.Add(hab);
                            }

                        }
                        else
                        {
                            if (ps == hab.FloorName && (hab.RoomNo.Contains(valor.ToUpper()) || hab.HSKGSName.Contains(valor.ToUpper()) || hab.Building.Contains(valor.ToUpper()) || hab.RoomTypeName.Contains(valor.ToUpper())) && (!habdispfecha(hab.ID_Room, DateTime.Today) || encontrado))
                            {

                                list.Add(hab);
                            }

                        }
                    }
                    else
                    {
                        if (md != "" && ps != "")//Por módulo y piso
                        {
                            if (md == hab.Section && ps == hab.FloorName && (!habdispfecha(hab.ID_Room, DateTime.Today) || encontrado))
                                list.Add(hab);

                        }
                        else if (md != "")//Por módulo
                        {
                            if (md == hab.Section && (!habdispfecha(hab.ID_Room, DateTime.Today) || encontrado))
                                list.Add(hab);

                        }
                        else if (ps != "")//Por piso
                        {
                            if (ps == hab.FloorName && (!habdispfecha(hab.ID_Room, DateTime.Today) || encontrado))
                                list.Add(hab);

                        }
                    }
                    // ----------------------------------------------------------------------------------


                }
            }
            con.desconectaIqware();
            return list;
        }

        public bool habdispfecha(int id, DateTime fecha)
        {

            if (con2 == null)
                con2 = new conexion();
            con2.conectar();

            SqlCommand cmd = new SqlCommand("_sp_HabDispFecha", con2.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idhab", id);
            cmd.Parameters.AddWithValue("@fecha", fecha);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                while (dr.Read())
                {

                    if (id == dr.GetInt32(3))
                    {

                        con2.desconectar();
                        return true;
                    }
                }
            }
            con2.desconectar();
            return false;
        }

        #endregion

        

        #region MÉTODO PARA FILTRAR HABITACIONES (MÓDULO DE EXTRA)
        public List<habitacionIqware> filtrarhabitacionesExtra(string valor)
        {
            List<habitacionIqware> list = new List<habitacionIqware>();
            if (con == null)
            {
                con = new conexion();
                con.conexionIqware();
            }
            con.conectarIqware();
            SqlCommand cmd = new SqlCommand("_listarHabitacionesToallas", con.cnxnIq);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    habitacionIqware hab = new habitacionIqware();
                    hab.status = "";
                    hab.ID_Room = Convert.ToInt32(dr["ID_Room"]);
                    hab.RoomNo = Convert.ToString(dr["RoomNo"]);
                    hab.HSKGSName = Convert.ToString(dr["HSKGSName"]);
                    hab.GuestTotal = Convert.ToInt32(dr["GuestTotal"]);
                    hab.IsHSKRoomOccupied = Convert.ToInt32(dr["IsHSKRoomOccupied"]);
                    hab.HSKRoomStatusType = Convert.ToInt32(dr["HSKRoomStatusType"]);
                    hab.HSKRoomInspectionType = Convert.ToInt32(dr["HSKRoomInspectionType"]);
                    if (hab.IsHSKRoomOccupied == 1)
                        hab.status = hab.status + "O";
                    else
                        hab.status = hab.status + "V";

                    if (hab.HSKRoomStatusType == 0)
                        hab.status = hab.status + "L";
                    else
                        hab.status = hab.status + "S";

                    if (hab.HSKRoomInspectionType == 0)
                        hab.status = hab.status + "I";
                    else
                        hab.status = hab.status + "N";


                    hab.ID_RoomType = dr.GetInt32(2);
                    hab.RoomTypeShortName = dr.GetString(3).Trim(new char[] { ' ' });
                    hab.RoomTypeName = dr.GetString(4).Trim(new char[] { ' ' });
                    hab.HSKSection = Convert.ToInt32(dr["HSKSection"]);
                    hab.HSKGShortName = dr.GetString(6).Trim(new char[] { ' ' });
                    hab.HSKGSName = dr.GetString(7).Trim(new char[] { ' ' });
                    hab.ID_Floor = dr.GetInt32(8);
                    hab.FloorShortName = dr.GetString(9).Trim(new char[] { ' ' });
                    hab.FloorName = dr.GetString(10).Trim(new char[] { ' ' });
                    hab.ID_Building = dr.GetInt32(11);
                    hab.Building = dr.GetString(12).Trim(new char[] { ' ' });
                    hab.nameBuilding = dr.GetString(13).Trim(new char[] { ' ' });

                    hab.RoomNo = hab.RoomNo.ToUpper();
                    hab.RoomTypeName = hab.RoomTypeName.ToUpper();
                    hab.HSKGSName = hab.HSKGSName.ToUpper();

                    if ((hab.RoomNo.Contains(valor.ToUpper()) || hab.HSKGSName.Contains(valor.ToUpper()) || hab.Building.Contains(valor.ToUpper()) || hab.RoomTypeName.Contains(valor.ToUpper())) && (hab.GuestTotal > 0 || (hab.movhabfecha(hab.ID_Room, DateTime.Today.AddDays(0))) ))
                    {

                        list.Add(hab);
                    }

                }
            }
            con.desconectaIqware();
            return list;
        }

        //Listado del día de ayer
        public List<habitacionIqware> filtrarhabitacionesExtraAyer(string valor)
        {
            List<habitacionIqware> list = new List<habitacionIqware>();
            if (con == null)
            {
                con = new conexion();
                con.conexionIqware();
            }
            con.conectarIqware();
            SqlCommand cmd = new SqlCommand("_listarHabitacionesToallas", con.cnxnIq);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    habitacionIqware hab = new habitacionIqware();
                    hab.status = "";
                    hab.ID_Room = Convert.ToInt32(dr["ID_Room"]);
                    hab.RoomNo = Convert.ToString(dr["RoomNo"]);
                    hab.HSKGSName = Convert.ToString(dr["HSKGSName"]);
                    hab.GuestTotal = Convert.ToInt32(dr["GuestTotal"]);
                    hab.IsHSKRoomOccupied = Convert.ToInt32(dr["IsHSKRoomOccupied"]);
                    hab.HSKRoomStatusType = Convert.ToInt32(dr["HSKRoomStatusType"]);
                    hab.HSKRoomInspectionType = Convert.ToInt32(dr["HSKRoomInspectionType"]);
                    if (hab.IsHSKRoomOccupied == 1)
                        hab.status = hab.status + "O";
                    else
                        hab.status = hab.status + "V";

                    if (hab.HSKRoomStatusType == 0)
                        hab.status = hab.status + "L";
                    else
                        hab.status = hab.status + "S";

                    if (hab.HSKRoomInspectionType == 0)
                        hab.status = hab.status + "I";
                    else
                        hab.status = hab.status + "N";


                    hab.ID_RoomType = dr.GetInt32(2);
                    hab.RoomTypeShortName = dr.GetString(3).Trim(new char[] { ' ' });
                    hab.RoomTypeName = dr.GetString(4).Trim(new char[] { ' ' });
                    hab.HSKSection = Convert.ToInt32(dr["HSKSection"]);
                    hab.HSKGShortName = dr.GetString(6).Trim(new char[] { ' ' });
                    hab.HSKGSName = dr.GetString(7).Trim(new char[] { ' ' });
                    hab.ID_Floor = dr.GetInt32(8);
                    hab.FloorShortName = dr.GetString(9).Trim(new char[] { ' ' });
                    hab.FloorName = dr.GetString(10).Trim(new char[] { ' ' });
                    hab.ID_Building = dr.GetInt32(11);
                    hab.Building = dr.GetString(12).Trim(new char[] { ' ' });
                    hab.nameBuilding = dr.GetString(13).Trim(new char[] { ' ' });

                    hab.RoomNo = hab.RoomNo.ToUpper();
                    hab.RoomTypeName = hab.RoomTypeName.ToUpper();
                    hab.HSKGSName = hab.HSKGSName.ToUpper();

                    if ((hab.RoomNo.Contains(valor.ToUpper()) || hab.HSKGSName.Contains(valor.ToUpper()) || hab.Building.Contains(valor.ToUpper()) || hab.RoomTypeName.Contains(valor.ToUpper())) && (hab.movhabfecha(hab.ID_Room,DateTime.Today.AddDays(-1)))      )
                    {

                        list.Add(hab);
                    }

                }
            }
            con.desconectaIqware();
            return list;
        }

        public bool movhabfecha(int id, DateTime fecha)
        {

            if (con2 == null)
                con2 = new conexion();
            con2.conectar();

            SqlCommand cmd = new SqlCommand("_sp_MovHabFecha", con2.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idh", id);
            cmd.Parameters.AddWithValue("@fecha", fecha);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                while (dr.Read())
                {

                    if (id == dr.GetInt32(2))
                    {

                        con2.desconectar();
                        return true;
                    }
                }
            }
            con2.desconectar();
            return false;
        }


        #endregion

        


        public List<modulo> listarModulos()
        {
            List<modulo> list = new List<modulo>();
            if (con == null)
            {
                con = new conexion();
                con.conexionIqware();
            }
            con.conectarIqware();
            SqlCommand cmd = new SqlCommand("_listarModulosToallas", con.cnxnIq);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    modulo mod = new Clases.modulo();
                    mod.idModulo = dr.GetInt32(0);
                    mod.descripcion = dr.GetString(1).Trim(new char[] { ' ' });
                    list.Add(mod);
                }
            }
            con.desconectaIqware();
            return list;
        }

        public List<modulo> listarPisos(string idModulo)
        {
            List<modulo> list = new List<modulo>();
            if (con == null)
            {
                con = new conexion();
                con.conexionIqware();
            }
            con.conectarIqware();
            SqlCommand cmd = new SqlCommand("_listarPisosToallas", con.cnxnIq);
            cmd.Parameters.AddWithValue("@idModulo", idModulo);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    modulo mod = new Clases.modulo();
                    mod.idModulo = dr.GetInt32(0);
                    mod.descripcion = dr.GetString(1).Trim(new char[] { ' ' });
                    list.Add(mod);
                }
            }
            con.desconectaIqware();
            return list;
        }

        
        
    }
    public class modulo
    {
        public int idModulo { get; set; }
        public string descripcion { get; set; }
    }
}
