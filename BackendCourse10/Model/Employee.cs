using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace BackendCourse10.Model
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name {  get; set; }
        public DateOnly? DOB { get; set; }
        public string ? Email { get; set; }
        public string? Postion { get; set; }
        public string? Departemnt { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LasteModifiedDate { get; set;  }

    }
}
