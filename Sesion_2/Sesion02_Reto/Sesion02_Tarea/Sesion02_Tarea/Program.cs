using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sesion02_Tarea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int secreto = random.Next(1, 101);

            bool acerto = false;
            int intentos = 0;

            Console.WriteLine("Bienvenido a Adivina el número. Tienes un total de 7 intentos para lograrlo. ¡Buena suerte!");
            Console.WriteLine("Empieza con un número del 1 al 100");

            do
            {
                int numero = Convert.ToInt32(Console.ReadLine().Trim());

                if (numero > secreto)
                {
                    intentos++;
                    Console.WriteLine($"El numero {numero} es mayor al secreto");
                }
                else if (numero < secreto)
                {
                    intentos++;
                    Console.WriteLine($"El numero {numero} es menor al secreto");
                }
                else
                {
                    intentos++;
                    Console.WriteLine($"Acertaste, el numero de intentos fueron: {intentos}");
                    acerto = true;
                }

                if (intentos == 7 && !acerto)
                {
                    Console.WriteLine("Terminaste con tus intentos, suerte para la proxima");
                    break;
                }
            } while (!acerto);


        }
    }
}
