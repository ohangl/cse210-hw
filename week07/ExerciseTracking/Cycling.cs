using System;

namespace ExerciseTracking
{
    public class Cycling : Activity
    {
        private double _speedMph;

        public Cycling(DateTime date, int lengthInMinutes, double speedMph)
            : base(date, lengthInMinutes)
        {
            _speedMph = speedMph;
        }

        public override double GetSpeed()
        {
            return _speedMph;
        }

        public override double GetDistance()
        {
            return (_speedMph * LengthInMinutes) / 60;
        }

        public override double GetPace()
        {
            return 60 / _speedMph;
        }
    }
}
