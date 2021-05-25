using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationTP.Models
{
    public class AlumnosCLS
    {
        [Key]
        [Display(Name = "IdAlumno")]
        public int alumnoid { get; set; }

        [Display(Name = "Apellidos")]
        [Required]
        [StringLength(100, ErrorMessage = "Longitud Maxima alcanzada")]
        public string apellidos { get; set; }

        [Display(Name = "Nombres")]
        [Required]
        public string nombres { get; set; }

        [Display(Name = "Escuela Profesional")]
        [Required]
        public string escuela { get; set; }
    }
}