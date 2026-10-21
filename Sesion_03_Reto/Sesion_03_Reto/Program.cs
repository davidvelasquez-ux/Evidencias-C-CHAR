//Crea el proyecto Reto en Sesion03. Pide una contraseña y revisa 6 reglas: mínimo 8 caracteres, una mayúscula, una minúscula, un número, 
//un carácter especial y sin espacios. Muestra ✔ o ✘ por regla y el nivel (Fuerte 6, Media 4 o 5, Débil 3 o menos). Si no es fuerte, vuelve a pedirla. 
//La evaluación va en un método.
Console.WriteLine("ingrese su contraseña")

    string contrasena = Console.ReadLine() ??"";

bool NumeroDeCaracteres = contrasena.Length >= 8;
bool Mayusculas = false;
bool Minusculas = false;
bool Numeros = false;
bool Characters = false;
bool Espacios = false;

int i = 0;
if (contrasena.Length > 0)
{
    do
    {
        char c = contrasena[i];

        if (char.IsUpper(c))
        {
            Mayusculas = true;
        }
        else if (char.IsLower(c))
        {
            Minusculas = true;
        }
        else if (char.IsNumber(c))
        {
            Numeros = true;
        }
        else if char.IsWhiteSpace(c))
        {
            Espacios = false;
        }

        else 
        {
            Characters = true;
        }

        i++;

        while (i < contrasena.Length) ;
        
    }
}

Console.WriteLine("\nResultado de las reglas:");
Console.WriteLine((longitudOk ? "✔" : "✘") + " Mínimo 8 caracteres");
Console.WriteLine((tieneMayuscula ? "✔" : "✘") + " Al menos una mayúscula");
Console.WriteLine((tieneMinuscula ? "✔" : "✘") + " Al menos una minúscula");
Console.WriteLine((tieneNumero ? "✔" : "✘") + " Al menos un número");
Console.WriteLine((tieneEspecial ? "✔" : "✘") + " Al menos un carácter especial");
Console.WriteLine((sinEspacios ? "✔" : "✘") + " Sin espacios");

int puntos = 0;
if (NumeroDeCaracteres) puntos++;
if (Mayusculas) puntos++;
if (Minusculas) puntos++;
if (Numeros) puntos++;
if (Espacios) puntos++;
if (Characters) puntos++;

string nivel;
if (puntos == 6)
{
    nivel = "fuerte";
}
else if (puntos >= 4);
{
    nivel = "Medio";
}
else
{
    nivel = "Debil";
}
Console.WriteLine($"\nReglas cumplidas: {puntos}/6");
Console.WriteLine($"Nivel: {nivel}");

esFuerte = (puntos == 6);

if (!esFuerte)
{
    Console.WriteLine("La contraseña no es fuerte. Inténtalo de nuevo.");
}
else
{
    Console.WriteLine("¡Contraseña aceptada!");
}
 
        } while (!esFuerte) ;

