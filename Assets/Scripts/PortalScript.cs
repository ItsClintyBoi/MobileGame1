using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public Gamemodes Gamemode;
    public Speeds Speed;
    public bool gravity;
    public int State;

    SpriteRenderer frontTexture;
    SpriteRenderer backTexture;

    BoxCollider2D col;

    void Start()
    {

    }


    public void initiatePortal(Movement movement)
    {
        movement.ChangeThroughPortal(Gamemode, Speed, gravity ? 1 : -1, State, transform.position.y);
    }
}
