using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pill : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public bool isBottle;	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player")){
			if (isBottle){
			other.GetComponent<Abuela>().life += 0.5f;

			}else{
			other.GetComponent<Abuela>().Memory = 1.0f;

			}
			gameObject.SetActive(false);

		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
