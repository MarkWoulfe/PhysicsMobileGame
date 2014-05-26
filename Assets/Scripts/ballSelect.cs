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

				buttonWidth = (Screen.width / 2) - 100;
				buttonHeight = (Screen.height / 2) - 100;
				fontSize = (int)buttonWidth/15;

		}

		void OnGUI ()
		{
				
				GUI.skin.button.fontSize = fontSize;
				GUI.skin.button.imagePosition = ImagePosition.ImageAbove;

				if (GUI.Button (new Rect (50, 50, buttonWidth, buttonHeight), new GUIContent ("Football \n Mass - " + g_football.rigidbody.mass, football))) {
						DontDestroyOnLoad (g_football);
						Application.LoadLevel ("main");
				}

				if (GUI.Button (new Rect (150 + buttonWidth, 50, buttonWidth, buttonHeight), new GUIContent ("Bowling Ball \n Mass - " + g_bowlingball.rigidbody.mass, bowlingball))) {
						DontDestroyOnLoad (g_bowlingball);
						Application.LoadLevel ("main");
				}

				if (GUI.Button (new Rect (50, 150 + buttonHeight, buttonWidth, buttonHeight), new GUIContent ("Cannonball \n Mass - " + g_cannonball.rigidbody.mass, cannonball))) {
						DontDestroyOnLoad (g_cannonball);
						Application.LoadLevel ("main");
				}

				if (GUI.Button (new Rect (150 + buttonWidth, 150 + buttonHeight, buttonWidth, buttonHeight), new GUIContent ("Leab Ball \n Mass - " + g_leadball.rigidbody.mass, leadball))) {
						DontDestroyOnLoad (g_leadball);
						Application.LoadLevel ("main");
				}

		}
}
