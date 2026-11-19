namespace Inventario.Escritorio
{
    partial class FormPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            dgvProductos = new DataGridView();
            lblCantidad = new Label();
            nudCantidad = new NumericUpDown();
            btnVender = new Button();
            btnAgregarStock = new Button();
            btnAgregar = new Button();
            btnEliminar = new Button();
            lblValor = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            SuspendLayout();
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(12, 16);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(158, 15);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar por nombre o código:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(190, 12);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(300, 23);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(12, 48);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(836, 320);
            dgvProductos.TabIndex = 2;
            dgvProductos.DataBindingComplete += dgvProductos_DataBindingComplete;
            // 
            // lblCantidad
            // 
            lblCantidad.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(12, 388);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(58, 15);
            lblCantidad.TabIndex = 3;
            lblCantidad.Text = "Cantidad:";
            // 
            // nudCantidad
            // 
            nudCantidad.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            nudCantidad.Location = new Point(80, 384);
            nudCantidad.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(70, 23);
            nudCantidad.TabIndex = 4;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnVender
            // 
            btnVender.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnVender.Location = new Point(160, 380);
            btnVender.Name = "btnVender";
            btnVender.Size = new Size(90, 32);
            btnVender.TabIndex = 5;
            btnVender.Text = "Vender";
            btnVender.UseVisualStyleBackColor = true;
            btnVender.Click += btnVender_Click;
            // 
            // btnAgregarStock
            // 
            btnAgregarStock.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAgregarStock.Location = new Point(258, 380);
            btnAgregarStock.Name = "btnAgregarStock";
            btnAgregarStock.Size = new Size(120, 32);
            btnAgregarStock.TabIndex = 6;
            btnAgregarStock.Text = "Agregar stock";
            btnAgregarStock.UseVisualStyleBackColor = true;
            btnAgregarStock.Click += btnAgregarStock_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAgregar.Location = new Point(12, 424);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(140, 32);
            btnAgregar.TabIndex = 7;
            btnAgregar.Text = "Nuevo producto";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEliminar.Location = new Point(160, 424);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(90, 32);
            btnEliminar.TabIndex = 8;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // lblValor
            // 
            lblValor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblValor.AutoSize = true;
            lblValor.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblValor.Location = new Point(12, 476);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(190, 21);
            lblValor.TabIndex = 10;
            lblValor.Text = "Valor del inventario: $0";
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(860, 516);
            Controls.Add(lblValor);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
            Controls.Add(btnAgregarStock);
            Controls.Add(btnVender);
            Controls.Add(nudCantidad);
            Controls.Add(lblCantidad);
            Controls.Add(dgvProductos);
            Controls.Add(txtBuscar);
            Controls.Add(lblBuscar);
            MinimumSize = new Size(560, 420);
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inventario";
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBuscar;
        private TextBox txtBuscar;
        private DataGridView dgvProductos;
        private Label lblCantidad;
        private NumericUpDown nudCantidad;
        private Button btnVender;
        private Button btnAgregarStock;
        private Button btnAgregar;
        private Button btnEliminar;
        private Label lblValor;
    }
}

