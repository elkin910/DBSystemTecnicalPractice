namespace DBSystemTP.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("Departamentos")]
    public partial class Departamento
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Nombre { get; set; }

        public int PaisId { get; set; }
              

        public virtual Pais Pais { get; set; }

        public virtual ICollection<Ciudade> Ciudades { get; set; }
    }
}
