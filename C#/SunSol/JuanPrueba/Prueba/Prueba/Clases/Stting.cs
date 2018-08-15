using System;
using Microsoft.Win32;

namespace Contratos.Clases
{
    public class Stting
    {

        public static void guardar(string app, string seccion, string campo, string valor)
        {
            // guarda un valor en el registro usando SaveSetting
            SaveSetting(app, seccion, campo, valor);
        }
        static public string leer(string app, string seccion, string campo)
        {
            return GetSetting(app, seccion, campo);
        }
        static public string leer(string app, string seccion, string campo,string sDefault)
        {
            return GetSetting(app, seccion, campo, sDefault);
        }
        //
        // Las funciones equivalentes para C#
        //
        static public string GetSetting(string appName, string section, string key, string sDefault)
        {
            // Los datos de VB se guardan en:
            // HKEY_CURRENT_USER\Software\VB and VBA Program Settings
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Software\VB and VBA Program Settings\" +
                                                              appName + "\\" + section);
            string s = sDefault;
            if (rk != null)
                s = (string)rk.GetValue(key);
            //
            return s;
        }
        static public string GetSetting(string appName, string section, string key)
        {
            return GetSetting(appName, section, key, "");
        }
        static public void SaveSetting(string appName, string section, string key, string setting)
        {
            // Los datos de VB se guardan en:
            // HKEY_CURRENT_USER\Software\VB and VBA Program Settings
            RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"Software\VB and VBA Program Settings\" +
                                                                appName + "\\" + section);
            rk.SetValue(key, setting);
        }

    }
}
