using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedulerlibrary.Models
{
    public class Availability
    {
        // Unique identifier for the staff member
        public int Id { get; set; }

        // List of days the staff member is available to work
        public List<DayOfWeek> AvailableDays { get; set; } = new List<DayOfWeek>();

        // Start and end time of availability on available days
        public TimeSpan StartAvailability { get; set; }
        public TimeSpan EndAvailability { get; set; }

        // Constructor to initialize the Availability object with a staff ID
        public Availability(int id)
        {
            this.Id = id; // Assign constructor parameter to the property
        }

        // Method to set the availability days and hours
        public void SetAvailability(List<DayOfWeek> days, TimeSpan start, TimeSpan end)
        {
            AvailableDays = days;
            StartAvailability = start;
            EndAvailability = end;
        }

        // Method to check if the staff member is available on a specific day and time
        public bool IsAvailable(DayOfWeek day, TimeSpan time)
        {
            return AvailableDays.Contains(day) && time >= StartAvailability && time <= EndAvailability;
        }
    }
}
