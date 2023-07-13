using Exportables_Sisde;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Windows.Forms;


public class ClassFuncionesSLEJ
{

	 private static string[,] excelData;

	public static void LoadExcelData(TextBox textBox, ProgressBar progressBar, Label label, Button button)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = "Archivos de Excel|*.xlsx;*.xls";
		openFileDialog.Title = "Seleccionar archivo de Excel";

		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			string filePath = openFileDialog.FileName; // Mostrar el nombre del archivo en el TextBox

			// Utilizar la biblioteca de interoperabilidad de Excel para leer el contenido del archivo
			textBox.Text = openFileDialog.SafeFileName;

			// Utilizar la biblioteca de interoperabilidad de Excel para leer el contenido del archivo     
			Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
			Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Open(filePath);
			Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.Sheets[1];

			// Obtener los datos de las celdas
			int lastRow = worksheet.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell).Row;
			int lastColumn = worksheet.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell).Column;
			excelData = new string[lastRow, lastColumn];

			int totalCells = lastRow * lastColumn;
			int cellsLoaded = 0;

			for (int row = 1; row <= lastRow; row++)
			{
				for (int column = 1; column <= lastColumn; column++)
				{
					excelData[row - 1, column - 1] = worksheet.Cells[row, column].Value?.ToString();

					cellsLoaded++;
					int progress = (int)(((double)cellsLoaded / totalCells) * 100);
					progressBar.Value = progress;
					label.Text = $"{progress}%";
					progressBar.Refresh(); // Actualiza el ProgressBar para mostrar el progreso en tiempo real
					label.Refresh(); // Actualiza el Label para mostrar el porcentaje en tiempo real
					Application.DoEvents(); // Permite que la interfaz de usuario se actualice durante el proceso de carga
				}
			}


			// Cerrar el archivo de Excel y liberar los recursos
			workbook.Close();
			excelApp.Quit();
			System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
			System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
			System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

			button.Enabled = true;
			// Aquí puedes utilizar los datos almacenados en la variable excelData
		}
	}
	public static void SetExcelData(string[,] data)
	{
		excelData = data;
	}

	public static string[,] GetExcelData()
	{
		return excelData;
	}

	public static void UpdateInsertPrecioMano(int idClaseMaterial, float precioNuevo, float precioDesmantelimiento, DateTime fecha, String zona, int filaError)
	{
		OracleConnection conn = ConnOra.GetDBConnection();

		try
		{
			OracleCommand objCmd = new OracleCommand();
			objCmd.Connection = conn;
			objCmd.CommandText = "PKG_SISTEMA4.PR_MANO_PRECIO";
			objCmd.CommandType = CommandType.StoredProcedure;
			// Agregar los parámetros al comando
			//objCmd.Parameters.Add("p_id_prefech_mo", OracleType.Number).Value = idPrecioFecha;
			objCmd.Parameters.Add("p_id_clas_mo", OracleType.Number).Value = idClaseMaterial;
			objCmd.Parameters.Add("p_precio_nuevo_mo", OracleType.Number).Value = precioNuevo;
			objCmd.Parameters.Add("p_precio_desmantelamiento_mo", OracleType.Number).Value = precioDesmantelimiento;
			objCmd.Parameters.Add("p_fecha_mo", OracleType.DateTime).Value = fecha;
			objCmd.Parameters.Add("p_zona", OracleType.Char).Value = zona;

			conn.Open();
			objCmd.ExecuteNonQuery();

			// Mostrar mensaje de éxito si no se producen excepciones
		}
		catch (OracleException ex1)
		{
			// Crear un nuevo formulario
			Form mensajeForm = new Form();
			mensajeForm.Text = "Error";
			mensajeForm.FormBorderStyle = FormBorderStyle.FixedDialog;
			mensajeForm.StartPosition = FormStartPosition.CenterScreen;

			// Crear una etiqueta para mostrar el mensaje
			Label mensajeLabel = new Label();
			mensajeLabel.Text = $"Error en la fila {filaError} del Excel:\n\n{ex1.Message}";
			mensajeLabel.AutoSize = false;
			mensajeLabel.Font = new Font("Arial", 12, FontStyle.Bold | FontStyle.Italic); // Establecer estilo de fuente personalizado
			mensajeLabel.TextAlign = ContentAlignment.MiddleCenter;
			mensajeLabel.Dock = DockStyle.Fill;

			// Crear un botón "Aceptar"
			Button aceptarButton = new Button();
			aceptarButton.Text = "Aceptar";
			aceptarButton.Font = new Font("Arial", 12, FontStyle.Bold);
			aceptarButton.Dock = DockStyle.Bottom;
			aceptarButton.DialogResult = DialogResult.OK;

			// Agregar el botón al formulario
			mensajeForm.Controls.Add(aceptarButton);

			// Agregar la etiqueta al formulario
			mensajeForm.Controls.Add(mensajeLabel);

			// Establecer el estilo de ventana de error
			mensajeForm.BackColor = Color.FromArgb(255, 245, 245, 245); // Color de fondo personalizado
			mensajeForm.ForeColor = Color.Red; // Color de texto personalizado

			// Asociar el evento Click del botón "Aceptar" para cerrar el formulario
			aceptarButton.Click += (sender, e) => { mensajeForm.Close(); };

			// Mostrar el formulario como un diálogo modal
			mensajeForm.ShowDialog();
			// Mostrar mensaje de error utilizando la información de la excepción
			//MessageBox.Show("Error en la actualización del material:\n" + ex1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

		}
		finally
		{
			conn.Close();
		}

	}

		public static void UpdateInsertMaterial(string codigoMaterial, string descripcionMaterial, int codigoUnidad, int clasificacionMaterial, float precioMaterial, DateTime fechaMaterial, int filaError)
	{
		OracleConnection conn = ConnOra.GetDBConnection();

		int numError = 0;

		try
		{
			OracleCommand objCmd = new OracleCommand();
			objCmd.Connection = conn;
			objCmd.CommandText = "PKG_SISTEMA4.PR_MATERIAL_PRECIO";
			objCmd.CommandType = CommandType.StoredProcedure;

			// Agregar los parámetros al comando
			objCmd.Parameters.Add("p_con_mat", OracleType.VarChar).Value = codigoMaterial;
			objCmd.Parameters.Add("p_desc_mat", OracleType.VarChar).Value = descripcionMaterial;
			objCmd.Parameters.Add("p_cod_unidad", OracleType.Number).Value = codigoUnidad;
			objCmd.Parameters.Add("p_id_mat_clasificacion", OracleType.Number).Value = clasificacionMaterial;
			objCmd.Parameters.Add("p_precio_mat", OracleType.Number).Value = precioMaterial;
			objCmd.Parameters.Add("p_fecha_mat", OracleType.DateTime).Value = fechaMaterial;

			conn.Open();
			objCmd.ExecuteNonQuery();

			// Mostrar mensaje de éxito si no se producen excepciones

		

		}
		catch (OracleException ex)
		{
			// Crear un nuevo formulario
			Form mensajeForm = new Form();
			mensajeForm.Text = "Error";
			mensajeForm.FormBorderStyle = FormBorderStyle.FixedDialog;
			mensajeForm.StartPosition = FormStartPosition.CenterScreen;

			// Crear una etiqueta para mostrar el mensaje
			Label mensajeLabel = new Label();
			mensajeLabel.Text = $"Error en la fila {filaError} del Excel:\n\n{ex.Message}";
			mensajeLabel.AutoSize = false;
			mensajeLabel.Font = new Font("Arial", 12, FontStyle.Bold | FontStyle.Italic); // Establecer estilo de fuente personalizado
			mensajeLabel.TextAlign = ContentAlignment.MiddleCenter;
			mensajeLabel.Dock = DockStyle.Fill;

			// Crear un botón "Aceptar"
			Button aceptarButton = new Button();
			aceptarButton.Text = "Aceptar";
			aceptarButton.Font = new Font("Arial", 12, FontStyle.Bold);
			aceptarButton.Dock = DockStyle.Bottom;
			aceptarButton.DialogResult = DialogResult.OK;

			// Agregar el botón al formulario
			mensajeForm.Controls.Add(aceptarButton);

			// Agregar la etiqueta al formulario
			mensajeForm.Controls.Add(mensajeLabel);

			// Establecer el estilo de ventana de error
			mensajeForm.BackColor = Color.FromArgb(255, 245, 245, 245); // Color de fondo personalizado
			mensajeForm.ForeColor = Color.Red; // Color de texto personalizado

			// Asociar el evento Click del botón "Aceptar" para cerrar el formulario
			aceptarButton.Click += (sender, e) => { mensajeForm.Close(); };

			// Mostrar el formulario como un diálogo modal
			mensajeForm.ShowDialog();





			// Mostrar mensaje de error utilizando la información de la excepción
			//MessageBox.Show("Error en la actualización del material:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//MessageBox.Show($"Error en la fila {filaError} del Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

		}
		finally
		{
			conn.Close();
		}
	}

	public ClassFuncionesSLEJ()
	{


	}
}
