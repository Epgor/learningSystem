using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace learningSystem.Entities
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Reminder { get; set; }
        public int? CreatorId { get; set; }
    }
}
