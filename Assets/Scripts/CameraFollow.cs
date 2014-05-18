using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject cannonBall;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;

        pos.x = cannonBall.transform.position.x;

        transform.position = pos;
	}
}
