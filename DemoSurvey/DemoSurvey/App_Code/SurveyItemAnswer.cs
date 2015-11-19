using System.Data.Linq.Mapping;

namespace DemoSurvey
{
    [Table(Name = "ItemAnswer")]
    public class SurveyItemAnswer
    {
        [Column]
        public int AnswerId { get; set; }

        [Column]
        public int ItemId { get; set; }

        [Column]
        public string AnswerText { get; set; }

        [Column]
        public int OrderNumber { get; set; }
    }
}