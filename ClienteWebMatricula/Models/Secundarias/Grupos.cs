using ClienteWebMatricula.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteWebMatricula.Models.Secundarias
{
    public class Grupos
    {
        public string codigoProfesor { get; set; }

        public string NombreProfesor { get; set; }

        public string Numero { get; set; }

        public string nombreCurso { get; set; }

        public string codigoHorario { get; set; }

        public string Horario { get; set; }

        public string codigoPeriodo { get; set; }

        public string Periodo { get; set; }

        public Grupos CargarDatosNuevos(GruposModel grupo)
        {
            Grupos t = new Grupos();
            t.Numero = grupo.Numero;
            t.codigoProfesor = grupo.codigoProfesor;
            t.NombreProfesor = obtenerNombreProfesor(grupo.codigoProfesor);
            t.nombreCurso = grupo.nombreCurso;
            t.codigoHorario = grupo.codigoHorario;
            t.Horario = obtenerHorario(grupo.codigoHorario);
            t.codigoPeriodo = grupo.codigoPeriodo;
            t.Periodo = obtenerPeriodo(grupo.codigoPeriodo);

            return t;

        }

        private string obtenerNombreProfesor(string codigoProfesor)
        {
            try
            {
                ProfesoresController controller = new ProfesoresController();

                List<ModelUsuario> profesores = controller.ConnectGET();

                foreach(ModelUsuario temp in profesores)
                {
                    if (temp.NumeroIdentificacion.Equals(codigoProfesor))
                    {
                        return temp.Nombre + " " + temp.Apellidos;
                    }
                }

                return "Sin Nombre";
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private string obtenerHorario(string codigoHorario)
        {
            try
            {
                HorariosController controller = new HorariosController();

                List<HorarioModel> horarios = controller.ConnectGET();

                foreach (HorarioModel temp in horarios)
                {
                    if (temp.Codigo == Int32.Parse(codigoHorario))
                    {
                        return temp.Dia + " " + temp.HoraInicio.ToString() + " - " + temp.HoraFinal.ToString();
                    }
                }

                return "Horario No encontrado";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string obtenerPeriodo(string codigoPeriodo)
        {
            try
            {
                PeriodosController controller = new PeriodosController();

                List<PeriodosModel> periodos = controller.ConnectGET();

                foreach (PeriodosModel temp in periodos)
                {
                    if (temp.Numero.Equals(codigoPeriodo))
                    {
                        return temp.FechaInicial.ToShortDateString() + " - " + temp.FechaFinal.ToShortDateString();
                    }
                }

                return "Periodo No encontrado";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
