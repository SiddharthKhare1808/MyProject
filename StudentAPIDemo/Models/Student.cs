using System.ComponentModel.DataAnnotations;

namespace StudentAPIDemo.Models
{
    public class Student
    {
        

        public int StudentID { get; set; }


        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Empty First Name Not Accepted")]
        [StringLength(14, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z][a-zA-Z]*$", ErrorMessage = "First Name must be alphabetical not accepted Numeric")]
        public string FirstName { get; set; }


        [RegularExpression(@"^[A-Z][a-zA-Z]*$", ErrorMessage = "Last Name must Be alphabetical and not accepted Numeric")]
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Empty Last Name Not Accepted")]
        [StringLength(15)]


        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Provide Age")]
        [Range(10,50, ErrorMessage = "Age should be in range 10 to 50")]
      
        [RegularExpression(@"[0-9]*$", ErrorMessage = "Float Values Not Accepted")]



        public int Age { get; set; }
        [Required(ErrorMessage = "Please Provide Gender")]
        [StringLength(1, ErrorMessage = "Gender Should be in M/F")]
        [Display(Name ="Gender")]
        [RegularExpression(@"[MF]", ErrorMessage = "Enter M for Male and F for Female")]
        public string Gender { get; set; }



        [Display(Name = "Team Name")]
        [RegularExpression(@"[A-D]", ErrorMessage = "Select Only A or B or C or D")]
        public string TeamName { get; set; }

    }
}
