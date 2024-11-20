using System;
using System.Collections.Generic;
using schedulerlibrary.Models;
using Google.Cloud.Firestore;

namespace schedulerlibrary.Models
{
    // Define the ShiftPreference class to manage staff shift preferences
    public class ShiftPreference

    {
     
        
            // Property to store the staff member associated with these preferences
            public Staff Staff { get; set; }

            // Property to store a list of preferred shift IDs for the staff member
            // Initialized to an empty list to avoid null reference issues
            public List<int> PreferredShiftIds { get; set; } = new List<int>();

            // Method to add a preferred shift ID to the list
            // Takes the ID of a shift (int) as a parameter and adds it to the PreferredShiftIds list
            public void AddPreference(int shiftId)
            {
                PreferredShiftIds.Add(shiftId); // Add the shift ID to the list of preferences
            }

            // Method to remove a preferred shift ID from the list
            // Takes the ID of a shift (int) as a parameter and removes it from the PreferredShiftIds list
            public void RemovePreference(int shiftId)
            {
                PreferredShiftIds.Remove(shiftId); // Remove the shift ID from the list of preferences
            }
        }
    }

