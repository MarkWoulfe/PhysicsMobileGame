using UnityEngine;
using System.Collections;

public class Cannon_Pitch : MonoBehaviour
{
	//the angle to be used for our cannon slider
	public float cannonAngle = 0.0f;
	public GUISkin myGUISkin;

	//The seperate cannon ball object defaults
	public GameObject cannonBall1;
	public GameObject cannonBall2;
	public GameObject cannonBall3;
	public GameObject cannonBall4;
	GameObject newCannonBall;
	float shotTimer = 1;
	float shotCount = 0;
	float shotLimit = 3;
	float pow = 1000;
	bool firePressed = false;
	bool disableGUI = false;
	public GameObject gameCamera;
	private CameraFollow gameCameraScript;

	//have the slider scale to the users device
	float sliderWidth = Screen.width * 0.05f;
	float sliderHeight = Screen.height - 50;

	//Keeps track if the cannon has been fired or not
	bool fired = false;

	//draw our GUI elements
	void OnGUI ()
	{

		if (disableGUI) {
			GUI.enabled = false;
		} else {
			GUI.enabled = true;
		}
		//use a custom skin
		GUI.skin = myGUISkin;
		//make sure our slider scales to the device
		GUI.skin.verticalSlider.fixedWidth = sliderWidth;
		GUI.skin.verticalSliderThumb.fixedWidth = sliderWidth;
		GUI.skin.button.fontSize = (int)sliderWidth;
		//draw our slider
		cannonAngle = GUI.VerticalSlider (new Rect (25, 25, sliderWidth, sliderHeight), cannonAngle, 45.0f, 0.0f);

		if (GUI.Button (new Rect (25 + sliderWidth + 25, 25, sliderWidth * 2, sliderWidth * 2), "-")) {
			if (pow > 1000) {
				pow -= 500;
			}	

		}

		if (GUI.Button (new Rect (25 + sliderWidth + 25 + sliderWidth * 2 + 25, 25, sliderWidth * 2, sliderWidth * 2), "+")) {
			if (pow < 4000) {
				pow += 500;
			}					
		}

		if (GUI.Button (new Rect (25 + sliderWidth + 25, 25 + sliderWidth * 2 + 25, sliderWidth * 4 + 25, sliderWidth * 2), pow + " Fire")) {
			firePressed = true;
		}

	}

	void Start ()
	{
		//Stores the script on the camera
		gameCameraScript = gameCamera.GetComponent<CameraFollow> ();
		//Creates a new cannon ball object
		newCannonBall = new GameObject ();
		//Adds a rigid body to the new cannon ball
		newCannonBall.AddComponent<Rigidbody> ();
		//Moves it to the position of the camera
		newCannonBall.transform.position = cannonBall1.transform.position;
	}

	// Update is called once per frame
	void Update ()
	{
		//Gets the current angle of the cannon
		Vector3 angle = transform.localEulerAngles;

		//Sets the current z angle
		angle.z = cannonAngle;

		//Set the angle of the cannon
		transform.localEulerAngles = angle;

		if (firePressed == true && fired == false && newCannonBall.rigidbody.velocity.x < 1) {
			fired = true;
					
			//Creates a new cannon ball based on the defaults defined in the editor
			newCannonBall = (GameObject)Instantiate (cannonBall1);
			//Moves the new cannonball to the position of the original
			newCannonBall.transform.position = cannonBall1.transform.position;
			//Call the fire function for the new cannon ball
			newCannonBall.GetComponent<cannon_ball> ().fire (transform.position, angle.z, pow);
			//Reset the timer back to 0
			shotTimer = 0;
			//Increase the amount of shots taken
			shotCount++;

			firePressed = false;
		}

		//legacy controls
		/*//If the space key is pressed or a mobile screen is tapped and the cannon has not already been fired
				if ((Input.GetKeyDown ("space") || (Input.touchCount == 2 && Input.GetTouch (1).phase == TouchPhase.Began)) && fired == false && newCannonBall.rigidbody.velocity.x < 1) {
						fired = true;

						//Creates a new cannon ball based on the defaults defined in the editor
						newCannonBall = (GameObject)Instantiate (cannonBall1);
						//Moves the new cannonball to the position of the original
						newCannonBall.transform.position = cannonBall1.transform.position;
						//Call the fire function for the new cannon ball
						newCannonBall.GetComponent<cannon_ball> ().fire (transform.position, angle.z, pow);
						//Reset the timer back to 0
						shotTimer = 0;
						//Increase the amount of shots taken
						shotCount++;
				}*/

		//Keeps track of how long the balls velocity is less than 1
        if (newCannonBall.rigidbody.velocity.x < 1 && newCannonBall.rigidbody.velocity.y < 1)
        {
			shotTimer += Time.deltaTime;
		} else {
			shotTimer = 0;
		}

		//If the cannon balls velocity is less than 1 for more than 2 seconds jump back to the cannon
		if (shotTimer < 1.0f) {
			//Moves the camera to follow the cannon
			gameCameraScript.MoveCamera (newCannonBall.transform.position);
			disableGUI = true;
		} else {
			//Allow another shot to be fired it is less than the limit
			if (shotCount < shotLimit) {
				fired = false;
			}
            else
            {
                Application.LoadLevel(Application.loadedLevel);
            }
			//Moves the camera to follow the new cannon ball
			gameCameraScript.MoveCamera (cannonBall1.transform.position);
			disableGUI = false;
		}
	}
}