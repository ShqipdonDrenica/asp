using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMIS.Models {
    public class Subject {

        [Key]
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public int Department { get; set; }
        public int Ects { get; set; }
    }
}
