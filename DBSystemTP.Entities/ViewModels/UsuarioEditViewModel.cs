using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace DBSystemTP.Entities.ViewModels
{
    public class UsuarioEditViewModel
    {

        [Required]
        [Display(Name = "Nombre Usuario ")]
        [StringLength(100)]
        public string NombreUsuario { get; set; }

        [Required]
        [Display(Name = "Direccion")]
        [StringLength(100)]
        public string DireccionUsuario { get; set; }

        [Required]
        [Display(Name = "Fecha Nacimiento (DD-MM-YYYY)")]
        [StringLength(100)]
        public string FechaUsuario { get; set; }

        [Required]
        [Display(Name = "Identificación Usuario")]
        [StringLength(100)]
        public string IdentificacionUsuario { get; set; }

        [Required]
        [Display(Name = "Tipo Identificacion")]
        public string SelectedTipoIdentificacion { get; set; }
        public IEnumerable<SelectListItem> TiposIdentificacion { get; set; }


        [Required]
        [Display(Name = "País Nacimiento")]
        public string SelectedPais { get; set; }
        public IEnumerable<SelectListItem> Paises { get; set; }

        [Required]
        [Display(Name = "Departamento Nacimiento")]
        public string SelectedDepartamento { get; set; }
        public IEnumerable<SelectListItem> Departamentos { get; set; }

        //[Required]
        //[Display(Name = "Ciudad Nacimiento")]
        //public string SelectedCiudad { get; set; }
        //public IEnumerable<SelectListItem> Ciudades { get; set; }
    }
}
