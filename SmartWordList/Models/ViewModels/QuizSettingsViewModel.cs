namespace SmartWordList.Models.ViewModels
{
    public class QuizSettingsViewModel
    {
        public string SelectedMode { get; set; } // "test" or "practice"

        // --- TEST MODE DATA ---
        public int TestQuestionCount { get; set; }
        public string TestAnswerMode { get; set; } // "multiple_choice" or "typing"

        // --- PRACTICE MODE DATA ---
        public int PracticeQuestionCount { get; set; }

        // Checkboxlar HTML'den "on" diye gelir ama .NET bunu bool'a çevirebilir (True/False)
        public bool PracticeUnasked { get; set; }
        public bool PracticeCurrentPoint { get; set; }
        public bool PracticeMistakes { get; set; }
    }
}
