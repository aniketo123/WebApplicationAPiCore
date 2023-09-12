using Core.CoreModel;
using Dto1;

namespace Core
{
    public class CoreStudentServices
    {
        DbStudent1Context _studentCoreContext;
        public CoreStudentServices()
        {
            _studentCoreContext = new DbStudent1Context();
        }
        public List<StudentDto> GetStudents()
        {
            var Studentslist = _studentCoreContext.StudentCoreModels.ToList();
            var studentCoretoDto = new DeepCopyservices.StudentCoreDeepCopyServices().CoreToDto(Studentslist);
            return studentCoretoDto;
        }
        public bool CreateStudent(StudentDto student)
        {
            var result = false;
            var checkStudent = _studentCoreContext.StudentCoreModels.Where(x => x.StudentName == student.StudentName).FirstOrDefault();
            if (checkStudent == null)
            {
                var CoreStudent = new DeepCopyservices.StudentCoreDeepCopyServices().DTOtoCore(student);
                _studentCoreContext.StudentCoreModels.Add(CoreStudent);
                _studentCoreContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return result;
            }

        }
        public StudentDto FillStudentData(int Id)
        {
            var StudentData = _studentCoreContext.StudentCoreModels.Where(x => x.StudentId == Id).FirstOrDefault();
            var EditCoreToDto = new DeepCopyservices.StudentCoreDeepCopyServices().EditCoreToDto(StudentData);
            return EditCoreToDto;
        }
        public bool EditStudentData(StudentDto studentDto)
        {
            var CoreStudent = _studentCoreContext.StudentCoreModels.Where(x => x.StudentId == studentDto.StudentId).FirstOrDefault();
            CoreStudent.StudentName = studentDto.StudentName;
            CoreStudent.StudentEmail = studentDto.StudentEmail;
            CoreStudent.StudentPhoneNumber = studentDto.StudentPhoneNumber;
            CoreStudent.RollNo = studentDto.RollNo;
            _studentCoreContext.SaveChanges();
            return true;
        }
        public bool DeleteStudent(StudentDto studentDto)
        {
            var deletestudentData = _studentCoreContext.StudentCoreModels.Where(x => x.StudentId == studentDto.StudentId).FirstOrDefault();
            _studentCoreContext.StudentCoreModels.Remove(deletestudentData);
            _studentCoreContext.SaveChangesAsync(true);
            return true;
        }
        public List<StudentDto> SearchStudent(StudentDto studentDto)
        {
            var studentData = _studentCoreContext.StudentCoreModels.Where(x => x.StudentName.Contains(studentDto.StudentName) || x.StudentEmail.Contains(studentDto.StudentName)).ToList();
            var studentcoretodto = new DeepCopyservices.StudentCoreDeepCopyServices().CoreToDto(studentData);
            return studentcoretodto;
        }
    }
}