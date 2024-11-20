using System.Collections.Generic;
using schedulerlibrary.Models;
using Google.Cloud.Firestore;
using System;

namespace schedulerlibrary.Models
{
    [FirestoreData]
    public class Staff
    {
        [FirestoreProperty]
        public int Id { get; set; }

        [FirestoreProperty]
        public string Name { get; set; }

        [FirestoreProperty]
        public string Position { get; set; }

        [FirestoreProperty]
        public List<TaskAllocation> TaskAllocations { get; set; }

        public StaffList staffList { get; set; }

        [FirestoreProperty]
        public List<ShiftAssignment> ShiftAssignments { get; set; } = new List<ShiftAssignment>();
        public object Availability { get; set; }

        public int? AssignedShiftId { get; set; }


        public Staff()
        {

            staffList = new StaffList();
            TaskAllocations = new List<TaskAllocation>();
            ShiftAssignments = new List<ShiftAssignment>();
        }
        public void AssignToShift(Shift shift)
        {
            var assignment = new ShiftAssignment(this, shift);
            ShiftAssignments.Add(assignment);
            shift.AddStaff(this);
        }
    }
}
