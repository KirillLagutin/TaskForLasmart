using System.Collections.Generic;

namespace TaskForLasmart.Domain.Entities
{
    public class Point
    {
        public int Id { get; init; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Radius { get; set; }
        public string Color { get; set; }
        public IReadOnlyList<Comment> Comments { get; set; }
    }
}