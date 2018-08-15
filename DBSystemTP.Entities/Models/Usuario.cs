namespace DBSystemTP.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class Usuario
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Direccion { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [StringLength(10)]
        public string NumeroIdentificacion { get; set; }

        //public int TipoIdentificacionId { get; set; }

        //public int CiudadId { get; set; }

        
        public virtual Ciudade Ciudade { get; set; }
       
        public virtual TiposDocumento TiposDocumento { get; set; }
    }
}
