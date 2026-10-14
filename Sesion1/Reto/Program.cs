using System;

class Program
{
    static void Main()
    {

        Console.OutputEncoding = System.Text.Encoding.UTF8;
        //aqui se pide el nombre en consola junto xon los otros datos usando Console.write

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        //el string es el input que recive el dato pedido

        Console.Write("Programa de formación: ");
        string programa = Console.ReadLine();

        Console.Write("Número de ficha: ");
        string ficha = Console.ReadLine();

        Console.Write("Una frase que te represente: ");
        string frase = Console.ReadLine();

        //aqui se genera la targeta de presentacion usando las lineas donde se depositaron los datos

        string titulo = "TARJETA DE PRESENTACIÓN";
        string linea1 = $"Nombre: {nombre}";
        string linea2 = $"Programa: {programa}";
        string linea3 = $"Ficha: {ficha}";
        string linea4 = $"Frase: {frase}";

        Console.WriteLine();

        //aqui se genera la targeta imprimiedo lineas con colores usando el Console.write

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("╔" + new string('═', 50) + "╗");
        Console.WriteLine($"║ {titulo,-48} ║");
        Console.WriteLine("╠" + new string('═', 50) + "╣");

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"║ {linea1,-48} ║");
        Console.WriteLine($"║ {linea2,-48} ║");
        Console.WriteLine($"║ {linea3,-48} ║");
        Console.WriteLine($"║ {linea4,-48} ║");

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("╚" + new string('═', 50) + "╝");

        Console.ResetColor();

        Console.ReadKey();
    }
}