using Microsoft.AspNetCore.Mvc;
using MVC_Day04.Models;
using MVC_Day04.Service;
using MVC_Day04.ViewModel;

namespace MVC_Day04.Controllers
{
    public class StudentController : Controller
    {
        private StudentServices _services;

        public StudentController(StudentServices services)
        {
            _services = services;
        }
        public IActionResult GetAll(string searchString, int? departmentId)
        {
            var students = _services.GetFilteredStudents(searchString, departmentId);

            var viewModel = new StudentListViewModel
            {
                Students = students,
                SearchString = searchString,
                DepartmentId = departmentId,
                Departments = _services.GetDepartments()
            };

            return View(viewModel);
        }
        public IActionResult GetById(int id)
        {
            var student = _services.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        /// <summary>
        /// Add student
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Add()
        {
            var viewModel = new StudentWithDepartmentsViewModel
            {
                Student = new AddStudentViewModel(),
                Departments = _services.GetDepartments()
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Add(StudentWithDepartmentsViewModel viewModel)
        {
            if (viewModel.Student.Name != null)
            {
                var student = new Student
                {
                    Name = viewModel.Student.Name,
                    Age = viewModel.Student.Age,
                    DepartmentId = viewModel.Student.DepartmentId
                };
                _services.Add(student);
                return RedirectToAction("GetAll");
            }
            viewModel.Departments = _services.GetDepartments();
            // get
            return View(viewModel);
        }

        /// <summary>
        /// Edit student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _services.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            var viewModel = new StudentWithDepartmentsViewModel
            {
                Student = new AddStudentViewModel
                {
                    Name = student.Name,
                    Age = student.Age,
                    DepartmentId = student.DepartmentId
                },
                Departments = _services.GetDepartments()
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(int id, StudentWithDepartmentsViewModel viewModel)
        {
            var student = _services.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            if (viewModel.Student.Name == null)
            {
                viewModel.Departments = _services.GetDepartments();
                return View(viewModel);
            }
            student.Name = viewModel.Student.Name;
            student.Age = viewModel.Student.Age;
            student.DepartmentId = viewModel.Student.DepartmentId;
            var status = _services.Update(student);
            if (status == null)
            {
                return BadRequest();
            }
            return RedirectToAction("GetAll");
        }
        /// <summary>
        /// Delete student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = _services.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View("Warning", student);
        }
        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            _services.Delete(id);
            return RedirectToAction("GetAll");
        }

    }
}
