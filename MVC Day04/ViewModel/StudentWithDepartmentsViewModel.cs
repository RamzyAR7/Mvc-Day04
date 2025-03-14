using MVC_Day04.Models;

namespace MVC_Day04.ViewModel
{
    public class StudentWithDepartmentsViewModel
    {
        public AddStudentViewModel Student { get; set; }
        public List<Department> Departments { get; set; }
    }
}
