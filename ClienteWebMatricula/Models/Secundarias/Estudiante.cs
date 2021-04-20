using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClienteWebMatricula.Models.Secundarias
{
    public class Estudiante
    {


        public string nombre { get; set; }
        public  string Apellidos { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string idtipoIdentificacion { get; set; }
        
        public string idtipoUsuario { get; set; }

        public string Telefonos { get; set; }

        public string emails { get; set; }

        public DateTime fechanacimiento { get; set; }

        public List<string> tiposIdentificacion { get; set; }

        public int idusuario { get; set; }
        public Estudiante()
        {
            

        }

        public Estudiante CargarDatosNuevos (ModelUsuario estudiante)
        {
            Estudiante t = new Estudiante();
            t.nombre = estudiante.Nombre;
            t.Apellidos = estudiante.Apellidos;
            t.NumeroIdentificacion = estudiante.NumeroIdentificacion;
            t.idtipoIdentificacion = estudiante.TipoIdentificacion;
            t.idtipoUsuario = estudiante.TipoUsuario;
            t.fechanacimiento = estudiante.FechaNac;
            string tempEmail = null;
            string tempTel = null;
            foreach (ModelTelefonos temp in estudiante.Telefonos)
            {
                string y = temp.telefono + "/";
                tempTel = tempTel + y;
            }
            t.Telefonos = tempTel;

            foreach (ModelEmails temp in estudiante.Emails)
            {
                string j = temp.email + "/";
                tempEmail = tempEmail + j;
            }
            t.emails = tempEmail;
            int Tempidusuario = 0;
            foreach (ModelEmails temp in estudiante.Emails)
            {
                Tempidusuario = temp.idUsuario;

            }
            t.idusuario = Tempidusuario;

            return t;

        }

        


    }
}