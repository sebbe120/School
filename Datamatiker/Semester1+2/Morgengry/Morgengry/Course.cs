using System;
using System.Collections.Generic;
using System.Text;
using static Morgengry.Controller;

namespace Morgengry
{
    public class Course : IValueable
    {
        public static double CourseHourValue { get; set; } = 875.00;
        public Course(string name)
        {
            Name = name;
        }

        public Course(string name, int duration)
        {
            Name = name;
            DurationInMinutes = duration;
        }

        public string Name { get; set; }
        public int DurationInMinutes { get; set; } = 0;

        public double GetValue()
        {
            if (DurationInMinutes <= 0)
                return 0.0;

            else if (DurationInMinutes <= 60)
                return CourseHourValue;

            int remainder = DurationInMinutes % 60;

            double value = ((DurationInMinutes - remainder) / 60) * CourseHourValue;

            if (remainder > 0)
                value += CourseHourValue;

            return value;
        }

        public override string ToString()
        {
            return "Name: " + Name + ", Duration in Minutes: " + DurationInMinutes + ", Pris pr påbegyndt time: " + GetValue();
        }
    }
}
