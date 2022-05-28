namespace learningSystem.Entities
{
    public class ArticleBlock
    {
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public int type { get; set; }
        public Article Article { get; set; }
        public int ArticleId { get; set; }
    }
}
