using learningSystem.Entities;

namespace learningSystem.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Role { get; set; }
    }
}
