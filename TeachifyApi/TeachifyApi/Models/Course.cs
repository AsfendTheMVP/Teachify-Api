using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeachifyApi.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}