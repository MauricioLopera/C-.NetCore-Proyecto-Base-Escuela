//podemos reutilizar los namespace para agrupar la logica de negocio de diferentes archivos pero el mismo objetivo
namespace CoreEscuela.Entidades
{
    //tipo de dato para listas de seleccion con ID, si no se asigna a las opciones C# lo asigna desde 0 automaticamente
    public enum TiposEscuela
    {
        Primaria,
        Secundaria,
        Preescolar
    }
}