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
            try
            {
                liquidacionCuotaModeradoraList = liquidacionCuotaModeradoraRepository.ConsultarTodos();

                if (liquidacionCuotaModeradoraList.Count == 0)
                {
                    Console.WriteLine("No hay liquidaciones registradas.");
                    return;
                }

                Console.WriteLine("Lista de liquidaciones realizadas:");
                Console.WriteLine("-----------------------------------");

                foreach (var liquidacion in liquidacionCuotaModeradoraList)
                {
                    double tarifaCuotaModeradora = 0;
                    double cuotaModeradora = 0;

                    tarifaCuotaModeradora = liquidacion.tipoAfiliacion.Equals("Subsidiado", StringComparison.OrdinalIgnoreCase) ? 0.5 : CalcularTarifaAfiliadoContributivo(liquidacion.salarioDevengado);

                    cuotaModeradora = Math.Min(liquidacion.valorServicio * tarifaCuotaModeradora, 200000);

                    Console.WriteLine($"Identificación del Paciente: {liquidacion.idPaciente}");
                    Console.WriteLine($"Tipo de Afiliación: {liquidacion.tipoAfiliacion}");
                    Console.WriteLine($"Salario Devengado por el Paciente: {liquidacion.salarioDevengado}");
                    Console.WriteLine($"Valor del Servicio de Hospitalización Prestado: {liquidacion.valorServicio}");
                    Console.WriteLine($"Tarifa Aplicada: {tarifaCuotaModeradora}");
                    Console.WriteLine($"Valor Liquidado Real de la Cuota Moderadora: {cuotaModeradora}");
                    Console.WriteLine(cuotaModeradora == 200000 ? "Se aplicó el tope máximo." : "No se aplicó el tope máximo.");
                    Console.WriteLine($"Valor de la Cuota Moderadora: {cuotaModeradora}");
                    Console.WriteLine("-----------------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al mostrar las liquidaciones: {ex.Message}");
            }
        }

        private double CalcularTarifaAfiliadoContributivo(double salarioPaciente)
        {
            double salarioMinimo = 1160000;
            double tarifaCuotaModeradora = 0;

            double factor = salarioPaciente / salarioMinimo;

            switch (factor)
            {
                case var _ when factor < 2:
                    tarifaCuotaModeradora = 0.15;
                    break;
                case var _ when factor < 5:
                    tarifaCuotaModeradora = 0.2;
                    break;
                default:
                    tarifaCuotaModeradora = 0.25;
                    break;
            }

            return tarifaCuotaModeradora;
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
