using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace CRUD.Models
{
    public class StudentInfo
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Need to Enter your full Name")]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter your College Name ")]
        [Display(Name = "College Name")]
        public string CollegeName { get; set; }

        [Required(ErrorMessage = "Enter your Course Name ")]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Enter your Address ")]
        [Display(Name = "Address")]
        public string Address { get; set; }
    }
}
