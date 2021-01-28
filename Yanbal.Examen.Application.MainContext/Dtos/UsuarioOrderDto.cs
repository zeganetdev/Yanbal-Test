
namespace Yanbal.Examen.Application.MainContext.Dtos
{
    public class UsuarioOrderDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is UsuarioOrderDto item)) return false;
            return this.Nombre.Equals(item.Nombre) && this.Apellido.Equals(item.Apellido);
        }
        public override int GetHashCode() => (Nombre, Apellido).GetHashCode();
    }
}
