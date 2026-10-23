using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace GestorAprendices
{
    class Program
    {
        // nombre -> lista de notas (ignora mayúsculas/minúsculas en el nombre)
        static readonly Dictionary<string, List<double>> aprendices =
            new Dictionary<string, List<double>>(StringComparer.OrdinalIgnoreCase);

        const double NOTA_MIN = 0.0;
        const double NOTA_MAX = 5.0;
        const double NOTA_APROBACION = 3.0;

        static void Main()
        {
            bool salir = false;

            while (!salir)
            {
                MostrarMenu();
                string opcion = Console.ReadLine()?.Trim() ?? "";
                Console.WriteLine();

                switch (opcion)
                {
                    case "1": RegistrarAprendiz(); break;
                    case "2": AgregarNota(); break;
                    case "3": ListarConPromedio(); break;
                    case "4": RankingPorPromedio(); break;
                    case "5": MejorAprendizYAprobados(); break;
                    case "6": EliminarAprendiz(); break;
                    case "7": salir = true; Console.WriteLine("¡Hasta pronto!"); break;
                    default: Console.WriteLine("Opción no válida."); break;
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresione Enter para continuar...");
                    Console.ReadLine();
                }
            }
        }

        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("===== GESTOR DE APRENDICES =====");
            Console.WriteLine("1. Registrar aprendiz");
            Console.WriteLine("2. Agregar nota (0 a 5)");
            Console.WriteLine("3. Listar con promedio y juicio (A/D)");
            Console.WriteLine("4. Ranking por promedio");
            Console.WriteLine("5. Mejor aprendiz y cantidad de aprobados");
            Console.WriteLine("6. Eliminar aprendiz");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione una opción: ");
        }

        // ---------- 1. Registrar ----------
        static void RegistrarAprendiz()
        {
            Console.Write("Nombre del aprendiz: ");
            string nombre = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("El nombre no puede estar vacío.");
                return;
            }

            if (aprendices.ContainsKey(nombre))
            {
                Console.WriteLine("Ese aprendiz ya está registrado.");
                return;
            }

            aprendices[nombre] = new List<double>();
            Console.WriteLine($"Aprendiz '{nombre}' registrado correctamente.");
        }

        // ---------- 2. Agregar nota ----------
        static void AgregarNota()
        {
            if (!HayAprendices()) return;

            Console.Write("Nombre del aprendiz: ");
            string nombre = Console.ReadLine()?.Trim() ?? "";

            if (!aprendices.TryGetValue(nombre, out List<double>? notas))
            {
                Console.WriteLine("El aprendiz no existe.");
                return;
            }

            Console.Write($"Nota ({NOTA_MIN} a {NOTA_MAX}): ");
            string entrada = (Console.ReadLine() ?? "").Trim().Replace(',', '.');

            if (!double.TryParse(entrada, NumberStyles.Float, CultureInfo.InvariantCulture, out double nota))
            {
                Console.WriteLine("Debe ingresar un número válido.");
                return;
            }

            if (nota < NOTA_MIN || nota > NOTA_MAX)
            {
                Console.WriteLine($"La nota debe estar entre {NOTA_MIN} y {NOTA_MAX}.");
                return;
            }

            notas.Add(nota);
            Console.WriteLine($"Nota {nota:F1} agregada a '{nombre}'.");
        }

        // ---------- 3. Listar con promedio y juicio ----------
        static void ListarConPromedio()
        {
            if (!HayAprendices()) return;

            Console.WriteLine($"{"Aprendiz",-20}{"Notas",-8}{"Promedio",-10}Juicio");
            Console.WriteLine(new string('-', 45));

            foreach (var par in aprendices)
            {
                double prom = Promedio(par.Value);
                Console.WriteLine($"{par.Key,-20}{par.Value.Count,-8}{prom,-10:F2}{Juicio(prom)}");
            }
        }

        // ---------- 4. Ranking (LINQ) ----------
        static void RankingPorPromedio()
        {
            if (!HayAprendices()) return;

            var ranking = aprendices
                .Select(p => new { Nombre = p.Key, Promedio = Promedio(p.Value) })
                .OrderByDescending(x => x.Promedio)
                .ThenBy(x => x.Nombre)
                .ToList();

            Console.WriteLine("=== RANKING POR PROMEDIO ===");
            for (int i = 0; i < ranking.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ranking[i].Nombre,-20} {ranking[i].Promedio:F2}");
            }
        }

        // ---------- 5. Mejor aprendiz y aprobados (LINQ) ----------
        static void MejorAprendizYAprobados()
        {
            if (!HayAprendices()) return;

            var mejor = aprendices
                .Select(p => new { Nombre = p.Key, Promedio = Promedio(p.Value) })
                .OrderByDescending(x => x.Promedio)
                .First();

            int aprobados = aprendices.Count(p => Promedio(p.Value) >= NOTA_APROBACION);

            Console.WriteLine($"Mejor aprendiz: {mejor.Nombre} (promedio {mejor.Promedio:F2})");
            Console.WriteLine($"Aprobados (A): {aprobados} de {aprendices.Count}");
        }

        // ---------- 6. Eliminar ----------
        static void EliminarAprendiz()
        {
            if (!HayAprendices()) return;

            Console.Write("Nombre del aprendiz a eliminar: ");
            string nombre = Console.ReadLine()?.Trim() ?? "";

            if (aprendices.Remove(nombre))
                Console.WriteLine($"Aprendiz '{nombre}' eliminado.");
            else
                Console.WriteLine("El aprendiz no existe.");
        }

        // ---------- Auxiliares ----------
        static double Promedio(List<double> notas) =>
            notas.Count == 0 ? 0 : notas.Average();

        static string Juicio(double promedio) =>
            promedio >= NOTA_APROBACION ? "A" : "D";

        static bool HayAprendices()
        {
            if (aprendices.Count == 0)
            {
                Console.WriteLine("No hay aprendices registrados.");
                return false;
            }
            return true;
        }
    }
}