namespace TaskForLasmart.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string TextBackgroundColor { get; set; }
        public int PointId { get; init; }
    }
}