using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteWebMatricula.Models.Secundarias
{
    public class Cursos
    {
        public int Codigo { get; set; }

        public string Nombre { get; set; }

        public string NombreCarrera { get; set; }

        public List<string> Carreras { get; set; }

        public Cursos CargarDatosNuevos(ModelCursos curso)
        {
            Cursos t = new Cursos();
            t.Codigo = curso.Codigo;
            t.Nombre = curso.Nombre;
            t.NombreCarrera = curso.NombreCarrera;
            
            return t;

        }

    }
}
