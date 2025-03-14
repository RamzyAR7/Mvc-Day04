using MVC_Day04.Models;

namespace MVC_Day04.ViewModel
{
    public class StudentListViewModel
    {
        public List<Student> Students { get; set; }
        public string SearchString { get; set; }
        public int? DepartmentId { get; set; }
        public List<Department> Departments { get; set; }
    }
}
