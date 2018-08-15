namespace DBSystemTP.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Paises")]
    public partial class Pais
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        
        public virtual ICollection<Departamento> Departamentos  { get; set; }
    }
}
