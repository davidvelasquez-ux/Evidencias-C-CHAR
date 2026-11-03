using System;
using System.Collections.Generic;
using System.Globalization;

CultureInfo.CurrentCulture = new CultureInfo("es-CO");

var procesador = new ProcesadorPagos();

var metodos = new List<(IMetodoPago Metodo, decimal Monto)>
{
    (new PagoEfectivo(), 150_000m),
    (new PagoTarjeta("1234567812345678"), 500_000m),
    (new PagoTarjeta("1234"), 500_000m),            // número inválido
    (new PagoBilletera(), 1_500_000m),
    (new PagoBilletera(), 2_500_000m)               // supera el máximo
};

Console.WriteLine("=== COBROS ===");
foreach (var (metodo, monto) in metodos)
    procesador.Cobrar(metodo, monto);

Console.WriteLine("\n=== DEVOLUCIONES ===");
procesador.Devolver(new PagoEfectivo(), 150_000m);
procesador.Devolver(new PagoTarjeta("1234567812345678"), 500_000m);
procesador.Devolver(new PagoBilletera(), 1_500_000m);

public interface IMetodoPago
{
    string Nombre { get; }
    decimal CalcularComision(decimal monto);
    bool Validar(decimal monto);
}

public interface IReembolsable
{
    void Reembolsar(decimal monto);
}

// Comisión 0 %, no reembolsable (no implementa IReembolsable)
public class PagoEfectivo : IMetodoPago
{
    public string Nombre => "Efectivo";

    public decimal CalcularComision(decimal monto) => 0m;

    public bool Validar(decimal monto) => monto > 0;
}


// Comisión 3 %, número de 16 dígitos, reembolsable
public class PagoTarjeta : IMetodoPago, IReembolsable
{
    private readonly string _numero;

    public PagoTarjeta(string numero)
    {
        _numero = numero ?? string.Empty;
    }

    public string Nombre => "Tarjeta";

    public decimal CalcularComision(decimal monto) => monto * 0.03m;

    public bool Validar(decimal monto) =>
        monto > 0 && _numero.Length == 16 && _numero.All(char.IsDigit);

    public void Reembolsar(decimal monto)
    {
        Console.WriteLine($"   [Tarjeta] Reembolso de {monto:C0} a la tarjeta terminada en {_numero[^4..]}.");
    }
}



// Comisión 1 %, máximo $2.000.000, reembolsable
public class PagoBilletera : IMetodoPago, IReembolsable
{
    private const decimal Maximo = 2_000_000m;

    public string Nombre => "Billetera";

    public decimal CalcularComision(decimal monto) => monto * 0.01m;

    public bool Validar(decimal monto) => monto > 0 && monto <= Maximo;

    public void Reembolsar(decimal monto)
    {
        Console.WriteLine($"   [Billetera] Reembolso de {monto:C0} a la billetera.");
    }
}


// Solo conoce interfaces, nunca las clases concretas
public class ProcesadorPagos
{
    public bool Cobrar(IMetodoPago metodo, decimal monto)
    {
        if (!metodo.Validar(monto))
        {
            Console.WriteLine($"   [{metodo.Nombre}] Cobro rechazado: monto o datos inválidos ({monto:C0}).");
            return false;
        }

        decimal comision = metodo.CalcularComision(monto);
        Console.WriteLine($"   [{metodo.Nombre}] Cobro aprobado: {monto:C0} + comisión {comision:C0} = {monto + comision:C0}");
        return true;
    }

    public bool Devolver(IMetodoPago metodo, decimal monto)
    {
        if (metodo is IReembolsable reembolsable)
        {
            reembolsable.Reembolsar(monto);
            return true;
        }

        Console.WriteLine($"   [{metodo.Nombre}] No admite reembolsos.");
        return false;
    }
}