//Crea el proyecto Sesion03/Tarea con 2 métodos:
//1.Generador de usuarios: primera letra del nombre + primer apellido + 2 últimos dígitos del documento, en minúsculas y sin tildes (Ana María Gómez Pérez, 1034567812 → agomez12).
//2. Analizador de frases: cuenta las palabras y muestra la frase en orden inverso con StringBuilder

using System.Text;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("===== Generador de usuarios =====");
Console.WriteLine("Ingrese los nombres: ");

string nombres = Console.ReadLine() ?? "";

Console.WriteLine("Ingrese los apellidos: ");
string apellidos = Console.ReadLine() ?? "";

Console.WriteLine("Ingrese el documento: ");
string documento = Console.ReadLine() ?? "";

string usuario = Generarusuario(nombres, apellidos, documento);

if (usuario == "")
{
    Console.WriteLine("Datos inválidos, revise nombres, apellidos y documento");
}
else
{
    Console.WriteLine("Usuario generado: " + usuario);
}

Console.WriteLine();
Console.WriteLine("===== Analizador de frases =====");
Console.WriteLine("Ingrese una frase: ");
string frase = Console.ReadLine() ?? "";

Analizarfrase(frase);

static string Generarusuario(string nombres, string apellidos, string documento)
{
    nombres = nombres.Trim();
    apellidos = apellidos.Trim();
    documento = documento.Trim();

    if (nombres.Length == 0 || apellidos.Length == 0 || documento.Length < 2)
    {
        return "";
    }

    char inicial = nombres[0];

    StringBuilder primerApellido = new StringBuilder();

    foreach (char c in apellidos)
    {
        if (c == ' ')
        {
            break;
        }
        primerApellido.Append(c);
    }

    char penultimo = documento[documento.Length - 2];
    char ultimo = documento[documento.Length - 1];

    string usuario = inicial + primerApellido.ToString() + penultimo + ultimo;

    string conTilde = "áàäâéèëêíìïîóòöôúùüûñ";
    string sinTilde = "aaaaeeeeiiiioooouuuun";

    StringBuilder resultado = new StringBuilder();

    foreach (char c in usuario)
    {
        char letra = char.ToLower(c);

        for (int i = 0; i < conTilde.Length; i++)
        {
            if (letra == conTilde[i])
            {
                letra = sinTilde[i];
            }
        }

        resultado.Append(letra);
    }

    return resultado.ToString();
}

static void Analizarfrase(string frase)
{
    int cantidad = 0;
    bool dentroPalabra = false;

  
    foreach (char c in frase)
    {
        if (c != ' ')
        {
            if (!dentroPalabra)
            {
                cantidad++;
                dentroPalabra = true;
            }
        }
        else
        {
            dentroPalabra = false;
        }
    }

    if (cantidad == 0)
    {
        Console.WriteLine("La frase está vacía");
        return;
    }

    string[] palabras = new string[cantidad];
    StringBuilder palabraActual = new StringBuilder();
    int posicion = 0;

    foreach (char c in frase)
    {
        if (c != ' ')
        {
            palabraActual.Append(c);
        }
        else if (palabraActual.Length > 0)
        {
            palabras[posicion] = palabraActual.ToString();
            posicion++;
            palabraActual.Clear();
        }
    }

    if (palabraActual.Length > 0)
    {
        palabras[posicion] = palabraActual.ToString();
    }

    StringBuilder inversa = new StringBuilder();

    for (int i = cantidad - 1; i >= 0; i--)
    {
        inversa.Append(palabras[i]);

        if (i > 0)
        {
            inversa.Append(" ");
        }
    }

    Console.WriteLine("Cantidad de palabras: " + cantidad);
    Console.WriteLine("Frase en orden inverso: " + inversa.ToString());
}