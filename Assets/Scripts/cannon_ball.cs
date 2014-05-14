using UnityEngine;
using System.Collections;

public class cannon_ball : MonoBehaviour {

	public float power;
	public Vector3 angle;

	void start(){
		angle.Normalize();
	}

	void Update() {

		if (Input.GetKeyDown ("space")) {
			rigidbody.AddForce(angle * power);			
		}

	}

}
