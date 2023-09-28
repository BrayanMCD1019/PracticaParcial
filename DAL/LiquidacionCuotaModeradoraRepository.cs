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

        public string Guardar(List<LiquidacionCuotaModeradora> liquidacionCuotaModeradora)
        {
            var escritor = new StreamWriter(fileName);
            foreach (var item in liquidacionCuotaModeradora)
            {
                escritor.WriteLine(item.ToString());
            }

            escritor.Close();
            return $"archivo actualizado";
        }

        public List<LiquidacionCuotaModeradora> ConsultarTodos()
        {
            var listaLiquidaciones = new List<LiquidacionCuotaModeradora>();
            try
            {
                StreamReader lector = new StreamReader(fileName);
                while (!lector.EndOfStream)
                {
                    listaLiquidaciones.Add(Map(lector.ReadLine()));
                }
                lector.Close();
                return listaLiquidaciones;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void EliminarLiquidacion(int numeroLiquidacion)
        {
            try
            {
                List<LiquidacionCuotaModeradora> liquidaciones = ConsultarTodos();
                FileStream file = new FileStream(fileName, FileMode.Create);
                file.Close();

                foreach (var item in liquidaciones)
                {
                    if (item.numLiquidacion != numeroLiquidacion)
                    {
                        Guardar(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar la liquidación: {ex.Message}");
            }
        }

        public LiquidacionCuotaModeradora Buscar(int numeroLiquidacion)
        {
            List<LiquidacionCuotaModeradora> liquidaciones = ConsultarTodos();
            return liquidaciones.FirstOrDefault(liq => liq.numLiquidacion == numeroLiquidacion);
        }

        private LiquidacionCuotaModeradora Map(string linea)
        {
            var liq = new LiquidacionCuotaModeradora();
            liq.numLiquidacion= int.Parse(linea.Split(';')[0]);
            liq.idPaciente = int.Parse(linea.Split(';')[1]);
            liq.tipoAfiliacion = linea.Split(';')[2];
            liq.salarioDevengado = double.Parse(linea.Split(';')[3]);
            liq.valorServicio = double.Parse(linea.Split(';')[4]);
            liq.fechaLiquidacion= DateTime.Parse(linea.Split(';')[5]);
            liq.tarifa = double.Parse(linea.Split(';')[6]); 
            liq.cuotaModerada = double.Parse(linea.Split(';')[7]);
            return liq;
        }
    }
}
