using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Google.Cloud.Firestore;

namespace schedulerlibrary.Models
{
    [FirestoreData]
    public class StaffList
    {
        // Store staff members in a dictionary for faster lookup by ID
        private readonly ConcurrentDictionary<int, Staff> _staffMembers;

        // Expose the staff members as a read-only collection
        [FirestoreProperty]
        public IReadOnlyCollection<Staff> StaffMembers => new List<Staff>(_staffMembers.Values);

        public StaffList()
        {
            _staffMembers = new ConcurrentDictionary<int, Staff>();
        }

        /// <summary>
        /// Adds a new staff member to the list.
        /// </summary>
        /// <param name="staff">The staff member to add.</param>
        /// <returns>True if added successfully; false if a duplicate ID exists.</returns>
        public bool AddStaff(Staff staff)
        {
            if (staff == null)
                throw new ArgumentNullException(nameof(staff), "Staff cannot be null.");

            // Check for duplicate staff ID before adding
            if (_staffMembers.ContainsKey(staff.Id))
            {
                Console.WriteLine($"Staff with ID {staff.Id} already exists. Skipping addition.");
                return false;
            }

            // Try to add the new staff member
            return _staffMembers.TryAdd(staff.Id, staff);
        }

        /// <summary>
        /// Retrieves a staff member by their ID.
        /// </summary>
        /// <param name="id">The ID of the staff member to retrieve.</param>
        /// <returns>The staff member if found; otherwise, null.</returns>
        public Staff GetStaff(int id)
        {
            _staffMembers.TryGetValue(id, out var staff);
            return staff;
        }

        /// <summary>
        /// Removes a staff member by their ID.
        /// </summary>
        /// <param name="id">The ID of the staff member to remove.</param>
        /// <returns>True if removed successfully; false if the staff member does not exist.</returns>
        public bool RemoveStaff(int id)
        {
            return _staffMembers.TryRemove(id, out _);
        }

        /// <summary>
        /// Clears all staff members from the list.
        /// </summary>
        public void Clear()
        {
            _staffMembers.Clear();
        }

        /// <summary>
        /// Checks if a staff member exists by their ID.
        /// </summary>
        /// <param name="id">The ID to check.</param>
        /// <returns>True if the staff member exists; otherwise, false.</returns>
        public bool ContainsStaff(int id)
        {
            return _staffMembers.ContainsKey(id);
        }

        /// <summary>
        /// Converts the staff list to a mutable List<Staff>.
        /// </summary>
        /// <returns>A List<Staff> containing all staff members.</returns>
        public List<Staff> GetStaffListAsList()
        {
            return new List<Staff>(_staffMembers.Values);
        }
    }
}
