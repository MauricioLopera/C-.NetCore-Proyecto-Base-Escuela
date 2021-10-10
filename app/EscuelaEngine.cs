using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;

namespace CoreEscuela
{
    public class EscuelaEngine
    {

        public Escuela escuela { get; set; }

        public void Inicializar()
        {
            escuela = new Escuela("Centro de Prueba", 2021);

            escuela.Pais = "Colombia";
            escuela.TipoEscuela = TiposEscuela.Primaria;

            Printer.EscribeTitulos("Bienvenido a la Escuela");
            WriteLine(escuela);

            //cargamos datos
            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();

            // var otraColeccion = new List<Curso>()
            // {
            //     new Curso(){Nombre="005A", Jornada=TipoJornada.Mañana},
            //     new Curso(){Nombre="006A", Jornada=TipoJornada.Tarde},
            //     new Curso(){Nombre="007A", Jornada=TipoJornada.Completa}
            // };

            //Agregar una coleccion a otra coleccion
            //escuela.Cursos.AddRange(otraColeccion);

            //arreglo de objetos
            // escuela.Cursos = new Curso[]
            // {
            //     new Curso(){Nombre="001A"},
            //     new Curso(){Nombre="002A"},
            //     new Curso(){Nombre="003A"}
            // };
        }

        //<Summary>
        //  Procesos de Carga de datos en las entidades
        //</Summary>
        private void CargarEvaluaciones()
        { 
            foreach (var curso in escuela.Cursos)
            {
                foreach (var asig in curso.Asignaturas)
                {
                    foreach (var alum in asig.Alumnos)
                    {
                        var listaEvaluaciones = new List<Evaluaciones>(){
                            new Evaluaciones(){Nombre="Evaluacion 1", Nota=GeneraNotaAleatoria()},
                            new Evaluaciones(){Nombre="Evaluacion 2", Nota=GeneraNotaAleatoria()},
                            new Evaluaciones(){Nombre="Evaluacion 3", Nota=GeneraNotaAleatoria()},
                            new Evaluaciones(){Nombre="Evaluacion 4", Nota=GeneraNotaAleatoria()},
                            new Evaluaciones(){Nombre="Evaluacion 5", Nota=GeneraNotaAleatoria()}
                        };

                        alum.Evaluaciones=listaEvaluaciones;
                    }

                    ImprimirEvaluacionesNota(asig);                   
                }
            }
        }

        private void CargarAsignaturas()
        {
            foreach (var curso in escuela.Cursos)
            {
                var listaAsignaturas = new List<Asignatura>(){
                    new Asignatura(){Nombre=$"Matematicas de {curso.Nombre}"},
                    new Asignatura(){Nombre=$"Ingles de {curso.Nombre}"},
                    new Asignatura(){Nombre=$"Ciencias Naturales de {curso.Nombre}"},
                    new Asignatura(){Nombre=$"Educación Fisica de {curso.Nombre}"}
                };

                curso.Asignaturas = listaAsignaturas;

                //matriculo los alumnos en las asignaturas
                MatriculaAlumnos(curso);

                ImprimirAsignaturasCursos(curso);
            }
        }

        private void CargarCursos()
        {
            escuela.Cursos = new List<Curso>()
            {
                new Curso(){Nombre="001A", Jornada=TipoJornada.Mañana},
                new Curso(){Nombre="002A", Jornada=TipoJornada.Tarde},
                new Curso(){Nombre="003A", Jornada=TipoJornada.Completa}
            };

            //Agregar un elemento a la coleccion
            escuela.Cursos.Add(new Curso() { Nombre = "004A", Jornada = TipoJornada.Mañana });

            //delegado, no es necesario declararlo C# lo asume
            Predicate<Curso> algoritmoEncapsulado = Predicado;

            escuela.Cursos.RemoveAll(algoritmoEncapsulado);

            //eliminar un elemento de una coleccion, delegado con expresion lambda
            escuela.Cursos.RemoveAll((Curso cur) => cur.Nombre == "006A");

            ImprimirCursosEscuela(escuela);

            //instancia para generacion de numeros random
            Random rnd = new Random();
            
            foreach (var cur in escuela.Cursos)
            {
                int cantRandom = rnd.Next(5,15);
                cur.Alumnos=GenerarAlumnos(cantRandom);

                ImprimirAlumnosCursos(cur);
            }
        }

