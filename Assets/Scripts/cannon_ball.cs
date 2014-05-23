using UnityEngine;
using System.Collections;

public class cannon_ball : MonoBehaviour {

    //Sets the power to launch the cannon ball
    public float power;
    //The cannon object
    public GameObject cannon;

    //Fires the cannon ball
    public void fire(Vector3 p, float a, float pow)
    {
        //Rotate the ball so that it is at the end of the cannon
        transform.RotateAround(p, Vector3.forward, a);

        //Scale the object up so that the object is not at 0, 0, 0 (default value)
        transform.localScale = new Vector3(1, 1, 1);

        //Gets the direction between the cannon and the ball
        Vector3 dir = transform.position - cannon.transform.position;
        //Normalises the vector
        dir.Normalize();
        //Adds force in the correct direction
        rigidbody.AddForce(dir * pow);
        //Makes sure that gravity is acting on the ball
        rigidbody.useGravity = true;
    }
}
