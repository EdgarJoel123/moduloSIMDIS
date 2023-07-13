using System;
//using DotSpatial.Controls;
using System.Collections.Generic;

namespace Exportables_Sisde
{
    public class ClassGlobalVar
    {
        //Esta variable maneja el numero de archivos de cartografia base que puede subir el sistema 2021/09/01
        
        public static string[] GlobalPathMapa = new string[4];
        public static List<string> ListGlobalPathMapa = new List<string>();
        public static List<string> ListGlobalPathMapaTmp = new List<string>();
        // parameterless constructor required for static class

        static ClassGlobalVar()
        {
            GlobalIdDisenio = 0;
            GlobalTipoRed = "A";
            GlobalIdUsuario = string.Empty;
            GlobalUsusario = string.Empty;
            GlobalClaveAut = string.Empty;
            GlobalPerfil = 0;
            //globalApp = null;

            
        } // default value
        //global app

        //public static AppManager globalApp { get; private set; }

        //datos de usuario

        public static String GlobalIdUsuario { get; private set; }

        public static String GlobalUsusario { get; private set; }

        public static String GlobalClaveAut { get; private set; }

        public static int GlobalPerfil { get; private set; }

        // public get, and private set for strict access control
        public static int GlobalIdDisenio { get; private set; }

        public static String GlobalTipoRed { get; private set; }

        //globalapp

       /* public static void SetglobalApp(AppManager newApp)
        {
            globalApp = newApp;
        }*/

        // GlobalInt can be changed only via this method

        public static void SetGlobalTipoRed(string newString)
        {
            GlobalTipoRed = newString;
        }

        public static void SetGlobalIdDisenio(int newInt)
        {
            GlobalIdDisenio = newInt;
        }

        //datos de usuarios
        public static void SetGlobalPerfil(int newInt)
        {
            GlobalPerfil = newInt;
        }

        public static void SetGlobalIdUsuario(string newString)
        {
            GlobalIdUsuario = newString;
        }

        public static void SetGlobalUsusario(string newString)
        {
            GlobalUsusario = newString;
        }
        public static void SetGlobalClaveAut(string newString)
        {
            GlobalClaveAut = newString;
        }
    }
}
