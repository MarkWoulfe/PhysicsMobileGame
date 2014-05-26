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

		void Start ()
		{

				buttonWidth = (Screen.width / 2) - 100;
				buttonHeight = (Screen.height / 2) - 100;

		}

		void OnGUI ()
		{

				if (GUI.Button (new Rect (50, 50, buttonWidth, buttonHeight), new GUIContent ("", football))) {
						DontDestroyOnLoad (g_football);
						Application.LoadLevel ("main");
				}

				if (GUI.Button (new Rect (150 + buttonWidth, 50, buttonWidth, buttonHeight), new GUIContent ("", bowlingball))) {
						DontDestroyOnLoad (g_bowlingball);
						Application.LoadLevel ("main");
				}

				if (GUI.Button (new Rect (50, 150 + buttonHeight, buttonWidth, buttonHeight), new GUIContent ("", cannonball))) {
						DontDestroyOnLoad (g_cannonball);
						Application.LoadLevel ("main");
				}

				if (GUI.Button (new Rect (150 + buttonWidth, 150 + buttonHeight, buttonWidth, buttonHeight), new GUIContent ("", leadball))) {
						DontDestroyOnLoad (g_leadball);
						Application.LoadLevel ("main");
				}

		}
}
