namespace learningSystem.Entities
{
    public class QuestionDto
    {
        public int QuestionId { get; set; }
        public string questionText { get; set; }
        public List<AnswerDto> answers { get; set; }
    }
}

