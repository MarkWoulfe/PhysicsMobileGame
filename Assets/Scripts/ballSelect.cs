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

				buttonWidth = (Screen.width / 2) - 50;
				buttonHeight = (Screen.height / 2) - 50;

		}

		void OnGUI ()
		{

				if (GUI.Button (new Rect (50, 50, buttonWidth, buttonHeight), "Football")) {
						DontDestroyOnLoad(g_football);
						Application.LoadLevel("main");
				}

				if (GUI.Button (new Rect (50 + buttonWidth, 50, buttonWidth, buttonHeight), "Bowlingball")) {
						DontDestroyOnLoad(g_bowlingball);
						Application.LoadLevel("main");
				}

				if (GUI.Button (new Rect (50, 50 + buttonHeight, buttonWidth, buttonHeight), "Leadball")) {
						DontDestroyOnLoad(g_leadball);
						Application.LoadLevel("main");
				}

				if (GUI.Button (new Rect (50 + buttonWidth, 50 + buttonHeight, buttonWidth, buttonHeight), "Cannonball")) {
						DontDestroyOnLoad(g_cannonball);
						Application.LoadLevel("main");
				}

		}
}
