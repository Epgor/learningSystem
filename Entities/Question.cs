namespace learningSystem.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Quiz quiz { get; set; }
        public int quizId { get; set; }


    }
}
