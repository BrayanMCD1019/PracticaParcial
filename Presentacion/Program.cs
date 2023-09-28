using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    internal class Program
    {
        public static LiquidacionCuotaModeradoraService liquidacionCuotaModeradoraService = new LiquidacionCuotaModeradoraService();
        public static void Main(string[] args)
        {
            Console.BufferWidth = 200;
            Menu();
        }

        public static void Menu()
        {
            int op = 0;
            
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
                        liquidacionCuotaModeradoraService.AgregarLiquidacion();
                        break;
                    case 2:
                        liquidacionCuotaModeradoraService.MostrarLiquidaciones();
                        break;
                    case 3:
                        liquidacionCuotaModeradoraService.ConsultarTotalLiquidacionesPorAfiliacion();
                        break;
                    case 4:
                        liquidacionCuotaModeradoraService.ConsultarValorTotalPorAfiliacion();
                        break;
                    case 5:
                        //ConsultarLiquidacionFecha();
                        break;
                    case 6:
                        liquidacionCuotaModeradoraService.EliminarLiquidacion();
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
    }
}
