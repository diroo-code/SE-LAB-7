using schedulerlibrary.Models;
using Google.Cloud.Firestore;

namespace schedulerlibrary.Models
{
    [FirestoreData]
    public class ShiftAssignment
    {
        [FirestoreProperty]
        public Staff AssignedStaff { get; set; }

        [FirestoreProperty]
        public Shift AssignedShift { get; set; }

        public ShiftAssignment(Staff staff, Shift shift)
        {
            AssignedStaff = staff;
            AssignedShift = shift;
        }

        public override string ToString()
        {
            return $"{AssignedStaff.Name} assigned to Shift {AssignedShift.ShiftId} from {AssignedShift.StartTime} to {AssignedShift.EndTime}";
        }
    }
}
