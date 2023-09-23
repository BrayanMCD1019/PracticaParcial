using DLL;
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
        void ILiquidacionCuotaModeradoraService.CalcularCuotaModeradora(LiquidacionCuotaModeradora liquidacion)
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
