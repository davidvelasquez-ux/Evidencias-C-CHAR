using System;
using System.Collections.Generic;

public record Factura(int Numero, DateTime Fecha, List<LineaVenta> Lineas, decimal Total);