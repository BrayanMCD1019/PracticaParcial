using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LiquidacionCuotaModeradoraRepository
    {
        string fileName = "liquidaciones.txt";
        public string Guardar(LiquidacionCuotaModeradora liquidacionCuotaModeradora)
        {

            var escritor = new StreamWriter(fileName, true);
            escritor.WriteLine(liquidacionCuotaModeradora.ToString());
            escritor.Close();
            return $"se agrego la liquidacion {liquidacionCuotaModeradora.idPaciente}";
        }
    }
}
