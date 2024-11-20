using System;
using System.Collections.Generic;
using schedulerlibrary.Models;
using Google.Cloud.Firestore;

namespace schedulerlibrary.Models
{
    [FirestoreData]
    public class Shift
    {
        [FirestoreProperty]
        public int ShiftId { get; set; }

        [FirestoreProperty]
        public DateTime StartTime { get; set; }

        [FirestoreProperty]
        public DateTime EndTime { get; set; }

        [FirestoreProperty]
        public List<ShiftAssignment> ShiftAssignments { get; set; } // Changed from AssignedStaff

        public Shift()
        {
            ShiftAssignments = new List<ShiftAssignment>();
        }

        public void AddStaff(Staff staff)
        {
            var assignment = new ShiftAssignment(staff, this);
            ShiftAssignments.Add(assignment);
        }

        // Property to store the Staff member assigned to this shift
        public Staff Staff { get; set; }
        public object Department { get; set; }

        // Constructor
        public Shift(int shiftId, DateTime startTime, DateTime endTime, Staff staff)
        {
            ShiftId = shiftId;
            StartTime = startTime;
            EndTime = endTime;
            Staff = staff; // Assign the staff member to this shift
        }
    }
}
