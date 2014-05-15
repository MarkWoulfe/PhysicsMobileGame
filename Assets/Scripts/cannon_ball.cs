using UnityEngine;
using System.Collections;

public class cannon_ball : MonoBehaviour {

	public float power;
	public Vector3 angle;

    public GameObject cannon;

	void start(){

	}

	void Update() {

		if (Input.GetKeyDown ("space") || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)) {

            angle = transform.position - cannon.transform.position;

            angle.Normalize();
            print(angle);

			rigidbody.AddForce(angle * power);
			rigidbody.useGravity = true;
		}
	}
}
