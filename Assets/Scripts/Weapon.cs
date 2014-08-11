// Credited to Francesco Maoli & Yang Song
// 8/8/2014
// 8/11/2014
// Attach to Player Prefab object

using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public float fireRate = 0;
	public LayerMask notToHit;
	public Transform firePointPosition;

	float timeToFire = 0;

	private Camera ref_mainCamera;
	
	public Vector3 mousePosition;
	private Plane zeroYPlane;

	void Awake () {
		/*firePointPosition = transform.FindChild ("FirePoint");
		if (firePointPosition == null) {
			Debug.LogError ("No firePoint? WHAT?!");		
		}*/

		ref_mainCamera = GameObject.FindGameObjectWithTag("MainCamera").camera;
		//This is the tool you need - plane
		zeroYPlane = new Plane(Vector3.up, Vector3.zero);
	}

	void Update () {

		// Fire ray from Camera to mouse
		Ray ray = ref_mainCamera.ScreenPointToRay(Input.mousePosition);
		
		
		float _hitDistance;
		//cast ray using zerpYplane to find out mouse position the ray intersects it
		zeroYPlane.Raycast(ray, out _hitDistance);
		mousePosition = ray.GetPoint(_hitDistance);

		mousePosition = new Vector3 (mousePosition.x, mousePosition.y = 1, mousePosition.z);
		Debug.DrawLine (transform.position, mousePosition);

		/* 
		 * Could be useful in future KEEP
		 * RaycastHit[] hits;
		 * Vector3 ray_point_onfloor;
		 * hits = Physics.RaycastAll(Camera.main.transform.position, Camera.main.transform.forward);
		 * int i = 0;
		 * while (i < hits.Length) {
		 * RaycastHit hit = hits[i];
		 * 		if (hit.transform.tag == "floor") {
		 * 			ray_point_onfloor = hit.point;
		 * 			Debug.DrawLine (transform.position, ray_point_onfloor);
		 * 			break;
		 * 		}
		 * 		i++;
		 * }
		 */

		if (fireRate == 0) {
			if (Input.GetButtonDown("Fire1")) {
				Shoot();

			}
		}
	}

	void Shoot () {
		Debug.Log ("Fire!");
	}
}
