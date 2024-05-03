using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public Gamemodes Gamemode;
    public Speeds Speed;
    public bool gravity;
    public int State;

    [SerializeField] PortalTextures portalTextures;

    SpriteRenderer frontTexture;
    SpriteRenderer backTexture;

    BoxCollider2D col;

    void Start()
    {
        //Refresh textures
        SpriteRenderer[] Renderers = GetComponentsInChildren<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();

        if (Renderers != null)
            frontTexture = GetComponent<SpriteRenderer>();
        if (Renderers.Length > 1)
            backTexture = GetComponentsInChildren<SpriteRenderer>()[1];

        switch (State)
        {
            case 0:
                col.size = portalTextures.SpeedSprites[(int)Speed].rect.size / portalTextures.SpeedSprites[(int)Speed].pixelsPerUnit;
                col.offset = Vector2.zero;
                frontTexture.sprite = portalTextures.SpeedSprites[(int)Speed];
                backTexture.sprite = null;
                break;
            case 1:
                col.size = new Vector2(2.6f, 1.35f);
                col.offset = new Vector2(0, 0.16f);
                frontTexture.sprite = portalTextures.GamemodeSpritesFront[(int)Gamemode];
                backTexture.sprite = portalTextures.GamemodeSpritesBack[(int)Gamemode];
                break;
            case 2:
                col.size = new Vector2(2.6f, 1.1f);
                col.offset = new Vector2(0, 0.16f);
                frontTexture.sprite = portalTextures.GravityPortalSpritesFront[(int)Gamemode];
                backTexture.sprite = portalTextures.GravityPortalSpritesBack[(int)Gamemode];
                break;
        }
    }

    public void initiatePortal(Movement movement)
    {
        movement.ChangeThroughPortal(Gamemode, Speed, gravity ? 1 : -1, State, transform.position.y);
    }
}
