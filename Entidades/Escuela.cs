using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Escuela
    {
        public string UniqueID { get; private set; }=Guid.NewGuid().ToString();
        //propiedades
        private string nombre;

        //encapsulamiento de propiedades
        public string Nombre
        {
            get {return nombre;  }
            set {nombre = value.ToUpper();   }
        }

        //es lo mismo que en la anterior propiedad pero dejamos que el IDE cree la variable automaticamente
        public int AñoDeCreacion{ get; set; }

        public string Pais { get; set; }

        //creo propiedad con la plantilla creada por mi
        public TiposEscuela TipoEscuela { get; set; }

        public List<Curso> Cursos { get; set; }
        
        


        
        //creacion del metodo constructor de forma estandar no es obligatorio porque C# lo crea automaticamente pero nos da mas control, recibe parametros minimos para crear el objeto
        // public Escuela(string nombre, int año)
        // {
        //     //el this nos permite seleccionar la variable de la clase principal y asi pueden tener el mismo nombre que la variable del constructor
        //     this.nombre = nombre;
        //     AñoDeCreacion = año;
        // }

        //creacion de constructor por asignacion de tuplas
        public Escuela(string nombre, int año) => (Nombre, AñoDeCreacion) = (nombre, año);

        //podemos crear multiples constructores con diferentes cantidades de parametros incluso opcionales
        public Escuela(string nombre, int año, TiposEscuela tipo, string pais = "")
        {
            (Nombre, AñoDeCreacion) = (nombre, año);
            TipoEscuela = tipo;
            Pais = pais;
        }

        //metodo override para sobreescribir la respuesta del objeto padre heredado a Escuela
        //System.Environment.NewLine es lo mismo que \n pero mas seguro para portabilidad entre sistemas operativos usando variables de entorno
        public override string ToString()
        {
            return $"Nombre: {Nombre} \nTipo: {TipoEscuela} {System.Environment.NewLine}Pais: {Pais} \nAño: {AñoDeCreacion}";
        }

    }
}