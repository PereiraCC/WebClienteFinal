using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClienteWebMatricula.Models.Secundarias;
using Newtonsoft.Json;

namespace ClienteWebMatricula.Models.Crear
{
    public class ModelUsuarioPos
    {
        public string NumeroIdentificacion { get; set; }

        public string idTipoIdentificacion { get; set; }

        public string idTipoUsuario { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public DateTime FechaNac { get; set; }

        
        public List<Telefono> Telefonos { get; set; }

        public List<Email> Emails { get; set; }
      
        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }

        public string ToJson()
        {
            string iden = this.NumeroIdentificacion;
            string nombre = this.Nombre;
            string apellidos = this.Apellidos;
            string fecha = this.FechaNac.ToShortDateString();
            //return "{NumeroIdentificacion:" + '"' + iden + '"' + "Nombre:" + '"' + nombre + '"' + "Apellidos:" + '"' + apellidos + '"' + "FechaNac:" + '"' + fecha + '"' + '}';
            return iden + ',' + nombre + ',' + apellidos + ',' + fecha;

        }

        public void cargarDatosNuevos(Estudiante estudiante)
        {
            try
            {
                //ModelUsuario temp = new ModelUsuario();
                List<Email> emails = new List<Email>();
                List<Telefono> telefonos = new List<Telefono>();

                this.Nombre = estudiante.nombre;
                this.Apellidos = estudiante.Apellidos;
                this.NumeroIdentificacion = estudiante.NumeroIdentificacion;
                if (estudiante.idtipoIdentificacion.Equals("Cédula de Identidad"))
                {
                    this.idTipoIdentificacion = "1";
                }
                else if (estudiante.idtipoIdentificacion.Equals("DIMEX"))
                {
                    this.idTipoIdentificacion = "2";
                }
                else if (estudiante.idtipoIdentificacion.Equals("Cédula de Residencia"))
                {
                    this.idTipoIdentificacion = "3";
                }
                else
                {
                    this.idTipoIdentificacion = "4";
                }
                this.FechaNac = estudiante.fechanacimiento;
                this.idTipoUsuario = "2";
                string[] tempEmail = estudiante.emails.Split('/');
                string[] tempTel = estudiante.Telefonos.Split('/');

                foreach (string t in tempEmail)
                {
                    Email email = new Email();
                    email.email = t;
                    //email.idUsuario = estudiante.idusuario;

                    emails.Add(email);

                }
                this.Emails = emails;

                foreach (string t in tempTel)
                {
                    Telefono telefono = new Telefono();
                    telefono.telefono = t;
                    //telefono.idUsuario = estudiante.idusuario;

                    telefonos.Add(telefono);

                }
                this.Telefonos = telefonos;
                //return temp;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void cargarDatosNuevos(Profesor profesor)
        {
            try
            {
                //ModelUsuario temp = new ModelUsuario();
                List<Email> emails = new List<Email>();
                List<Telefono> telefonos = new List<Telefono>();

                this.Nombre = profesor.nombre;
                this.Apellidos = profesor.Apellidos;
                this.NumeroIdentificacion = profesor.NumeroIdentificacion;
                if (profesor.idtipoIdentificacion.Equals("Cédula de Identidad"))
                {
                    this.idTipoIdentificacion = "1";
                }
                else if (profesor.idtipoIdentificacion.Equals("DIMEX"))
                {
                    this.idTipoIdentificacion = "2";
                }
                else if (profesor.idtipoIdentificacion.Equals("Cédula de Residencia"))
                {
                    this.idTipoIdentificacion = "3";
                }
                else
                {
                    this.idTipoIdentificacion = "4";
                }
                this.FechaNac = profesor.fechanacimiento;
                this.idTipoUsuario = "1";
                string[] tempEmail = profesor.emails.Split('/');
                string[] tempTel = profesor.Telefonos.Split('/');

                foreach (string t in tempEmail)
                {
                    Email email = new Email();
                    email.email = t;

                    emails.Add(email);

                }
                this.Emails = emails;

                foreach (string t in tempTel)
                {
                    Telefono telefono = new Telefono();
                    telefono.telefono = t;

                    telefonos.Add(telefono);

                }
                this.Telefonos = telefonos;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
