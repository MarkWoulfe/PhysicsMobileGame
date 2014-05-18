using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    //The cannon ball object to follow
    public GameObject cannonBall;
	
	// Update is called once per frame
	void Update () {
        //Gets the position of the camera
        Vector3 pos = transform.position;

        //Changes the cameras x to be alongside the cannonball
        pos.x = cannonBall.transform.position.x;

        //sets the position of the camera
        transform.position = pos;
	}
}
