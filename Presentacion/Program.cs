using BLL;
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
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            int op = 0;
            do
            {
                Console.Clear();
                Console.SetCursorPosition(20, 2); Console.Write("MENU IPS MAS SALUD Y VIDA ");
                Console.SetCursorPosition(10, 5); Console.Write("1. Refistrar Liquidacion");
                Console.SetCursorPosition(10, 7); Console.Write("2. Mostrar Liquidaciones");
                Console.SetCursorPosition(10, 9); Console.Write("3. Buscar Liquidaciones por Afiliacion");
                Console.SetCursorPosition(10, 11); Console.Write("4. Buscar Liquidaciones por Cuota Moderadoras");
                Console.SetCursorPosition(10, 13); Console.Write("5. Buscar Liquidaciones por Fecha");
                Console.SetCursorPosition(10, 15); Console.Write("5. Eliminar Liquidaciones");
                Console.SetCursorPosition(10, 17); Console.Write("5. Modificar Liquidaciones");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        //RegistrarLiquidacion();
                        break;
                    case 2:
                        //ConsultarTodos();
                        break;
                    case 3:
                        //ConsultarAfiliaciones();
                        break;
                    case 4:
                        //ConsultarFecha();
                        break;
                    case 5:
                        //ConsultarAfiliacion();
                        break;
                    case 6:
                        //ConsultarCuotaModeradora();
                        break;
                    case 7:
                        //ConsultarFecha();
                        break;
                    case 8:
                        //EliminarLiquidacion();
                        break;
                    case 9:
                        //ModificarLiquidacion();
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            } while (op != 9);
        }

        private static void AgregarLiquidacion(LiquidacionCuotaModeradoraService liquidacionCuotaModeradoraService)
        {
            Console.Clear();
            Console.WriteLine("Ingrese el numero de Liquidacion:");
            int numLiquidacion = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la identificacion del Paciente:");
            int idPaciente = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el tipo de afiliacion:");
            String tipoAfiliacion = Console.ReadLine();

            Console.WriteLine("Ingrese el salario devengado:");
            double salarioDevengado = double.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el valor del servicio:");
            double valorServicio = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el año:");
            int year = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el mes (1-12):");
            int month = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el día:");
            int day = int.Parse(Console.ReadLine());

            DateTime fechaPersonalizada;

            try
            {
                fechaPersonalizada = CrearFechaPersonalizada(year, month, day);
                LiquidacionCuotaModeradora liquidacion = new LiquidacionCuotaModeradora(numLiquidacion, idPaciente, tipoAfiliacion, salarioDevengado, valorServicio, fechaPersonalizada);
                Console.Write(liquidacionCuotaModeradoraService.Guardar(liquidacion));
                Console.ReadKey();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("La fecha ingresada no es válida.");
            }

        }
        static DateTime CrearFechaPersonalizada(int year, int month, int day)
        {
            return new DateTime(year, month, day);
        }

    }
}
