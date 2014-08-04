using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float moveSpeed;
	public GameObject deathParticles;

	private float maxSpeed = 5f;
	private Vector3 input;

	private Vector3 spawn;

	private float targetAngle = 0;
	const float rotationAmount = 1.5f;
	public float rSpeed = 1.0f;

	// Use this for initialization
	void Start () {
		spawn = transform.position;

	}

	void Update () {
		// Rotation method
		if (Input.GetKeyDown(KeyCode.Q)) {
			targetAngle -= 90.0f;
		} 
		if (Input.GetKeyDown(KeyCode.E)) {
			targetAngle += 90.0f;
		}
		
		
		if(targetAngle !=0)
		{
			Rotate();
		}
	}

	void FixedUpdate () {


		// Movement method
		input = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));

		if (rigidbody.velocity.magnitude < maxSpeed){
			rigidbody.AddRelativeForce (input * moveSpeed);
		}


		// Die if fall off edge
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

	protected void Rotate()
	{
		

		
		if (targetAngle>0)
		{
			transform.RotateAround(transform.position, Vector3.up, -rotationAmount);
			targetAngle -= rotationAmount;
		}
		if(targetAngle <0)
		{
			transform.RotateAround(transform.position, Vector3.up, rotationAmount);
			targetAngle += rotationAmount;
		}
		
	}
}

