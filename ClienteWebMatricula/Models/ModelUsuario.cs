using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClienteWebMatricula.Models
{
    public class ModelUsuario
    {
        public string NumeroIdentificacion { get; set; }

        public string TipoIdentificacion { get; set; }

        public string TipoUsuario { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public DateTime FechaNac { get; set; }

        public List<ModelTelefonos> Telefonos { get; set; }

        public List<ModelEmails> Emails { get; set; }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }

    }
}
