using CQRSPattern.DTOs;

namespace CQRSPattern.Commands.StudentCommand
{
    public class UpdateStudentCommand
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentAddress { get; set; }
        public int StudentAge { get; set; }

        public UpdateStudentCommand(int id,StudentDTO model)
        {
            Id = id;
            StudentName = model.StudentName;
            StudentEmail = model.StudentEmail;
            StudentAddress = model.StudentAddress;
            StudentAge = model.StudentAge;
        }
    }
}
