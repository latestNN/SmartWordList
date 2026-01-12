namespace SmartWordList.Models.Entities
{
    public class UserWord : Word
    {
        public decimal SuccessAnswerCount { get; set; } = 0;

        public decimal WrongAnswerCount { get; set; } = 0;

        public decimal SuccesPercent { get; set; } = 0;

        public int AskCount { get; set; } = 0;

        public bool IsAsked { get; set; } = false;

        public DateTime? LastAskedDate { get; set; }
    }
}
