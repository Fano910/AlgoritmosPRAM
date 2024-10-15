using System.Drawing;
using System.Windows.Forms;

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
            this.ListInicial = new System.Windows.Forms.ListView();
            this.BoxAlgoritmo = new System.Windows.Forms.ComboBox();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.NumericBoxAgregar = new System.Windows.Forms.NumericUpDown();
            this.DataGridOut = new System.Windows.Forms.DataGridView();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.LblResultado = new System.Windows.Forms.Label();
            this.NumericBoxBusqueda = new System.Windows.Forms.NumericUpDown();
            this.BtnMult = new System.Windows.Forms.Button();
            this.CheckBoxIsByDefault = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBoxAgregar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBoxBusqueda)).BeginInit();
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
            // ListInicial
            // 
            this.ListInicial.Font = new System.Drawing.Font("Roboto Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListInicial.HideSelection = false;
            this.ListInicial.Location = new System.Drawing.Point(13, 99);
            this.ListInicial.Name = "ListInicial";
            this.ListInicial.Size = new System.Drawing.Size(1250, 33);
            this.ListInicial.TabIndex = 1;
            this.ListInicial.UseCompatibleStateImageBehavior = false;
            this.ListInicial.View = System.Windows.Forms.View.Details;
            this.ListInicial.Visible = false;
            this.ListInicial.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ListInicial_ItemSelectionChanged);
            this.ListInicial.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListInicial_MouseDoubleClick);
            // 
            // BoxAlgoritmo
            // 
            this.BoxAlgoritmo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BoxAlgoritmo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BoxAlgoritmo.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxAlgoritmo.Items.AddRange(new object[] {
            "sumaEREW",
            "sumaCREW",
            "busquedaEREW",
            "busquedaCRCW",
            "ordenamientoCRCW",
            "ordenamientoEREW"});
            this.BoxAlgoritmo.Location = new System.Drawing.Point(146, 25);
            this.BoxAlgoritmo.Name = "BoxAlgoritmo";
            this.BoxAlgoritmo.Size = new System.Drawing.Size(162, 27);
            this.BoxAlgoritmo.TabIndex = 1;
            this.BoxAlgoritmo.SelectedIndexChanged += new System.EventHandler(this.BoxAlgoritmo_SelectedIndexChanged_1);
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
            // BtnAgregar
            // 
            this.BtnAgregar.BackColor = System.Drawing.Color.White;
            this.BtnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAgregar.Font = new System.Drawing.Font("Roboto Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregar.Location = new System.Drawing.Point(32, 66);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(104, 29);
            this.BtnAgregar.TabIndex = 4;
            this.BtnAgregar.Text = "AGREGAR";
            this.BtnAgregar.UseVisualStyleBackColor = false;
            this.BtnAgregar.Visible = false;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click_1);
            // 
            // NumericBoxAgregar
            // 
            this.NumericBoxAgregar.Font = new System.Drawing.Font("Roboto Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericBoxAgregar.Location = new System.Drawing.Point(146, 66);
            this.NumericBoxAgregar.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumericBoxAgregar.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.NumericBoxAgregar.Name = "NumericBoxAgregar";
            this.NumericBoxAgregar.Size = new System.Drawing.Size(76, 27);
            this.NumericBoxAgregar.TabIndex = 5;
            this.NumericBoxAgregar.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericBoxAgregar.Visible = false;
            this.NumericBoxAgregar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericBoxAgregar_KeyPress);
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
            // BtnLimpiar
            // 
            this.BtnLimpiar.BackColor = System.Drawing.Color.White;
            this.BtnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLimpiar.Font = new System.Drawing.Font("Roboto Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLimpiar.Location = new System.Drawing.Point(146, 141);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(104, 29);
            this.BtnLimpiar.TabIndex = 7;
            this.BtnLimpiar.Text = "LIMPIAR";
            this.BtnLimpiar.UseVisualStyleBackColor = false;
            this.BtnLimpiar.Visible = false;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // LblResultado
            // 
            this.LblResultado.AutoSize = true;
            this.LblResultado.Font = new System.Drawing.Font("Roboto Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblResultado.Location = new System.Drawing.Point(256, 144);
            this.LblResultado.Name = "LblResultado";
            this.LblResultado.Size = new System.Drawing.Size(288, 25);
            this.LblResultado.TabIndex = 8;
            this.LblResultado.Text = "<<El resultado se vera aqui>>";
            this.LblResultado.Visible = false;
            // 
            // NumericBoxBusqueda
            // 
            this.NumericBoxBusqueda.Font = new System.Drawing.Font("Roboto Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericBoxBusqueda.Location = new System.Drawing.Point(232, 66);
            this.NumericBoxBusqueda.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumericBoxBusqueda.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.NumericBoxBusqueda.Name = "NumericBoxBusqueda";
            this.NumericBoxBusqueda.Size = new System.Drawing.Size(76, 27);
            this.NumericBoxBusqueda.TabIndex = 9;
            this.NumericBoxBusqueda.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.NumericBoxBusqueda.Visible = false;
            // 
            // BtnMult
            // 
            this.BtnMult.BackColor = System.Drawing.Color.White;
            this.BtnMult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnMult.Font = new System.Drawing.Font("Roboto Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMult.Location = new System.Drawing.Point(1138, 12);
            this.BtnMult.Name = "BtnMult";
            this.BtnMult.Size = new System.Drawing.Size(114, 29);
            this.BtnMult.TabIndex = 10;
            this.BtnMult.Text = "MULTIPLICAR";
            this.BtnMult.UseVisualStyleBackColor = false;
            this.BtnMult.Click += new System.EventHandler(this.BtnMult_Click);
            // 
            // CheckBoxIsByDefault
            // 
            this.CheckBoxIsByDefault.AutoSize = true;
            this.CheckBoxIsByDefault.Location = new System.Drawing.Point(315, 34);
            this.CheckBoxIsByDefault.Name = "CheckBoxIsByDefault";
            this.CheckBoxIsByDefault.Size = new System.Drawing.Size(105, 17);
            this.CheckBoxIsByDefault.TabIndex = 11;
            this.CheckBoxIsByDefault.Text = "Utilizar aleatorias";
            this.CheckBoxIsByDefault.UseVisualStyleBackColor = true;
            // 
            // Creator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.CheckBoxIsByDefault);
            this.Controls.Add(this.BtnMult);
            this.Controls.Add(this.NumericBoxBusqueda);
            this.Controls.Add(this.LblResultado);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.DataGridOut);
            this.Controls.Add(this.NumericBoxAgregar);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.BoxAlgoritmo);
            this.Controls.Add(this.ListInicial);
            this.Controls.Add(this.lblTitulo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Creator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Algoritmos C#";
            ((System.ComponentModel.ISupportInitialize)(this.NumericBoxAgregar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBoxBusqueda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ListView ListInicial;
        private System.Windows.Forms.ComboBox BoxAlgoritmo;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.NumericUpDown NumericBoxAgregar;
        private System.Windows.Forms.DataGridView DataGridOut;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.Label LblResultado;
        private System.Windows.Forms.NumericUpDown NumericBoxBusqueda;
        private Button BtnMult;
        private CheckBox CheckBoxIsByDefault;
    }
}

