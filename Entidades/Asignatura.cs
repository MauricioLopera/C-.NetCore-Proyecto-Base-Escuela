using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Asignatura
    {
        public string UniqueID { get; private set; }

        public string Nombre { get; set; }

        public List<Alumno> Alumnos { get; set; }

        //constructor compacto con asignador lambda
        public Asignatura() => UniqueID = Guid.NewGuid().ToString();
    }
}