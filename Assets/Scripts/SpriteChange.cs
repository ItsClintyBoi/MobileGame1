using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour
{
    public Sprite newSprite; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        SpriteRenderer renderer = other.GetComponentInChildren<SpriteRenderer>();

        if (renderer != null)
        {
            renderer.sprite = newSprite;
        }
    }
}