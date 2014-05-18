using UnityEngine;
using System.Collections;

public class Cannon_Pitch : MonoBehaviour
{
	//the angle to be used for our cannon slider
	public float cannonAngle = 0.0f;

    //The cannon ball object
    public GameObject cannonBall;

	//have the slider scale to the users device
	float sliderWidth = Screen.width * 0.4f;
	float sliderHeight = Screen.height-50;

    //Keeps track if the cannon has been fired or not
    bool fired = false;

	//draw our slider
	void OnGUI() {
		cannonAngle = GUI.VerticalSlider(new Rect(25, 25, sliderWidth, sliderHeight), cannonAngle, 45.0f, 0.0f);
	}

    // Update is called once per frame
    void Update()
    {
        //Gets the current angle of the cannon
        Vector3 angle = transform.localEulerAngles;

        //Sets the current z angle
		angle.z = cannonAngle;

        //Set the angle of the cannon
        transform.localEulerAngles = angle;

        //If the space key is pressed or a mobile screen is tapped and the cannon has not already been fired
        if ((Input.GetKeyDown("space") || (Input.touchCount == 2 && Input.GetTouch(1).phase == TouchPhase.Began)) && fired == false)
        {
            fired = true;
            //Call the fire function for the cannon ball
            cannonBall.GetComponent<cannon_ball>().fire(transform.position, angle.z);
        }
    }
}