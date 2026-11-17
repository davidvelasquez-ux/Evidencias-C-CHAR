namespace Tarea;

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
        components = new System.ComponentModel.Container();
        lblValor = new Label();
        txtValor = new TextBox();
        lblOrigen = new Label();
        cboOrigen = new ComboBox();
        lblDestino = new Label();
        cboDestino = new ComboBox();
        btnConvertir = new Button();
        lblResultado = new Label();
        errorProvider1 = new ErrorProvider(components);
        ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
        SuspendLayout();

        lblValor.AutoSize = true;
        lblValor.Location = new Point(20, 25);
        lblValor.Text = "Valor:";

        txtValor.Location = new Point(110, 22);
        txtValor.Name = "txtValor";
        txtValor.Size = new Size(160, 23);

        lblOrigen.AutoSize = true;
        lblOrigen.Location = new Point(20, 65);
        lblOrigen.Text = "De:";

        cboOrigen.Location = new Point(110, 62);
        cboOrigen.Name = "cboOrigen";
        cboOrigen.Size = new Size(160, 23);

        lblDestino.AutoSize = true;
        lblDestino.Location = new Point(20, 105);
        lblDestino.Text = "A:";

        cboDestino.Location = new Point(110, 102);
        cboDestino.Name = "cboDestino";
        cboDestino.Size = new Size(160, 23);

        btnConvertir.Location = new Point(110, 145);
        btnConvertir.Name = "btnConvertir";
        btnConvertir.Size = new Size(160, 30);
        btnConvertir.Text = "Convertir";
        btnConvertir.Click += btnConvertir_Click;

        lblResultado.AutoSize = true;
        lblResultado.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblResultado.Location = new Point(20, 195);
        lblResultado.Name = "lblResultado";
        lblResultado.Text = "Resultado:";

        errorProvider1.ContainerControl = this;

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(360, 240);
        Controls.Add(lblValor);
        Controls.Add(txtValor);
        Controls.Add(lblOrigen);
        Controls.Add(cboOrigen);
        Controls.Add(lblDestino);
        Controls.Add(cboDestino);
        Controls.Add(btnConvertir);
        Controls.Add(lblResultado);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Conversor de temperatura";
        ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblValor;
    private TextBox txtValor;
    private Label lblOrigen;
    private ComboBox cboOrigen;
    private Label lblDestino;
    private ComboBox cboDestino;
    private Button btnConvertir;
    private Label lblResultado;
    private ErrorProvider errorProvider1;
}
