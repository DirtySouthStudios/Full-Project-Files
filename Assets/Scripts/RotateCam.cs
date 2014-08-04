// Francesco Maoli
// 8/1/2014
// 8/1/2014
// Attach to "Main Camera" object
// Currently needs work. Directional inputs do not correspond to new camera position (eg. up becomes left).

using UnityEngine;
using System.Collections;

public class RotateCam : MonoBehaviour {

	public GameObject targetObject;
	private Vector3 playerPos;
	private float targetAngle = 0;
	const float rotationAmount = 1.5f;
	public float rDistance = 1.0f;
	public float rSpeed = 1.0f;


	// Update is called once per frame
	void Update()
	{

		playerPos.x = targetObject.transform.position.x;
		playerPos.y = targetObject.transform.position.y;
		
		// Trigger functions if Rotate is requested
		if (Input.GetKeyDown(KeyCode.Q)) {
			targetAngle -= 90.0f;
		} else if (Input.GetKeyDown(KeyCode.E)) {
			targetAngle += 90.0f;
		}
		
		if(targetAngle !=0)
		{
			Rotate();
		}
	}
	
	protected void Rotate()
	{
		
		float step = rSpeed * Time.deltaTime;
		float orbitCircumfrance = 2F * rDistance * Mathf.PI;
		float distanceDegrees = (rSpeed / orbitCircumfrance) * 360;
		float distanceRadians = (rSpeed / orbitCircumfrance) * 2 * Mathf.PI;
		
		if (targetAngle>0)
		{
			transform.RotateAround(playerPos, Vector3.up, -rotationAmount);
			targetAngle -= rotationAmount;
		}
		else if(targetAngle <0)
		{
			transform.RotateAround(playerPos, Vector3.up, rotationAmount);
			targetAngle += rotationAmount;
		}
		
	}
}