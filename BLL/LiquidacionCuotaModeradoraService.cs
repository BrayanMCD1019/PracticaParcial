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

        //4. eliminar liquidacion
        public bool EliminarEstablecimiento(int numLiquidacion)
        {
            return liquidacionCuotaModeradoraRepository.Eliminar(numLiquidacion);
        }

        //5. modificar liquidacion



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
            foreach (var item in ConsultarTodos())
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

        private double CalcularTarifaAfiliadoContributivo(double salarioDevengado)
        {
            throw new NotImplementedException();
        }

        public void ConsultarTotalLiquidacionesPorAfiliacion()
        {
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
                    resultado = $"Consulta por tipo de afiliación\n" +
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
        }

        public void ConsultarValorTotalPorAfiliacion()
        {
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
                        double cuotaModeradora = CalcularCuotaModeradora(liquidacion);
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

                    Console.WriteLine("Consulta de valor total por tipo de afiliación");
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine($"Valor Total de Cuotas Moderadoras Liquidadas: {valorTotalCuotasModeradoras}");
                    Console.WriteLine($"Valor Total Liquidado por Régimen Subsidiado: {valorTotalSubsidiado}");
                    Console.WriteLine($"Valor Total Liquidado por Régimen Contributivo: {valorTotalContributivo}");
                    Console.WriteLine("--------------------------------------------");
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
        }

        private double CalcularCuotaModeradora(LiquidacionCuotaModeradora liquidacion)
        {
            throw new NotImplementedException();
        }

        /*c) consulta que permita filtrar por tipo de afiliación totalizando cantidad de liquidaciones
        realizadas, liquidaciones del régimen subsidiado y liquidaciones de régimen contributivo,*/


        /*d) consulta que permita visualizar el valor total de las cuotas moderadoras liquidadas y el valor
        total liquidado por tipo de afiliación régimen subsidiado y régimen contributivo*/


        /*e) consulta que permita filtrar las liquidaciones realizadas en un mes y año especifico, mostrando
        los totalizado del punto c y d*/


        //f) consulta que permita filtrar por nombres que coincidan con la palabra digitada


    }
}
