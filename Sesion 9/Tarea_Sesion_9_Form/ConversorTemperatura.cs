namespace Tarea;

// Toda la lógica de conversión vive aquí; el formulario solo la llama.
public static class ConversorTemperatura
{
    public static readonly string[] Unidades = { "°C", "°F", "K" };

    public static double Convertir(double valor, string origen, string destino)
    {
        double celsius = origen switch
        {
            "°C" => valor,
            "°F" => (valor - 32) * 5 / 9,
            "K"  => valor - 273.15,
            _    => throw new ArgumentException($"Unidad desconocida: {origen}")
        };

        return destino switch
        {
            "°C" => celsius,
            "°F" => celsius * 9 / 5 + 32,
            "K"  => celsius + 273.15,
            _    => throw new ArgumentException($"Unidad desconocida: {destino}")
        };
    }
}
