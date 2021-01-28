using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Yanbal.Examen.Application.MainContext.Dtos
{
    public class ClienteDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo nombre es requerido")]
        [StringLength(250)]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "El campo apellidos es requerido")]
        [StringLength(250)]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "El campo correo es requerido")]
        [EmailAddress( ErrorMessage = "El correo no es válido" )]
        [StringLength(320)]
        public string Correo { get; set; }
        [DisplayName("Fecha nacimiento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? FechaNacimiento { get; set; }
        [StringLength(800)]
        [DisplayName("Dirección")]
        public string Direccion { get; set; }
        [DefaultValue(true)]
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is ClienteDto item)) return false;
            return this.Id.Equals(item.Id);
        }
        public override int GetHashCode() => (Id).GetHashCode();
    }
}
