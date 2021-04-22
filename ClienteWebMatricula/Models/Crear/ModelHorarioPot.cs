using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteWebMatricula.Models.Crear
{
    public class ModelHorarioPot
    {
        public int Codigo { get; set; }

        public string dia { get; set; }

        public TimeSpan HoraInicio { get; set; }

        public TimeSpan HoraFinal { get; set; }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }

        public void cargarDatosNuevos(HorarioModel horario)
        {
            try
            {
                this.Codigo = horario.Codigo;
                this.dia = horario.Dia;
                this.HoraInicio = horario.HoraInicio;
                this.HoraFinal = horario.HoraFinal;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
