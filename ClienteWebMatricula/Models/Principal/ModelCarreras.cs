using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClienteWebMatricula.Models
{
    public class ModelCarreras
    {
        public string Codigo { get; set; }

        public string Nombre { get; set; }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }
    }
}