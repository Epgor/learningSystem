namespace learningSystem.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public CourseMain Course { get; set; }
        public int CourseId { get; set; }

    }
}
