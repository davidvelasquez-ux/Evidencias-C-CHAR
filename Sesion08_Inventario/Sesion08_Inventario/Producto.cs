namespace Inventario.Modelos;

public class Producto
{
    public string Codigo { get; }
    public string Nombre { get; }
    public decimal Precio { get; }
    public int Stock { get; private set; }

    // Un solo constructor público, con parámetros llamados igual que las propiedades,
    // para que el JSON pueda volver a crear el producto.
    public Producto(string codigo, string nombre, decimal precio, int stock)
    {
        if (string.IsNullOrWhiteSpace(codigo))
            throw new ArgumentException("El código no puede estar vacío.");
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("El nombre no puede estar vacío.");
        if (precio < 0)
            throw new ArgumentException("El precio no puede ser negativo.");
        if (stock < 0)
            throw new ArgumentException("El stock no puede ser negativo.");

        Codigo = codigo.Trim().ToUpper();
        Nombre = nombre.Trim();
        Precio = precio;
        Stock = stock;
    }

    public void AgregarStock(int cantidad)
    {
        if (cantidad <= 0)
            throw new ArgumentException("La cantidad debe ser mayor que cero.");
        Stock += cantidad;
    }

    public void Vender(int cantidad)
    {
        if (cantidad <= 0)
            throw new ArgumentException("La cantidad debe ser mayor que cero.");
        if (cantidad > Stock)
            throw new StockInsuficienteException(Nombre, Stock);
        Stock -= cantidad;
    }
}