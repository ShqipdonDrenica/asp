using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMIS.Models {
    public class Course {

        [Key]
        public int CourseId { get; set; }
        public int Subject { get; set; }
        public int Professor { get; set; }
    }
}
