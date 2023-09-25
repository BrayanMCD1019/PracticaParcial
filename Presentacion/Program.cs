﻿using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    internal class Program
    {
        public static LiquidacionCuotaModeradoraService liquidacionCuotaModeradoraService = new LiquidacionCuotaModeradoraService();
        public static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            int op = 0;
            LiquidacionCuotaModeradoraService liquidacion = new LiquidacionCuotaModeradoraService();
            do
            {
                Console.Clear();
                Console.SetCursorPosition(20, 2); Console.Write("MENU IPS MAS SALUD Y VIDA ");
                Console.SetCursorPosition(10, 5); Console.Write("1. Registrar Liquidacion");
                Console.SetCursorPosition(10, 6); Console.Write("2. Mostrar Liquidaciones");
                Console.SetCursorPosition(10, 7); Console.Write("3. Buscar Liquidaciones Tipo De Afiliacion");
                Console.SetCursorPosition(10, 8); Console.Write("4. Buscar Liquidaciones por Cuota Moderadoras");
                Console.SetCursorPosition(10, 9); Console.Write("5. Buscar Liquidaciones por Fecha");
                Console.SetCursorPosition(10, 10); Console.Write("6. Eliminar Liquidaciones");
                Console.SetCursorPosition(10, 11); Console.Write("7. Modificar Liquidaciones");
                Console.SetCursorPosition(10, 13); Console.Write("Ingrese una Opcion: ");
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        AgregarLiquidacion();
                        break;
                    case 2:
                        liquidacion.MostrarLiquidaciones();
                        break;
                    case 3:
                        liquidacion.ConsultarTotalLiquidacionesPorAfiliacion();
                        break;
                    case 4:
                        liquidacion.ConsultarValorTotalPorAfiliacion();
                        break;
                    case 5:
                        //ConsultarLiquidacionFecha();
                        break;
                    case 6:
                        //ConsultaridPaciente();
                        break;
                    case 7:
                        //EliminarLiquidacion();
                        break;
                    case 8:
                        //ModificarLiquidacion();
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            } while (op != 8);
        }

        private static void AgregarLiquidacion()
        {
            Console.Clear();
            Console.SetCursorPosition(20, 2); Console.Write("AGREGAR LIQUIDACION");

            Console.SetCursorPosition(10, 5); Console.WriteLine("Ingrese el numero de Liquidacion:");
            int numLiquidacion = int.Parse(Console.ReadLine());

            Console.SetCursorPosition(10, 6); Console.WriteLine("Ingrese la identificacion del Paciente:");
            int idPaciente = int.Parse(Console.ReadLine());

            Console.SetCursorPosition(10, 7); Console.WriteLine("Ingrese el tipo de afiliacion (subsidiado / contributivo):");
            String tipoAfiliacion = Console.ReadLine();

            Console.SetCursorPosition(10, 8); Console.WriteLine("Ingrese el salario devengado:");
            double salarioDevengado = double.Parse(Console.ReadLine());

            Console.SetCursorPosition(10, 9); Console.WriteLine("Ingrese el valor del servicio:");
            double valorServicio = int.Parse(Console.ReadLine());

            Console.SetCursorPosition(10, 10); Console.WriteLine("Ingrese el año:");
            int year = int.Parse(Console.ReadLine());

            Console.SetCursorPosition(10, 11); Console.WriteLine("Ingrese el mes (1-12):");
            int month = int.Parse(Console.ReadLine());

            Console.SetCursorPosition(10, 12); Console.WriteLine("Ingrese el día:");
            int day = int.Parse(Console.ReadLine());

            DateTime fechaPersonalizada;
            fechaPersonalizada = CrearFechaPersonalizada(year, month, day);

            LiquidacionCuotaModeradora liquidacion = new LiquidacionCuotaModeradora(numLiquidacion, idPaciente, tipoAfiliacion, salarioDevengado, valorServicio, fechaPersonalizada);

            Console.Write(liquidacionCuotaModeradoraService.Guardar(liquidacion));
            Console.ReadKey();
        }
        static DateTime CrearFechaPersonalizada(int year, int month, int day)
        {
            return new DateTime(year, month, day);
        }

    }
}
