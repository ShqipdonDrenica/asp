using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMIS.Models {
    public class Lecture {

        [Key]
        public int LectureId { get; set; }
        public int Student { get; set; }
        public int Course { get; set; }
    }
}
