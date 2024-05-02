using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public Gamemodes Gamemode;
    public Speeds Speed;
    public bool Gravity;
    public int State;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        try
        {
            Movement movement = collision.gameObject.GetComponent<Movement>();

            movement.ChangeThroughPortal(Gamemode, Speed, Gravity ? 1 : -1, State);
        }
        catch { }
    }
}
