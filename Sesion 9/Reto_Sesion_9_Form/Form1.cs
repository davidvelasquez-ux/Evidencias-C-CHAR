namespace Reto;

public partial class Form1 : Form
{
    private readonly CuentaBancaria _cuenta = new("Tu Nombre", "001-123", 500000m);
    private readonly CuentaBancaria _destino = new("Cuenta destino", "002-456", 0m);

    public Form1()
    {
        InitializeComponent();
        ActualizarSaldo();
    }

    private void ActualizarSaldo()
    {
        lblTitular.Text = $"Titular: {_cuenta.Titular}  ({_cuenta.Numero})";
        lblSaldo.Text = $"Saldo: {_cuenta.Saldo:C0}";
    }

    private void Registrar(string tipo, decimal monto)
    {
        string texto = $"{DateTime.Now:HH:mm:ss}  |  {tipo}  |  {monto:C0}";
        lstMovimientos.Items.Insert(0, texto);   // el más reciente arriba
    }

    private void Ejecutar(string tipo, Action<decimal> operacion)
    {
        decimal monto = nudMonto.Value;
        try
        {
            operacion(monto);
            Registrar(tipo, monto);
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(ex.Message, $"No se pudo {tipo.ToLower()}",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        ActualizarSaldo();
    }

    private void btnDepositar_Click(object sender, EventArgs e) =>
        Ejecutar("Depósito", _cuenta.Depositar);

    private void btnRetirar_Click(object sender, EventArgs e) =>
        Ejecutar("Retiro", _cuenta.Retirar);

    private void btnTransferir_Click(object sender, EventArgs e) =>
        Ejecutar("Transferencia", m => _cuenta.Transferir(_destino, m));
}
