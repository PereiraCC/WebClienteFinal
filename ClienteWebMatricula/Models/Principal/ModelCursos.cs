
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClienteWebMatricula.Models.Secundarias;
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

        public void cargarDatosNuevos(Cursos curso)
        {
            try
            {
                this.Codigo = curso.Codigo;
                this.Nombre = curso.Nombre;
                this.NombreCarrera = curso.NombreCarrera;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}