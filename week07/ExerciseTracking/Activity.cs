using System;

namespace ExerciseTracking
{
    public abstract class Activity
    {
        private DateTime _date;
        private int _lengthInMinutes;

        public Activity(DateTime date, int lengthInMinutes)
        {
            _date = date;
            _lengthInMinutes = lengthInMinutes;
        }

        public DateTime Date => _date;
        public int LengthInMinutes => _lengthInMinutes;

        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();

        public string GetSummary()
        {
            return $"{Date:dd MMM yyyy} {this.GetType().Name} ({LengthInMinutes} min): " +
                   $"Distance: {GetDistance():0.0} miles, Speed: {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
        }
    }
}
