
using System;
using System.Collections.Generic;
using ProyectoFinal.Core.Abstractions;
using ProyectoFinal.Core.Entities;
using ProyectoFinal.Core.Interfaces;
using ProyectoFinal.Infrastructure.Repositories;

Console.WriteLine("====================================");
Console.WriteLine("       COFFEFLOW - PRUEBAS POO       ");
Console.WriteLine("====================================");

// 1. Crear objetos mediante herencia
Producto cappuccino = new BebidaCaliente(
    "Cappuccino", 65m, 20, 65);

Producto coldBrew = new BebidaFria(
    "Cold Brew", 75m, 15, true);

Producto croissant = new Alimento(
    "Croissant de mantequilla", 45m, 12, true);

// 2. Colección del tipo base
List<Producto> productos = new()
{
    cappuccino,
    coldBrew,
    croissant
};

// 3. Demostración de polimorfismo
Console.WriteLine("\n--- POLIMORFISMO ---");

foreach (Producto producto in productos)
{
    Console.WriteLine(producto.ObtenerDescripcion());
    Console.WriteLine(
        $"Disponible: {producto.TieneDisponibilidad()}");

    Console.WriteLine();
}

// 4. Demostración de la interfaz IVendible
Console.WriteLine("--- INTERFAZ IVENDIBLE ---");

IVendible vendible = cappuccino;

decimal importe = vendible.CalcularImporte(2);

Console.WriteLine($"Precio unitario: ${vendible.Precio:F2}");
Console.WriteLine($"Importe de 2 unidades: ${importe:F2}");

// 5. Demostración de la interfaz IRepositorio
Console.WriteLine("\n--- INTERFAZ IREPOSITORIO ---");

IRepositorio<Producto> repositorio =
    new RepositorioProductosEnMemoria();

foreach (Producto producto in productos)
{
    repositorio.Agregar(producto);
}

Console.WriteLine(
    $"Productos registrados: {repositorio.ObtenerTodos().Count}");

// 6. Verificar resultados
Comprobar(
    importe == 130m,
    "Calculo correcto del importe");

Comprobar(
    repositorio.ObtenerTodos().Count == 3,
    "Almacenamiento de tres productos");

Comprobar(
    cappuccino.ObtenerDescripcion().Contains("Bebida caliente") &&
    coldBrew.ObtenerDescripcion().Contains("Bebida fría") &&
    croissant.ObtenerDescripcion().Contains("Alimento"),
    "Comportamiento polimorfico");

// 7. Demostración de encapsulamiento
Console.WriteLine("\n--- VALIDACIONES ---");

ComprobarExcepcion<ArgumentOutOfRangeException>(
    () => cappuccino.Precio = -50m,
    "Precio negativo");

ComprobarExcepcion<ArgumentOutOfRangeException>(
    () => coldBrew.Stock = -10,
    "Stock negativo");

ComprobarExcepcion<ArgumentException>(
    () => croissant.Nombre = "",
    "Nombre vacio");

ComprobarExcepcion<InvalidOperationException>(
    () => vendible.CalcularImporte(100),
    "Stock insuficiente");

Console.WriteLine("\n====================================");
Console.WriteLine("   PRUEBAS FINALIZADAS CORRECTAMENTE");
Console.WriteLine("====================================");

// Funciones auxiliares de comprobación
static void Comprobar(bool condicion, string nombre)
{
    if (!condicion)
    {
        throw new Exception($"Prueba fallida: {nombre}");
    }

    Console.WriteLine($"[OK] {nombre}");
}

static void ComprobarExcepcion<TException>(
    Action accion, string nombre)
    where TException : Exception
{
    try
    {
        accion();
    }
    catch (TException)
    {
        Console.WriteLine($"[OK] {nombre}: valor rechazado");
        return;
    }

    throw new Exception($"Prueba fallida: {nombre}");
}

