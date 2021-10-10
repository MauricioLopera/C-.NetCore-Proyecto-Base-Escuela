using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Alumno
    {
        public string UniqueID { get; private set; }

        public string Nombre { get; set; }

        public List<Evaluaciones> Evaluaciones { get; set; }

        //constructor compacto con asignador lambda
        public Alumno() => UniqueID = Guid.NewGuid().ToString();
    }
}