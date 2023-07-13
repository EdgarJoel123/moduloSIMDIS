using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Data.OracleClient;

namespace Exportables_Sisde
{
    public partial class IfrmExportacion : Form
    {
        DataTable dt = new DataTable();
        public IfrmExportacion()
        {
            InitializeComponent();
        }

        
        public void buscarProyecto(string varoption)
        {
            dt.Rows.Clear();

            OracleConnection conn = ConnOra.GetDBConnection();

            try
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = conn;
                objCmd.CommandText = "PKG_SISTEMA.PROC_SD_DISENIOS_BUSQUEDA";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("IN_VAR_OPCION", OracleType.VarChar).Value = varoption;
                objCmd.Parameters.Add("IN_VAR_BUSQUEDA", OracleType.VarChar).Value = txtParamBusqueda.Text;
                objCmd.Parameters.Add("IN_ID_USUARIO", OracleType.VarChar).Value = ClassGlobalVar.GlobalIdUsuario;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();
                while (objReader.Read())
                {
                    // MessageBox.Show(objReader["MENSAJE"].ToString());
                    DataRow row = dt.NewRow();
                    row["CODIGO DISEÑO"] = objReader["COD_DIS"].ToString();
                    //row["COD_DISENADOR"] = objReader["COD_DISENADOR"].ToString();
                    //row["COD_PARROQUIA"] = objReader["COD_PARROQUIA"].ToString();
                    //row["COD_DEPARTAMENTO"] = objReader["COD_DEPARTAMENTO"].ToString();
                    row["NOMBRE DISEÑO"] = objReader["NOMB_DIS"].ToString();
                    row["NOMBRE SECTOR"] = objReader["NOMB_SECTOR"].ToString();
                    //row["CODIGOEMPRESA"] = objReader["CODIGOEMPRESA"].ToString();
                    row["TIPO DISEÑO"] = objReader["TIPO_DIS"].ToString();
                    row["FECHA DISEÑO"] = objReader["FECH_DIS"].ToString();
                    //row["ALIMENTADORID"] = objReader["ALIMENTADORID"].ToString();
                    //row["ALIMENTADORID2"] = objReader["ALIMENTADORID2"].ToString();
                    //row["DIAS_CONST"] = objReader["DIAS_CONST"].ToString();
                    //row["DIAS_REUB"] = objReader["DIAS_REUB"].ToString();
                    //row["DIAS_RETIRO"] = objReader["DIAS_RETIRO"].ToString();
                    row["FISCALIZADOR"] = objReader["FISCALIZADOR"].ToString();
                    //row["DISTANCIA"] = objReader["DISTANCIA"].ToString();
                    //row["KM_INV_PROY"] = objReader["KM_INV_PROY"].ToString();
                    //row["KM_INV_EXI"] = objReader["KM_INV_EXI"].ToString();
                    //row["M_DESB_PROY"] = objReader["M_DESB_PROY"].ToString();
                    //row["M_DESB_EXI"] = objReader["M_DESB_EXI"].ToString();
                    //row["ZONA_COMPLEJA"] = objReader["ZONA_COMPLEJA"].ToString();
                    row["DISEÑADOR"] = objReader["DISENIADOR"].ToString();
                    row["PROVINCIA"] = objReader["PROVINCIA"].ToString();
                    row["CANTON"] = objReader["CANTON"].ToString();
                    row["PARROQUIA"] = objReader["PARROQUIA"].ToString();

                    dt.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("## ERROR: " + ex.Message);
                return;
            }

            conn.Close();
            //TabProy.SelectedIndex = 0;
        }

        




















































        // para crear el archivo DE TEXTO    PRUEBAS ********************************************************************     
        private void btnExporta_Click(object sender, EventArgs e)
        {
            GenerarTXT();
            AdicionarInfoAlTxt();
            LeerInfoTxt();
        }


        void GenerarTXT()
        {
            string rutaCompleta = @" e:\mi archivo.txt";
            string texto = "HOLA MUNDO ";

            using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
            {

                //se adiciona alguna información y la fecha


                DateTime dateTime = new DateTime();
                dateTime = DateTime.Now;
                string strDate = Convert.ToDateTime(dateTime).ToString("yyMMdd");

                mylogs.WriteLine(texto + strDate);

                mylogs.Close();


            }
        }

        // para escribir en el archivo
        void AdicionarInfoAlTxt()
        {
            string rutaCompleta = @" e:\mi archivo.txt";
            string texto = "HOLA DE NUEVO";

            using (StreamWriter file = new StreamWriter(rutaCompleta, true))
            {
                file.WriteLine(texto); //se agrega información al documento

                file.Close();
            }
        }

        // para leer la información el archivo
        void LeerInfoTxt()
        {
            string rutaCompleta = @" e:\mi archivo.txt";

            string line = "";
            using (StreamReader file = new StreamReader(rutaCompleta))
            {
                while ((line = file.ReadLine()) != null)                //Leer linea por linea
                {
                    //Console.WriteLine(line);
                    MessageBox.Show("Pruebas", line, MessageBoxButtons.OK);
                }

                // OTRA FORMA DE LEER TODO EL ARCHIVO

                line = file.ReadToEnd();

                //Console.WriteLine(line);
                MessageBox.Show("Pruebas", line, MessageBoxButtons.OK);

                file.Close();


            }

        }

        private void IfrmExportacion_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("CODIGO DISEÑO");

            //dt.Columns.Add("COD_DISENADOR");
            //dt.Columns.Add("COD_PARROQUIA");
            //dt.Columns.Add("COD_DEPARTAMENTO");
            dt.Columns.Add("NOMBRE DISEÑO");
            dt.Columns.Add("NOMBRE SECTOR");
            //dt.Columns.Add("CODIGOEMPRESA");
            dt.Columns.Add("TIPO DISEÑO");
            dt.Columns.Add("FECHA DISEÑO");
            //dt.Columns.Add("ALIMENTADORID");
            //dt.Columns.Add("ALIMENTADORID2");
            //dt.Columns.Add("DIAS_CONST");
            //dt.Columns.Add("DIAS_REUB");
            //dt.Columns.Add("DIAS_RETIRO");
            dt.Columns.Add("FISCALIZADOR");
            //dt.Columns.Add("DISTANCIA");
            //dt.Columns.Add("KM_INV_PROY");
            //dt.Columns.Add("KM_INV_EXI");
            //dt.Columns.Add("M_DESB_PROY");
            //dt.Columns.Add("M_DESB_EXI");
            //dt.Columns.Add("ZONA_COMPLEJA");

            dt.Columns.Add("DISEÑADOR");
            dt.Columns.Add("PROVINCIA");
            dt.Columns.Add("CANTON");
            dt.Columns.Add("PARROQUIA");
            dgvProyectos.DataSource = dt;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (rButtonCodigo.Checked == true)
            {

                buscarProyecto("CODPROYECTO");
                return;
            }
            else if (rButtonNomProyecto.Checked == true)
            {
                buscarProyecto("NOMBPROY");
                return;
            }
        }

        private void btnExportable_Click(object sender, EventArgs e)
        {

        }

        private void txtParamBusqueda_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtParamBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                this.btnBuscar.PerformClick();
            }
        }
        //****************************************************************************************************
    }
}
