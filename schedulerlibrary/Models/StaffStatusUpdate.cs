using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedulerlibrary.Models
{
    public class StaffStatusUpdate : RealTimeStatusUpdate
    {
        // Additional property for staff-specific status updates
        public Staff AssignedStaff { get; set; }

        // Constructor to initialize status update with status ID, shift, staff, and status
        public StaffStatusUpdate(int statusId, Shift assignedShift, Staff assignedStaff, string status)
            : base(statusId, assignedShift, status)
        {
            AssignedStaff = assignedStaff; // Initialize the specific staff member for this update
        }

        // Override UpdateStatus to implement staff-specific update logic
        // public override void UpdateStatus()
        //{
        // Staff-specific logic for status update
        //   Console.WriteLine($"Staff {AssignedStaff.Name} status updated to: {Status} for shift {Shift.ShiftId} at {UpdateTime}");
        //}

        static void UpdateStaffStatus(StaffList staffList)
        {
            Console.WriteLine("\nUpdating Staff Statuses:");

            foreach (var staff in staffList.StaffMembers)
            {
                // Check if staff has at least one shift assignment
                if (staff.ShiftAssignments.Any())
                {
                    var firstAssignment = staff.ShiftAssignments[0];
                    string status = "Active"; // Example status

                    // Create and update the staff status
                    var staffStatusUpdate = new StaffStatusUpdate(1, firstAssignment.AssignedShift, staff, status); // Assuming the first shift
                    staffStatusUpdate.UpdateStatus(); // Display the update
                }
                else
                {
                    Console.WriteLine($"{staff.Name} has no shift assignments.");
                }
            }
        }

    }
}
