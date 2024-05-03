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
    public Transform GroundCamera;
    public Transform TopGround;
    public Transform Background;
    public Movement playerScript;

    Vector3 newVector;
    bool firstFrame = true;

    void FixedUpdate()
    {
        newVector = new Vector3(player.position.x + cameraOffset.x, newVector.y, -10);

        if (playerScript.cameraValues[(int)playerScript.CurrentGamemode] > 10)
            FreeCam(firstFrame);
        else
            StaticCam(playerScript.cameraValues[(int)playerScript.CurrentGamemode], playerScript.yPosLastPortal, firstFrame);

        Background.localPosition = new Vector3((-player.position.x * 0.5f) + Mathf.Floor(player.transform.position.x / 96) * 48, 2.2f, 10);
        transform.position = newVector;
        firstFrame = false;
    }

    void FreeCam(bool doInstantly)
    {
        GroundCamera.position = InterpolateVec3(new Vector3(0, GroundCamera.position.y), Vector3.up * cameraOffset, 20) + Vector3.right * (Mathf.Floor(player.transform.position.x / 5) * 5);

        if (Vector2.Distance(TopGround.localPosition, Vector3.up * 20f) < 0.3f)
            TopGround.gameObject.SetActive(false);
        if (TopGround)
            TopGround.localPosition = InterpolateVec3(TopGround.localPosition, Vector3.up * 20f, 100);

        if (!doInstantly)
            newVector += Vector3.up * (Mathf.Lerp(player.transform.position.y + 1.7f - newVector.y, -0.6f - newVector.y, (player.position.y <= 4.2f) ? 1 : 0)) * Time.deltaTime / interpolationTime;
        else
            newVector += Vector3.up * (player.transform.position.y + 1.7f);
    }

    Vector3 InterpolateVec3(Vector3 current, Vector3 target, float speed)
    {
        return current + Vector3.Normalize(target - current) * Time.deltaTime * speed * Mathf.Clamp(Vector2.Distance(current, target), 0, 1);
    }

    void StaticCam(int CamSize, float yPosLastPortal, bool doInstantly)
    {
        TopGround.gameObject.SetActive(true);

        GroundCamera.position = InterpolateVec3(new Vector3(0, GroundCamera.position.y), Vector3.up * Mathf.Clamp(yPosLastPortal - CamSize * 0.5f, cameraOffset.y, float.MaxValue), 20) + Vector3.right * (Mathf.Floor(player.transform.position.x / 5) * 5);
        TopGround.transform.localPosition = InterpolateVec3(TopGround.transform.localPosition, Vector3.up * (4.5f + CamSize), 30);

        if (!doInstantly)
            newVector += Vector3.up * (5 + Mathf.Clamp(yPosLastPortal - CamSize * 0.5f, cameraOffset.y, 2048) - newVector.y - ((11 - CamSize) * 0.5f)) * Time.deltaTime / interpolationTime;
        else
            newVector += Vector3.up * (5 + Mathf.Clamp(yPosLastPortal - CamSize * 0.5f, cameraOffset.y, 2048) - ((11 - CamSize) * 0.5f));
    }
}

