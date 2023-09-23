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


        /*c) consulta que permita filtrar por tipo de afiliación totalizando cantidad de liquidaciones
        realizadas, liquidaciones del régimen subsidiado y liquidaciones de régimen contributivo,*/


        /*d) consulta que permita visualizar el valor total de las cuotas moderadoras liquidadas y el valor
        total liquidado por tipo de afiliación régimen subsidiado y régimen contributivo*/


        /*e) consulta que permita filtrar las liquidaciones realizadas en un mes y año especifico, mostrando
        los totalizado del punto c y d*/


        //f) consulta que permita filtrar por nombres que coincidan con la palabra digitada


    }
}
