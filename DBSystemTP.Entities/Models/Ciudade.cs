namespace DBSystemTP.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Ciudade
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        public int DepartamentoId { get; set; }

        public virtual Departamento Departamento { get; set; }
               
        

        //public virtual Usuario Usuario { get; set; }
    }
}
