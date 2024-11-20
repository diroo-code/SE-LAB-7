using System;
using System.Collections.Generic;
using schedulerlibrary.Models;
using Google.Cloud.Firestore;


namespace schedulerlibrary.Models
{
    public class ShiftStatusUpdate : RealTimeStatusUpdate
    {
        // Constructor for ShiftStatusUpdate, passing values to the base class constructor
        public ShiftStatusUpdate(int statusId, Shift assignedShift, string status)
            : base(statusId, assignedShift, status)
        {
            // Validate inputs to prevent null reference issues
            if (assignedShift == null)
                throw new ArgumentNullException(nameof(assignedShift), "Assigned shift cannot be null.");

            if (string.IsNullOrWhiteSpace(status))
                throw new ArgumentException("Status cannot be null or empty.", nameof(status));
        }

        // Override UpdateStatus to implement shift-specific logic
        public override void UpdateStatus()
        {
            if (Staff == null)
            {
                Console.WriteLine($"Staff for Shift {Shift.ShiftId} is not assigned, unable to update status.");
                return;
            }

            Console.WriteLine($"Shift {Shift.ShiftId} status updated to: {Status} for staff {Staff.Name} at {UpdateTime}");
        }

    }
}

