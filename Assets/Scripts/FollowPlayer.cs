using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowPlayer : MonoBehaviour
{
    //(3.4, -2.3)
    public Vector2 cameraOffset;

    public float interpolationTime = 0.1f;

    public Transform player;
    public Transform Background;
    public Movement playerScript;

    bool jump = false;
    float scrollSpeed;
    Vector3 newVector;
    bool firstFrame = true;
    private void Update()
    {

    }
    void FixedUpdate()
    {

        newVector = new Vector3(player.position.x + cameraOffset.x, newVector.y, -10);

        if (playerScript.cameraValues[(int)playerScript.CurrentGamemode] > 10)
            FreeCam(firstFrame);

        Background.localPosition = new Vector3((-player.position.x * 0.5f) + Mathf.Floor(player.transform.position.x / 96) * 48, 2.2f, 10);
        transform.position = newVector;
        firstFrame = false;
    }

    void FreeCam(bool doInstantly)
    {
        
    }

    Vector3 InterpolateVec3(Vector3 current, Vector3 target, float speed)
    {
        return current + Vector3.Normalize(target - current) * Time.deltaTime * speed * Mathf.Clamp(Vector2.Distance(current, target), 0, 1);
    }
}

