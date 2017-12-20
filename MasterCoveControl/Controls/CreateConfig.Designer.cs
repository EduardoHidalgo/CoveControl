namespace MasterCoveControl
{
    partial class CreateConfig
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
            this.ButtonGetFolder = new System.Windows.Forms.Button();
            this.ButtonCreateConfig = new System.Windows.Forms.Button();
            this.TextboxPath = new System.Windows.Forms.TextBox();
            this.ButtonDeleteConfig = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonGetFolder
            // 
            this.ButtonGetFolder.Location = new System.Drawing.Point(3, 3);
            this.ButtonGetFolder.Name = "ButtonGetFolder";
            this.ButtonGetFolder.Size = new System.Drawing.Size(141, 23);
            this.ButtonGetFolder.TabIndex = 1;
            this.ButtonGetFolder.Text = "Seleccionar Carpeta Raíz";
            this.ButtonGetFolder.UseVisualStyleBackColor = true;
            this.ButtonGetFolder.Click += new System.EventHandler(this.ButtonGetFolder_Click);
            // 
            // ButtonCreateConfig
            // 
            this.ButtonCreateConfig.Location = new System.Drawing.Point(278, 151);
            this.ButtonCreateConfig.Name = "ButtonCreateConfig";
            this.ButtonCreateConfig.Size = new System.Drawing.Size(133, 23);
            this.ButtonCreateConfig.TabIndex = 2;
            this.ButtonCreateConfig.Text = "Generar Configuración";
            this.ButtonCreateConfig.UseVisualStyleBackColor = true;
            this.ButtonCreateConfig.Click += new System.EventHandler(this.ButtonCreateConfig_Click);
            // 
            // TextboxPath
            // 
            this.TextboxPath.Enabled = false;
            this.TextboxPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextboxPath.Location = new System.Drawing.Point(149, 4);
            this.TextboxPath.Name = "TextboxPath";
            this.TextboxPath.Size = new System.Drawing.Size(547, 21);
            this.TextboxPath.TabIndex = 0;
            // 
            // ButtonDeleteConfig
            // 
            this.ButtonDeleteConfig.Location = new System.Drawing.Point(577, 151);
            this.ButtonDeleteConfig.Name = "ButtonDeleteConfig";
            this.ButtonDeleteConfig.Size = new System.Drawing.Size(119, 23);
            this.ButtonDeleteConfig.TabIndex = 3;
            this.ButtonDeleteConfig.Text = "Eliminar Configuración";
            this.ButtonDeleteConfig.UseVisualStyleBackColor = true;
            this.ButtonDeleteConfig.Click += new System.EventHandler(this.ButtonDeleteConfig_Click);
            // 
            // CreateConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Controls.Add(this.ButtonDeleteConfig);
            this.Controls.Add(this.TextboxPath);
            this.Controls.Add(this.ButtonCreateConfig);
            this.Controls.Add(this.ButtonGetFolder);
            this.Name = "CreateConfig";
            this.Size = new System.Drawing.Size(700, 180);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonGetFolder;
        private System.Windows.Forms.Button ButtonCreateConfig;
        private System.Windows.Forms.TextBox TextboxPath;
        private System.Windows.Forms.Button ButtonDeleteConfig;
    }
}