        //<Summary>
        //  Metodos de Generacion
        //</Summary>
         private void MatriculaAlumnos(Curso curso)
        {
            foreach (var asig in curso.Asignaturas)
            {
                asig.Alumnos = curso.Alumnos;
            }
        }

        private List<Alumno> GenerarAlumnos(int cantidad)
        {
            string[] nombre = {"Andres","Mauricio","Alexander","Yesenia","Jonathan","Cesar","Karen","Jeanethe","Julieth","Marino","Mateo"};
            string[] papellido = {"Lopera","Rivera","Delgado","Isaza","Mosquera","Gil","Lopez","Ortiz","Pidra","Brito","Paz"};
            string[] sapellido = {"Paz","Ortiz","Lopera","Rivera","Isaza","Delgado","Mosquera","Gil","Lopez","Pidra","Brito"};

            //usamos LinQ para combinar los datos de los arrays
            var listaAlumnos = from nom in nombre
                               from ap1 in papellido
                               from ap2 in sapellido
                               select new Alumno{Nombre=$"{nom} {ap1} {ap2} "};
                            
            return listaAlumnos.OrderBy((al) => al.UniqueID).Take(cantidad).ToList();
        }

        private double GeneraNotaAleatoria()
        {
            //notas random
            Random nota = new Random();
            
            return Math.Round((nota.Next(0,4) + nota.NextDouble()),2);
        }

        //metodo delegado estandar
        private static bool Predicado(Curso obj)
        {
            if(obj.Nombre=="004A")
            {
                Printer.EscribeTitulos("Curso 004A Eliminado");
            }
            return obj.Nombre == "004A";
        }

        //<Summary>
        //  Metodos de impresion de reultados
        //</Summary>
        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            Printer.DibujarLinea();
            Printer.EscribeTitulos("Cursos de la Escuela");
            Printer.DibujarLinea();

            //el simbolo ? es como un operados AND donde valida primero si escuela es null y si no entonces valida si cursos es null
            if(escuela?.Cursos == null){
                return;
            }else{
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre: {curso.Nombre }, Id: {curso.UniqueID}");
                }
            }
            
        }
        private static void ImprimirAlumnosCursos(Curso curso)
        {
            Printer.DibujarLinea();
            Printer.EscribeTitulos($"Alumnos del Curso {curso.Nombre}");
            Printer.DibujarLinea();

            //el simbolo ? es como un operados AND donde valida primero si escuela es null y si no entonces valida si cursos es null
            if(curso?.Alumnos == null){
                return;
            }else{
                foreach (var alum in curso.Alumnos)
                {
                    WriteLine($"Nombre: {alum.Nombre }, Id: {alum.UniqueID}");
                }
            }
            
        }
        private static void ImprimirAsignaturasCursos(Curso curso)
        {
            Printer.DibujarLinea();
            Printer.EscribeTitulos($"Asignaturas del Curso {curso.Nombre}");
            Printer.DibujarLinea();

            //el simbolo ? es como un operados AND donde valida primero si escuela es null y si no entonces valida si cursos es null
            if(curso?.Asignaturas == null){
                return;
            }else{
                foreach (var asig in curso.Asignaturas)
                {
                    WriteLine($"Nombre: {asig.Nombre }, Id: {asig.UniqueID}");
                }
            }           
        }
        private static void ImprimirEvaluacionesNota(Asignatura asignatura)
        {
            Printer.DibujarLinea();
            Printer.EscribeTitulos($"Evaluaciones de la Asignatura {asignatura.Nombre}");
            Printer.DibujarLinea();

            //el simbolo ? es como un operados AND donde valida primero si escuela es null y si no entonces valida si cursos es null
            if(asignatura?.Alumnos == null){
                return;
            }else{
                foreach (var alum in asignatura.Alumnos)
                {
                    WriteLine($"Estudiante: {alum.Nombre }");
                    foreach (var eval in alum.Evaluaciones)
                    {
                        WriteLine($"--Evaluacion: {eval.Nombre }, Nota: {eval.Nota}");
                    }                 
                }
            }           
        }
    }
}