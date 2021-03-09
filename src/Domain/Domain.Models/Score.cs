using System;

namespace Domain.Models
{
    public class Score
    {
        public Score( int point)
        {
            Point = point;
        }

        public int Id { get; set; }
        public int Point { get;private set; }

        public void Update(int point)
        {
            Point += point;
        }
        
    }
}