using System.ComponentModel.DataAnnotations;

namespace MVC_Day04.ViewModel
{
    public class AddStudentViewModel
    {
        //[Required(ErrorMessage = "Name is required")]
        //[StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(15, 60, ErrorMessage = "Age must be between 15 and 60")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public int DepartmentId { get; set; }
    }
}
