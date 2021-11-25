using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMIS.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase {

        private ApplicationDbContext context;

        public FacultyController(ApplicationDbContext _context) {
            context = _context;
        }

        [HttpPost]
        [Route("CreateFaculty")]
        public IActionResult CreateFaculty(Faculty model) {
            if (ModelState.IsValid) {
                context.Add(model);
                context.SaveChanges();
                return Ok("Faculty addedd successfully !");
            }
            return new JsonResult("Error adding faculty !");
        }


        [Route("GetFaculties")]
        [HttpGet]
        public IActionResult GetFaculties() {
            var fc = context.Faculties.ToList();
            if (fc != null) {
                return Ok(fc);
            }
            return new JsonResult("There are no faculties !");
        }
    }
}
