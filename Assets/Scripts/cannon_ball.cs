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

		//have the user fire based on the spacebar for debugging or touch controls
		if (Input.GetKeyDown ("space") || (Input.touchCount == 2 && Input.GetTouch(1).phase == TouchPhase.Began)) {

            angle = transform.position - cannon.transform.position;

            angle.Normalize();
		}

        float scaleValue = transform.localScale.x;

        if (scaleValue >= 20 && fired == false)
        {
            fired = true;
			//add a force to the cannonball
            rigidbody.AddForce(angle * power);
			//have gravity start affecting it
            rigidbody.useGravity = true;
        }
	}
}
