namespace POS_DePrisa
{
    partial class FrmPrincipal
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
            this.tableLayoutBackGround = new System.Windows.Forms.TableLayoutPanel();
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.panelShowData = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.panelExitButton = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnFacturas = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnConfiguracion = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tableLayoutBackGround.SuspendLayout();
            this.panelSuperior.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutMenu.SuspendLayout();
            this.panelExitButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutBackGround
            // 
            this.tableLayoutBackGround.ColumnCount = 1;
            this.tableLayoutBackGround.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1281F));
            this.tableLayoutBackGround.Controls.Add(this.panelSuperior, 0, 0);
            this.tableLayoutBackGround.Controls.Add(this.panelShowData, 0, 2);
            this.tableLayoutBackGround.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutBackGround.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutBackGround.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutBackGround.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutBackGround.Name = "tableLayoutBackGround";
            this.tableLayoutBackGround.RowCount = 3;
            this.tableLayoutBackGround.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutBackGround.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutBackGround.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutBackGround.Size = new System.Drawing.Size(1281, 590);
            this.tableLayoutBackGround.TabIndex = 0;
            this.tableLayoutBackGround.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutBackGround_Paint);
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(81)))), ((int)(((byte)(161)))));
            this.panelSuperior.Controls.Add(this.pictureBox1);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Margin = new System.Windows.Forms.Padding(0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(1281, 80);
            this.panelSuperior.TabIndex = 0;
            // 
            // panelShowData
            // 
            this.panelShowData.BackColor = System.Drawing.Color.White;
            this.panelShowData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelShowData.Location = new System.Drawing.Point(0, 150);
            this.panelShowData.Margin = new System.Windows.Forms.Padding(0);
            this.panelShowData.Name = "panelShowData";
            this.panelShowData.Size = new System.Drawing.Size(1281, 440);
            this.panelShowData.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.11765F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.882353F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutMenu, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelExitButton, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 83);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1275, 64);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // flowLayoutMenu
            // 
            this.flowLayoutMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.flowLayoutMenu.Controls.Add(this.btnFacturas);
            this.flowLayoutMenu.Controls.Add(this.btnProductos);
            this.flowLayoutMenu.Controls.Add(this.btnReportes);
            this.flowLayoutMenu.Controls.Add(this.btnUsuarios);
            this.flowLayoutMenu.Controls.Add(this.btnConfiguracion);
            this.flowLayoutMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutMenu.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutMenu.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutMenu.Name = "flowLayoutMenu";
            this.flowLayoutMenu.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.flowLayoutMenu.Size = new System.Drawing.Size(1149, 64);
            this.flowLayoutMenu.TabIndex = 3;
            // 
            // panelExitButton
            // 
            this.panelExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelExitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.panelExitButton.Controls.Add(this.btnSalir);
            this.panelExitButton.Location = new System.Drawing.Point(1152, 3);
            this.panelExitButton.Name = "panelExitButton";
            this.panelExitButton.Size = new System.Drawing.Size(120, 58);
            this.panelExitButton.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POS_DePrisa.Properties.Resources.logoPrisaBlueHorizontal;
            this.pictureBox1.Location = new System.Drawing.Point(10, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(183, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnFacturas
            // 
            this.btnFacturas.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturas.Image = global::POS_DePrisa.Properties.Resources.iconFactura32;
            this.btnFacturas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFacturas.Location = new System.Drawing.Point(10, 15);
            this.btnFacturas.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.btnFacturas.Name = "btnFacturas";
            this.btnFacturas.Size = new System.Drawing.Size(111, 38);
            this.btnFacturas.TabIndex = 0;
            this.btnFacturas.Text = "Facturas";
            this.btnFacturas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFacturas.UseVisualStyleBackColor = true;
            this.btnFacturas.Click += new System.EventHandler(this.btnFacturas_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductos.Image = global::POS_DePrisa.Properties.Resources.iconOficina32;
            this.btnProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.Location = new System.Drawing.Point(134, 15);
            this.btnProductos.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(122, 38);
            this.btnProductos.TabIndex = 1;
            this.btnProductos.Text = "Productos";
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.Image = global::POS_DePrisa.Properties.Resources.iconPdf32;
            this.btnReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportes.Location = new System.Drawing.Point(269, 15);
            this.btnReportes.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(108, 38);
            this.btnReportes.TabIndex = 3;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReportes.UseVisualStyleBackColor = true;
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.Image = global::POS_DePrisa.Properties.Resources.iconUsuario32;
            this.btnUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.Location = new System.Drawing.Point(390, 15);
            this.btnUsuarios.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(108, 38);
            this.btnUsuarios.TabIndex = 2;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnConfiguracion
            // 
            this.btnConfiguracion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.btnConfiguracion.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfiguracion.Image = global::POS_DePrisa.Properties.Resources.iconConfiguracion32;
            this.btnConfiguracion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfiguracion.Location = new System.Drawing.Point(511, 15);
            this.btnConfiguracion.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.Size = new System.Drawing.Size(147, 38);
            this.btnConfiguracion.TabIndex = 4;
            this.btnConfiguracion.Text = "Configuración";
            this.btnConfiguracion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfiguracion.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::POS_DePrisa.Properties.Resources.iconClose32;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(32, 12);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(82, 38);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click_1);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 590);
            this.Controls.Add(this.tableLayoutBackGround);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrincipal";
            this.Text = "Software Caminando de Prisa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.tableLayoutBackGround.ResumeLayout(false);
            this.panelSuperior.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutMenu.ResumeLayout(false);
            this.panelExitButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutBackGround;
        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Panel panelShowData;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutMenu;
        private System.Windows.Forms.Button btnFacturas;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnConfiguracion;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panelExitButton;
    }
}

