// Francesco Maoli & Yang Song
// Attach to empty object in scene
// Created 6/19/2014
// Last Updated 7/3/2014

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Score variables
	public static int currentScorer;
	public static int highScorer;

	// Level variables
	public static int currentLevel = 0;
	public static int unlockedLevel;

	[SerializeField]
	private Rect timerRect;

	[SerializeField]
	private GUISkin skin;

	[SerializeField]
	private float startTime;

	private string currentTime;

	// Pause boolean, do not touch
	private bool ispaused = false;

	// Makes sure GameManager presists throughout levels
	void Start(){
		DontDestroyOnLoad (gameObject);
		Debug.Log ("I'm Here");
	}

	void Update (){
		startTime -= Time.deltaTime;
		currentTime = string.Format("{0:0.00}", startTime) ;

		// Pause method, see below
		Pause ();
	}


	// Verifies the level and moves player to next level based on level # as long as level is less than 2. Otherwise prints.
	public static void CompleteLevel() {

		if (currentLevel < 2) {
			currentLevel += 1;
			Application.LoadLevel (currentLevel);
		}else{
			print ("You Win!");
		}
	}

	// Pauses game on key press "space" (must setup input in inspector)
	public void  Pause() {
		if(Input.GetKeyDown("escape") && !ispaused){
			Debug.Log("Space key pressed");
			Time.timeScale = 0.0000001f;
			ispaused = true;
			return ;
		}
		
		if (Input.GetKeyDown ("escape") && ispaused) {
			Time.timeScale = 1;
			ispaused = false;
			return;
		}
		
	}


	void OnGUI(){
		GUI.Label (timerRect, currentTime);

		if (GUI.Button (new Rect (300, 400, 50, 20), "Quit")) {
			Application.Quit ();		
		}
	}
}


