using ClienteWebMatricula.Models.Secundarias;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteWebMatricula.Models.Crear
{
    public class ModelPeriodosPot
    {
        public string Numero { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFinal { get; set; }

        public bool activo { get; set; }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }

        public void cargarDatosNuevos(Periodos periodo)
        {
            try
            {
                this.Numero = periodo.Numero;
                this.FechaInicio = periodo.FechaInicial;
                this.FechaFinal = periodo.FechaFinal;
                if (periodo.activo.Equals("Si"))
                {
                    this.activo = true;
                }
                else
                {
                    this.activo = false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
