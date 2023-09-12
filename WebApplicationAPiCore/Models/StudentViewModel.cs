using System.ComponentModel.DataAnnotations;

namespace WebApplicationCore.Models
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Student Name is Required")]
        public string StudentName { get; set; }
        [Required(ErrorMessage = "Student PhoneNumber is Required")]
        public string StudentPhoneNumber { get; set; }
        [Required(ErrorMessage = "Student Email is Required")]
        public string StudentEmail { get; set; }
        [Required(ErrorMessage = "Student RollNo is Required")]
        public string RollNo { get; set; }
    }
}
