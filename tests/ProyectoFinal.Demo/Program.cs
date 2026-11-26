
using System;
using System.Collections.Generic;
using ProyectoFinal.Core.Abstractions;
using ProyectoFinal.Core.Entities;
using ProyectoFinal.Core.Interfaces;
using ProyectoFinal.Infrastructure.Repositories;
using System.Linq;
using ProyectoFinal.Core.Generics;

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


// 8. Demostración de clases genéricas
Console.WriteLine("\n--- CLASES GENERICAS ---");

RepositorioEnMemoria<Producto> repositorioGenerico = new();

foreach (Producto producto in productos)
{
    repositorioGenerico.Agregar(producto);
}

Console.WriteLine(
    $"Total de productos: {repositorioGenerico.Contar()}");

// Repositorio especializado en alimentos
RepositorioEnMemoria<Alimento> repositorioAlimentos = new();

foreach (Alimento alimento in productos.OfType<Alimento>())
{
    repositorioAlimentos.Agregar(alimento);
}

Console.WriteLine(
    $"Total de alimentos: {repositorioAlimentos.Contar()}");

// 9. Demostración de métodos genéricos
Console.WriteLine("\n--- METODOS GENERICOS ---");

var bebidasDisponibles =
    ConsultasProductos.ObtenerDisponibles<BebidaCaliente>(
        productos.OfType<BebidaCaliente>());

var alimentosDisponibles =
    ConsultasProductos.ObtenerDisponibles<Alimento>(
        repositorioAlimentos.ObtenerTodos());

Console.WriteLine(
    $"Bebidas calientes disponibles: {bebidasDisponibles.Count}");

Console.WriteLine(
    $"Alimentos disponibles: {alimentosDisponibles.Count}");

decimal valorInventario =
    ConsultasProductos.CalcularValorInventario<Producto>(
        repositorioGenerico.ObtenerTodos());

Console.WriteLine(
    $"Valor total del inventario: ${valorInventario:F2}");

// Verificaciones
Comprobar(
    repositorioGenerico.Contar() == 3,
    "Repositorio generico de productos");

Comprobar(
    repositorioAlimentos.Contar() == 1,
    "Repositorio generico de alimentos");

Comprobar(
    bebidasDisponibles.Count == 1 &&
    alimentosDisponibles.Count == 1,
    "Metodo generico utilizado con dos tipos");

Comprobar(
    valorInventario == 2965m,
    "Calculo del valor del inventario");

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

