using Inventario.Datos;
using Inventario.Modelos;
using Inventario.Servicios;

var servicio = new ServicioInventario(new RepositorioJson("inventario.json"));

Console.WriteLine($"Los datos se guardan en: {Path.GetFullPath("inventario.json")}");

bool salir = false;
while (!salir)
{
    MostrarMenu();
    string opcion = Console.ReadLine()?.Trim() ?? "";

    try
    {
        switch (opcion)
        {
            case "1": RegistrarProducto(servicio); break;
            case "2": AgregarStock(servicio); break;
            case "3": Vender(servicio); break;
            case "4": VerInventario(servicio); break;
            case "5": VerStockBajo(servicio); break;
            case "6": BuscarProductos(servicio); break;
            case "7": EliminarProducto(servicio); break;
            case "8": salir = true; break;
            default: Console.WriteLine("Opción no válida."); break;
        }
    }
    catch (StockInsuficienteException ex)
    {
        Console.WriteLine($"Aviso: {ex.Message}");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Dato inválido: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error inesperado: {ex.Message}");
    }
}

Console.WriteLine("Hasta luego.");

static void MostrarMenu()
{
    Console.WriteLine();
    Console.WriteLine("===== INVENTARIO =====");
    Console.WriteLine("1. Registrar producto");
    Console.WriteLine("2. Agregar stock");
    Console.WriteLine("3. Vender");
    Console.WriteLine("4. Ver inventario");
    Console.WriteLine("5. Ver stock bajo");
    Console.WriteLine("6. Buscar por texto");
    Console.WriteLine("7. Eliminar producto");
    Console.WriteLine("8. Salir");
    Console.Write("Elige una opción: ");
}

static void RegistrarProducto(ServicioInventario servicio)
{
    string codigo = LeerTexto("Código: ");
    string nombre = LeerTexto("Nombre: ");
    decimal precio = LeerDecimal("Precio: ");
    int stock = LeerEntero("Stock inicial: ");

    servicio.Agregar(new Producto(codigo, nombre, precio, stock));
    Console.WriteLine("Producto registrado.");
}

static void AgregarStock(ServicioInventario servicio)
{
    string codigo = LeerTexto("Código del producto: ");
    int cantidad = LeerEntero("Cantidad a agregar: ");

    servicio.AgregarStock(codigo, cantidad);
    Console.WriteLine("Stock actualizado.");
}

static void Vender(ServicioInventario servicio)
{
    string codigo = LeerTexto("Código del producto: ");
    int cantidad = LeerEntero("Cantidad a vender: ");

    servicio.Vender(codigo, cantidad);
    Console.WriteLine("Venta realizada.");
}

static void VerInventario(ServicioInventario servicio)
{
    MostrarProductos(servicio.Listar(), "No hay productos registrados.");
}

static void VerStockBajo(ServicioInventario servicio)
{
    MostrarProductos(servicio.StockBajo(), "No hay productos con stock bajo.");
}

// TAREA 1
static void BuscarProductos(ServicioInventario servicio)
{
    string texto = LeerTexto("Texto a buscar (nombre o código): ");
    MostrarProductos(servicio.BuscarPorTexto(texto), "No se encontraron productos.");
}

// TAREA 2
static void EliminarProducto(ServicioInventario servicio)
{
    string codigo = LeerTexto("Código del producto a eliminar: ");
    string respuesta = LeerTexto($"¿Seguro que quieres eliminar {codigo.ToUpper()}? (s/n): ").ToLower();

    if (respuesta == "s")
    {
        servicio.Eliminar(codigo);
        Console.WriteLine("Producto eliminado.");
    }
    else
    {
        Console.WriteLine("Operación cancelada.");
    }
}

static void MostrarProductos(List<Producto> productos, string mensajeVacio)
{
    if (productos.Count == 0)
    {
        Console.WriteLine(mensajeVacio);
        return;
    }

    Console.WriteLine($"{"Código",-10} {"Nombre",-20} {"Precio",12} {"Stock",6}");
    foreach (Producto p in productos)
        Console.WriteLine($"{p.Codigo,-10} {p.Nombre,-20} {p.Precio,12:C0} {p.Stock,6}");
}

static string LeerTexto(string mensaje)
{
    Console.Write(mensaje);
    return Console.ReadLine()?.Trim() ?? "";
}

static int LeerEntero(string mensaje)
{
    while (true)
    {
        Console.Write(mensaje);
        if (int.TryParse(Console.ReadLine(), out int valor)) return valor;
        Console.WriteLine("Debes escribir un número entero.");
    }
}

static decimal LeerDecimal(string mensaje)
{
    while (true)
    {
        Console.Write(mensaje);
        if (decimal.TryParse(Console.ReadLine(), out decimal valor)) return valor;
        Console.WriteLine("Debes escribir un número.");
    }
}
