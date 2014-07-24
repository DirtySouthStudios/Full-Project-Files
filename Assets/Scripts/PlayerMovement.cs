using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float moveSpeed;
	public GameObject deathParticles;

	private float maxSpeed = 5f;
	private Vector3 input;

	private Vector3 spawn;

	// Use this for initialization
	void Start () {
		spawn = transform.position;

	}
	

	void FixedUpdate () {

		input = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));

		if (rigidbody.velocity.magnitude < maxSpeed){
			rigidbody.AddRelativeForce (input * moveSpeed);
		}

		if (transform.position.y < -4) {Die ();}
	}
	

	void OnCollisionEnter (Collision other){
		if (other.transform.tag == "Enemy") {
			Die ();
		}
	}
	
	void OnTriggerEnter (Collider other){
		if (other.transform.tag == "Goal"){
			GameManager.CompleteLevel();
		}
	}

	void Die (){
		Instantiate(deathParticles, transform.position, Quaternion.Euler (270,0,0));
		//yield return new WaitForSeconds(4);
		transform.position = spawn;
	}

}

