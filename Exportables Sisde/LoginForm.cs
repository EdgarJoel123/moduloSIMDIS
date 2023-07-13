//using DotSpatial.Controls;
//using DotSpatial.Controls.Header;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Exportables_Sisde
{
    public partial class LoginForm : Form
    {
        Form varmainform;
        

        public LoginForm()
        {

            //varmainform = varmain;
            InitializeComponent();

        }



        /// <summary>
        /// Finds the MAC address of the NIC with maximum speed.
        /// </summary>
        /// <returns>The MAC address.</returns>
        private string GetMacAddress()
        {
            const int MIN_MAC_ADDR_LENGTH = 12;
            string macAddress = string.Empty;
            long maxSpeed = -1;

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                /*log.Debug(
                    "Found MAC Address: " + nic.GetPhysicalAddress() +
                    " Type: " + nic.NetworkInterfaceType);*/

                string tempMac = nic.GetPhysicalAddress().ToString();
                if (nic.Speed > maxSpeed &&
                    !string.IsNullOrEmpty(tempMac) &&
                    tempMac.Length >= MIN_MAC_ADDR_LENGTH)
                {
                    //log.Debug("New Max Speed = " + nic.Speed + ", MAC: " + tempMac);
                    maxSpeed = nic.Speed;
                    macAddress = tempMac;
                }
            }

            return macAddress;
        }
        private void OKButton_Click(object sender, EventArgs e)
        {

           try
            { 

                ClassFunciones varFunciones = new ClassFunciones();

                List<string> varLoginUser = varFunciones.Login(TxtUsuario.Text,TxtContra.Text);

                // List<DataSourceItem> dataSource = new List<DataSourceItem>();

                if (!varLoginUser.Any())
                {
                    MessageBox.Show("Datos de ingreso incorrectos","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    /*Int16 var_MAC = varFunciones.cons_mac_address(GetMacAddress());
                    if (var_MAC != 1)
                    {
                        MessageBox.Show("COMPUTADORA NO AUTORIZADA, INGRESE LA CLAVE DE AUTORIZACIÓN.", "AUTORIZACIÓN SISDE EEASA", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //Entrada de datos medianta un inputbox
                        //clave = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la clave de autorización: ", "ACTIVACIÓN SISDE EEASA", "Clave", 100, 0);
                        IfrmActivacion varFormActivacion = new IfrmActivacion();

                        varFormActivacion.ShowDialog(this);

                        if (ClassGlobalVar.GlobalClaveAut == "GEOVANNY2012")
                        {
                            string varMACIngre = varFunciones.InsertMacAddress(GetMacAddress());
                            if (varMACIngre != string.Empty)
                            {
                                MessageBox.Show("Autorización exitosa, bienvenido al SISDE.", "AUTORIZACIÓN SISDE EEASA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No se puede registrar la máquina, consulte con el administrador del sistema SISDE (Ing. Iván Vargas 0998931125).", "AUTORIZACIÓN SISDE EEASA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Application.Exit();
                            }
                        }
                        else
                        {
                            MessageBox.Show("AUTORIZACIÓN FALLIDA. consulte con el administrador del sistema SISDE (Ing. Iván Vargas 0998931125).", "AUTORIZACIÓN SISDE EEASA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();
                        }
                    }*/

                    foreach (string varDataUser in varLoginUser)
                    {
                        var varInfoUser = varDataUser.Split(',');

                        ClassGlobalVar.SetGlobalIdUsuario(varInfoUser[0]);
                        ClassGlobalVar.SetGlobalUsusario(varInfoUser[3] + " " + varInfoUser[4]);
                        // ClassGlobalVar.SetGlobalPerfil(Convert.ToInt32(varInfoUser[6]));
                        //varmainform.WindowState = FormWindowState.Maximized;
                        //varmainform.Enabled = true;
                        // _app1.LoadExtensions();
                       // IfrmExportacion formExp = new IfrmExportacion();
                        
                        //formExp.Show();

                        FormSLEJ formSLEJ = new FormSLEJ();
                        formSLEJ.Show();
                        //Close();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
                return;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private void function_enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OKButton.PerformClick();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
