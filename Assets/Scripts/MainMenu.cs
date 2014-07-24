using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GUISkin skin;

	void OnGUI(){

		GUI.skin = skin;
		GUI.Label (new Rect (10, 10, 400, 45), "Go Home");

		if (GUI.Button (new Rect (10, 150, 100, 45), "Play")) {
			Application.LoadLevel(0);		
		}

		if (GUI.Button (new Rect (10, 205, 100, 45), "Quit")) {
			Application.Quit ();		
		}
	}
}
