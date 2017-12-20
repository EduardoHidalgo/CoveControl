namespace MasterCoveControl
{
    partial class ImportRelation
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
            this.TextboxPath = new System.Windows.Forms.TextBox();
            this.ButtonGetExcel = new System.Windows.Forms.Button();
            this.CheckedListProgress = new System.Windows.Forms.CheckedListBox();
            this.ButtonUpdateConfig = new System.Windows.Forms.Button();
            this.ProgressBarUpdate = new System.Windows.Forms.ProgressBar();
            this.Label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label2 = new System.Windows.Forms.Label();
            this.ProgressBarLoadExcel = new System.Windows.Forms.ProgressBar();
            this.ButtonLoadExcel = new System.Windows.Forms.Button();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // TextboxPath
            // 
            this.TextboxPath.Enabled = false;
            this.TextboxPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextboxPath.Location = new System.Drawing.Point(149, 4);
            this.TextboxPath.Name = "TextboxPath";
            this.TextboxPath.Size = new System.Drawing.Size(547, 21);
            this.TextboxPath.TabIndex = 0;
            this.TextboxPath.TabStop = false;
            // 
            // ButtonGetExcel
            // 
            this.ButtonGetExcel.Location = new System.Drawing.Point(3, 3);
            this.ButtonGetExcel.Name = "ButtonGetExcel";
            this.ButtonGetExcel.Size = new System.Drawing.Size(141, 23);
            this.ButtonGetExcel.TabIndex = 1;
            this.ButtonGetExcel.Text = "Buscar Relación";
            this.ButtonGetExcel.UseVisualStyleBackColor = true;
            this.ButtonGetExcel.Click += new System.EventHandler(this.ButtonGetExcel_Click);
            // 
            // CheckedListProgress
            // 
            this.CheckedListProgress.Enabled = false;
            this.CheckedListProgress.FormattingEnabled = true;
            this.CheckedListProgress.Items.AddRange(new object[] {
            "Excel Obtenido",
            "Carpeta Año",
            "Carpeta Acuses",
            "Carpeta Detalles",
            "Carpeta Referencias",
            "Data Obtenida"});
            this.CheckedListProgress.Location = new System.Drawing.Point(3, 54);
            this.CheckedListProgress.Name = "CheckedListProgress";
            this.CheckedListProgress.Size = new System.Drawing.Size(693, 94);
            this.CheckedListProgress.TabIndex = 0;
            this.CheckedListProgress.TabStop = false;
            // 
            // ButtonUpdateConfig
            // 
            this.ButtonUpdateConfig.Enabled = false;
            this.ButtonUpdateConfig.Location = new System.Drawing.Point(3, 154);
            this.ButtonUpdateConfig.Name = "ButtonUpdateConfig";
            this.ButtonUpdateConfig.Size = new System.Drawing.Size(141, 23);
            this.ButtonUpdateConfig.TabIndex = 3;
            this.ButtonUpdateConfig.Text = "Cargar Relación";
            this.ButtonUpdateConfig.UseVisualStyleBackColor = true;
            this.ButtonUpdateConfig.Click += new System.EventHandler(this.ButtonUpdateConfig_Click);
            // 
            // ProgressBarUpdate
            // 
            this.ProgressBarUpdate.Enabled = false;
            this.ProgressBarUpdate.Location = new System.Drawing.Point(200, 154);
            this.ProgressBarUpdate.Name = "ProgressBarUpdate";
            this.ProgressBarUpdate.Size = new System.Drawing.Size(496, 23);
            this.ProgressBarUpdate.TabIndex = 0;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(146, 159);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(52, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Progreso:";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Progreso:";
            // 
            // ProgressBarLoadExcel
            // 
            this.ProgressBarLoadExcel.Enabled = false;
            this.ProgressBarLoadExcel.Location = new System.Drawing.Point(200, 28);
            this.ProgressBarLoadExcel.Name = "ProgressBarLoadExcel";
            this.ProgressBarLoadExcel.Size = new System.Drawing.Size(496, 23);
            this.ProgressBarLoadExcel.TabIndex = 0;
            // 
            // ButtonLoadExcel
            // 
            this.ButtonLoadExcel.Enabled = false;
            this.ButtonLoadExcel.Location = new System.Drawing.Point(3, 28);
            this.ButtonLoadExcel.Name = "ButtonLoadExcel";
            this.ButtonLoadExcel.Size = new System.Drawing.Size(141, 23);
            this.ButtonLoadExcel.TabIndex = 2;
            this.ButtonLoadExcel.Text = "Cargar Excel";
            this.ButtonLoadExcel.UseVisualStyleBackColor = true;
            this.ButtonLoadExcel.Click += new System.EventHandler(this.ButtonLoadExcel_Click);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // ImportRelation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ProgressBarLoadExcel);
            this.Controls.Add(this.ButtonLoadExcel);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.ProgressBarUpdate);
            this.Controls.Add(this.ButtonUpdateConfig);
            this.Controls.Add(this.CheckedListProgress);
            this.Controls.Add(this.TextboxPath);
            this.Controls.Add(this.ButtonGetExcel);
            this.Name = "ImportRelation";
            this.Size = new System.Drawing.Size(700, 180);
            this.Load += new System.EventHandler(this.ImportRelation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextboxPath;
        private System.Windows.Forms.Button ButtonGetExcel;
        private System.Windows.Forms.CheckedListBox CheckedListProgress;
        private System.Windows.Forms.Button ButtonUpdateConfig;
        private System.Windows.Forms.ProgressBar ProgressBarUpdate;
        private System.Windows.Forms.Label Label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar ProgressBarLoadExcel;
        private System.Windows.Forms.Button ButtonLoadExcel;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}
