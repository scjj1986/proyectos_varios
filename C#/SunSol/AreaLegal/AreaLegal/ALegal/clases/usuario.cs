namespace ALegal
{

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using ALegal;
    using System.ComponentModel;
    using System.Text;
    using System.Security.Cryptography;
    public class usuario
    {

        public basededatos bd = new basededatos();
        public int id { get; set; }


        public string nac { get; set; }
        public string ndoc { get; set; }

        public string cedula { get; set; }

        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string email { get; set; }
        public string login { get; set; }
        public string clave { get; set; }

        public int idnivel { get; set; }
        public string strnivel { get; set; }

        public int idestatus { get; set; }
        public string strestatus { get; set; }

        public string clave_md5()
        {
            
            
            string cad = "";
            using (MD5 md5Hash = MD5.Create())//Codificiación MD5 para la contraseña
            {
                cad = GetMd5Hash(md5Hash, clave);
            }
            return cad;
        }

        public string GetMd5Hash(MD5 md5Hash, string input)
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

        public int autenticar()
        {
            
            
                bd = new basededatos();
                List<parametros> lparams = new List<parametros>();
                lparams.Add(new parametros { nombre = "@login", Valor = login.ToUpper() });
                lparams.Add(new parametros { nombre = "@clave", Valor = clave_md5() });
                DataTable resultado = bd.generar_datatable("_sp_login", CommandType.StoredProcedure, lparams);
                if (resultado==null)
                    return -3;
                foreach (DataRow rw in resultado.Rows)
                {

                    if (Convert.ToInt32(rw["idEstatus"]) == 0)
                        return -2;
                    
                    id = Convert.ToInt32(rw["id"]);
                    nombres = Convert.ToString(rw["nombres"]).TrimEnd(' ');
                    apellidos = Convert.ToString(rw["apellidos"]).TrimEnd(' ');
                    login = Convert.ToString(rw["login"]).TrimEnd(' ');
                    strnivel = Convert.ToString(rw["desc_NivUsuario"]).TrimEnd(' ');
                    return 1;
                }

                return -1;
            
        }

        public void guardar_editar()
        {
            bd = new basededatos();
            List<parametros> lparams = new List<parametros>();
            lparams.Add(new parametros { nombre = "@id", Valor = id });
            lparams.Add(new parametros { nombre = "@nac", Valor = nac });
            lparams.Add(new parametros { nombre = "@ndoc", Valor = ndoc });
            lparams.Add(new parametros { nombre = "@nombre", Valor = nombres.ToUpper() });
            lparams.Add(new parametros { nombre = "@apellido", Valor = apellidos.ToUpper() });
            lparams.Add(new parametros { nombre = "@login", Valor = login.ToUpper() });
            lparams.Add(new parametros { nombre = "@clave", Valor = clave });
            lparams.Add(new parametros { nombre = "@email", Valor = email.ToUpper() });
            lparams.Add(new parametros { nombre = "@nivel", Valor = idnivel });
            lparams.Add(new parametros { nombre = "@estatus", Valor = idestatus });
            bd.ejecutar_consulta("sp_guardareditar_Usuario", CommandType.StoredProcedure, lparams);
        }

        public List<usuario> lista_usuarios()
        {
            bd = new basededatos();
            List<usuario> l = new List<usuario>();
            DataTable resultado = bd.generar_datatable("SELECT * FROM V_Usuario", CommandType.Text, new List<parametros>());
            foreach (DataRow rw in resultado.Rows)
            {
                usuario n = new usuario();

                n.id = Convert.ToInt32(rw["id"]);
                n.nac = Convert.ToString(rw["Nac"]).TrimEnd(' ');
                n.ndoc = Convert.ToString(rw["NrDocumento"]).TrimEnd(' ');

                n.cedula = n.nac + "-" + n.ndoc;

                n.nombres = Convert.ToString(rw["nombres"]).TrimEnd(' ');
                n.apellidos = Convert.ToString(rw["apellidos"]).TrimEnd(' ');
                n.login = Convert.ToString(rw["login"]).TrimEnd(' ');
                n.idnivel = Convert.ToInt32(rw["idNivel"]);
                n.idestatus = Convert.ToInt32(rw["idEstatus"]);
                n.email = Convert.ToString(rw["email"]).TrimEnd(' ');
                n.strnivel = Convert.ToString(rw["desc_NivUsuario"]).TrimEnd(' ');
                n.strestatus = Convert.ToString(rw["desc_EstUsuario"]).TrimEnd(' ');
                n.clave = Convert.ToString(rw["clave"]).TrimEnd(' ');

                l.Add(n);
            }
            return l;
        }

        public List<usuario> lista_niveles()
        {
            bd = new basededatos();
            List<usuario> l = new List<usuario>();
            DataTable resultado = bd.generar_datatable("SELECT * FROM NivelUsuario", CommandType.Text, new List<parametros>());
            foreach (DataRow rw in resultado.Rows)
            {
                usuario n = new usuario();
                n.idnivel = Convert.ToInt32(rw["id"]);
                n.strnivel = Convert.ToString(rw["descripcion"]).TrimEnd(' ');
                l.Add(n);
            }
            return l;
        }

        public List<usuario> lista_estatus()
        {
            bd = new basededatos();
            List<usuario> l = new List<usuario>();
            DataTable resultado = bd.generar_datatable("SELECT * FROM Estatus", CommandType.Text, new List<parametros>());
            foreach (DataRow rw in resultado.Rows)
            {
                usuario n = new usuario();
                n.idestatus = Convert.ToInt32(rw["id"]);
                n.strestatus = Convert.ToString(rw["descripcion"]).TrimEnd(' ');
                l.Add(n);
            }
            return l;
        }

        public bool existe_cedula()
        {
            bd = new basededatos();
            List<parametros> lparams = new List<parametros>();
            lparams.Add(new parametros { nombre = "@nac", Valor = nac });
            lparams.Add(new parametros { nombre = "@ndoc", Valor = ndoc });
            lparams.Add(new parametros { nombre = "@id", Valor = id });
            DataTable resultado = bd.generar_datatable("_sp_existeCedula", CommandType.StoredProcedure, lparams);
            return resultado.Rows.Count == 0 ? false : true;
        }

        public bool existe_login()
        {
            bd = new basededatos();
            List<parametros> lparams = new List<parametros>();
            lparams.Add(new parametros { nombre = "@login", Valor = login });
            lparams.Add(new parametros { nombre = "@id", Valor = id });
            DataTable resultado = bd.generar_datatable("_sp_existeLogin", CommandType.StoredProcedure, lparams);
            return resultado.Rows.Count == 0 ? false : true;
        }



    }
}
