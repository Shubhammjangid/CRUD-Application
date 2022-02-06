using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace CRUD.Models
{
    public class StudentInfo
    {
        
        public int Id { get; set; }

        public string Name { get; set; }

        public string CollegeName { get; set; }

        public string CourseName { get; set; }

        public string Address { get; set; }
    }
}
