using UnityEngine;
using System.Collections;

public class androidClose : MonoBehaviour {
	
	// Quit the app when hitting the back button
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) 
			Application.Quit(); 
	}

}
