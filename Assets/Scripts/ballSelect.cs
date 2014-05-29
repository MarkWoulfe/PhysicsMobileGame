using UnityEngine;
using System.Collections;

public class ballSelect : MonoBehaviour
{
		public Texture football;
		public Texture bowlingball;
		public Texture leadball;
		public Texture cannonball;
		public GameObject g_football;
		public GameObject g_bowlingball;
		public GameObject g_leadball;
		public GameObject g_cannonball;
		float buttonWidth, buttonHeight;
		int fontSize;

		void Start ()
		{

				buttonWidth = (Screen.width / 2) - 75;
				buttonHeight = (Screen.height / 2) - 150;
				fontSize = (int)buttonWidth/15;

		}

		void OnGUI ()
		{
				
				GUI.skin.button.fontSize = fontSize;
				GUI.skin.button.imagePosition = ImagePosition.ImageAbove;
				GUI.skin.box.fontSize = fontSize*3;

				GUI.Box(new Rect(10,10,Screen.width-20,Screen.height-20), "Pick a Cannonball!");

				if (GUI.Button (new Rect (50, 225, buttonWidth, buttonHeight), new GUIContent ("Football \n Mass - " + g_football.rigidbody.mass, football))) {
						DontDestroyOnLoad (g_football);
						Application.LoadLevel ("main");
				}

				if (GUI.Button (new Rect (100 + buttonWidth, 225, buttonWidth, buttonHeight), new GUIContent ("Bowling Ball \n Mass - " + g_bowlingball.rigidbody.mass, bowlingball))) {
						DontDestroyOnLoad (g_bowlingball);
						Application.LoadLevel ("main");
				}

				if (GUI.Button (new Rect (50, 275 + buttonHeight, buttonWidth, buttonHeight), new GUIContent ("Cannonball \n Mass - " + g_cannonball.rigidbody.mass, cannonball))) {
						DontDestroyOnLoad (g_cannonball);
						Application.LoadLevel ("main");
				}

				if (GUI.Button (new Rect (100 + buttonWidth, 275 + buttonHeight, buttonWidth, buttonHeight), new GUIContent ("Leab Ball \n Mass - " + g_leadball.rigidbody.mass, leadball))) {
						DontDestroyOnLoad (g_leadball);
						Application.LoadLevel ("main");
				}

		}
}
