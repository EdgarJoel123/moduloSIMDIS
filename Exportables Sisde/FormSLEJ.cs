using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using Oracle.ManagedDataAccess.Client;
namespace Exportables_Sisde
{
	public partial class FormSLEJ : Form
	{



		public FormSLEJ()
		{
			InitializeComponent();
			button3.Enabled = false;
			button4.Enabled = false;

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void FormSLEJ_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{

			try
			{
				ClassFuncionesSLEJ.LoadExcelData(textBox1, progressBar1, label3, button3);
			}
			catch (IndexOutOfRangeException ex)
			{
				MessageBox.Show("Error al procesar los datos del Excel. Asegúrate de que el formato de los datos sea correcto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				ClassFuncionesSLEJ.LoadExcelData(textBox2, progressBar2, label4, button4);
			}
			catch (IndexOutOfRangeException ex)
			{
				MessageBox.Show("Error al procesar los datos del Excel. Asegúrate de que el formato de los datos sea correcto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			
		}


		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void button3_EnabledChanged(object sender, EventArgs e)
		{

		}

		private void button4_EnabledChanged(object sender, EventArgs e)
		{

		}

		private void button5_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			// Obtener los datos del Excel cargado
			string[,] excelData = ClassFuncionesSLEJ.GetExcelData();

			// Verificar si hay datos cargados desde el Excel
			if (excelData != null)
			{
				int filasExitosas = 0;



				// Recorrer los datos y llamar al procedimiento PR_IN_UPDATE_MATERIAL por cada fila
				for (int row = 1; row < excelData.GetLength(0); row++)
				{
					// Verificar si la fila actual está vacía
					bool isRowEmpty = true;
					for (int column = 0; column < excelData.GetLength(1); column++)
					{
						if (!string.IsNullOrEmpty(excelData[row, column]))
						{
							isRowEmpty = false;
							break;
						}
					}

					// Si la fila está vacía, omitir el procesamiento y pasar a la siguiente fila
					if (isRowEmpty)
					{
						continue;
					}

					
						string codigoMaterial = excelData[row, 0];
					string descripcionMaterial = excelData[row, 1];

					int codigoUnidad;
					if (int.TryParse(excelData[row, 2], out codigoUnidad))
					{
						// La conversión a entero fue exitosa
						// Continuar con el resto del código
					}
					else
					{
						// La conversión a entero falló
						// Manejar el caso de error de acuerdo a tus necesidades
					}

					// No se mencionó el parámetro "PRECIO MATERIAL" en el procedimiento, por lo que se omitirá

					// No se mencionó el parámetro "FECHA _MATERIAL" en el procedimiento, por lo que se omitirá

					float precioMaterial;
					if (float.TryParse(excelData[row, 3], out precioMaterial))
					{
						// La conversión a entero fue exitosa
						// Continuar con el resto del código
					}
					else
					{
						// La conversión a entero falló
						// Manejar el caso de error de acuerdo a tus necesidades
					}

					DateTime fechaMaterial;
					if (DateTime.TryParse(excelData[row,4], out fechaMaterial))
					{

					}

					int clasificacionMaterial;
					if (int.TryParse(excelData[row, 5], out clasificacionMaterial))
					{
						// La conversión a entero fue exitosa
						// Continuar con el resto del código
					}
					else
					{
						// La conversión a entero falló
						// Manejar el caso de error de acuerdo a tus necesidades
					}


					

						// Llamar al procedimiento PR_MATERIAL_PRECIO con los datos de la fila actual
						ClassFuncionesSLEJ.UpdateInsertMaterial(codigoMaterial, descripcionMaterial, codigoUnidad, clasificacionMaterial, precioMaterial, fechaMaterial, row);

						// Incrementar el contador de filas exitosas
						filasExitosas++;
				}


				string mensajeExitoso = $"Se procesaron {filasExitosas} filas del archivo de excel";
				MessageBox.Show(mensajeExitoso, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

			}

			textBox1.Text = string.Empty;        // Restablecer el valor del TextBox a vacío
			progressBar1.Value = 0;              // Restablecer el valor de la ProgressBar a 0
			label3.Text = string.Empty;          // Restablecer el valor del Label a vacío
			button3.Enabled = false;              // Habilitar el botón nuevamente


		}
		private void button4_Click(object sender, EventArgs e)
		{

			// Obtener los datos del Excel cargado
			string[,] excelData = ClassFuncionesSLEJ.GetExcelData();

			// Verificar si hay datos cargados desde el Excel
			if (excelData != null)
			{
				int filasExitosas = 0;

				for (int row = 1; row < excelData.GetLength(0); row++)
				{
					

					// Verificar si la fila actual está vacía
					bool isRowEmpty = true;
					for (int column = 0; column < excelData.GetLength(1); column++)
					{
						if (!string.IsNullOrEmpty(excelData[row, column]))
						{
							isRowEmpty = false;
							break;
						}
					}

					// Si la fila está vacía, omitir el procesamiento y pasar a la siguiente fila
					if (isRowEmpty)
					{
						continue;
					}


		

					int idClaseMaterial;
					if (int.TryParse(excelData[row, 0], out idClaseMaterial))
					{
						// La conversión a entero fue exitosa
						// Continuar con el resto del código
					}
					else
					{
						// La conversión a entero falló
						// Manejar el caso de error de acuerdo a tus necesidades
					}

					float precioNuevo;
					if (float.TryParse(excelData[row, 2], out precioNuevo))
					{
						// La conversión a entero fue exitosa
						// Continuar con el resto del código
					}
					else
					{
						// La conversión a entero falló
						// Manejar el caso de error de acuerdo a tus necesidades
					}

					float precioDesmantelimiento;
					if (float.TryParse(excelData[row, 3], out precioDesmantelimiento))
					{
						// La conversión a entero fue exitosa
						// Continuar con el resto del código
					}
					else
					{
						// La conversión a entero falló
						// Manejar el caso de error de acuerdo a tus necesidades
					}


					DateTime fecha;
					if (DateTime.TryParse(excelData[row, 4], out fecha))
					{
						// La conversión a entero fue exitosa
						// Continuar con el resto del código
					}
					else
					{
						// La conversión a entero falló
						// Manejar el caso de error de acuerdo a tus necesidades
					}

					string zona = excelData[row, 5];



					// Llamar al procedimiento con los datos de la fila actual
					ClassFuncionesSLEJ.UpdateInsertPrecioMano(idClaseMaterial, precioNuevo, precioDesmantelimiento, fecha, zona, row);

					// Incrementar el contador de filas exitosas
					filasExitosas++;
				}


				string mensajeExitoso = $"Se procesaron {filasExitosas} filas del archivo de excel";
				MessageBox.Show(mensajeExitoso, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

			}
			textBox2.Text = string.Empty;        // Restablecer el valor del TextBox a vacío
			progressBar2.Value = 0;              // Restablecer el valor de la ProgressBar a 0
			label4.Text = string.Empty;          // Restablecer el valor del Label a vacío
			button4.Enabled = false;              // Habilitar el botón nuevamente

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}
	}
}
