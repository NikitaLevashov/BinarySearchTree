using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Tests
{
    public struct Time : IEquatable<Time>
    {
        private const int NumberOfHoursInDay = 24;
        private const int NumberOfMinutesInHour = 60;

        /// <summary>
        /// Gets hours.
        /// </summary>
        public int Hours { get; }

        /// <summary>
        /// Gets minutes.
        /// </summary>
        public int Minutes { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Time"/> struct.
        /// </summary>
        /// <param name="minutes">Minutes.</param>
        public Time(int minutes)
            : this(0, minutes)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Time"/> struct.
        /// Constructor has an integer parameter minutes.
        /// </summary>
        /// <param name="hours"> Hours.</param>
        /// <param name="minutes"> Minutes.</param>
        public Time(int hours, int minutes)
        {
            IsCorrectTime(ref hours, ref minutes);

            this.Minutes = minutes;
            this.Hours = hours;
        }

        public static Time operator +(Time lhs, int minutes)
        {
            int newHour = lhs.Hours;
            int newMinutes = lhs.Minutes + minutes;

            var newTime = new Time(newHour, newMinutes);

            return newTime;
        }

        public static Time operator -(Time lhs, int minutes)
        {
            int newHour = lhs.Hours;
            int newMinutes = lhs.Minutes - minutes;

            var newTime = new Time(newHour, newMinutes);

            return newTime;
        }

        public static bool operator ==(Time lhs, Time rhs)
            => lhs.Equals(rhs);

        public static bool operator !=(Time lhs, Time rhs) =>
            !(lhs == rhs);


        /// <summary>
        /// Method to return the information about time.
        /// </summary>
        /// <returns>information about time</returns>
        public override string ToString()
        {
            return string.Format("{0:00}:{1:00}", this.Hours, this.Minutes);
        }

        private static void IsCorrectTime(ref int hours, ref int minutes)
        {
            while (hours < 0)
            {
                hours = NumberOfHoursInDay + hours;
            }

            hours = Math.Abs(hours);

            while (hours > NumberOfHoursInDay - 1)
            {
                hours -= NumberOfHoursInDay;
            }

            while (minutes < 0)
            {
                minutes = NumberOfMinutesInHour + minutes;
                hours--;

                while (hours < 0)
                {
                    hours = NumberOfHoursInDay + hours;
                }
            }

            while (minutes > NumberOfMinutesInHour - 1)
            {
                minutes -= NumberOfMinutesInHour;
                hours++;

                while (hours > NumberOfHoursInDay - 1)
                {
                    hours -= NumberOfHoursInDay;
                }
            }
        }

        /// <summary>
        /// Equal time.
        /// </summary>
        /// <param name="obj">Time obj.</param>
        /// <returns>Bool check result.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            else
            {
                return this.Equals((Time)obj);
            }
        }

        /// <summary>
        /// Equal time.
        /// </summary>
        /// <param name="other">Time obj.</param>
        /// <returns>Bool check result.</returns>
        public bool Equals(Time other)
        {
            if (this.Hours == other.Hours && this.Minutes == other.Minutes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// HashCode time.
        /// </summary>
        /// <returns>Hash code time.</returns>
        public override int GetHashCode()
        {
            int hashCode = this.Hours.GetHashCode() + this.Minutes.GetHashCode();

            return hashCode;
        }

        /// <summary>
        /// Method Add for Time.
        /// </summary>
        /// <param name="left">Time left obj.</param>
        /// <param name="right">Add hours.</param>
        /// <returns>Sum times.</returns>
        public static Time Add(Time left, int right)
        {
            return left + right;
        }

        /// <summary>
        /// Method Subtract for Time.
        /// </summary>
        /// <param name="left">Time left obj.</param>
        /// <param name="right">Subtruct minutes.</param>
        /// <returns>Subtract times.</returns>
        public static Time Subtract(Time left, int right)
        {
            return left - right;
        }
    }

}
