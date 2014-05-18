using UnityEngine;
using System.Collections;

public class Cannon_Pitch : MonoBehaviour
{
	//the angle to be used for our cannon slider
	public float cannonAngle = 0.0f;

    public int rotateSpeed = 10;
    public GameObject cannonBall;

    float scaleValue = 0.01f;

	//have the slider scale to the users device
	float sliderWidth = Screen.width * 0.4f;
	float sliderHeight = Screen.height-50;

    bool fired = false;

	//draw our slider
	void OnGUI() {
		cannonAngle = GUI.VerticalSlider(new Rect(25, 25, sliderWidth, sliderHeight), cannonAngle, 45.0f, 0.0f);
	}

    void start()
    { 

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 angle = transform.localEulerAngles;
        bool pitchedTurret = false;

		angle.z = cannonAngle;

        if (Input.GetKey("up") && (angle.z < 45.1f || angle.z > 359.9f))
        {
            transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
            pitchedTurret = true;
        }
        if (Input.GetKey("down") && (angle.z < 45.1f || angle.z > 359.9f))
        {
            transform.Rotate(Vector3.forward, -rotateSpeed * Time.deltaTime);
            pitchedTurret = true;
        }
        if (Input.GetKeyDown("space") || (Input.touchCount == 2 && Input.GetTouch(1).phase == TouchPhase.Began))
        {
            fired = true;
        }

        angle = transform.localEulerAngles;

        if (angle.z > 45 && angle.z < 60)
        {
            angle.z = 45;
            pitchedTurret = false;
        }

        if (angle.z > 310 && angle.z < 360)
        {
            angle.z = 0;
            pitchedTurret = false;
        }

        transform.localEulerAngles = angle;

        if (pitchedTurret && Input.GetKey("up") && fired == false)
        {
            cannonBall.transform.RotateAround(transform.position, Vector3.forward, rotateSpeed * Time.deltaTime);
        }
        if (pitchedTurret && Input.GetKey("down") && fired == false)
        {
            cannonBall.transform.RotateAround(transform.position, Vector3.forward, -rotateSpeed * Time.deltaTime);
        }

        if (scaleValue < 20 && fired == true)
            scaleValue += 2.0f;

        if(scaleValue > 20)
        {
            cannonBall.GetComponent<cannon_ball>().fire();

            scaleValue = 20;
        }

        cannonBall.transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
    }
}