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

    public void fire(Vector3 p, float a)
    {
        transform.RotateAround(p, Vector3.forward, a);

        transform.localScale = new Vector3(20, 20, 20);

        angle = transform.position - cannon.transform.position;

        angle.Normalize();

        rigidbody.AddForce(angle * power);
        rigidbody.useGravity = true;
    }
}
