namespace AbarrotesGenerales.Mantenimientos
{
    partial class MantenimientoInventario
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
            this.components = new System.ComponentModel.Container();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.datosInventario = new System.Windows.Forms.DataGridView();
            this.idArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelFecha = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.textBoxCveProv = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownCant = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxCveArt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBoxNomArt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNomProv = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.inventarioTableAdapter1 = new AbarrotesGenerales.PuntoVentaDataSetTableAdapters.InventarioTableAdapter();
            this.articuloProveedorTableAdapter1 = new AbarrotesGenerales.PuntoVentaDataSetTableAdapters.ArticuloProveedorTableAdapter();
            this.articuloTableAdapter1 = new AbarrotesGenerales.PuntoVentaDataSetTableAdapters.ArticuloTableAdapter();
            this.proveedorTableAdapter1 = new AbarrotesGenerales.PuntoVentaDataSetTableAdapters.ProveedorTableAdapter();
            this.labelArtProvValido = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datosInventario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCant)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Bright", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(256, 23);
            this.label6.TabIndex = 25;
            this.label6.Text = "CONTROL INVENTARIO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Bright", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(276, 24);
            this.label5.TabIndex = 24;
            this.label5.Text = "ABARROTES GENERALES";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.Font = new System.Drawing.Font("Lucida Bright", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(639, 24);
            this.label4.TabIndex = 23;
            this.label4.Text = "INSTITUTO TECNOLOGICO DE MEXICO CAMPUS MEXICALI";
            // 
            // datosInventario
            // 
            this.datosInventario.AllowUserToAddRows = false;
            this.datosInventario.AllowUserToDeleteRows = false;
            this.datosInventario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datosInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datosInventario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idArticulo,
            this.nombreArticulo,
            this.idProveedor,
            this.nombreProveedor,
            this.cantidadArticulo,
            this.precioArticulo});
            this.datosInventario.Location = new System.Drawing.Point(28, 122);
            this.datosInventario.Name = "datosInventario";
            this.datosInventario.ReadOnly = true;
            this.datosInventario.Size = new System.Drawing.Size(690, 207);
            this.datosInventario.TabIndex = 26;
            this.datosInventario.TabStop = false;
            // 
            // idArticulo
            // 
            this.idArticulo.HeaderText = "idArticulo";
            this.idArticulo.Name = "idArticulo";
            this.idArticulo.ReadOnly = true;
            // 
            // nombreArticulo
            // 
            this.nombreArticulo.HeaderText = "nombreArticulo";
            this.nombreArticulo.Name = "nombreArticulo";
            this.nombreArticulo.ReadOnly = true;
            this.nombreArticulo.Width = 200;
            // 
            // idProveedor
            // 
            this.idProveedor.HeaderText = "idProveedor";
            this.idProveedor.Name = "idProveedor";
            this.idProveedor.ReadOnly = true;
            // 
            // nombreProveedor
            // 
            this.nombreProveedor.HeaderText = "nombreProveedor";
            this.nombreProveedor.Name = "nombreProveedor";
            this.nombreProveedor.ReadOnly = true;
            this.nombreProveedor.Width = 200;
            // 
            // cantidadArticulo
            // 
            this.cantidadArticulo.HeaderText = "cantidadArticulo";
            this.cantidadArticulo.Name = "cantidadArticulo";
            this.cantidadArticulo.ReadOnly = true;
            // 
            // precioArticulo
            // 
            this.precioArticulo.HeaderText = "precioArticulo";
            this.precioArticulo.Name = "precioArticulo";
            this.precioArticulo.ReadOnly = true;
            // 
            // labelFecha
            // 
            this.labelFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFecha.AutoSize = true;
            this.labelFecha.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFecha.Location = new System.Drawing.Point(395, 59);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelFecha.Size = new System.Drawing.Size(159, 20);
            this.labelFecha.TabIndex = 27;
            this.labelFecha.Text = "Fecha y hora actual";
            this.labelFecha.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(16, 82);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 53;
            this.button4.TabStop = false;
            this.button4.Text = "ATRAS";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBoxCveProv
            // 
            this.textBoxCveProv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCveProv.Location = new System.Drawing.Point(201, 407);
            this.textBoxCveProv.Name = "textBoxCveProv";
            this.textBoxCveProv.Size = new System.Drawing.Size(165, 20);
            this.textBoxCveProv.TabIndex = 69;
            this.textBoxCveProv.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(23, 409);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 18);
            this.label8.TabIndex = 75;
            this.label8.Text = "Clave Proveedor:";
            // 
            // numericUpDownCant
            // 
            this.numericUpDownCant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownCant.Location = new System.Drawing.Point(203, 466);
            this.numericUpDownCant.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDownCant.Name = "numericUpDownCant";
            this.numericUpDownCant.Size = new System.Drawing.Size(104, 20);
            this.numericUpDownCant.TabIndex = 71;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(23, 464);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 18);
            this.label7.TabIndex = 74;
            this.label7.Text = "Cantidad:";
            // 
            // textBoxCveArt
            // 
            this.textBoxCveArt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCveArt.Location = new System.Drawing.Point(201, 355);
            this.textBoxCveArt.Name = "textBoxCveArt";
            this.textBoxCveArt.Size = new System.Drawing.Size(165, 20);
            this.textBoxCveArt.TabIndex = 68;
            this.textBoxCveArt.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 357);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 18);
            this.label2.TabIndex = 72;
            this.label2.Text = "Clave Articulo:";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(621, 449);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 50);
            this.button3.TabIndex = 78;
            this.button3.TabStop = false;
            this.button3.Text = "CAMBIO";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(515, 449);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 50);
            this.button2.TabIndex = 77;
            this.button2.TabStop = false;
            this.button2.Text = "BAJA";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(403, 449);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 50);
            this.button1.TabIndex = 76;
            this.button1.TabStop = false;
            this.button1.Text = "ALTA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBoxNomArt
            // 
            this.textBoxNomArt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNomArt.Enabled = false;
            this.textBoxNomArt.Location = new System.Drawing.Point(201, 381);
            this.textBoxNomArt.Name = "textBoxNomArt";
            this.textBoxNomArt.Size = new System.Drawing.Size(165, 20);
            this.textBoxNomArt.TabIndex = 79;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 383);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 18);
            this.label1.TabIndex = 80;
            this.label1.Text = "Nombre Articulo:";
            // 
            // textBoxNomProv
            // 
            this.textBoxNomProv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNomProv.Enabled = false;
            this.textBoxNomProv.Location = new System.Drawing.Point(201, 433);
            this.textBoxNomProv.Name = "textBoxNomProv";
            this.textBoxNomProv.Size = new System.Drawing.Size(165, 20);
            this.textBoxNomProv.TabIndex = 81;
            this.textBoxNomProv.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 435);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 18);
            this.label3.TabIndex = 82;
            this.label3.Text = "Nombre Proveedor:";
            // 
            // inventarioTableAdapter1
            // 
            this.inventarioTableAdapter1.ClearBeforeFill = true;
            // 
            // articuloProveedorTableAdapter1
            // 
            this.articuloProveedorTableAdapter1.ClearBeforeFill = true;
            // 
            // articuloTableAdapter1
            // 
            this.articuloTableAdapter1.ClearBeforeFill = true;
            // 
            // proveedorTableAdapter1
            // 
            this.proveedorTableAdapter1.ClearBeforeFill = true;
            // 
            // labelArtProvValido
            // 
            this.labelArtProvValido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelArtProvValido.AutoSize = true;
            this.labelArtProvValido.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelArtProvValido.Location = new System.Drawing.Point(372, 399);
            this.labelArtProvValido.Name = "labelArtProvValido";
            this.labelArtProvValido.Size = new System.Drawing.Size(68, 13);
            this.labelArtProvValido.TabIndex = 83;
            this.labelArtProvValido.Text = "No Existe";
            // 
            // MantenimientoInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 511);
            this.Controls.Add(this.labelArtProvValido);
            this.Controls.Add(this.textBoxNomProv);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxNomArt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxCveProv);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numericUpDownCant);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxCveArt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.labelFecha);
            this.Controls.Add(this.datosInventario);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Name = "MantenimientoInventario";
            this.Text = "MantenimientoInventario";
            this.Load += new System.EventHandler(this.MantenimientoInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datosInventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCant)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView datosInventario;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBoxCveProv;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDownCant;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxCveArt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private PuntoVentaDataSetTableAdapters.InventarioTableAdapter inventarioTableAdapter1;
        private PuntoVentaDataSetTableAdapters.ArticuloProveedorTableAdapter articuloProveedorTableAdapter1;
        private System.Windows.Forms.TextBox textBoxNomArt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNomProv;
        private System.Windows.Forms.Label label3;
        private PuntoVentaDataSetTableAdapters.ArticuloTableAdapter articuloTableAdapter1;
        private PuntoVentaDataSetTableAdapters.ProveedorTableAdapter proveedorTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioArticulo;
        private System.Windows.Forms.Label labelArtProvValido;
    }
}