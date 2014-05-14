using UnityEngine;
using System.Collections;

public class Cannon_Pitch : MonoBehaviour {

	public int rotateSpeed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        Vector3 angle = transform.localEulerAngles;

        if (Input.GetKey("up") && (angle.z <= 45.1f || angle.z >= 329.9f))
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        if (Input.GetKey("down") && (angle.z <= 45.1f || angle.z >= 329.9f))
            transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime);

        angle = transform.localEulerAngles;

        if (angle.z > 45 && angle.z < 60)
            angle.z = 45;

        if (angle.z > 310 && angle.z < 330)
            angle.z = 330;

        transform.localEulerAngles = angle;

        print(angle.z);
	}
}
