using System.ComponentModel.DataAnnotations;

namespace BackendCourse10.Dto
{
    public class UserDto
    {

        [Key]
        public Guid Id { get; set; }= Guid.NewGuid();
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

    public class RegisterUserDto
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }


}
