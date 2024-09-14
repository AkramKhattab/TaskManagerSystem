using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.G02.DAL.Models
{
    public class Department
    {
        public int Id { get; set; } // Default Value = 0

        [Required(ErrorMessage = "Code is Required")] 
        public string Code { get; set; }  // Default Value = null


        [Required(ErrorMessage = "Name is Required")]       
        public string Name { get; set; } // Default Value = null


        [DisplayName("Date Of Creation")]
        public DateTime DateOfCreation { get; set; }

    }
}
