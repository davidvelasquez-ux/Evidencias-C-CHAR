using System;

var cuenta1 = new CuentaBancaria("David Velasquez", "001-123", 500000m);
var cuenta2 = new CuentaBancaria("Sofia Sanchez", "001-456", 200000m);

Mostrar("Estado inicial");

Console.WriteLine($"\nDepositar 100.000 en cuenta 1: {(cuenta1.Depositar(100000m) ? "OK" : "Rechazado")}");
Mostrar("Después del depósito");

Console.WriteLine($"\nRetirar 2.000.000 de cuenta 2: {(cuenta2.Retirar(2000000m) ? "OK" : "Rechazado (saldo insuficiente)")}");
Mostrar("Después del retiro rechazado");

Console.WriteLine($"\nTransferir 150.000 de cuenta 1 a cuenta 2: {(cuenta1.Transferir(cuenta2, 150000m) ? "OK" : "Rechazado")}");
Mostrar("Después de la transferencia");

void Mostrar(string titulo)
{
    Console.WriteLine($"\n--- {titulo} ---");
    Console.WriteLine($"{cuenta1.Titular} ({cuenta1.Numero}): {cuenta1.Saldo:C0}");
    Console.WriteLine($"{cuenta2.Titular} ({cuenta2.Numero}): {cuenta2.Saldo:C0}");
}

