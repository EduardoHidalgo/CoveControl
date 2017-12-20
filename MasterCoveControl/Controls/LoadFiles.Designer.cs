namespace MasterCoveControl
{
    partial class LoadFiles
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
            this.ComboboxYears = new System.Windows.Forms.ComboBox();
            this.ProgressBarFiles = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonLoadFiles = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ButtonGetAcusesFolder = new System.Windows.Forms.Button();
            this.TextboxPathAcuse = new System.Windows.Forms.TextBox();
            this.ButtonGetDetailFolder = new System.Windows.Forms.Button();
            this.TextboxPathDetail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ProgressBarChecker = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // ComboboxYears
            // 
            this.ComboboxYears.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboboxYears.FormattingEnabled = true;
            this.ComboboxYears.Location = new System.Drawing.Point(104, 7);
            this.ComboboxYears.Name = "ComboboxYears";
            this.ComboboxYears.Size = new System.Drawing.Size(152, 21);
            this.ComboboxYears.Sorted = true;
            this.ComboboxYears.TabIndex = 1;
            this.ComboboxYears.SelectedIndexChanged += new System.EventHandler(this.ComboboxYears_SelectedIndexChanged);
            this.ComboboxYears.TextChanged += new System.EventHandler(this.ComboboxYears_TextChanged);
            // 
            // ProgressBarFiles
            // 
            this.ProgressBarFiles.Location = new System.Drawing.Point(103, 121);
            this.ProgressBarFiles.Name = "ProgressBarFiles";
            this.ProgressBarFiles.Size = new System.Drawing.Size(592, 23);
            this.ProgressBarFiles.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Archivos Cargados:";
            // 
            // ButtonLoadFiles
            // 
            this.ButtonLoadFiles.Enabled = false;
            this.ButtonLoadFiles.Location = new System.Drawing.Point(277, 93);
            this.ButtonLoadFiles.Name = "ButtonLoadFiles";
            this.ButtonLoadFiles.Size = new System.Drawing.Size(150, 23);
            this.ButtonLoadFiles.TabIndex = 10;
            this.ButtonLoadFiles.Text = "Cargar Archivos";
            this.ButtonLoadFiles.UseVisualStyleBackColor = true;
            this.ButtonLoadFiles.Click += new System.EventHandler(this.ButtonLoadFiles_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Seleccionar Año:";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // ButtonGetAcusesFolder
            // 
            this.ButtonGetAcusesFolder.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.ButtonGetAcusesFolder.Enabled = false;
            this.ButtonGetAcusesFolder.Location = new System.Drawing.Point(5, 33);
            this.ButtonGetAcusesFolder.Name = "ButtonGetAcusesFolder";
            this.ButtonGetAcusesFolder.Size = new System.Drawing.Size(96, 23);
            this.ButtonGetAcusesFolder.TabIndex = 13;
            this.ButtonGetAcusesFolder.Text = "Buscar Acuses";
            this.ButtonGetAcusesFolder.UseVisualStyleBackColor = true;
            this.ButtonGetAcusesFolder.Click += new System.EventHandler(this.ButtonGetAcusesFolder_Click);
            // 
            // TextboxPathAcuse
            // 
            this.TextboxPathAcuse.Enabled = false;
            this.TextboxPathAcuse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextboxPathAcuse.Location = new System.Drawing.Point(104, 34);
            this.TextboxPathAcuse.Name = "TextboxPathAcuse";
            this.TextboxPathAcuse.Size = new System.Drawing.Size(592, 21);
            this.TextboxPathAcuse.TabIndex = 12;
            this.TextboxPathAcuse.TabStop = false;
            // 
            // ButtonGetDetailFolder
            // 
            this.ButtonGetDetailFolder.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.ButtonGetDetailFolder.Enabled = false;
            this.ButtonGetDetailFolder.Location = new System.Drawing.Point(5, 61);
            this.ButtonGetDetailFolder.Name = "ButtonGetDetailFolder";
            this.ButtonGetDetailFolder.Size = new System.Drawing.Size(96, 23);
            this.ButtonGetDetailFolder.TabIndex = 15;
            this.ButtonGetDetailFolder.Text = "Buscar Detalles";
            this.ButtonGetDetailFolder.UseVisualStyleBackColor = true;
            this.ButtonGetDetailFolder.Click += new System.EventHandler(this.ButtonGetDetailFolder_Click);
            // 
            // TextboxPathDetail
            // 
            this.TextboxPathDetail.Enabled = false;
            this.TextboxPathDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextboxPathDetail.Location = new System.Drawing.Point(104, 62);
            this.TextboxPathDetail.Name = "TextboxPathDetail";
            this.TextboxPathDetail.Size = new System.Drawing.Size(592, 21);
            this.TextboxPathDetail.TabIndex = 14;
            this.TextboxPathDetail.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Archivos Revisados:";
            // 
            // ProgressBarChecker
            // 
            this.ProgressBarChecker.Location = new System.Drawing.Point(103, 150);
            this.ProgressBarChecker.Name = "ProgressBarChecker";
            this.ProgressBarChecker.Size = new System.Drawing.Size(592, 23);
            this.ProgressBarChecker.TabIndex = 16;
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // LoadFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ProgressBarChecker);
            this.Controls.Add(this.ButtonGetDetailFolder);
            this.Controls.Add(this.TextboxPathDetail);
            this.Controls.Add(this.ButtonGetAcusesFolder);
            this.Controls.Add(this.TextboxPathAcuse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ButtonLoadFiles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProgressBarFiles);
            this.Controls.Add(this.ComboboxYears);
            this.Name = "LoadFiles";
            this.Size = new System.Drawing.Size(700, 180);
            this.Load += new System.EventHandler(this.LoadFiles_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox ComboboxYears;
        private System.Windows.Forms.ProgressBar ProgressBarFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonLoadFiles;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button ButtonGetAcusesFolder;
        private System.Windows.Forms.TextBox TextboxPathAcuse;
        private System.Windows.Forms.Button ButtonGetDetailFolder;
        private System.Windows.Forms.TextBox TextboxPathDetail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar ProgressBarChecker;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}
