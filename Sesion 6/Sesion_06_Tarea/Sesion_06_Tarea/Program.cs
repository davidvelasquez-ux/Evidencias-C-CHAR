using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

CultureInfo.CurrentCulture = new CultureInfo("es-CO");

List<Empleado> nomina =
[
    new EmpleadoPlanta("Melenie Montoya", "1001", 3_200_000m, 6),
    new EmpleadoPlanta("Luis Enrrique", "1002", 2_800_000m, 2),
    new EmpleadoPorHoras("Patricia Rojas", "1003", 170, 18_000m),
    new EmpleadoPorHoras("Jhontan Hernández", "1004", 120, 18_000m),
    new Contratista("Sofía Sanchez", "1005", 4_000_000m)
];

Console.WriteLine("=== PAGO DE CADA EMPLEADO ===");
foreach (Empleado e in nomina)
    Console.WriteLine(e);   // polimorfismo: ToString() y CalcularSalario() de cada hija

decimal total = nomina.Sum(e => e.CalcularSalario());
Console.WriteLine($"\nTOTAL NÓMINA: {total:C0}");
Console.WriteLine(total == 15_070_000m ? "✔ El total coincide con $15.070.000" : "✘ El total NO coincide");

var mayor = nomina.MaxBy(e => e.CalcularSalario())!;
Console.WriteLine($"\nMAYOR PAGO: {mayor.Nombre} -> {mayor.CalcularSalario():C0}");

Console.WriteLine("\n=== TOTAL POR TIPO ===");
foreach (var grupo in nomina.GroupBy(e => e.Tipo))
    Console.WriteLine($"{grupo.Key,-18} {grupo.Sum(e => e.CalcularSalario()),15:C0}");

decimal totalBonos = nomina.OfType<IBonificable>().Sum(b => b.CalcularBono());
Console.WriteLine($"\nTOTAL DE BONOS: {totalBonos:C0}");

public abstract class Empleado
{
    public string Nombre { get; }
    public string Documento { get; }

    protected Empleado(string nombre, string documento)
    {
        Nombre = nombre;
        Documento = documento;
    }

    public virtual string Tipo => "Empleado";

    public abstract decimal CalcularSalario();

    public override string ToString() =>
        $"{Tipo,-18} {Nombre,-12} ({Documento}) -> {CalcularSalario():C0}";
}

public interface IBonificable
{
    decimal CalcularBono();
}

public class EmpleadoPlanta : Empleado, IBonificable
{
    public decimal SalarioMensual { get; }
    public int AniosAntiguedad { get; }

    public EmpleadoPlanta(string nombre, string documento, decimal salarioMensual, int aniosAntiguedad)
        : base(nombre, documento)
    {
        SalarioMensual = salarioMensual;
        AniosAntiguedad = aniosAntiguedad;
    }

    public override string Tipo => "Empleado de planta";

    // 5 % de bonificación con 5 años o más
    public decimal CalcularBono() => AniosAntiguedad >= 5 ? SalarioMensual * 0.05m : 0m;

    public override decimal CalcularSalario() => SalarioMensual + CalcularBono();
}

public class EmpleadoPorHoras : Empleado
{
    private const int HorasNormales = 160;

    public int Horas { get; }
    public decimal ValorHora { get; }

    public EmpleadoPorHoras(string nombre, string documento, int horas, decimal valorHora)
        : base(nombre, documento)
    {
        Horas = horas;
        ValorHora = valorHora;
    }

    public override string Tipo => "Empleado por horas";

    // Las horas por encima de 160 se pagan a 1,5 veces
    public override decimal CalcularSalario()
    {
        int normales = Math.Min(Horas, HorasNormales);
        int extras = Math.Max(0, Horas - HorasNormales);
        return normales * ValorHora + extras * ValorHora * 1.5m;
    }
}

public class Contratista : Empleado
{
    public decimal ValorContrato { get; }

    public Contratista(string nombre, string documento, decimal valorContrato)
        : base(nombre, documento)
    {
        ValorContrato = valorContrato;
    }

    public override string Tipo => "Contratista";

    // Valor del contrato menos 10 % de retención
    public override decimal CalcularSalario() => ValorContrato * 0.90m;
}