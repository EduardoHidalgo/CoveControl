namespace MasterCoveControl
{
    partial class CreateReports
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.ComboboxYears = new System.Windows.Forms.ComboBox();
            this.ButtonCreateReports = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Seleccionar Año:";
            // 
            // ComboboxYears
            // 
            this.ComboboxYears.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboboxYears.FormattingEnabled = true;
            this.ComboboxYears.Location = new System.Drawing.Point(97, 3);
            this.ComboboxYears.Name = "ComboboxYears";
            this.ComboboxYears.Size = new System.Drawing.Size(152, 21);
            this.ComboboxYears.Sorted = true;
            this.ComboboxYears.TabIndex = 12;
            this.ComboboxYears.SelectedIndexChanged += new System.EventHandler(this.ComboboxYears_SelectedIndexChanged);
            // 
            // ButtonCreateReports
            // 
            this.ButtonCreateReports.Enabled = false;
            this.ButtonCreateReports.Location = new System.Drawing.Point(255, 2);
            this.ButtonCreateReports.Name = "ButtonCreateReports";
            this.ButtonCreateReports.Size = new System.Drawing.Size(150, 23);
            this.ButtonCreateReports.TabIndex = 14;
            this.ButtonCreateReports.Text = "Generar Reportes";
            this.ButtonCreateReports.UseVisualStyleBackColor = true;
            this.ButtonCreateReports.Click += new System.EventHandler(this.ButtonCreateReports_Click);
            // 
            // CreateReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Controls.Add(this.ButtonCreateReports);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ComboboxYears);
            this.Name = "CreateReports";
            this.Size = new System.Drawing.Size(700, 180);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ComboboxYears;
        private System.Windows.Forms.Button ButtonCreateReports;
    }
}
