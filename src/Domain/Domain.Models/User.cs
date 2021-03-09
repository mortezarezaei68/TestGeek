using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get;private set; }
        public string LastName { get;private set; }
        private readonly List<Score> _scores = new();
        public IReadOnlyCollection<Score> Scores => _scores;

        public void Add(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

        }
        public void AddInCache(int id)
        {
            Id = id+1;

        }

        public void AddPoint(int point)
        {
            var points = new Score(point);
            _scores.Add(points);
        }

        public void UpdatePoint(int point)
        {
            var score = _scores.Last();
            score.Update(point);
        }
    }
}