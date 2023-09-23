using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LiquidacionCuotaModeradoraService : ILiquidacionCuotaModeradoraService
    {
        LiquidacionCuotaModeradoraRepository liquidacionCuotaModeradoraRepository = null;
        private List<LiquidacionCuotaModeradora> liquidacionCuotaModeradoraList = null;

        public LiquidacionCuotaModeradoraService()
        {
            liquidacionCuotaModeradoraRepository = new LiquidacionCuotaModeradoraRepository();

        }

        public String Guardar(LiquidacionCuotaModeradora liquidacionCuotaModeradora)
        {
            if (liquidacionCuotaModeradora == null)
            {
                return "no se puede agregar liquidaciones nulas o sin informacion";

            }
            var msg = (liquidacionCuotaModeradoraRepository.Guardar(liquidacionCuotaModeradora));
            return msg;
        }

        double ILiquidacionCuotaModeradoraService.CalcularCuotaModeradora(LiquidacionCuotaModeradora liquidacion)
        {
            throw new NotImplementedException();
        }

        List<LiquidacionCuotaModeradora> ILiquidacionCuotaModeradoraService.ConsultarPorTipoAfiliacion(string tipoAfiliacion)
        {
            throw new NotImplementedException();
        }

        List<LiquidacionCuotaModeradora> ILiquidacionCuotaModeradoraService.FiltrarPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }

        List<LiquidacionCuotaModeradora> ILiquidacionCuotaModeradoraService.ObtenerTodasLasLiquidaciones()
        {
            throw new NotImplementedException();
        }
    }
}
