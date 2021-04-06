
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ClienteWebMatricula.Models
{
    public class ModelCursos
    {
        
        public int Codigo { get; set; }

        public string Nombre { get; set; }

        public string NombreCarrera { get; set; }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }


    }
}