using System;
using System.Collections.Generic;
using System.Text;


using Microsoft.Win32;

namespace Contratos.Clases
{
    public static class VbNetSettings
    {
        public static string GetSetting(string applicationName, string sectionName, string key)
        {
            return GetSetting(applicationName, sectionName, key, null);
        }


        public static string GetSetting(string applicationName, string sectionName, string key, string valeurParDéfaut)
        {
            StringBuilder path;
            RegistryKey registryKey;


            path = new StringBuilder(@"Software\VB and VBA Program Settings");


            // Générer le chemin de la clé
            if (string.IsNullOrEmpty(applicationName) == false)
            {
                path.Append('\\');
                path.Append(applicationName);


                if (string.IsNullOrEmpty(sectionName) == false)
                {
                    path.Append('\\');
                    path.Append(sectionName);
                }
            }


            // Ouvrir la clé
            registryKey = Registry.CurrentUser.OpenSubKey(path.ToString());


            // Si la clé est inexistante, retourner la valeur par défaut
            if (registryKey == null)
            {
                return valeurParDéfaut;
            }


            try
            {
                // Lire la valeur contenu dans la clé
                return (string)registryKey.GetValue(key, valeurParDéfaut);
            }
            finally
            {
                registryKey.Dispose();
            }
        }
    }
}
