namespace learningSystem.Entities
{
    public class CourseFile//future develpoment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? URL { get; set; }
        public bool ToDisplay { get; set; } = false;
        public Article article { get; set; }
        public int articleId { get; set; }

    }
}
