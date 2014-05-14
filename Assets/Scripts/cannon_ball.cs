using UnityEngine;
using System.Collections;

public class cannon_ball : MonoBehaviour {

	public float power;
	public Vector3 angle;

    public GameObject cannon;

	void start(){
		angle.Normalize();
	}

	void Update() {

		if (Input.GetKeyDown ("space")) {
            angle.x = 90.0f - cannon.transform.localEulerAngles.z;
            angle.y = cannon.transform.localEulerAngles.z;
            angle.Normalize();
            print(angle.x);
            print(angle.y);
			rigidbody.AddForce(angle * power);
			rigidbody.useGravity = true;
		}

	}

}
