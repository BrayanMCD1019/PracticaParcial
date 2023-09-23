using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ILiquidacionCuotaModeradoraService
    {
        double CalcularCuotaModeradora(LiquidacionCuotaModeradora liquidacion);
        List<LiquidacionCuotaModeradora> ObtenerTodasLasLiquidaciones();
        List<LiquidacionCuotaModeradora> ConsultarPorTipoAfiliacion(string tipoAfiliacion);
        List<LiquidacionCuotaModeradora> FiltrarPorFecha(DateTime fechaInicio, DateTime fechaFin);
    }
}
