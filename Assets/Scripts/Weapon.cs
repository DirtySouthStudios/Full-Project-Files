// Credited to Francesco Maoli & Yang Song
// 8/8/2014
// 8/11/2014
// Attach to Player Prefab object

using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	
	public LayerMask notToHit;
	public Transform firePointPosition;

	float timeToFire = 0;

	void Awake () {
		/*firePointPosition = transform.FindChild ("FirePoint");
		if (firePointPosition == null) {
			Debug.LogError ("No firePoint? WHAT?!");		
		}*/
	}

	void Update () {
		
		RaycastHit[] hits;
		Vector3 ray_point_onfloor;
		hits = Physics.RaycastAll(Camera.main.transform.position, Camera.main.transform.forward);
		int i = 0;
		while (i < hits.Length) {
			RaycastHit hit = hits[i];
			
			if (hit.transform.tag == "floor") {
				ray_point_onfloor = hit.point;
				Debug.DrawLine (transform.position, ray_point_onfloor);
				break;

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
			i++;
		}
	}

	void Shoot () {
		Debug.Log ("Fire!");
	}
}
