using UnityEngine;
using System.Collections;

public class FloorSound : MonoBehaviour {

	//script that plays sounds when the towers hit the floor
	public AudioClip wood;
	public AudioClip stone;
	public AudioClip iron;

	void OnCollisionEnter (Collision other)
	{
		//avoid playing a sound on initial towers resting on the floor
		if(Time.timeSinceLevelLoad > 1){
			if (other.gameObject.tag == "Wood") {
				AudioSource.PlayClipAtPoint(wood, other.transform.position);
			}
			if (other.gameObject.tag == "Stone") {
				AudioSource.PlayClipAtPoint(stone, other.transform.position);
			}
			if (other.gameObject.tag == "Iron") {
				AudioSource.PlayClipAtPoint(iron, other.transform.position);
			}
		}
	}
}
