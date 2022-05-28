namespace learningSystem.Entities
{
    public class CourseMain
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Desc { get; set; }
        public string? LogoURL { get; set; }

        public int? CreatorId { get; set; }
    }
}
