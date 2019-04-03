using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeachifyApi.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(20)]
        public string Name { get; set; }

        [Required, StringLength(15)]
        public string Language { get; set; }

        [Required, StringLength(25)]
        public string Nationality { get; set; }

        [Required, StringLength(10)]
        public string Gender { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone Format is not valid")]
        public string Phone { get; set; }

        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email format is not valid")]
        public string Email { get; set; }

        [Required]
        public string Education { get; set; }

        [Required, StringLength(50)]
        public string OneLineTitle { get; set; }
            
        [Required, StringLength(500)]
        public string Description { get; set; }
        public string Experience { get; set; }
        public string HourlyRate { get; set; }
        public string CourseDomain { get; set; }
        public string City { get; set; }
        public string ImagePath { get; set; }

        [NotMapped]
        public byte[] ImageArray { get; set; }

        public string UserId { get; set; }

    }
}