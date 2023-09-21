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
        public DateTime fechaLiquidacion { get; set }
        public double cuotaModerada { get; set }
        public double tarifa { get; set }

    }
}
