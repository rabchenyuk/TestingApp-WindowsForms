namespace DBLibrary.EF.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsTrue { get; set; }

        public int? QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
