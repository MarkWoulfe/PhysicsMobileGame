using UnityEngine;
using System.Collections;

public class cannon_ball : MonoBehaviour {

	public float power;
	public Vector3 angle;

    public GameObject cannon;

	void start(){

	}

	void Update() {

	}

    public void fire()
    {
        angle = transform.position - cannon.transform.position;

        angle.Normalize();

        rigidbody.AddForce(angle * power);
        rigidbody.useGravity = true;
    }
}
