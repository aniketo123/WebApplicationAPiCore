using Dto1;
using Infra;
using Microsoft.AspNetCore.Mvc;
using WebApplicationCore.Models;

namespace WebApplicationCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        StudentInfra studentInfra;
        public StudentController()
        {
            studentInfra = new StudentInfra();
        }
        [Route("Index")]
        [HttpGet]
        public List<StudentViewModel> Index()
        {
            var studentList = studentInfra.GetStudnetList();
            List<StudentViewModel> studentViewModels = new List<StudentViewModel>();
            foreach (var item in studentList)
            {
                StudentViewModel studentViewModel = new StudentViewModel();
                studentViewModel.StudentId = item.StudentId;
                studentViewModel.StudentName = item.StudentName;
                studentViewModel.StudentPhoneNumber = item.StudentPhoneNumber;
                studentViewModel.StudentEmail = item.StudentEmail;
                studentViewModel.RollNo = item.RollNo;
                studentViewModels.Add(studentViewModel);
            }
            return studentViewModels;
        }

        [Route("Index")]
        [HttpPost]
        public IActionResult Index(string StudentName)
        {
            var student = new StudentDto();
            student.StudentName = StudentName;
            if (StudentName == null)
            {
                return RedirectToAction("Index", "Student");
            }
            var Model = studentInfra.SearchStudent(student);
            List<StudentViewModel> studentViewModels = new List<StudentViewModel>();
            foreach (var item in Model)
            {
                StudentViewModel viewModel = new StudentViewModel();
                viewModel.StudentId = item.StudentId;
                viewModel.StudentName = item.StudentName;
                viewModel.StudentPhoneNumber = item.StudentPhoneNumber;
                viewModel.StudentEmail = item.StudentEmail;
                viewModel.RollNo = item.RollNo;
                studentViewModels.Add(viewModel);
            }
            return View(studentViewModels);
        }

        [Route("Create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("Create")]
        [HttpPost]
        public string Create(StudentViewModel studentViewModel)
        {
            var StudentDto = new StudentDto();
            {
                StudentDto.StudentId = studentViewModel.StudentId;
                StudentDto.StudentName = studentViewModel.StudentName;
                StudentDto.StudentPhoneNumber = studentViewModel.StudentPhoneNumber;
                StudentDto.StudentEmail = studentViewModel.StudentEmail;
                StudentDto.RollNo = studentViewModel.RollNo;
            };
            var result = studentInfra.CreateStudent(StudentDto);
            if (result == true)
            {
                return "Created successfully";
            }
            else
            {
                return "User Already Created";
            }

        }

        [Route("Edit")]
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var StudentData = studentInfra.FillStudentData(Id);
            StudentViewModel viewModel = new StudentViewModel();
            viewModel.StudentId = StudentData.StudentId;
            viewModel.StudentName = StudentData.StudentName;
            viewModel.StudentPhoneNumber = StudentData.StudentPhoneNumber;
            viewModel.StudentEmail = StudentData.StudentEmail;
            viewModel.RollNo = StudentData.RollNo;
            TempData["EditSuccess"] = "<script>alert('User Update successfully');</script>";
            return View(viewModel);
        }

        [Route("Edit")]
        [HttpPost]
        public IActionResult Edit(StudentViewModel studentViewModel)
        {
            var studentDto = new StudentDto();
            {
                studentDto.StudentId = studentViewModel.StudentId;
                studentDto.StudentName = studentViewModel.StudentName;
                studentDto.StudentPhoneNumber = studentViewModel.StudentPhoneNumber;
                studentDto.StudentEmail = studentViewModel.StudentEmail;
                studentDto.RollNo = studentViewModel.RollNo;
                studentInfra.EditStudentData(studentDto);
                return RedirectToAction("Index", "Student");
            }

        }

        [Route("Delete")]
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var StudentDeleteData = new StudentDto();
            {
                StudentDeleteData.StudentId = Id;
            }

            studentInfra.DeleteStudent(StudentDeleteData);
            return RedirectToAction("Index", "Student");
        }
    }
}
