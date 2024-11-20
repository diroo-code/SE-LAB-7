using Google.Cloud.Firestore;

namespace schedulerlibrary.Models

{
    [FirestoreData]
    public class TaskAllocation
    {
        [FirestoreProperty]
        public int TaskId { get; set; }

        [FirestoreProperty]
        public string TaskName { get; set; } = string.Empty;

        [FirestoreProperty]
        public Staff AssignedStaff { get; set; }

        public void AssignTask(Staff staff)
        {
            AssignedStaff = staff;
        }


    }
}
