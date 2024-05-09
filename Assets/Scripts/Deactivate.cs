using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    public void DeactivatePanel()
    {
        // Assuming this script is attached to the panel itself
        gameObject.SetActive(false);
    }
}
