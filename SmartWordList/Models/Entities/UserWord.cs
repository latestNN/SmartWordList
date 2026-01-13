namespace SmartWordList.Models.Entities
{
    public class UserWord 
    {
        public int Id { get; set; }
        public decimal SuccessAnswerCount { get; set; } = 0;

        public decimal WrongAnswerCount { get; set; } = 0;

        public decimal SuccesPercent { get; set; } = 0;

        public int AskCount { get; set; } = 0;

        public bool IsAsked { get; set; } = false;

        public DateTime? LastAskedDate { get; set; }

        public int? WeekPartialWordListId { get; set; }

        public WeekPartialWordList? WeekPartialWordList { get; set; }

        public int WordId { get; set; }

        public Word Word { get; set; }
    }
}
