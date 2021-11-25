using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMIS.Models {
    public class Department {

        [Key]
        public int DepId { get; set; }
        public string Name { get; set; }
        public int Faculty { get; set; }
    }
}
