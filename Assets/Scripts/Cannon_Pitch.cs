using UnityEngine;
using System.Collections;

public class Cannon_Pitch : MonoBehaviour
{
	//the angle to be used for our cannon slider
	public float cannonAngle = 0.0f;

    public int rotateSpeed = 10;
    public GameObject cannonBall;

	//have the slider scale to the users device
	float sliderWidth = Screen.width * 0.4f;
	float sliderHeight = Screen.height-50;

    bool fired = false;

	//draw our slider
	void OnGUI() {
		cannonAngle = GUI.VerticalSlider(new Rect(25, 25, sliderWidth, sliderHeight), cannonAngle, 45.0f, 0.0f);
	}

    // Update is called once per frame
    void Update()
    {
        Vector3 angle = transform.localEulerAngles;

		angle.z = cannonAngle;

        if (Input.GetKeyDown("space") || (Input.touchCount == 2 && Input.GetTouch(1).phase == TouchPhase.Began))
        {
            fired = true;
        }

        transform.localEulerAngles = angle;

        if(fired == true)
        {
            fired = false;
            cannonBall.GetComponent<cannon_ball>().fire(transform.position, angle.z);
        }
    }
}