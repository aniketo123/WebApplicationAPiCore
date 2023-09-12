//using Core.CoreModel;
//using Dto1;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Core.Model;


//namespace Core.DeepCopyservices
//{
//    public class StudentCoreDeepCopyServices
//    {
//        public List<StudentDto> CoreToDto(List<Core.Model.StudentCoreModel> studentCoreModels)
//        {
//            List<StudentDto> Studentlist = new List<StudentDto>();
//            foreach (var Item in studentCoreModels)
//            {
//                StudentDto Student = new StudentDto();
//                Student.StudentName = Item.StudentName;
//                Student.StudentId = Item.StudentId;
//                Student.StudentEmail = Item.StudentEmail;
//                Student.StudentPhoneNumber = Item.StudentPhoneNumber;
//                Studentlist.Add(Student);
//            }
//            return Studentlist;
//        }
//        public Core.Model.StudentCoreModel DTOtoCore(StudentDto student)
//        {
//            Core.Model.StudentCoreModel studentCoreModel = new Core.Model.StudentCoreModel();
//            studentCoreModel.StudentName = student.StudentName;
//            studentCoreModel.StudentEmail = student.StudentEmail;
//            studentCoreModel.StudentPhoneNumber = student.StudentPhoneNumber;
//            studentCoreModel.RollNo = student.RollNo;
//            studentCoreModel.StudentId = student.StudentId;
//            return studentCoreModel;
//        }
//        public StudentDto EditCoreToDto(Core.Model.StudentCoreModel model)
//        {
//            StudentDto student = new StudentDto();
//            student.StudentId = model.StudentId;
//            student.StudentName = model.StudentName;
//            student.StudentPhoneNumber = model.StudentPhoneNumber;
//            student.StudentEmail = model.StudentEmail;
//            student.RollNo = model.RollNo;
//            return student;
//        }
//    }
//}
