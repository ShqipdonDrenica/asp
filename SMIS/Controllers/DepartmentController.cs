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
    public class DepartmentController : ControllerBase {

        private ApplicationDbContext context;

        public DepartmentController(ApplicationDbContext _context) {
            context = _context;
        }

        [HttpPost]
        [Route("CreateDepartment")]
        public IActionResult CreateDepartment(Department model) {
            if (ModelState.IsValid) {
                context.Add(model);
                context.SaveChanges();
                return Ok("Department addedd successfully !");
            }
            return new JsonResult("Error adding department !");
        }


        [Route("GetDepartments")]
        [HttpGet]
        public IActionResult GetDepartments() {
            var deps = context.Departments.ToList();
            if(deps != null) {
                return Ok(deps);
            }
            return new JsonResult("There are no departments !");
        }

    }
}
