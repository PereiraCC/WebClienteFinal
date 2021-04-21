using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteWebMatricula.Models.Secundarias
{
    public class Profesor
    {
        public string nombre { get; set; }
        public string Apellidos { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string idtipoIdentificacion { get; set; }

        public string idtipoUsuario { get; set; }

        public string Telefonos { get; set; }

        public string emails { get; set; }

        public DateTime fechanacimiento { get; set; }

        public List<string> tiposIdentificacion { get; set; }

        public int idusuario { get; set; }
        public Profesor()
        {
        }

        public Profesor CargarDatosNuevos(ModelUsuario profesor)
        {
            Profesor t = new Profesor();
            t.nombre = profesor.Nombre;
            t.Apellidos = profesor.Apellidos;
            t.NumeroIdentificacion = profesor.NumeroIdentificacion;
            t.idtipoIdentificacion = profesor.TipoIdentificacion;
            t.idtipoUsuario = profesor.TipoUsuario;
            t.fechanacimiento = profesor.FechaNac;
            string tempEmail = null;
            string tempTel = null;
            foreach (ModelTelefonos temp in profesor.Telefonos)
            {
                string y = temp.telefono + "/";
                tempTel = tempTel + y;
            }
            t.Telefonos = tempTel;

            foreach (ModelEmails temp in profesor.Emails)
            {
                string j = temp.email + "/";
                tempEmail = tempEmail + j;
            }
            t.emails = tempEmail;
            int Tempidusuario = 0;
            foreach (ModelEmails temp in profesor.Emails)
            {
                Tempidusuario = temp.idUsuario;

            }
            t.idusuario = Tempidusuario;

            return t;

        }
    }
}
