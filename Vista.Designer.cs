namespace Algoritmos
{
    partial class Creator
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Creator));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.listInicial = new System.Windows.Forms.ListView();
            this.boxAlgoritmo = new System.Windows.Forms.ComboBox();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.numericBox = new System.Windows.Forms.NumericUpDown();
            this.DataGridOut = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.numericBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridOut)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Roboto Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(27, 27);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(113, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Algoritmo:";
            // 
            // listInicial
            // 
            this.listInicial.Font = new System.Drawing.Font("Roboto Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listInicial.HideSelection = false;
            this.listInicial.Location = new System.Drawing.Point(12, 101);
            this.listInicial.Name = "listInicial";
            this.listInicial.Size = new System.Drawing.Size(1240, 33);
            this.listInicial.TabIndex = 1;
            this.listInicial.UseCompatibleStateImageBehavior = false;
            this.listInicial.View = System.Windows.Forms.View.Details;
            this.listInicial.Visible = false;
            this.listInicial.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listInicial_MouseClick);
            // 
            // boxAlgoritmo
            // 
            this.boxAlgoritmo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.boxAlgoritmo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxAlgoritmo.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxAlgoritmo.Items.AddRange(new object[] {
            "sumaEREW",
            "sumaCREW",
            "busquedaEREW",
            "busquedaCRCW",
            "ordenamientoCRCW"});
            this.boxAlgoritmo.Location = new System.Drawing.Point(146, 25);
            this.boxAlgoritmo.Name = "boxAlgoritmo";
            this.boxAlgoritmo.Size = new System.Drawing.Size(162, 27);
            this.boxAlgoritmo.TabIndex = 1;
            this.boxAlgoritmo.SelectedIndexChanged += new System.EventHandler(this.boxAlgoritmo_SelectedIndexChanged);
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackColor = System.Drawing.Color.White;
            this.btnProcesar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcesar.Font = new System.Drawing.Font("Roboto Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcesar.Location = new System.Drawing.Point(32, 140);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(104, 29);
            this.btnProcesar.TabIndex = 2;
            this.btnProcesar.Text = "PROCESAR";
            this.btnProcesar.UseVisualStyleBackColor = false;
            this.btnProcesar.Visible = false;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.White;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.Font = new System.Drawing.Font("Roboto Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(32, 66);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(104, 29);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "AGREGAR";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Visible = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // numericBox
            // 
            this.numericBox.Font = new System.Drawing.Font("Roboto Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericBox.Location = new System.Drawing.Point(146, 66);
            this.numericBox.Name = "numericBox";
            this.numericBox.Size = new System.Drawing.Size(162, 27);
            this.numericBox.TabIndex = 5;
            this.numericBox.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericBox.Visible = false;
            this.numericBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericBox_KeyPress);
            // 
            // DataGridOut
            // 
            this.DataGridOut.AllowUserToAddRows = false;
            this.DataGridOut.AllowUserToDeleteRows = false;
            this.DataGridOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridOut.Location = new System.Drawing.Point(13, 176);
            this.DataGridOut.Name = "DataGridOut";
            this.DataGridOut.ReadOnly = true;
            this.DataGridOut.Size = new System.Drawing.Size(1239, 493);
            this.DataGridOut.TabIndex = 6;
            // 
            // Creator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.DataGridOut);
            this.Controls.Add(this.numericBox);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.boxAlgoritmo);
            this.Controls.Add(this.listInicial);
            this.Controls.Add(this.lblTitulo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Creator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Algoritmos C#";
            ((System.ComponentModel.ISupportInitialize)(this.numericBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridOut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ListView listInicial;
        private System.Windows.Forms.ComboBox boxAlgoritmo;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.NumericUpDown numericBox;
        private System.Windows.Forms.DataGridView DataGridOut;
    }
}

