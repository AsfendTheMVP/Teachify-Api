using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TeachifyApi.Models;

namespace TeachifyApi.Controllers
{
    public class CitiesController : ApiController
    {

        private readonly List<City> _cities = new List<City>()
        {
            new City() {Name = "Alabama"},
            new City() {Name = "Alaska"},
            new City() {Name = "California"},
            new City() {Name = "Florida"},
            new City() {Name = "Georgia"},
            new City() {Name = "Indiana"},
            new City() {Name = "Louisiana"},
            new City() {Name = "Mississippi"},
            new City() {Name = "New Mexico"},
            new City() {Name = "New York"},
            new City() {Name = "Pennsylvania"},
            new City() {Name = "Seattle"},
            new City() {Name = "Texas"},
            new City() {Name = "Washington"},
        };

        // GET: api/Cities
        public IQueryable<City> GetCities()
        {
            return _cities.AsQueryable();
        }

    }
}