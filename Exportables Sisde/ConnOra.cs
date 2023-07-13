using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exportables_Sisde
{
    public class ConnOra
    {

        public static OracleConnection GetDBConnection(string host, int port, String sid, String user, String password)
        {

            //("Getting Connection ...");

            // 'Connection string' to connect directly to Oracle.
            try
            {
                string connString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                 + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                 + sid + ")));Password=" + password + ";User ID=" + user;


                OracleConnection conn = new OracleConnection();

                conn.ConnectionString = connString;

                return conn;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ERROR: " + ex.Message);
                return null;
            }
            
        }
        /*
           public static OracleConnection GetDBConnection()
        {
            string host = "172.20.1.189";
            int port = 1521;
            string sid = "SISDE";
            string user = "C##SISDE2018";
            string password = "Sis2017";

            return GetDBConnection(host, port, sid, user, password);
        }
        */
        /*
        public static OracleConnection GetDBConnection()
        {
            string host = "localhost";
            int port = 1521;
            string sid = "XEPDB1";
            string user = "SISDE2018";
            string password = "Sis2017";

            return GetDBConnection(host, port, sid, user, password);
        }
        */
        
        public static OracleConnection GetDBConnection()
        {
            //ORACLE 12C
            try
            {
                //ORACLE 19C
                
                string host = "raceeaamb-scan.eeasa.com";
                int port = 1521;
                string sid = "PDBAMB";
                string user = "SISDE2018";
                string password = "Disenios2022_";
                
                //CONTRATISTAS 18C EXPRESS
                /*
                string host = "localhost";
                int port = 1521;
                string sid = "xepdb1";
                string user = "SISDE2018";
                string password = "Disenios2021_";
                */
                return GetDBConnection(host, port, sid, user, password);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ERROR: " + ex.Message);
                return null;
            }
            
        }
        
    }
}
