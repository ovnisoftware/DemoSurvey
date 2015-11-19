using System.Data.Linq.Mapping;

namespace DemoSurvey
{
    [Table(Name = "Item")]
    public class SurveyItem
    {
        [Column]
        public int ItemId { get; private set; }

        [Column]
        public int SurveyId { get; private set; }

        [Column]
        public string ItemText { get; private set; }
    }
}