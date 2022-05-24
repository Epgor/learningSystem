namespace learningSystem.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public CourseDetail Course { get; set; }
        public int CourseId { get; set; }

    }
}
