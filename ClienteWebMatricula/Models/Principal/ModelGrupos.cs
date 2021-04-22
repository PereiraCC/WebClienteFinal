
using ClienteWebMatricula.Controllers;
using ClienteWebMatricula.Models.Secundarias;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClienteWebMatricula.Models
{
    public class GruposModel
    {
      
        public string codigoProfesor { get; set; }

        public string Numero { get; set; }

        public string nombreCurso { get; set; }

        public string codigoHorario { get; set; }

        public string codigoPeriodo { get; set; }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }

        public void cargarDatosNuevos(Grupos grupo)
        {
            try
            {
                this.Numero = grupo.Numero;
                this.codigoProfesor = obtenerCodigoProfesor(grupo.NombreProfesor);
                this.nombreCurso = grupo.nombreCurso;
                this.codigoHorario = obtenerCodigoHorario(grupo.Horario);
                this.codigoPeriodo = obtenerCodigoPeriodo(grupo.Periodo);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private string obtenerCodigoProfesor(string nombreProfesor)
        {
            try
            {
                ProfesoresController controller = new ProfesoresController();
                List<ModelUsuario> profesores = controller.ConnectGET();

                foreach (ModelUsuario temp in profesores)
                {
                    string t = temp.Nombre + " " +  temp.Apellidos;
                    if (t.Equals(nombreProfesor))
                    {
                        return temp.NumeroIdentificacion;
                    }
                }

                return "Sin Codigo";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string obtenerCodigoHorario(string nombreHorario)
        {
            try
            {
                HorariosController controller = new HorariosController();
                List<HorarioModel> horarios = controller.ConnectGET();
                string[] data = nombreHorario.Split(' ');

                foreach (HorarioModel temp in horarios)
                {
                    if (temp.Dia.Equals(data[0]) && (temp.HoraInicio.ToString().Equals(data[1]) && temp.HoraFinal.ToString().Equals(data[3])))
                    {
                        return temp.Codigo.ToString();
                    }
                }

                return "Sin Codigo";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string obtenerCodigoPeriodo(string nombrePerido)
        {
            try
            {
                PeriodosController controller = new PeriodosController();
                List<PeriodosModel> periodos = controller.ConnectGET();

                foreach (PeriodosModel temp in periodos)
                {
                    string t = temp.FechaInicial.ToShortDateString() + " - " + temp.FechaFinal.ToShortDateString();
                    if (t.Equals(nombrePerido))
                    {
                        return temp.Numero;
                    }
                }

                return "Sin Codigo";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}