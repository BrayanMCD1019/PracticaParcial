using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class LiquidacionCuotaModeradora
    {
        public int numLiquidacion {  get; set; }
        public int idPaciente { get; set;}
        public string tipoAfiliacion { get; set; }
        public double salarioDevengado { get; set; }
        public double valorServicio { get; set; }
        public DateTime fechaLiquidacion { get; set; }
        public double cuotaModerada { get; set; }
        public double tarifa { get; set; }

        public LiquidacionCuotaModeradora()
        {
        }

        public LiquidacionCuotaModeradora(int numLiquidacion, int idPaciente, string tipoAfiliacion, double salarioDevengado, double valorServicio, DateTime fechaLiquidacion, double cuotaModerada, double tarifa)
        {
            this.numLiquidacion = numLiquidacion;
            this.idPaciente = idPaciente;
            this.tipoAfiliacion = tipoAfiliacion;
            this.salarioDevengado = salarioDevengado;
            this.valorServicio = valorServicio;
            this.fechaLiquidacion = fechaLiquidacion;
            this.cuotaModerada = cuotaModerada;
            this.tarifa = tarifa;
        }
        public override string ToString()
        {
            return $"{numLiquidacion};{idPaciente};{tipoAfiliacion};{salarioDevengado};{valorServicio};{fechaLiquidacion};{cuotaModerada};{tarifa};";
        }

    }
}
