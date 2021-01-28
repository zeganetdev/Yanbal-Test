using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Yanbal.Examen.Domain.MainContext.Aggregates.ClienteAgg
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(250)]
        public string Apellidos { get; set; }

        [Required]
        [StringLength(320)]
        [EmailAddress]
        public string Correo { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? FechaNacimiento { get; set; }

        [StringLength(800)]
        public string Direccion { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool Activo { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime FechaRegistro { get; set; }

        public void ValidaCorreo(string correoBuscado)
        {
            if (Correo == correoBuscado)
                throw new ArgumentException(nameof(Correo), new Exception("Ya existe un cliente con este correo"));
        }
    }
}
