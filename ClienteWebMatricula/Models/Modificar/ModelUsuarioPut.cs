using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClienteWebMatricula.Models.Secundarias;
using Newtonsoft.Json;

namespace ClienteWebMatricula.Models.Modificar
{
    public class ModelUsuarioPut
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
                if(estudiante.idtipoIdentificacion.Equals("Cedula Identidad"))
                {
                    this.idTipoIdentificacion ="1" ;
                }else if(estudiante.idtipoIdentificacion.Equals("DIMEX"))
                {
                    this.idTipoIdentificacion = "2";
                }
                else if (estudiante.idtipoIdentificacion.Equals("Cedula Residencia"))
                {
                    this.idTipoIdentificacion = "3";
                }
                else if (estudiante.idtipoIdentificacion.Equals("Pasaporte"))
                {
                    this.idTipoIdentificacion = "4";
                }

                this.FechaNac = estudiante.fechanacimiento;
                if(estudiante.idtipoUsuario.Equals("Estudiante"))
                {
                    this.idTipoUsuario = "2";
                }
                else
                {
                    this.idTipoUsuario = "1";
                }
                
                string[] tempEmail = estudiante.emails.Split('/');
                string[] tempTel = estudiante.Telefonos.Split('/');

                foreach (string t in tempEmail)
                {
                    if (!String.IsNullOrEmpty(t))
                    {
                        Email email = new Email();
                        email.email = t;
                        //email.idUsuario = estudiante.idusuario;

                        emails.Add(email);
                    }

                }
                this.Emails = emails;

                foreach (string t in tempTel)
                {
                    if (!String.IsNullOrEmpty(t))
                    {
                        Telefono telefono = new Telefono();
                        telefono.telefono = t;
                        //telefono.idUsuario = estudiante.idusuario;

                        telefonos.Add(telefono);
                    }

                }
                this.Telefonos = telefonos;
                //return temp;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
