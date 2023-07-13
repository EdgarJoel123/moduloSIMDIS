namespace Exportables_Sisde
{
    partial class IfrmExportacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnExporta = new System.Windows.Forms.Button();
            this.rButtonCodigo = new System.Windows.Forms.RadioButton();
            this.rButtonNomProyecto = new System.Windows.Forms.RadioButton();
            this.txtParamBusqueda = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnExportable = new System.Windows.Forms.Button();
            this.dgvProyectos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProyectos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExporta
            // 
            this.btnExporta.Location = new System.Drawing.Point(193, 336);
            this.btnExporta.Name = "btnExporta";
            this.btnExporta.Size = new System.Drawing.Size(121, 32);
            this.btnExporta.TabIndex = 0;
            this.btnExporta.Text = "Prueba archivos TXT";
            this.btnExporta.UseVisualStyleBackColor = true;
            this.btnExporta.Click += new System.EventHandler(this.btnExporta_Click);
            // 
            // rButtonCodigo
            // 
            this.rButtonCodigo.AutoSize = true;
            this.rButtonCodigo.Checked = true;
            this.rButtonCodigo.Location = new System.Drawing.Point(17, 13);
            this.rButtonCodigo.Name = "rButtonCodigo";
            this.rButtonCodigo.Size = new System.Drawing.Size(103, 17);
            this.rButtonCodigo.TabIndex = 2;
            this.rButtonCodigo.TabStop = true;
            this.rButtonCodigo.Text = "Código Proyecto";
            this.rButtonCodigo.UseVisualStyleBackColor = true;
            // 
            // rButtonNomProyecto
            // 
            this.rButtonNomProyecto.AutoSize = true;
            this.rButtonNomProyecto.Location = new System.Drawing.Point(158, 12);
            this.rButtonNomProyecto.Name = "rButtonNomProyecto";
            this.rButtonNomProyecto.Size = new System.Drawing.Size(124, 17);
            this.rButtonNomProyecto.TabIndex = 3;
            this.rButtonNomProyecto.Text = "Nombre del Proyecto";
            this.rButtonNomProyecto.UseVisualStyleBackColor = true;
            // 
            // txtParamBusqueda
            // 
            this.txtParamBusqueda.Location = new System.Drawing.Point(12, 35);
            this.txtParamBusqueda.Name = "txtParamBusqueda";
            this.txtParamBusqueda.Size = new System.Drawing.Size(207, 20);
            this.txtParamBusqueda.TabIndex = 4;
            this.txtParamBusqueda.TextChanged += new System.EventHandler(this.txtParamBusqueda_TextChanged);
            this.txtParamBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtParamBusqueda_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(225, 30);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(86, 28);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnExportable
            // 
            this.btnExportable.Location = new System.Drawing.Point(80, 308);
            this.btnExportable.Name = "btnExportable";
            this.btnExportable.Size = new System.Drawing.Size(139, 25);
            this.btnExportable.TabIndex = 6;
            this.btnExportable.Text = "Exporta Proyectos";
            this.btnExportable.UseVisualStyleBackColor = true;
            this.btnExportable.Click += new System.EventHandler(this.btnExportable_Click);
            // 
            // dgvProyectos
            // 
            this.dgvProyectos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvProyectos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProyectos.Location = new System.Drawing.Point(14, 68);
            this.dgvProyectos.Name = "dgvProyectos";
            this.dgvProyectos.Size = new System.Drawing.Size(296, 229);
            this.dgvProyectos.TabIndex = 7;
            // 
            // IfrmExportacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 367);
            this.Controls.Add(this.dgvProyectos);
            this.Controls.Add(this.btnExportable);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtParamBusqueda);
            this.Controls.Add(this.rButtonNomProyecto);
            this.Controls.Add(this.rButtonCodigo);
            this.Controls.Add(this.btnExporta);
            this.Name = "IfrmExportacion";
            this.Text = "Exportables SISDE";
            this.Load += new System.EventHandler(this.IfrmExportacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProyectos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExporta;
        private System.Windows.Forms.RadioButton rButtonCodigo;
        private System.Windows.Forms.RadioButton rButtonNomProyecto;
        private System.Windows.Forms.TextBox txtParamBusqueda;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnExportable;
        private System.Windows.Forms.DataGridView dgvProyectos;
    }
}