namespace learningSystem.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public Question question { get; set; }
        public int questionId { get; set; }

    }
}
