namespace MasterCoveControl
{
    partial class CreateLoadFolder
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
            this.ButtonCreateFolder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ComboboxYears = new System.Windows.Forms.ComboBox();
            this.ProgressBarUpdate = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // ButtonCreateFolder
            // 
            this.ButtonCreateFolder.Enabled = false;
            this.ButtonCreateFolder.Location = new System.Drawing.Point(255, 2);
            this.ButtonCreateFolder.Name = "ButtonCreateFolder";
            this.ButtonCreateFolder.Size = new System.Drawing.Size(150, 23);
            this.ButtonCreateFolder.TabIndex = 17;
            this.ButtonCreateFolder.Text = "Generar Carpeta de Carga";
            this.ButtonCreateFolder.UseVisualStyleBackColor = true;
            this.ButtonCreateFolder.Click += new System.EventHandler(this.ButtonCreateFolder_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 16;
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
            this.ComboboxYears.TabIndex = 15;
            this.ComboboxYears.SelectedIndexChanged += new System.EventHandler(this.ComboboxYears_SelectedIndexChanged);
            // 
            // ProgressBarUpdate
            // 
            this.ProgressBarUpdate.Location = new System.Drawing.Point(7, 151);
            this.ProgressBarUpdate.Name = "ProgressBarUpdate";
            this.ProgressBarUpdate.Size = new System.Drawing.Size(687, 23);
            this.ProgressBarUpdate.TabIndex = 18;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // CreateLoadFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Controls.Add(this.ProgressBarUpdate);
            this.Controls.Add(this.ButtonCreateFolder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ComboboxYears);
            this.Name = "CreateLoadFolder";
            this.Size = new System.Drawing.Size(700, 180);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonCreateFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ComboboxYears;
        private System.Windows.Forms.ProgressBar ProgressBarUpdate;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
