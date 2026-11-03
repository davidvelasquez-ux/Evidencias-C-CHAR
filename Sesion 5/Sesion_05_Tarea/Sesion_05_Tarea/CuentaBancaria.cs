using System;

public class CuentaBancaria
{
    public string Titular { get; private set; }
    public string Numero { get; private set; }
    public decimal Saldo { get; private set; }

    public CuentaBancaria(string titular, string numero, decimal saldoInicial = 0)
    {
        if (string.IsNullOrWhiteSpace(titular))
            throw new ArgumentException("El titular es obligatorio.");
        if (string.IsNullOrWhiteSpace(numero))
            throw new ArgumentException("El número de cuenta es obligatorio.");
        if (saldoInicial < 0)
            throw new ArgumentException("El saldo inicial no puede ser negativo.");

        Titular = titular.Trim();
        Numero = numero.Trim();
        Saldo = saldoInicial;
    }

    public bool Depositar(decimal monto)
    {
        if (monto <= 0) return false;
        Saldo += monto;
        return true;
    }

    public bool Retirar(decimal monto)
    {
        if (monto <= 0 || monto > Saldo) return false;
        Saldo -= monto;
        return true;
    }

    public bool Transferir(CuentaBancaria destino, decimal monto)
    {
        if (destino == null || ReferenceEquals(destino, this)) return false;
        if (!Retirar(monto)) return false;
        destino.Depositar(monto);
        return true;
    }
}