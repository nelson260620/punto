using System;
using System.Collections.Generic;

namespace SurveyPlatform.date
{
    public class Survey
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Question> Questions { get; set; }
    }

    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public ICollection<Option> Options { get; set; }
    }

    public class Option
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Votes { get; set; }
    }

    public class SurveyResultViewModel
    {
        public string Title { get; set; }
        public ICollection<QuestionResultViewModel> QuestionResults { get; set; }
    }

    public class QuestionResultViewModel
    {
        public string Text { get; set; }
        public ICollection<OptionResultViewModel> OptionResults { get; set; }
    }

    public class OptionResultViewModel
    {
        public string Text { get; set; }
        public int Votes { get; set; }
    }
}
