using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour{
	
	public float lifetime = 0;
	
	void Start () {
		Destroy(gameObject, lifetime);	
	}
	
	
	void Update () {
		
	}
}