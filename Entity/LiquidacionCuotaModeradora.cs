using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class LiquidacionCuotaModeradora
    {
        public int numLiquidacion { get; set; }
        public int idPaciente { get; set; }
        public string tipoAfiliacion { get; set; }
        public double salarioDevengado { get; set; }
        public double valorServicio { get; set; }
        public DateTime fechaLiquidacion { get; set; }
        public double cuotaModerada { get; set; }
        public double tarifa { get; set; }

        public LiquidacionCuotaModeradora()
        {
        }

        public LiquidacionCuotaModeradora(int numLiquidacion, int idPaciente, string tipoAfiliacion, double salarioDevengado, double valorServicio, DateTime fechaLiquidacion)
        { 
            this.numLiquidacion = numLiquidacion;
            this.idPaciente = idPaciente;
            this.tipoAfiliacion = tipoAfiliacion;
            this.salarioDevengado = salarioDevengado;
            this.valorServicio = valorServicio;
            this.fechaLiquidacion = fechaLiquidacion;
            this.cuotaModerada = CalcularCuotaModeradora();
            this.tarifa = CalcularTarifa();
        }

        public override string ToString()
        {
            return $"{numLiquidacion};{idPaciente};{tipoAfiliacion};{salarioDevengado};{valorServicio};{fechaLiquidacion};{cuotaModerada};{tarifa};";
        }

        private double CalcularCuotaModeradora()
        {
            const double TopeMaximo = 200000;

            double tarifaCuotaModeradora = this.tarifa;

            double cuotaModeradora = this.valorServicio * tarifaCuotaModeradora;

            return cuotaModeradora <= TopeMaximo ? cuotaModeradora : TopeMaximo;
        }

        private double CalcularTarifa()
        {
            double salarioMinimo = 1160000;
            double tarifaCuotaModeradora = 0;

            double factor = this.salarioDevengado / salarioMinimo;

            if (this.tipoAfiliacion.Equals("Subsidiado", StringComparison.OrdinalIgnoreCase))
            {
                tarifaCuotaModeradora = 0.5;
            }
            else
            {
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
            }
            return tarifaCuotaModeradora;
        }

    }
}
