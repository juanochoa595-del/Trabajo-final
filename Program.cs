using System;

public class HelloWorld
{
    static void Main()
    {
        int cantidad = 0;
        string[] nombres = new string[10]; double[] precios = new double[10]; int[] stocks = new int[10]; double totalVendido = 0; bool registrado = false; int opcion = 0;
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
                    do { 
                    Console.WriteLine("Registrar producto");
                    Console.WriteLine("¿Cuantos productos desea ingresar?");
                    int.TryParse(Console.ReadLine(),out cantidad);
                    }
                    while (cantidad < 1 || cantidad > 10);
                    RegistrarProductos(nombres, precios, stocks, cantidad);
                    break;
                case 2:
                    Console.WriteLine("Vender");
                    break;
                case 3:
                    Console.WriteLine("Mostrar inventario");
                    break;
                case 4:
                    Console.WriteLine("Ver mas caro, mas barato y total vendido");
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
                Console.WriteLine($"Ingrese el nombre del producto {i+1}");
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
                esNumero =double.TryParse(Console.ReadLine(), out precios[i]);
                if (!esNumero)
                { Console.WriteLine("Error, el precio debe ser un numero (no letras ni simbolos)"); }
                else if (precios[i] <= 0)
                { Console.WriteLine("Error, ingrese un valor de precio mayor a 0"); }

            }
           while (precios[i] <=0 || !esNumero);

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
            while (stocks[i]<0 || !esNumero);

        }
    }
    }
