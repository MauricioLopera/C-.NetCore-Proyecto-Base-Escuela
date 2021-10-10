using static System.Console;

namespace CoreEscuela.Util
{
    public static class Printer
    {
        public static void DibujarLinea(int tam = 20)
        {
            WriteLine("".PadLeft(tam,'='));
        }
        public static void EscribeTitulos(string titulo)
        {
            DibujarLinea(titulo.Length);
            WriteLine(titulo);
            DibujarLinea(titulo.Length);
        }
    }
}