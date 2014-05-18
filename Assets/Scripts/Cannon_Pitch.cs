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

    public GameObject gameCamera;
    private CameraFollow gameCameraScript;

	//have the slider scale to the users device
	float sliderWidth = Screen.width * 0.05f;
	float sliderHeight = Screen.height-50;

    //Keeps track if the cannon has been fired or not
    bool fired = false;

	//draw our slider
	void OnGUI() {
		GUI.skin = myGUISkin;
		GUI.skin.verticalSlider.fixedWidth = sliderWidth;
		GUI.skin.verticalSliderThumb.fixedWidth = sliderWidth;
		cannonAngle = GUI.VerticalSlider(new Rect(25, 25, sliderWidth, sliderHeight), cannonAngle, 45.0f, 0.0f);
	}

    void Start()
    {
        gameCameraScript = gameCamera.GetComponent<CameraFollow>();
        newCannonBall = new GameObject();
        newCannonBall.AddComponent<Rigidbody>();
        newCannonBall.transform.position = cannonBall1.transform.position;
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
            //fired = true;

            //Creates a new cannon ball based on the defaults defined in the editor
            newCannonBall = (GameObject)Instantiate(cannonBall1);
            //Moves the new cannonball to the position of the original
            newCannonBall.transform.position = cannonBall1.transform.position;
            //Call the fire function for the new cannon ball
            newCannonBall.GetComponent<cannon_ball>().fire(transform.position, angle.z);
        }

        if (newCannonBall.rigidbody.velocity.x < 1)
        {
            gameCameraScript.MoveCamera(cannonBall1.transform.position);
        }
        else
        {
            //Moves the camera to follow the new cannon ball
            gameCameraScript.MoveCamera(newCannonBall.transform.position);
        }
    }
}