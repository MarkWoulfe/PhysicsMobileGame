using UnityEngine;
using System.Collections;

public class Cannon_Pitch : MonoBehaviour {

	public int rotateSpeed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("up"))
			transform.Rotate (0, 0, rotateSpeed);
		if(Input.GetKey("down"))
			transform.Rotate (0, 0, -rotateSpeed);
	}
}
