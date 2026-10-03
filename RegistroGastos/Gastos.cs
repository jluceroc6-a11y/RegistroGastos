using System;
using System.Collections.Generic;
using System.IO;

namespace RegistroGastos
{
    class Program
    {
        public static void Main(string[] args)
        {
            string ruta = "gastos.csv";
            List<Gasto> gastos = Cargar(ruta);

            int siguienteId = 1;

            foreach (Gasto g in gastos)
            {
                if (g.Id >= siguienteId)
                    siguienteId = g.Id + 1;
            }

            string opcion;

            do
            {
                opcion = LeerOpcionMenu();

                switch (opcion)
                {
                    case "1":
                        Agregar(gastos, ref siguienteId);
                        break;

                    case "2":
                        Listar(gastos);
                        break;

                    case "3":
                        BuscarPorCategoria(gastos);
                        break;

                    case "4":
                        Guardar(gastos, ruta);
                        Console.WriteLine("Saliendo...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

            } while (opcion != "4");
        }

        private static string LeerOpcionMenu()
        {
            Console.WriteLine("=== REGISTRO DE GASTOS ===");
            Console.WriteLine("1. Agregar gasto");
            Console.WriteLine("2. Listar gastos");
            Console.WriteLine("3. Buscar por categoría");
            Console.WriteLine("4. Salir");
            Console.Write("Elige una opción: ");

            return Console.ReadLine();
        }

        private static void Agregar(List<Gasto> gastos, ref int siguienteId)
        {
            Console.Write("Descripción: ");
            string descripcion = Console.ReadLine();

            Console.Write("Monto: ");
            string montoTexto = Console.ReadLine();

            Console.Write("Categoría: ");
            string categoria = Console.ReadLine();

            if (!decimal.TryParse(montoTexto, out decimal monto) ||
                monto <= 0 ||
                string.IsNullOrWhiteSpace(descripcion) ||
                string.IsNullOrWhiteSpace(categoria))
            {
                Console.WriteLine("Datos inválidos.");
                return;
            }

            Gasto gasto = new Gasto
            {
                Id = siguienteId,
                Descripcion = descripcion.Trim(),
                Monto = monto,
                Categoria = categoria.Trim()
            };

            gastos.Add(gasto);
            siguienteId++;

            Console.WriteLine("Gasto agregado.");
        }

        private static void Listar(List<Gasto> gastos)
        {
            decimal totalGeneral = 0;

            foreach (Gasto g in gastos)
            {
                Console.WriteLine(g);
                totalGeneral += g.Monto;
            }

            Console.WriteLine($"TOTAL GASTADO: Q {totalGeneral:N2}");
        }

        private static void BuscarPorCategoria(List<Gasto> gastos)
        {
            Console.Write("Categoría a buscar: ");
            string texto = Console.ReadLine().Trim().ToUpper();

            bool encontrado = false;

            foreach (Gasto g in gastos)
            {
                if (g.Categoria.ToUpper().Contains(texto))
                {
                    Console.WriteLine($"- {g}");
                    encontrado = true;
                }
            }

            if (!encontrado)
                Console.WriteLine("Sin coincidencias.");
        }

        private static void Guardar(List<Gasto> gastos, string ruta)
        {
            var lineas = new List<string>();

            foreach (Gasto g in gastos)
            {
                lineas.Add(
                    $"{g.Id};{g.Descripcion};{g.Monto};{g.Categoria}");
            }

            File.WriteAllLines(ruta, lineas);

            Console.WriteLine(
                $"Gastos guardados en {ruta} ({gastos.Count} registros).");
        }

        private static List<Gasto> Cargar(string ruta)
        {
            var gastos = new List<Gasto>();

            if (!File.Exists(ruta))
                return gastos;

            foreach (string linea in File.ReadAllLines(ruta))
            {
                string[] campos = linea.Split(';');

                if (campos.Length != 4)
                    continue;

                gastos.Add(new Gasto
                {
                    Id = int.Parse(campos[0]),
                    Descripcion = campos[1],
                    Monto = decimal.Parse(campos[2]),
                    Categoria = campos[3]
                });
            }

            Console.WriteLine(
                $"Cargados {gastos.Count} gastos desde {ruta}.");

            return gastos;
        }
    }
}