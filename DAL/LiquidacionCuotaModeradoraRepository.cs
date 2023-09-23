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
            var listaPersonas = new List<LiquidacionCuotaModeradora>();
            try
            {
                StreamReader lector = new StreamReader(fileName);
                while (!lector.EndOfStream)
                {
                    listaPersonas.Add(Map(lector.ReadLine()));
                }
                lector.Close();
                return listaPersonas;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Eliminar(int numLiquidacion)
        {
            try
            {
                var listaLiquidaciones = ConsultarTodos();
                if (listaLiquidaciones != null)
                {
                    var LiquidacionAEliminar = listaLiquidaciones.FirstOrDefault(liq => liq.numLiquidacion == numLiquidacion);
                    if (LiquidacionAEliminar != null)
                    {
                        listaLiquidaciones.Remove(LiquidacionAEliminar);
                        using (var escritor = new StreamWriter(fileName, false))
                        {
                            foreach (var liquidacion in listaLiquidaciones)
                            {
                                escritor.WriteLine(liquidacion.ToString());
                            }
                        }
                        return true;
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error al Eliminar la liquidacion...");
            }
            return false;
        }

        private LiquidacionCuotaModeradora Map(string linea)
        {
            var liq = new LiquidacionCuotaModeradora();
            liq.numLiquidacion= int.Parse(linea.Split(';')[0]);
            liq.idPaciente = int.Parse(linea.Split(';')[1]);
            liq.tipoAfiliacion = linea.Split(';')[3];
            liq.salarioDevengado = double.Parse(linea.Split(';')[4]);
            liq.valorServicio = double.Parse(linea.Split(';')[5]);
            liq.fechaLiquidacion= DateTime.Parse(linea.Split(';')[6]);
            liq.cuotaModerada = double.Parse(linea.Split(';')[7]);
            liq.tarifa = double.Parse(linea.Split(';')[8]); 
            return liq;
        }
    }
}
