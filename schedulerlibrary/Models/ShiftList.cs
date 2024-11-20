using System.Collections.Generic;
using Google.Cloud.Firestore;

namespace schedulerlibrary.Models
{
    [FirestoreData]
    public class ShiftList
    {
        [FirestoreProperty]
        public List<Shift> Shifts { get; private set; }

        public ShiftList()
        {
            Shifts = new List<Shift>();
        }

        public void AddShift(Shift shift)
        {
            Shifts.Add(shift);
        }
    }
}
