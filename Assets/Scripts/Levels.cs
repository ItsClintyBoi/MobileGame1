using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    public GameObject panelToActivate; // Reference to the panel you want to activate

    private void Start()
    {
        // Ensure the panel is initially deactivated
        if (panelToActivate != null)
        {
            panelToActivate.SetActive(false);
        }
    }

    public void OnButtonClick()
    {
        // Activate the panel when the button is clicked
        if (panelToActivate != null)
        {
            panelToActivate.SetActive(true);
        }
    }
}
