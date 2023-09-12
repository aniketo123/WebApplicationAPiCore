using Core;
using Dto1;

namespace Infra
{
    public class StudentInfra
    {
        CoreStudentServices coreStudentServices;
        public StudentInfra()
        {
            coreStudentServices = new CoreStudentServices();
        }
        public List<StudentDto> GetStudnetList()
        {
            return coreStudentServices.GetStudents();
        }
        public bool CreateStudent(StudentDto student)
        {
            return coreStudentServices.CreateStudent(student);
        }
        public StudentDto FillStudentData(int Id)
        {
            return coreStudentServices.FillStudentData(Id);
        }
        public bool EditStudentData(StudentDto student)
        {
            return coreStudentServices.EditStudentData(student);
        }
        public bool DeleteStudent(StudentDto studentDto)
        {
            return coreStudentServices.DeleteStudent(studentDto);
        }
        public List<StudentDto> SearchStudent(StudentDto studentDto)
        {
            return coreStudentServices.SearchStudent(studentDto);
            }
        }
}