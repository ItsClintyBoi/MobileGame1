using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    // Reference to the panel you want to deactivate
    public GameObject panelToDeactivate;

    // Method to deactivate the panel
    public void DeactivatePanel()
    {
        // Check if the panelToDeactivate is not null
        if (panelToDeactivate != null)
        {
            // Deactivate the panel
            panelToDeactivate.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Panel to deactivate is not assigned!");
        }
    }
}
