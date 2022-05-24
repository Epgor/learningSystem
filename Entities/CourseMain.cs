namespace learningSystem.Entities
{
    public class CourseMain
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Desc { get; set; }
        public string? LogoURL { get; set; }
        public CourseDetail? Eye { get; set; }
        public int? EyeId { get; set; }
        public CourseDetail? Ear { get; set; }
        public int? EarId { get; set; }
        public CourseDetail? Work { get; set;}
        public int? WorkId { get; set; }
        public int? CreatorId { get; set; }
    }
}
