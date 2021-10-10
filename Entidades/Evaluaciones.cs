using System;

namespace CoreEscuela.Entidades
{
    public class Evaluaciones
    {
        public string UniqueID { get; private set; }

        public string Nombre { get; set; }

        public double Nota { get; set; }

        //constructor compacto con asignador lambda
        public Evaluaciones() => UniqueID = Guid.NewGuid().ToString();
    }
}