using System;
using System.Data;

public class HelloWorld
{
    static void Main()
    {
        int cantidad = 0;
        bool esNumero;
        string[] nombres = new string[10]; double[] precios = new double[10]; int[] stocks = new int[10]; double totalVendido = 0; bool registrado = false; int opcion = 0; int totalProductos = 0;
        do
        {

            Console.WriteLine("Bienvenido a la tienda de Don Pedro,¿Que desea hacer?");
            Console.WriteLine("1. Registrar producto");
            Console.WriteLine("2. Vender");
            Console.WriteLine("3. Mostrar inventario");
            Console.WriteLine("4. Ver mas caro, mas barato y total vendido");
            Console.WriteLine("5. Salir");
            int.TryParse(Console.ReadLine(), out opcion);
            switch (opcion)
            {
                case 1:
                    do
                    {
                        Console.WriteLine("Registrar producto");
                        Console.WriteLine("¿Cuantos productos desea ingresar?");
                        esNumero = int.TryParse(Console.ReadLine(), out cantidad);
                        if (!esNumero)
                        { Console.WriteLine("Error, la cantidad debe ser un numero entero (no decimales, ni letras o simbolos"); }
                        else if (cantidad < 1 || cantidad > 10)
                        { Console.WriteLine("Error, solo puede ingresar minimo un producto y maximo 10"); }
                    }
                    while (cantidad < 1 || cantidad > 10);
                    RegistrarProductos(nombres, precios, stocks, cantidad);
                    totalProductos = cantidad;
                    break;
                case 2:
                    Console.WriteLine("Vender");
                    totalVendido += Vender(nombres, precios, stocks, totalProductos);
                    Console.WriteLine($"Total vendido: {totalVendido}");
                    break;
                case 3:
                    Console.WriteLine("Mostrar inventario");
                    MostrarInventario(nombres, precios, stocks, totalProductos);
                    break;
                case 4:
                    Console.WriteLine("Ver mas caro, mas barato y total vendido");
                    productoCaroBaratoTotalVendido(nombres, precios, totalProductos, totalVendido);
                    break;
                case 5:
                    Console.WriteLine("Salir");
                    break;
                default:
                    Console.WriteLine("Opcion no valida, intente de nuevo.");
                    break;
            }
        }
        while (opcion != 5);
    }
    static void RegistrarProductos(string[] nombres, double[] precios, int[] stocks, int cantidad)
    {
        for (int i = 0; i < cantidad; i++)
        {
            do
            {
                Console.WriteLine($"Ingrese el nombre del producto {i + 1}");
                nombres[i] = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nombres[i]))
                {
                    Console.WriteLine("Error, ingrese un nombre valido");
                }
            }
            while (string.IsNullOrWhiteSpace(nombres[i]));

        }
        for (int i = 0; i < cantidad; i++)
        {
            bool esNumero;
            do
            {
                Console.WriteLine($"Ingrese el precio del producto {i + 1}");
                esNumero = double.TryParse(Console.ReadLine(), out precios[i]);
                if (!esNumero)
                { Console.WriteLine("Error, el precio debe ser un numero (no letras ni simbolos)"); }
                else if (precios[i] <= 0)
                { Console.WriteLine("Error, ingrese un valor de precio mayor a 0"); }

            }
            while (precios[i] <= 0 || !esNumero);

        }
        for (int i = 0; i < cantidad; i++)
        {
            bool esNumero;
            do
            {
                Console.WriteLine($"Ingrese el stock del producto {i + 1}");
                esNumero = int.TryParse(Console.ReadLine(), out stocks[i]);
                if (!esNumero)
                { Console.WriteLine("Error, ingrese un numero (no letras ni simbolos)"); }
                else if (stocks[i] < 0)
                { Console.WriteLine("Error, el stock no puede ser negativo"); }
            }
            while (stocks[i] < 0 || !esNumero);
        }
    }
    static double Vender(string[] nombres, double[] precios, int[] stocks, int totalProductos)
    {
        if (totalProductos == 0)
        {
            Console.WriteLine("Primero debe registrar productos.");
            return 0;
        }

        int indice = -1;
        bool asistencia = false;

        while (!asistencia)
        {
            Console.WriteLine("Ingrese el producto que esta buscando");
            string buscado = Console.ReadLine();

            for (int i = 0; i < totalProductos; i++)
            {
                if (nombres[i] == buscado)
                {
                    asistencia = true;
                    indice = i;
                }
            }

            if (asistencia == false)
            {
                Console.WriteLine("El producto que estaba buscando no existe");
            }
        }
        Console.WriteLine($"Encontrado: {nombres[indice]}, precio {precios[indice]}, stock {stocks[indice]}");
        Console.WriteLine("¿Cuanto quiere comprar?");
        int cantidadCompra = 0;
        int.TryParse(Console.ReadLine(), out cantidadCompra);
        double subtotal = 0;
        if (stocks[indice] < cantidadCompra || cantidadCompra < 1)
        { Console.WriteLine("Cantidad no valida o mayor al stock disponible"); }
        else
        {
            stocks[indice] = stocks[indice] - cantidadCompra;
            Console.WriteLine("Compra exitosa");
            return precios[indice] * cantidadCompra;
        }
        return subtotal;
    }
    static void MostrarInventario(string[] nombres, double[] precios, int[] stocks, int totalProductos)
    {
        if (totalProductos == 0)
        {
            Console.WriteLine("Primero debe registrar productos.");
            return ;
        }
        for (int i = 0; i < totalProductos; i++)
        {
            Console.WriteLine($"Inventario: {nombres[i]}, {precios[i]}, {stocks[i]}");
            if (stocks[i] < 5)
            { Console.WriteLine($"Por reponer: {nombres[i]}, {precios[i]} "); }
        }
    }
    static void productoCaroBaratoTotalVendido(string[] nombres, double[] precios, int totalProductos, double totalVendido)
    {
        if (totalProductos == 0)
        {
            Console.WriteLine("Primero debe registrar productos.");
            return ;
        }
        double productoCaro = precios[0];
        double productoBarato = precios[0];
        for (int i = 0; i < totalProductos; i++)
        { if (precios[i] > productoCaro)
            { productoCaro = precios[i]; }
            else if (precios[i] < productoBarato)
            { productoBarato = precios[i];}
        }
        Console.WriteLine($"Producto mas caro: {productoCaro}, producto mas barato: {productoBarato}, total vendido: {totalVendido}");
    }
}