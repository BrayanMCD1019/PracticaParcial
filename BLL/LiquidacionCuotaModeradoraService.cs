using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LiquidacionCuotaModeradoraService
    {
        LiquidacionCuotaModeradoraRepository liquidacionCuotaModeradoraRepository = null;
        private List<LiquidacionCuotaModeradora> liquidacionCuotaModeradoraList = null;

        public LiquidacionCuotaModeradoraService()
        {
            liquidacionCuotaModeradoraRepository = new LiquidacionCuotaModeradoraRepository();
            liquidacionCuotaModeradoraList = liquidacionCuotaModeradoraRepository.ConsultarTodos();
        }

        //a) registrar liquidacion

        public String Guardar(LiquidacionCuotaModeradora liquidacionCuotaModeradora)
        {
            if (liquidacionCuotaModeradora == null)
            {
                return "no se puede agregar liquidaciones nulas o sin informacion";

            }
            var msg = (liquidacionCuotaModeradoraRepository.Guardar(liquidacionCuotaModeradora));
            liquidacionCuotaModeradoraList = liquidacionCuotaModeradoraRepository.ConsultarTodos();
            return msg;
        }

        public void AgregarLiquidacion()
        {
            Console.Clear();
            Console.SetCursorPosition(20, 2); Console.Write("AGREGAR LIQUIDACION");

            Console.SetCursorPosition(10, 5); Console.Write("Ingrese el numero de Liquidacion:");
            int numLiquidacion = int.Parse(Console.ReadLine());

            Console.SetCursorPosition(10, 6); Console.Write("Ingrese la identificacion del Paciente:");
            int idPaciente = int.Parse(Console.ReadLine());

            Console.SetCursorPosition(10, 7); Console.Write("Ingrese el tipo de afiliacion (subsidiado / contributivo):");
            string tipoAfiliacion = Console.ReadLine();

            Console.SetCursorPosition(10, 8); Console.Write("Ingrese el salario devengado:");
            double salarioDevengado = double.Parse(Console.ReadLine());

            Console.SetCursorPosition(10, 9); Console.Write("Ingrese el valor del servicio:");
            double valorServicio = int.Parse(Console.ReadLine());

            Console.SetCursorPosition(10, 10); Console.Write("Ingrese el año:");
            int year = int.Parse(Console.ReadLine());

            Console.SetCursorPosition(10, 11); Console.Write("Ingrese el mes (1-12):");
            int month = int.Parse(Console.ReadLine());

            Console.SetCursorPosition(10, 12); Console.Write("Ingrese el día:");
            int day = int.Parse(Console.ReadLine());

            DateTime fechaPersonalizada = CrearFechaPersonalizada(year, month, day);

            LiquidacionCuotaModeradora liquidacion = new LiquidacionCuotaModeradora(numLiquidacion, idPaciente, tipoAfiliacion, salarioDevengado, valorServicio, fechaPersonalizada);
            Console.SetCursorPosition(10, 14); Console.Write(Guardar(liquidacion));
            Console.ReadKey();
        }
        public DateTime CrearFechaPersonalizada(int year, int month, int day)
        {
            return new DateTime(year, month, day);
        }

        //b) visualizar todas las liquidaciones
        public List<LiquidacionCuotaModeradora> ConsultarTodos()
        {
            return liquidacionCuotaModeradoraList;
        }

        public void MostrarLiquidaciones()
        {
            Console.Clear();
            Console.SetCursorPosition(20, 2); Console.Write("CONSULTAS DE LIQUIDACIONES");
            Console.SetCursorPosition(1, 5); Console.Write("--------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(1, 6); Console.Write("| Numero De Liquidacion |    Id Paciente    | Tipo Afiliacion |  salarioDevengado  |  valorServicio  |  fechaLiquidacion  |    tarifa    |   cuotaModerada   |");
            Console.SetCursorPosition(1, 7); Console.Write("--------------------------------------------------------------------------------------------------------------------------------------------------------------");
            
            int posicion = 8;
            foreach (var item in liquidacionCuotaModeradoraRepository.ConsultarTodos())
            {
                Console.SetCursorPosition(2,posicion); Console.Write(item.numLiquidacion);
                Console.SetCursorPosition(27,posicion); Console.Write(item.idPaciente);
                Console.SetCursorPosition(47,posicion); Console.Write(item.tipoAfiliacion);
                Console.SetCursorPosition(66,posicion); Console.Write(item.salarioDevengado);
                Console.SetCursorPosition(87,posicion); Console.Write(item.valorServicio);
                Console.SetCursorPosition(105,posicion); Console.Write(item.fechaLiquidacion.Date.ToString("dd/MM/yyyy"));
                Console.SetCursorPosition(126,posicion); Console.Write(item.tarifa);
                Console.SetCursorPosition(141,posicion); Console.Write(item.cuotaModerada);
                posicion++;
            }
            Console.ReadKey();
        }

        //4. eliminar liquidacion
        public void EliminarLiquidacion()
        {
            try
            {
                Console.Clear();
                Console.SetCursorPosition(20, 2); Console.Write("ELIMINAR LIQUIDACION");
                Console.SetCursorPosition(1, 5); Console.Write("--------------------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.SetCursorPosition(1, 6); Console.Write("| Numero De Liquidacion |    Id Paciente    | Tipo Afiliacion |  salarioDevengado  |  valorServicio  |  fechaLiquidacion  |    tarifa    |   cuotaModerada   |");
                Console.SetCursorPosition(1, 7); Console.Write("--------------------------------------------------------------------------------------------------------------------------------------------------------------");
                List<LiquidacionCuotaModeradora> liquidaciones = ConsultarTodos();
                int posicion = 8;
                foreach (var item in liquidacionCuotaModeradoraRepository.ConsultarTodos())
                {
                    Console.SetCursorPosition(2, posicion); Console.Write(item.numLiquidacion);
                    Console.SetCursorPosition(27, posicion); Console.Write(item.idPaciente);
                    Console.SetCursorPosition(47, posicion); Console.Write(item.tipoAfiliacion);
                    Console.SetCursorPosition(66, posicion); Console.Write(item.salarioDevengado);
                    Console.SetCursorPosition(87, posicion); Console.Write(item.valorServicio);
                    Console.SetCursorPosition(105, posicion); Console.Write(item.fechaLiquidacion.Date.ToString("dd/MM/yyyy"));
                    Console.SetCursorPosition(126, posicion); Console.Write(item.tarifa);
                    Console.SetCursorPosition(141, posicion); Console.Write(item.cuotaModerada);
                    posicion++;
                }
                Console.SetCursorPosition(10, posicion+2); Console.Write("INGRESE EL NUMERO DE LIQUIDACION A ELIMINAR: ");
                int numeroLiquidacion = int.Parse(Console.ReadLine());
                LiquidacionCuotaModeradora liquidacion = liquidacionCuotaModeradoraRepository.Buscar(numeroLiquidacion);

                if (liquidacion != null)
                {
                    liquidacionCuotaModeradoraRepository.EliminarLiquidacion(numeroLiquidacion);
                    Console.SetCursorPosition(10, posicion + 4); Console.WriteLine($"Se eliminó la liquidación con número de liquidación {numeroLiquidacion} satisfactoriamente.");
                    Console.ReadKey();
                }
                else
                {
                    Console.SetCursorPosition(10, posicion + 4);Console.WriteLine($"No se encontró ninguna liquidación con el número de liquidación {numeroLiquidacion}.");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar la liquidación: {ex.Message}");
            }
        }


        //5. modificar liquidacion




        /*c) consulta que permita filtrar por tipo de afiliación totalizando cantidad de liquidaciones
        realizadas, liquidaciones del régimen subsidiado y liquidaciones de régimen contributivo,*/

        public void ConsultarTotalLiquidacionesPorAfiliacion()
        {
            Console.Clear();
            Console.SetCursorPosition(20, 2); Console.Write("CONSULTAS POR TIPO DE AFILIACION");
            try
            {
                liquidacionCuotaModeradoraList = liquidacionCuotaModeradoraRepository.ConsultarTodos();

                int totalLiquidaciones = liquidacionCuotaModeradoraList.Count;
                int totalSubsidiado = liquidacionCuotaModeradoraList.Count(l => l.tipoAfiliacion.Equals("Subsidiado", StringComparison.OrdinalIgnoreCase));
                int totalContributivo = liquidacionCuotaModeradoraList.Count(l => l.tipoAfiliacion.Equals("Contributivo", StringComparison.OrdinalIgnoreCase));

                string resultado;

                if (totalLiquidaciones == 0)
                    resultado = "No hay liquidaciones registradas.";
                else
                    Console.SetCursorPosition(0,4);resultado =
                    "---------------------------------------------\n" +
                    $"Total de Liquidaciones Realizadas: {totalLiquidaciones}\n" +
                    $"Total de Liquidaciones del Régimen Subsidiado: {totalSubsidiado}\n" +
                    $"Total de Liquidaciones del Régimen Contributivo: {totalContributivo}\n" +
                    "---------------------------------------------";

                    Console.WriteLine(resultado);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al consultar las liquidaciones por tipo de afiliación: {ex.Message}");
            }
            Console.ReadKey();
        }


        /*d) consulta que permita visualizar el valor total de las cuotas moderadoras liquidadas y el valor
        total liquidado por tipo de afiliación régimen subsidiado y régimen contributivo*/

        public void ConsultarValorTotalPorAfiliacion()
        {
            Console.Clear();
            Console.SetCursorPosition(20, 2); Console.Write("CONSULTA DE VALOR TOTAL POR TIPO DE AFILIACION");
            try
            {
                liquidacionCuotaModeradoraList = liquidacionCuotaModeradoraRepository.ConsultarTodos();

                if (liquidacionCuotaModeradoraList.Count > 0)
                {
                    double valorTotalCuotasModeradoras = 0;
                    double valorTotalSubsidiado = 0;
                    double valorTotalContributivo = 0;

                    foreach (var liquidacion in liquidacionCuotaModeradoraList)
                    {
                        double cuotaModeradora = liquidacion.cuotaModerada;
                        valorTotalCuotasModeradoras += cuotaModeradora;

                        if (string.Equals(liquidacion.tipoAfiliacion, "Subsidiado", StringComparison.OrdinalIgnoreCase))
                        {
                            valorTotalSubsidiado += cuotaModeradora;
                        }
                        else if (string.Equals(liquidacion.tipoAfiliacion, "Contributivo", StringComparison.OrdinalIgnoreCase))
                        {
                            valorTotalContributivo += cuotaModeradora;
                        }
                    }

                    Console.SetCursorPosition(10, 4); Console.WriteLine($"Valor Total de Cuotas Moderadoras Liquidadas: {valorTotalCuotasModeradoras}");
                    Console.SetCursorPosition(10, 5); Console.WriteLine($"Valor Total Liquidado por Régimen Subsidiado: {valorTotalSubsidiado}");
                    Console.SetCursorPosition(10, 6); Console.WriteLine($"Valor Total Liquidado por Régimen Contributivo: {valorTotalContributivo}");
                    
                }
                else
                {
                    Console.WriteLine("No hay liquidaciones registradas.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al consultar el valor total por tipo de afiliación: {ex.Message}");
            }
            Console.ReadKey();
        }

        /*e) consulta que permita filtrar las liquidaciones realizadas en un mes y año especifico, mostrando
        los totalizado del punto c y d*/





        //f) consulta que permita filtrar por nombres que coincidan con la palabra digitada


    }
}
