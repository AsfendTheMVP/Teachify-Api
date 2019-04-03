using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeachifyApi.Models
{
    public class City
    {
        public int CityId { get; set; }

        [Required]
        public string Name { get; set; }

    }
}