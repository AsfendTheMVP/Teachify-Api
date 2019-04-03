using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeachifyApi.Models
{
    public class InstructorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public string Experience { get; set; }
        public string HourlyRate { get; set; }
        public string CourseDomain { get; set; }
        public string City { get; set; }
        public string ImagePath { get; set; }
    }
}