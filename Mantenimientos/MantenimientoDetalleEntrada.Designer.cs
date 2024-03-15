namespace AbarrotesGenerales.Mantenimientos
{
    partial class MantenimientoDetalleEntrada
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
            this.labelFecha = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBoxIdEnt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.datosEntrada = new System.Windows.Forms.DataGridView();
            this.IdArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostoArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxIdArt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericCosto = new System.Windows.Forms.NumericUpDown();
            this.numericCant = new System.Windows.Forms.NumericUpDown();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.detalleEntradaTableAdapter1 = new AbarrotesGenerales.PuntoVentaDataSetTableAdapters.DetalleEntradaTableAdapter();
            this.textBoxIdProv = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.articuloProveedorTableAdapter1 = new AbarrotesGenerales.PuntoVentaDataSetTableAdapters.ArticuloProveedorTableAdapter();
            this.textBoxNomArt = new System.Windows.Forms.TextBox();
            this.labelNomArt = new System.Windows.Forms.Label();
            this.textBoxNomProv = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.labelArtProvValido = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datosEntrada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCosto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCant)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Bright", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(409, 23);
            this.label6.TabIndex = 22;
            this.label6.Text = "MANTENIMIENTO DETALLE ENTRADA";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Bright", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(276, 24);
            this.label5.TabIndex = 21;
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
            this.label4.TabIndex = 20;
            this.label4.Text = "INSTITUTO TECNOLOGICO DE MEXICO CAMPUS MEXICALI";
            // 
            // labelFecha
            // 
            this.labelFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFecha.AutoSize = true;
            this.labelFecha.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFecha.Location = new System.Drawing.Point(505, 59);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelFecha.Size = new System.Drawing.Size(159, 20);
            this.labelFecha.TabIndex = 23;
            this.labelFecha.Text = "Fecha y hora actual";
            this.labelFecha.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 82);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 51;
            this.button4.TabStop = false;
            this.button4.Text = "ATRAS";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBoxIdEnt
            // 
            this.textBoxIdEnt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxIdEnt.Location = new System.Drawing.Point(296, 142);
            this.textBoxIdEnt.Name = "textBoxIdEnt";
            this.textBoxIdEnt.Size = new System.Drawing.Size(261, 20);
            this.textBoxIdEnt.TabIndex = 0;
            this.textBoxIdEnt.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBoxIdEnt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(118, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 18);
            this.label1.TabIndex = 53;
            this.label1.Text = "Clave entrada:";
            // 
            // datosEntrada
            // 
            this.datosEntrada.AllowUserToAddRows = false;
            this.datosEntrada.AllowUserToDeleteRows = false;
            this.datosEntrada.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datosEntrada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datosEntrada.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdArticulo,
            this.IdProveedor,
            this.NombreArticulo,
            this.CantidadArticulo,
            this.CostoArticulo});
            this.datosEntrada.Location = new System.Drawing.Point(28, 165);
            this.datosEntrada.Name = "datosEntrada";
            this.datosEntrada.ReadOnly = true;
            this.datosEntrada.Size = new System.Drawing.Size(678, 161);
            this.datosEntrada.TabIndex = 54;
            this.datosEntrada.TabStop = false;
            // 
            // IdArticulo
            // 
            this.IdArticulo.HeaderText = "IdArticulo";
            this.IdArticulo.Name = "IdArticulo";
            this.IdArticulo.ReadOnly = true;
            this.IdArticulo.Width = 150;
            // 
            // IdProveedor
            // 
            this.IdProveedor.HeaderText = "IdProveedor";
            this.IdProveedor.Name = "IdProveedor";
            this.IdProveedor.ReadOnly = true;
            this.IdProveedor.Width = 150;
            // 
            // NombreArticulo
            // 
            this.NombreArticulo.HeaderText = "NombreArticulo";
            this.NombreArticulo.Name = "NombreArticulo";
            this.NombreArticulo.ReadOnly = true;
            this.NombreArticulo.Width = 200;
            // 
            // CantidadArticulo
            // 
            this.CantidadArticulo.HeaderText = "CantidadArticulo";
            this.CantidadArticulo.Name = "CantidadArticulo";
            this.CantidadArticulo.ReadOnly = true;
            // 
            // CostoArticulo
            // 
            this.CostoArticulo.HeaderText = "CostoArticulo";
            this.CostoArticulo.Name = "CostoArticulo";
            this.CostoArticulo.ReadOnly = true;
            // 
            // textBoxIdArt
            // 
            this.textBoxIdArt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxIdArt.Location = new System.Drawing.Point(274, 344);
            this.textBoxIdArt.Name = "textBoxIdArt";
            this.textBoxIdArt.Size = new System.Drawing.Size(195, 20);
            this.textBoxIdArt.TabIndex = 1;
            this.textBoxIdArt.TextChanged += new System.EventHandler(this.textBoxIdArt_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(96, 346);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 18);
            this.label2.TabIndex = 56;
            this.label2.Text = "Clave Articulo:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(96, 466);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 18);
            this.label3.TabIndex = 58;
            this.label3.Text = "Costo:                    $";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(96, 492);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 18);
            this.label7.TabIndex = 60;
            this.label7.Text = "Cantidad:";
            // 
            // numericCosto
            // 
            this.numericCosto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericCosto.DecimalPlaces = 2;
            this.numericCosto.Location = new System.Drawing.Point(274, 469);
            this.numericCosto.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            131072});
            this.numericCosto.Name = "numericCosto";
            this.numericCosto.Size = new System.Drawing.Size(112, 20);
            this.numericCosto.TabIndex = 3;
            // 
            // numericCant
            // 
            this.numericCant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericCant.Location = new System.Drawing.Point(274, 494);
            this.numericCant.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericCant.Name = "numericCant";
            this.numericCant.Size = new System.Drawing.Size(0, 20);
            this.numericCant.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(622, 449);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 50);
            this.button3.TabIndex = 65;
            this.button3.TabStop = false;
            this.button3.Text = "CAMBIO";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(516, 449);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 50);
            this.button2.TabIndex = 64;
            this.button2.TabStop = false;
            this.button2.Text = "BAJA";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(404, 449);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 50);
            this.button1.TabIndex = 63;
            this.button1.TabStop = false;
            this.button1.Text = "ALTA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // detalleEntradaTableAdapter1
            // 
            this.detalleEntradaTableAdapter1.ClearBeforeFill = true;
            // 
            // textBoxIdProv
            // 
            this.textBoxIdProv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxIdProv.Location = new System.Drawing.Point(274, 396);
            this.textBoxIdProv.Name = "textBoxIdProv";
            this.textBoxIdProv.Size = new System.Drawing.Size(195, 20);
            this.textBoxIdProv.TabIndex = 2;
            this.textBoxIdProv.TextChanged += new System.EventHandler(this.textBoxIdProv_TextChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(96, 398);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 18);
            this.label8.TabIndex = 67;
            this.label8.Text = "Clave Proveedor:";
            // 
            // articuloProveedorTableAdapter1
            // 
            this.articuloProveedorTableAdapter1.ClearBeforeFill = true;
            // 
            // textBoxNomArt
            // 
            this.textBoxNomArt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNomArt.Enabled = false;
            this.textBoxNomArt.Location = new System.Drawing.Point(274, 370);
            this.textBoxNomArt.Name = "textBoxNomArt";
            this.textBoxNomArt.Size = new System.Drawing.Size(287, 20);
            this.textBoxNomArt.TabIndex = 68;
            // 
            // labelNomArt
            // 
            this.labelNomArt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNomArt.AutoSize = true;
            this.labelNomArt.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomArt.Location = new System.Drawing.Point(96, 372);
            this.labelNomArt.Name = "labelNomArt";
            this.labelNomArt.Size = new System.Drawing.Size(146, 18);
            this.labelNomArt.TabIndex = 69;
            this.labelNomArt.Text = "Nombre Articulo:";
            // 
            // textBoxNomProv
            // 
            this.textBoxNomProv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNomProv.Enabled = false;
            this.textBoxNomProv.Location = new System.Drawing.Point(274, 422);
            this.textBoxNomProv.Name = "textBoxNomProv";
            this.textBoxNomProv.Size = new System.Drawing.Size(287, 20);
            this.textBoxNomProv.TabIndex = 70;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(96, 424);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(164, 18);
            this.label10.TabIndex = 71;
            this.label10.Text = "Nombre Proveedor:";
            // 
            // labelArtProvValido
            // 
            this.labelArtProvValido.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelArtProvValido.AutoSize = true;
            this.labelArtProvValido.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelArtProvValido.Location = new System.Drawing.Point(201, 450);
            this.labelArtProvValido.Name = "labelArtProvValido";
            this.labelArtProvValido.Size = new System.Drawing.Size(91, 13);
            this.labelArtProvValido.TabIndex = 72;
            this.labelArtProvValido.Text = "No Coinciden";
            // 
            // MantenimientoDetalleEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 511);
            this.Controls.Add(this.labelArtProvValido);
            this.Controls.Add(this.textBoxNomProv);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxNomArt);
            this.Controls.Add(this.labelNomArt);
            this.Controls.Add(this.textBoxIdProv);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numericCant);
            this.Controls.Add(this.numericCosto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxIdArt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.datosEntrada);
            this.Controls.Add(this.textBoxIdEnt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.labelFecha);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Name = "MantenimientoDetalleEntrada";
            this.Text = "MantenimientoDetalleEntrada";
            this.Load += new System.EventHandler(this.MantenimientoDetalleEntrada_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datosEntrada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCosto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCant)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBoxIdEnt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView datosEntrada;
        private System.Windows.Forms.TextBox textBoxIdArt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericCosto;
        private System.Windows.Forms.NumericUpDown numericCant;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private PuntoVentaDataSetTableAdapters.DetalleEntradaTableAdapter detalleEntradaTableAdapter1;
        private System.Windows.Forms.TextBox textBoxIdProv;
        private System.Windows.Forms.Label label8;
        private PuntoVentaDataSetTableAdapters.ArticuloProveedorTableAdapter articuloProveedorTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostoArticulo;
        private System.Windows.Forms.TextBox textBoxNomArt;
        private System.Windows.Forms.Label labelNomArt;
        private System.Windows.Forms.TextBox textBoxNomProv;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelArtProvValido;
    }
}