using UnityEngine;
using System.Collections;

public class cannon_ball : MonoBehaviour {

    //Sets the power to launch the cannon ball
    public float power;

    //Fires the cannon ball
    public void fire(Vector3 p, float a, float pow)
    {
        collider.enabled = true;

        //Rotate the ball so that it is at the end of the cannon
        transform.RotateAround(p, Vector3.forward, a);

        if (rigidbody.mass > 15)
        {
            //Smaller scale for the lead ball for greater effect of mass.
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }
        else
        {
            //Scale the object up so that the object is not at 0, 0, 0 (default value)
            transform.localScale = new Vector3(1, 1, 1);
        }

        //Gets the direction between the cannon and the ball
        Vector3 dir = transform.position - p;
        //Normalises the vector
        dir.Normalize();
        //Adds force in the correct direction
        rigidbody.AddForce(dir * (pow * rigidbody.mass));
        rigidbody.AddTorque(new Vector3(0,0,-1) * pow);
        //Makes sure that gravity is acting on the ball
        rigidbody.useGravity = true;
    }
}
