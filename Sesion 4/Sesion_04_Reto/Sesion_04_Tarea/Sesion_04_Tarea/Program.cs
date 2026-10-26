using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AnalisisVentas
{
    // Una venta: producto, ciudad, unidades y precio por unidad
    record Venta(string Producto, string Ciudad, int Unidades, decimal PrecioUnitario)
    {
        public decimal Ingreso => Unidades * PrecioUnitario;
    }

    class Program
    {
        static void Main()
        {
            var co = new CultureInfo("es-CO");

            // DATOS DE EJEMPLO: reemplázalos por la lista de tu guía
            var ventas = new List<Venta>
            {
                new("Portátil", "Bogotá",   2, 2_500_000m),
                new("Celular",  "Medellín", 3, 1_200_000m),
                new("Monitor",  "Cali",     2,   800_000m),
                new("Teclado",  "Bogotá",  10,   100_000m),
                new("Mouse",    "Medellín",20,    50_000m),
                new("Portátil", "Cali",     1, 2_500_000m),
                new("Celular",  "Bogotá",   2, 1_200_000m),
                new("Monitor",  "Medellín", 3,   800_000m),
                new("Teclado",  "Cali",     8,   100_000m),
                new("Mouse",    "Bogotá",  30,    50_000m),
            };

            // 1. Total vendido y promedio por venta
            decimal total = ventas.Sum(v => v.Ingreso);
            decimal promedio = ventas.Average(v => v.Ingreso);

            Console.WriteLine($"Total vendido:      {total.ToString("C0", co)}");
            Console.WriteLine($"Promedio por venta: {promedio.ToString("C0", co)}");

            // 2. Ventas por ciudad, de mayor a menor (GroupBy)
            Console.WriteLine("\nVentas por ciudad (mayor a menor):");
            var porCiudad = ventas
                .GroupBy(v => v.Ciudad)
                .Select(g => new { Ciudad = g.Key, Total = g.Sum(v => v.Ingreso) })
                .OrderByDescending(x => x.Total);

            foreach (var c in porCiudad)
                Console.WriteLine($"  {c.Ciudad,-10} {c.Total.ToString("C0", co)}");

            // 3. Top 3 de productos por ingresos (GroupBy)
            Console.WriteLine("\nTop 3 productos por ingresos:");
            var top3 = ventas
                .GroupBy(v => v.Producto)
                .Select(g => new { Producto = g.Key, Ingresos = g.Sum(v => v.Ingreso) })
                .OrderByDescending(x => x.Ingresos)
                .Take(3)
                .ToList();

            for (int i = 0; i < top3.Count; i++)
                Console.WriteLine($"  {i + 1}. {top3[i].Producto,-10} {top3[i].Ingresos.ToString("C0", co)}");

            // 4. Producto más vendido en unidades
            var masVendido = ventas
                .GroupBy(v => v.Producto)
                .Select(g => new { Producto = g.Key, Unidades = g.Sum(v => v.Unidades) })
                .OrderByDescending(x => x.Unidades)
                .First();

            Console.WriteLine($"\nMás vendido en unidades: {masVendido.Producto} ({masVendido.Unidades} unidades)");
        }
    }
}