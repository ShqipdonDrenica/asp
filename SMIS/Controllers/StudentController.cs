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
    public class StudentController : ControllerBase {

        private ApplicationDbContext context;

        public StudentController(ApplicationDbContext _context) {
            context = _context;
        }

        [HttpPost]
        [Route("CreateStudent")]
        public IActionResult CreateStudent(Student model) {
            if (ModelState.IsValid) {
                context.Add(model);
                context.SaveChanges();
                return Ok("Student addedd successfully !");
            }
            return new JsonResult("Error adding Student !");
        }


        [Route("GetStudents")]
        [HttpGet]
        public IActionResult GetStudents() {
            var stds = context.Students.ToList();
            if (stds != null) {
                return Ok(stds);
            }
            return new JsonResult("There are no Student !");
        }







    }
}
