namespace Reto;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitular = new Label();
        lblSaldo = new Label();
        lblMonto = new Label();
        nudMonto = new NumericUpDown();
        btnDepositar = new Button();
        btnRetirar = new Button();
        btnTransferir = new Button();
        lblMovimientos = new Label();
        lstMovimientos = new ListBox();
        ((System.ComponentModel.ISupportInitialize)nudMonto).BeginInit();
        SuspendLayout();

        lblTitular.AutoSize = true;
        lblTitular.Font = new Font("Segoe UI", 11F);
        lblTitular.Location = new Point(20, 15);
        lblTitular.Name = "lblTitular";
        lblTitular.Text = "Titular:";

        lblSaldo.AutoSize = true;
        lblSaldo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblSaldo.Location = new Point(20, 45);
        lblSaldo.Name = "lblSaldo";
        lblSaldo.Text = "Saldo:";

        lblMonto.AutoSize = true;
        lblMonto.Location = new Point(20, 95);
        lblMonto.Name = "lblMonto";
        lblMonto.Text = "Monto:";

        nudMonto.Location = new Point(75, 92);
        nudMonto.Name = "nudMonto";
        nudMonto.Size = new Size(150, 23);
        nudMonto.Maximum = 100000000;
        nudMonto.Increment = 10000;
        nudMonto.ThousandsSeparator = true;

        btnDepositar.Location = new Point(20, 130);
        btnDepositar.Name = "btnDepositar";
        btnDepositar.Size = new Size(100, 30);
        btnDepositar.Text = "Depositar";
        btnDepositar.Click += btnDepositar_Click;

        btnRetirar.Location = new Point(130, 130);
        btnRetirar.Name = "btnRetirar";
        btnRetirar.Size = new Size(100, 30);
        btnRetirar.Text = "Retirar";
        btnRetirar.Click += btnRetirar_Click;

        btnTransferir.Location = new Point(240, 130);
        btnTransferir.Name = "btnTransferir";
        btnTransferir.Size = new Size(100, 30);
        btnTransferir.Text = "Transferir";
        btnTransferir.Click += btnTransferir_Click;

        lblMovimientos.AutoSize = true;
        lblMovimientos.Location = new Point(20, 175);
        lblMovimientos.Name = "lblMovimientos";
        lblMovimientos.Text = "Movimientos (hora | tipo | valor):";

        lstMovimientos.FormattingEnabled = true;
        lstMovimientos.ItemHeight = 15;
        lstMovimientos.Location = new Point(20, 195);
        lstMovimientos.Name = "lstMovimientos";
        lstMovimientos.Size = new Size(420, 169);

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(464, 385);
        Controls.Add(lblTitular);
        Controls.Add(lblSaldo);
        Controls.Add(lblMonto);
        Controls.Add(nudMonto);
        Controls.Add(btnDepositar);
        Controls.Add(btnRetirar);
        Controls.Add(btnTransferir);
        Controls.Add(lblMovimientos);
        Controls.Add(lstMovimientos);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Reto - Cuenta Bancaria";
        ((System.ComponentModel.ISupportInitialize)nudMonto).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitular;
    private Label lblSaldo;
    private Label lblMonto;
    private NumericUpDown nudMonto;
    private Button btnDepositar;
    private Button btnRetirar;
    private Button btnTransferir;
    private Label lblMovimientos;
    private ListBox lstMovimientos;
}
