namespace Inventario.Escritorio
{
    partial class FormReportes
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
            lblMasValiosos = new Label();
            dgvMasValiosos = new DataGridView();
            lblStockBajo = new Label();
            dgvStockBajo = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvMasValiosos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvStockBajo).BeginInit();
            SuspendLayout();
            // 
            // lblMasValiosos
            // 
            lblMasValiosos.AutoSize = true;
            lblMasValiosos.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMasValiosos.Location = new Point(12, 12);
            lblMasValiosos.Name = "lblMasValiosos";
            lblMasValiosos.Size = new Size(278, 19);
            lblMasValiosos.TabIndex = 0;
            lblMasValiosos.Text = "Productos más valiosos (precio × stock)";
            // 
            // dgvMasValiosos
            // 
            dgvMasValiosos.AllowUserToAddRows = false;
            dgvMasValiosos.AllowUserToDeleteRows = false;
            dgvMasValiosos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvMasValiosos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMasValiosos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMasValiosos.Location = new Point(12, 38);
            dgvMasValiosos.Name = "dgvMasValiosos";
            dgvMasValiosos.ReadOnly = true;
            dgvMasValiosos.RowHeadersVisible = false;
            dgvMasValiosos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMasValiosos.Size = new Size(676, 200);
            dgvMasValiosos.TabIndex = 1;
            // 
            // lblStockBajo
            // 
            lblStockBajo.AutoSize = true;
            lblStockBajo.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStockBajo.Location = new Point(12, 254);
            lblStockBajo.Name = "lblStockBajo";
            lblStockBajo.Size = new Size(110, 19);
            lblStockBajo.TabIndex = 2;
            lblStockBajo.Text = "Productos con stock bajo";
            // 
            // dgvStockBajo
            // 
            dgvStockBajo.AllowUserToAddRows = false;
            dgvStockBajo.AllowUserToDeleteRows = false;
            dgvStockBajo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvStockBajo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStockBajo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStockBajo.Location = new Point(12, 280);
            dgvStockBajo.Name = "dgvStockBajo";
            dgvStockBajo.ReadOnly = true;
            dgvStockBajo.RowHeadersVisible = false;
            dgvStockBajo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStockBajo.Size = new Size(676, 228);
            dgvStockBajo.TabIndex = 3;
            // 
            // FormReportes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 520);
            Controls.Add(dgvStockBajo);
            Controls.Add(lblStockBajo);
            Controls.Add(dgvMasValiosos);
            Controls.Add(lblMasValiosos);
            MinimumSize = new Size(500, 450);
            Name = "FormReportes";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Reportes";
            ((System.ComponentModel.ISupportInitialize)dgvMasValiosos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvStockBajo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMasValiosos;
        private DataGridView dgvMasValiosos;
        private Label lblStockBajo;
        private DataGridView dgvStockBajo;
    }
}
