using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedulerlibrary.Models
{
    public class ScheduleHistory
    {
        // Properties to store history details
        public int ShiftId { get; set; }
        public DateTime OldStartTime { get; set; }
        public DateTime OldEndTime { get; set; }
        public string ChangeReason { get; set; }
        public DateTime ChangeDate { get; private set; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }

        // Constructor to initialize a new ScheduleHistory instance
        public ScheduleHistory(int shiftId, DateTime oldStartTime, DateTime oldEndTime, string changeReason)
        {
            // Setting properties when a shift modification is logged
            ShiftId = shiftId;
            OldStartTime = oldStartTime;
            OldEndTime = oldEndTime;
            ChangeReason = changeReason;
            ChangeDate = DateTime.Now; // Set the current date and time of the change
        }

        public ScheduleHistory(int shiftId, DateTime startTime, DateTime endTime)
        {
            ShiftId = shiftId;
            StartTime = startTime;
            EndTime = endTime;
        }

        // Method to display the history details
        public void DisplayHistoryDetails()
        {
            Console.WriteLine("Schedule History:");
            Console.WriteLine($"Change Date: {ChangeDate}");
            Console.WriteLine($"Shift ID: {ShiftId}");
            Console.WriteLine($"Old Start Time: {OldStartTime}");
            Console.WriteLine($"Old End Time: {OldEndTime}");
            Console.WriteLine($"Change Reason: {ChangeReason}");
        }

        public object LogHistory()
        {
            throw new NotImplementedException();
        }
    }
}

