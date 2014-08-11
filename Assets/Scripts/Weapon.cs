using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public float fireRate = 0;
	public float damage = 10;
	public LayerMask notToHit;

	float timeToFire = 0;
	Transform firePoint;

	void Awake () {
		/*firePoint = transform.FindChild ("FirePoint");
		if (firePoint == null) {
			Debug.LogError ("No firePoint? WHAT?!");		
		}*/
	}

	void Update () {

		Plane plane = new Plane (Vector3.zero, transform.position);
		Ray rayToMouse = Camera.main.ScreenPointToRay (Input.mousePosition);
		float dist;
		plane.Raycast (rayToMouse, out dist);
		Vector3 targetPos = rayToMouse.GetPoint (dist);

		Debug.DrawRay (transform.position, targetPos);

		/*
		Vector3 mousePostion = new Vector3 ((Camera.main.ScreenToWorldPoint (Input.mousePosition).x), 0, (Camera.main.ScreenToWorldPoint (Input.mousePosition).z));
		Vector3 firePointPosition = new Vector3 (firePoint.position.x, firePoint.position.y, firePoint.position.z);
		Debug.DrawLine (firePointPosition, mousePostion);

		Vector3 mousePostion = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mousePostion.y = 0;
		Vector3 firePointPosition = new Vector3 (firePoint.position.x, firePoint.position.y, firePoint.position.z);
		
		float distToMouse = Vector3.Distance(mousePostion, firePointPosition) ;
		
		RaycastHit hit;
		Ray myRay = new Ray (firePointPosition, mousePostion);
        ////////////////////////////////////////////////////
	    RaycastHit[] hits;
        Vector3 ray_point_onfloor;
        hits = Physics.RaycastAll(firePointPosition mousePosition);
        int i = 0;
        while (i < hits.Length) {
            RaycastHit hit = hits[i];

            if (hit.tag == "floor") {
                ray_point_onfloor= hit.point;
				break;
            }
            i++;
        }

		Debug.DrawRay (firePointPosition, mousePostion);

		if (fireRate == 0) {
			if (Input.GetButtonDown("Fire1") && Physics.Raycast(myRay, out hit, distToMouse, notToHit)) {
				Shoot();
			}
		}
		else{
			if (Input.GetButtonDown ("Fire1") && Time.time > timeToFire) {
				timeToFire = Time.time + 1/fireRate;
				Shoot();
			}
		}*/
	}

	void Shoot () {
		Debug.Log ("Fire!");
	}
}
