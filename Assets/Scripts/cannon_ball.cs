using UnityEngine;
using System.Collections;

public class cannon_ball : MonoBehaviour {

	public float power;
	public Vector3 angle;

    public GameObject cannon;
    bool fired = false;

	void start(){

	}

	void Update() {

		if (Input.GetKeyDown ("space") || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)) {

            angle = transform.position - cannon.transform.position;

            angle.Normalize();
		}

        float scaleValue = transform.localScale.x;

        if (scaleValue >= 20 && fired == false)
        {
            fired = true;
            rigidbody.AddForce(angle * power);
            rigidbody.useGravity = true;
        }
	}
}
