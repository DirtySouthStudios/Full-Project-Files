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
			}
			i++;
		}
	}

	void Shoot () {
		Debug.Log ("Fire!");
	}
}
