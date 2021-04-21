using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteWebMatricula.Models.Secundarias
{
    public class Periodos
    {
        public string Numero { get; set; }

        public DateTime FechaInicial { get; set; }

        public DateTime FechaFinal { get; set; }

        public string activo { get; set; }

        public Periodos CargarDatosNuevos(PeriodosModel periodo)
        {
            Periodos t = new Periodos();
            t.Numero = periodo.Numero;
            t.FechaInicial = periodo.FechaInicial;
            t.FechaFinal = periodo.FechaFinal;
            if (periodo.activo)
            {
                t.activo = "Si";
            }
            else
            {
                t.activo = "No";
            }
            

            return t;

        }
    }
}
