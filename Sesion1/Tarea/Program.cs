using System;

class Program
{
    static void Main()
    {

        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("CALCULADORA: ");
        
        Console.Write("Escribe los segundos: ");

        if (int.TryParse(Console.ReadLine(), out int segundos))
        {
            int horas = segundos / 3600;
            int minutos = (segundos % 3600) / 60;
            int segundosRestantes = segundos % 60;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{horas} h {minutos} min {segundosRestantes} s");
        }
        else
        {
            Console.WriteLine("Eso no es un número entero.");
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Escribe los grados Celsius: ");
        if (double.TryParse(Console.ReadLine(), out double celsius))
        {
            double fahrenheit = celsius * 9 / 5 + 32;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{celsius} °C = {fahrenheit:N1} °F");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Eso no es un número válido.");
        }
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Nota 1: ");
        bool nota1Valida = double.TryParse(Console.ReadLine(), out double nota1);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Nota 2: ");
        bool nota2Valida = double.TryParse(Console.ReadLine(), out double nota2);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Nota 3: ");
        bool nota3Valida = double.TryParse(Console.ReadLine(), out double nota3);


        if (nota1Valida && nota2Valida && nota3Valida)
        {
            double promedio = (nota1 + nota2 + nota3) / 3;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Promedio: {promedio:N1}");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Alguna nota no es válida.");
        }

        Console.ReadKey();
    }
}