using CQRSPattern.DTOs;

namespace CQRSPattern.Commands.StudentCommand
{
    public class CreateStudentCommand
    {
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentAddress { get; set; }
        public int StudentAge { get; set; }

        public CreateStudentCommand(StudentDTO model)
        {
            StudentName = model.StudentName;
            StudentEmail = model.StudentEmail;
            StudentAddress = model.StudentAddress;
            StudentAge = model.StudentAge;
        }
    }
}
