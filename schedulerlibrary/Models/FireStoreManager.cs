using Google.Cloud.Firestore;
using System;
using System.Threading.Tasks;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Api.Gax;

namespace schedulerlibrary.Models
{
    public class FirestoreManager
    {
        private FirestoreDb db;
        private string projectId;
        private string credentialsFilePath;

        // Constructor for dynamic configuration
        public FirestoreManager(string projectId, string credentialsFilePath)
        {
            this.projectId = "scheduler-dc971";
            this.credentialsFilePath = @"C:\Users\HP\source\repos\SchedulerStaff\scheduler-dc971-firebase-adminsdk-x08h0-a9820976bb.json";
        }

        // Initialize FirestoreManager with Firebase project ID and credentials
        public void InitFireStore()
        {
            try
            {
                if (FirebaseApp.DefaultInstance == null)
                {
                    Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialsFilePath);
                    FirebaseApp.Create(new AppOptions
                    {
                        Credential = GoogleCredential.GetApplicationDefault(),
                        ProjectId = projectId,
                    });
                }

                db = FirestoreDb.Create(projectId);
                Console.WriteLine("Connected to Firestore.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to initialize Firestore: {ex.Message}");
            }
        }

        // Save staff data to Firestore
        public async Task SaveStaffAsync(Staff staff)
        {
            try
            {
                var staffCollection = db.Collection("Staff");
                var docRef = staffCollection.Document(staff.Id.ToString());
                await docRef.SetAsync(staff);
                Console.WriteLine($"Staff with ID {staff.Id} saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving staff data: {ex.Message}");
            }
        }

        // Retrieve staff data by staffId
        public async Task<Staff> GetStaffAsync(int staffId)
        {
            try
            {
                var docRef = db.Collection("Staff").Document(staffId.ToString());
                var snapshot = await docRef.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    return snapshot.ConvertTo<Staff>();
                }

                Console.WriteLine($"No staff found with ID {staffId}.");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving staff data: {ex.Message}");
                return null;
            }
        }

        // Save shift data to Firestore
        public async Task SaveShiftAsync(Shift shift)
        {
            try
            {
                var shiftCollection = db.Collection("Shifts");
                var docRef = shiftCollection.Document(shift.ShiftId.ToString());
                await docRef.SetAsync(shift);
                Console.WriteLine($"Shift with ID {shift.ShiftId} saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving shift data: {ex.Message}");
            }
        }

        // Retrieve shift data by shiftId
        public async Task<Shift> GetShiftAsync(int shiftId)
        {
            try
            {
                var docRef = db.Collection("Shifts").Document(shiftId.ToString());
                var snapshot = await docRef.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    return snapshot.ConvertTo<Shift>();
                }

                Console.WriteLine($"No shift found with ID {shiftId}.");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving shift data: {ex.Message}");
                return null;
            }
        }

        // Save task allocation data to Firestore
        public async Task SaveTaskAllocationAsync(TaskAllocation taskAllocation)
        {
            try
            {
                var taskAllocCollection = db.Collection("TaskAllocations");
                var docRef = taskAllocCollection.Document(taskAllocation.TaskId.ToString());
                await docRef.SetAsync(taskAllocation);
                Console.WriteLine($"Task allocation with ID {taskAllocation.TaskId} saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving task allocation: {ex.Message}");
            }
        }
    }
}
