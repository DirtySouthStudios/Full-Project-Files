// Credit: SharpDevelopment for overshoot method
// Attach to Enemy Prefab
// Place in Assets/Scripts
// Created 6/19/2014
// Last Update 6/26/2014

using UnityEngine;
using System.Collections;

public class Patrol : GameManager {
	
	public float moveSpeed;

	// Last Position Navigation variables 
	private Transform _playerTransform, _transform;
	private Vector3 _targetPosition, _forward;
	private bool _isWaiting;
	public float overshoot, waitTime;

	// Point Array Navigation
	public Transform[] patrolPoints;
	private int currentPoint;

	// Follow Player Navigation variables
	public Transform target;
	public Vector3 targetPosition;
	private Transform enemyTransform;

	void Start () {

		//if (currentLevel == 0) {
			_playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
			_transform = transform;

			UpdateMovement ();
		//}

		/*if (currentLevel == 1) {
			//Locate Patrol Points
			transform.position = patrolPoints [0].position;
			currentPoint = 0;
		}

		if (currentLevel == 2) {
			// Locate Player
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			target = player.transform;

			// Locate Player Position
			targetPosition = player.transform.position;

			// Enemy Current Position
			GameObject enemy = this.gameObject;
			enemyTransform = enemy.transform;
		}*/
	}
	

	void Update () {

		//if (currentLevel == 0) {
			if (_isWaiting)
					return;

			_transform.position += _forward * moveSpeed * Time.deltaTime;

			if (Vector3.Dot (_forward, _targetPosition - _transform.position) < 0) {
					StartCoroutine (Wait ());
			}
		//}

		/*if (currentLevel == 1) {
			// Follow Player Indefinitely [Works]
			transform.LookAt (target);
			enemyTransform.position += enemyTransform.forward * moveSpeed * Time.deltaTime;
		}

		if (currentLevel == 2) {
			// Array Point Navigation [Works]
			if (transform.position == patrolPoints [currentPoint].position) {
					currentPoint ++;
			}

			if (currentPoint >= patrolPoints.Length) {
					currentPoint = 0;	
			}

			transform.position = Vector3.MoveTowards (transform.position, patrolPoints [currentPoint].position, moveSpeed * Time.deltaTime);
		}*/
	}

	// Updates player position and calculates the overshot position
	void UpdateMovement() {
		_transform.LookAt( _playerTransform );
		_forward = _transform.forward; 
		_targetPosition = _playerTransform.position + _forward*overshoot; 
	}

	// Used in conjuction with the UpdateMovement() method to create a "dumb" AI with waiting time
	private IEnumerator Wait () {
		_isWaiting = true;
		yield return new WaitForSeconds(waitTime);
		UpdateMovement();
		_isWaiting = false;
	}
}
