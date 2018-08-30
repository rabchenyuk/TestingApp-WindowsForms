namespace DBLibrary.EF.Models
{
    public class Result
    {
        public int Id { get; set; }
        public int CountRightAnswers { get; set; }
        public int CountWrongAnswers { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
