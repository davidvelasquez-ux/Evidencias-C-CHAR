using System;
using System.Collections.Generic;
using System.Linq;

var inventario = new List<Producto>
{
    new Producto("ACE-001", "Aceite de motor 10W-40", 45000m, 20),
    new Producto("FIL-002", "Filtro de aire", 28000m, 15),
    new Producto("BAT-003", "Batería 12V 45Ah", 320000m, 6)
};

var carrito = new List<LineaVenta>();
int consecutivoFactura = 1;
bool salir = false;

while (!salir)
{
    Console.WriteLine("\n===== TIENDA AUTOMOTRIZ =====");
    Console.WriteLine("1. Registrar producto");
    Console.WriteLine("2. Agregar stock");
    Console.WriteLine("3. Vender (agregar al carrito)");
    Console.WriteLine("4. Ver carrito y total");
    Console.WriteLine("5. Confirmar compra (factura)");
    Console.WriteLine("6. Ver inventario");
    Console.WriteLine("0. Salir");
    Console.Write("Opción: ");

    switch (Console.ReadLine())
    {
        case "1": RegistrarProducto(); break;
        case "2": AgregarStock(); break;
        case "3": Vender(); break;
        case "4": VerCarrito(); break;
        case "5": ConfirmarCompra(); break;
        case "6": VerInventario(); break;
        case "0": salir = true; break;
        default: Console.WriteLine("Opción no válida."); break;
    }
}

Console.WriteLine("¡Hasta pronto!");

// ---------------- Funciones ----------------

void RegistrarProducto()
{
    Console.Write("Código: ");
    string codigo = (Console.ReadLine() ?? "").Trim().ToUpper();

    if (inventario.Any(p => p.Codigo == codigo))
    {
        Console.WriteLine("Ya existe un producto con ese código.");
        return;
    }

    Console.Write("Nombre: ");
    string nombre = Console.ReadLine() ?? "";

    decimal precio = LeerDecimal("Precio: ");
    int stock = LeerEntero("Stock inicial: ");

    try
    {
        inventario.Add(new Producto(codigo, nombre, precio, stock));
        Console.WriteLine("Producto registrado correctamente.");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"No se pudo registrar: {ex.Message}");
    }
}

void AgregarStock()
{
    var producto = BuscarProducto();
    if (producto == null) return;

    int cantidad = LeerEntero("Cantidad a agregar: ");
    try
    {
        producto.AgregarStock(cantidad);
        Console.WriteLine($"Stock actualizado: {producto.Stock} unidades.");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void Vender()
{
    var producto = BuscarProducto();
    if (producto == null) return;

    int cantidad = LeerEntero("Cantidad a vender: ");
    if (producto.Vender(cantidad))
    {
        carrito.Add(new LineaVenta(producto.Codigo, producto.Nombre, cantidad, producto.Precio * cantidad));
        Console.WriteLine("Producto agregado al carrito.");
    }
    else
    {
        Console.WriteLine($"Venta rechazada: cantidad inválida o stock insuficiente (disponible: {producto.Stock}).");
    }
}

void VerCarrito()
{
    if (carrito.Count == 0)
    {
        Console.WriteLine("El carrito está vacío.");
        return;
    }

    Console.WriteLine("\n--- CARRITO ---");
    foreach (var l in carrito)
        Console.WriteLine($"{l.Codigo,-8} {l.Nombre,-26} x{l.Cantidad,-3} {l.Subtotal,12:C0}");

    Console.WriteLine($"TOTAL: {carrito.Sum(l => l.Subtotal):C0}");
}

void ConfirmarCompra()
{
    if (carrito.Count == 0)
    {
        Console.WriteLine("No hay nada en el carrito.");
        return;
    }

    var factura = new Factura(
        consecutivoFactura++,
        DateTime.Now,
        new List<LineaVenta>(carrito),
        carrito.Sum(l => l.Subtotal));

    MostrarFactura(factura);
    carrito.Clear();
}

void MostrarFactura(Factura f)
{
    Console.WriteLine("\n==================================");
    Console.WriteLine("        TIENDA AUTOMOTRIZ");
    Console.WriteLine("==================================");
    Console.WriteLine($"Factura N°: {f.Numero:D5}");
    Console.WriteLine($"Fecha: {f.Fecha:dd/MM/yyyy HH:mm}");
    Console.WriteLine("----------------------------------");
    foreach (var l in f.Lineas)
    {
        Console.WriteLine($"{l.Nombre}");
        Console.WriteLine($"   {l.Cantidad} x {l.Subtotal / l.Cantidad:C0} = {l.Subtotal:C0}");
    }
    Console.WriteLine("----------------------------------");
    Console.WriteLine($"TOTAL: {f.Total:C0}");
    Console.WriteLine("¡Gracias por su compra!");
    Console.WriteLine("==================================");
}

void VerInventario()
{
    Console.WriteLine("\n--- INVENTARIO ---");
    foreach (var p in inventario)
        Console.WriteLine($"{p.Codigo,-8} {p.Nombre,-26} {p.Precio,12:C0}  Stock: {p.Stock}");
}

Producto? BuscarProducto()
{
    Console.Write("Código del producto: ");
    string codigo = (Console.ReadLine() ?? "").Trim().ToUpper();

    var producto = inventario.FirstOrDefault(p => p.Codigo == codigo);
    if (producto == null)
        Console.WriteLine("El producto no existe.");
    return producto;
}

int LeerEntero(string mensaje)
{
    Console.Write(mensaje);
    return int.TryParse(Console.ReadLine(), out int valor) ? valor : 0; // 0 será rechazado por las validaciones
}

decimal LeerDecimal(string mensaje)
{
    Console.Write(mensaje);
    return decimal.TryParse(Console.ReadLine(), out decimal valor) ? valor : 0m;
}