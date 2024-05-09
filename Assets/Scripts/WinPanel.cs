using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanel : MonoBehaviour
{
    public GameObject winPanel; // Reference to the win panel UI object

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Activate the win panel
            if (winPanel != null)
            {
                Time.timeScale = 0f;
                winPanel.SetActive(true);
            }
        }
    }
}
