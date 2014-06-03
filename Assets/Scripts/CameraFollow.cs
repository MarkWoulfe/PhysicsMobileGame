using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public void MoveCamera(Vector3 p)
    {
        //Gets the position of the camera
        Vector3 pos = transform.position;

        //Changes the cameras x to be alongside the cannonball
        pos.x = p.x;

        //sets the position of the camera
        transform.position = pos;
    }
}
