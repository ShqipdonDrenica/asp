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
    public class SubjectController : ControllerBase {


        private ApplicationDbContext context;

        public SubjectController(ApplicationDbContext _context) {
            context = _context;
        }

        [HttpPost]
        [Route("CreateProfessor")]
        public IActionResult CreateProfessor(Professor model) {
            if (ModelState.IsValid) {
                context.Add(model);
                context.SaveChanges();
                return Ok("Professor addedd successfully !");
            }
            return new JsonResult("Error adding Professor !");
        }


        [Route("GetProfessors")]
        [HttpGet]
        public IActionResult GetProfessors() {
            var prof = context.Professors.ToList();
            if (prof != null) {
                return Ok(prof);
            }
            return new JsonResult("There are no Professors !");
        }




    }
}
