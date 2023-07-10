using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crudSystemADO.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide First Name")]
        //[StringLength(20, MinimumLength = 5, ErrorMessage = "First Name Should be min 5 and max 20 length")]
        //[Required]
        public string FirstName { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Last Name")]
        //[StringLength(20, MinimumLength = 5, ErrorMessage = "First Name Should be min 5 and max 20 length")]
        //[Required]
        public string LastName { get; set; }
        public Boolean Status { get; set; }
        //[Required]
        public string State { get; set; }
        public string CheckBox1 { get; set; }
        public string CheckBox2 { get; set; }

    }
}
