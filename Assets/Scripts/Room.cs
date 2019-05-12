using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

	public int typeRoom = 0;
	public int renderOrder;
	public bool activated = false;
	public SpriteRenderer House;
	public GameObject objects;
	public bool starterRoom = false;
	public Transform Spawn;
	public GameObject cat;
	public bool catRoom = false;
	void Start()
	{
		if (objects == null){
			objects = gameObject.transform.GetChild(2).gameObject;
		}
		if (!starterRoom){
			Desactivate();
		}
	}
	 /// <summary>
	/// Sent when another object enters a trigger collider attached to this
	/// object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player")){
			GameMaster.Instance.ChangeRoom(this);
		}
	}

	public	void Desactivate(){
		House.color =Color.black;
		activated = false;
		House.sortingOrder = 0;
		objects.SetActive(false);
		if (catRoom){
			cat.GetComponent<Cat>().Deactivate();
		}
	}

	public void Activate(){
		House.color = Color.white;
		House.sortingOrder = 1;
		activated = true;
		objects.SetActive(true);
		if (catRoom){
			cat.GetComponent<Cat>().Activate();
		}

	}
}
