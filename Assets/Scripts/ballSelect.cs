using UnityEngine;
using System.Collections;

public class ballSelect : MonoBehaviour {

	public Texture football;
	public Texture bowlingball;
	public Texture leadball;
	public Texture cannonball;

	float buttonWidth, buttonHeight;

	void Start () {

		buttonWidth = (Screen.width / 2) - 50;
		buttonHeight = (Screen.height / 2) - 50;

	}

	void OnGUI(){

		if (GUI.Button(new Rect(50, 50, buttonWidth, buttonHeight), "Football"))
			Debug.Log("1");

		if (GUI.Button(new Rect(50 + buttonWidth, 50, buttonWidth, buttonHeight), "Bowlingball"))
			Debug.Log("2");

		if (GUI.Button(new Rect(50, 50+buttonHeight, buttonWidth, buttonHeight), "Leadball"))
			Debug.Log("3");

		if (GUI.Button(new Rect(50 + buttonWidth, 50+buttonHeight, buttonWidth, buttonHeight), "Cannonball"))
			Debug.Log("4");

	}
}
