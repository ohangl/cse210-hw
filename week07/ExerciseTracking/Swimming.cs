using System;

namespace ExerciseTracking
{
    public class Swimming : Activity
    {
        private int _laps;

        public Swimming(DateTime date, int lengthInMinutes, int laps)
            : base(date, lengthInMinutes)
        {
            _laps = laps;
        }

        public override double GetDistance()
        {
            double distanceKm = _laps * 50 / 1000.0;
            double distanceMiles = distanceKm * 0.62;
            return distanceMiles;
        }

        public override double GetSpeed()
        {
            return (GetDistance() / LengthInMinutes) * 60;
        }

        public override double GetPace()
        {
            return LengthInMinutes / GetDistance();
        }
    }
}
