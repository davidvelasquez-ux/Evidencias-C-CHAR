namespace Reto;

// Copia de tu clase CuentaBancaria (reemplaza este archivo por la tuya si ya la tienes).
// Las operaciones fallidas lanzan InvalidOperationException con un mensaje claro.
public class CuentaBancaria
{
    private const decimal Multiplo = 10000m;

    public string Titular { get; }
    public string Numero { get; }
    public decimal Saldo { get; private set; }

    public CuentaBancaria(string titular, string numero, decimal saldoInicial)
    {
        Titular = titular;
        Numero = numero;
        Saldo = saldoInicial;
    }

    public void Depositar(decimal monto)
    {
        Validar(monto);
        Saldo += monto;
    }

    public void Retirar(decimal monto)
    {
        Validar(monto);
        if (monto > Saldo)
            throw new InvalidOperationException("Saldo insuficiente para realizar el retiro.");
        Saldo -= monto;
    }

    public void Transferir(CuentaBancaria destino, decimal monto)
    {
        Retirar(monto);       // valida múltiplo y saldo; si falla, no se deposita nada
        destino.Depositar(monto);
    }

    private static void Validar(decimal monto)
    {
        if (monto <= 0)
            throw new InvalidOperationException("El monto debe ser mayor que cero.");
        if (monto % Multiplo != 0)
            throw new InvalidOperationException("El monto debe ser múltiplo de $10.000.");
    }
}
