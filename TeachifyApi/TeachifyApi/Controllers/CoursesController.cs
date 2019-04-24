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
    public class CoursesController : ApiController
    {

        private readonly List<Course> _courses = new List<Course>()
        {
            new Course() {Name = "Accounting"},
            new Course() {Name = "Arts"},
            new Course() {Name = "Biological Science"},
            new Course() {Name = "Chemistry"},
            new Course() {Name = "Computer Science"},
            new Course() {Name = "Dentistry"},
            new Course() {Name = "Forensic Science"},
            new Course() {Name = "Medicine"},
            new Course() {Name = "Philosophy"},
            new Course() {Name = "Sociology"},
        };


        // GET: api/Courses
        public IQueryable<Course> GetCourses()
        {
            return _courses.AsQueryable();
        }
    }
}