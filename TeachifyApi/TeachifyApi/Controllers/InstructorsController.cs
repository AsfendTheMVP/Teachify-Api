using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.AspNet.Identity;
using TeachifyApi.Helpers;
using TeachifyApi.Models;

namespace TeachifyApi.Controllers
{
    [Authorize]
    public class InstructorsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Instructors
        public IQueryable<InstructorViewModel> GetAllInstructors()
        {
            return db.Instructors.ToList().Select(i => new InstructorViewModel
            {
                Id = i.Id,
                Name = i.Name,
                Language = i.Language,
                CourseDomain = i.CourseDomain,
                City = i.City,
                Experience = i.Experience,
                HourlyRate = i.HourlyRate,
                ImagePath = i.ImagePath,
            }).AsQueryable();
        }


        // GET: api/instructors?subject=Biology&gender=Male&city=Seattle
        public IQueryable<Instructor> GetInstructors(string subject, string gender, string city)
        {
            return db.Instructors.Where(user =>
                user.CourseDomain.StartsWith(subject)
                && user.Gender.StartsWith(gender)
                && user.City.StartsWith(city));
        }


        // GET: api/Instructors/5
        [ResponseType(typeof(Instructor))]
        public async Task<IHttpActionResult> GetInstructor(int id)
        {
            Instructor instructor = await db.Instructors.FindAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }

            return Ok(instructor);
        }

        // PUT: api/Instructors/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInstructor(int id, Instructor instructor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != instructor.Id)
            {
                return BadRequest();
            }

            db.Entry(instructor).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstructorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Instructors
        //[ResponseType(typeof(Instructor))]
        public async Task<IHttpActionResult> PostInstructor([FromBody]Instructor _instructor)
        {
            string userId = User.Identity.GetUserId();
            _instructor.UserId = userId;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stream = new MemoryStream(_instructor.ImageArray);
            var guid = Guid.NewGuid().ToString();
            var file = String.Format("{0}.jpg", guid);
            var folder = "~/Content/Instructors";
            var fullPath = String.Format("{0}/{1}", folder, file);
            var response = FilesHelper.UploadPhoto(stream, folder, file);
            if (response)
            {
                _instructor.ImagePath = fullPath;
            }
            var instructor = new Instructor()
            {
                Name = _instructor.Name,
                Education = _instructor.Education,
                Email = _instructor.Email,
                Phone = _instructor.Phone,
                Experience = _instructor.Experience,
                Gender = _instructor.Gender,
                HourlyRate = _instructor.HourlyRate,
                OneLineTitle = _instructor.OneLineTitle,
                Language = _instructor.Language,
                Description = _instructor.Description,
                Nationality = _instructor.Nationality,
                ImagePath = _instructor.ImagePath,
                CourseDomain = _instructor.CourseDomain,
                City = _instructor.City,
            };
            db.Instructors.Add(instructor);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.Created);
        }

        // DELETE: api/Instructors/5
        [ResponseType(typeof(Instructor))]
        public async Task<IHttpActionResult> DeleteInstructor(int id)
        {
            Instructor instructor = await db.Instructors.FindAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }

            db.Instructors.Remove(instructor);
            await db.SaveChangesAsync();

            return Ok(instructor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InstructorExists(int id)
        {
            return db.Instructors.Count(e => e.Id == id) > 0;
        }
    }
}