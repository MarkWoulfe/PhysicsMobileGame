﻿using UnityEngine;
using System.Collections;

public class Cannon_Pitch : MonoBehaviour
{
    public GUISkin myGUISkin;

    //The seperate cannon ball object defaults
    GameObject cannonBall;
    GameObject newCannonBall;
    //the angle to be used for our cannon slider
    float cannonAngle = 0.0f;
    float shotTimer = 1;
    float shotCount = 0;
    float shotLimit = 1;
    float shotsLeft = 0;
    //default low power
    float pow = 1000;
    bool firePressed = false;
    bool disableGUI = false;
    bool over = false;
    public GameObject gameCamera;
    private CameraFollow gameCameraScript;

    //have the slider scale to the users device
    float sliderWidth = Screen.width * 0.05f;
    float sliderHeight = Screen.height - 50;

    //Keeps track if the cannon has been fired or not
    bool fired = false;

    //draw our GUI elements
    void OnGUI()
    {
        //while our ui is not disabled
        if (!disableGUI)
        {

            //use a custom skin
            GUI.skin = myGUISkin;
            //make sure our sliders scales to the device
            GUI.skin.verticalSlider.fixedWidth = sliderWidth;
            GUI.skin.verticalSliderThumb.fixedWidth = sliderWidth;
            GUI.skin.horizontalSlider.fixedHeight = sliderWidth;
            GUI.skin.horizontalSliderThumb.fixedHeight = sliderWidth;
            //font size based on device (so you can see it well)
            GUI.skin.button.fontSize = (int)sliderWidth;
            GUI.skin.box.fontSize = (int)sliderWidth - 5;
            GUI.skin.box.alignment = TextAnchor.MiddleCenter;
            GUI.skin.label.fontSize = (int)sliderWidth - 5;
            GUI.skin.label.alignment = TextAnchor.UpperCenter;
            //some label rotation for our angle indicator (4x4 backup acting as a push/pop)
            Matrix4x4 backup = GUI.matrix;
            GUIUtility.RotateAroundPivot(-90, new Vector2(25 + sliderWidth / 2, sliderHeight));
            GUI.Label(new Rect((sliderWidth - (sliderWidth / 2)), sliderHeight - (sliderWidth / 2) - 10, sliderHeight, sliderWidth * 2), "Angle");
            GUI.matrix = backup;
            //draw our angle slider
            cannonAngle = GUI.VerticalSlider(new Rect(25, 25, sliderWidth, sliderHeight), cannonAngle, 45.0f, 0.0f);
            //draw our power slider with label
            GUI.Label(new Rect(25 + sliderWidth + 25, 20, (Screen.width / 2) - (sliderWidth + 50), sliderWidth * 2), "Power");
            pow = GUI.HorizontalSlider(new Rect(25 + sliderWidth + 25, 25, (Screen.width / 2) - (sliderWidth + 50), sliderWidth * 2), pow, 1000.0f, 3000.0f);
            //label showing the user how many shots they have left			
            GUI.Box(new Rect(25 + sliderWidth + 25, sliderWidth + 35, (Screen.width / 2) - (sliderWidth + 50), sliderWidth), "Shots Left: " + shotsLeft);
            //button for firing the cannonball
            if (GUI.Button(new Rect(25 + sliderWidth + 25, sliderWidth * 2 + 50, (Screen.width / 2) - (sliderWidth + 50), sliderWidth * 2), "Fire"))
            {
                firePressed = true;
            }

        }
        //a reset button when the user is out of shots
        if (over)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - (sliderWidth * 3) / 2, 50, sliderWidth * 3, sliderWidth * 2), "Retry"))
            {
                //Reloads the start menu
                Application.LoadLevel("cannonBallSelect");
            }
        }

    }

    void Start()
    {
        //When the scene starts it finds the ball that the user selected from the menu
        cannonBall = GameObject.FindGameObjectWithTag("CannonBall");

        //Finds which ball was selected between Football, BowlingBall, CannonBall and LeadBall

        //Football
        if (cannonBall.rigidbody.mass < 0.6f)
        {
            shotLimit = 4;
        }
        //Bowling Ball
        else if (cannonBall.rigidbody.mass < 5.1f)
        {
            shotLimit = 3;
        }
        //CannonBall
        else if (cannonBall.rigidbody.mass < 10.1f)
        {
            shotLimit = 2;
        }
        //LeadBall
        else if (cannonBall.rigidbody.mass < 20.1f)
        {
            shotLimit = 1;
        }

        //Stores the script on the camera
        gameCameraScript = gameCamera.GetComponent<CameraFollow>();
        //Creates a new cannon ball object
        newCannonBall = new GameObject();
        //Adds a rigid body to the new cannon ball
        newCannonBall.AddComponent<Rigidbody>();
        //Moves it to the position of the camera
        newCannonBall.transform.position = cannonBall.transform.position;
    }
	
    // Update is called once per frame
    void FixedUpdate()
    {
        //Gets the current angle of the cannon
        Vector3 angle = transform.localEulerAngles;

        //Sets the current z angle
        angle.z = cannonAngle;

        //Set the angle of the cannon
        transform.localEulerAngles = angle;

        if (firePressed == true && fired == false && newCannonBall.rigidbody.velocity.x < 1)
        {
            fired = true;

            //Creates a new cannon ball based on the defaults defined in the editor
            newCannonBall = (GameObject)Instantiate(cannonBall);
            //Moves the new cannonball to the position of the original
            newCannonBall.transform.position = cannonBall.transform.position;
            //Call the fire function for the new cannon ball
            newCannonBall.GetComponent<cannon_ball>().fire(transform.position, angle.z, pow);
			//play a firing sound with volume based on the power
			audio.volume = pow/1500;
			audio.Play ();
            //Reset the timer back to 0
            shotTimer = 0;
            //Increase the amount of shots taken
            shotCount++;

            firePressed = false;
        }

        //Keeps track of how long the balls velocity is less than 1
        if (newCannonBall.rigidbody.velocity.x < 1 && newCannonBall.rigidbody.velocity.y < 1)
        {
            shotTimer += Time.deltaTime;
        }
        else
        {
            shotTimer = 0;
        }
    }

	void Update(){
		//check how many shots we have left
		shotsLeft = shotLimit - shotCount;

		//If the cannon balls velocity is less than 1 for more than 2 seconds jump back to the cannon
		if (shotTimer < 1 && fired == true && over == false)
		{
			//pans out when firing the ball
			Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 90, Time.deltaTime * 5);
			//Moves the camera to follow the cannon
			gameCameraScript.MoveCamera(newCannonBall.transform.position);
			//stop drawing the gui
			disableGUI = true;
		}
		else
		{
			//Allow another shot to be fired it is less than the limit
			if (shotCount < shotLimit)
			{
				fired = false;
				//pans the camera back into the cannon
				Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 60, Time.deltaTime * 5);
				//Moves the camera to follow the new cannon ball
				gameCameraScript.MoveCamera(cannonBall.transform.position);
				//redraw the gui
				disableGUI = false;
			}
			else
			{
				//Set the game over 
				over = true;
				//Destroys the cannonBall at the end of the game
				DestroyObject(cannonBall);
				//Resets the camera pan
				Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 60, Time.deltaTime * 5);
				//Turns the GUI back on
				disableGUI = true;
				//Moves the camera to give a view of the whole scene
				Camera.main.transform.position = new Vector3(10, 10, -28);
				Camera.main.transform.rotation = Quaternion.Euler(0, 0, 0);
			}
		}
	}
}