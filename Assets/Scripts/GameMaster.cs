using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

	public List<GameObject> listRooms;
	public bool debugMode;
	public Abuela player;
	public Room Actualroom;
	public GameObject EndPlace;
	public bool lose;
	public GameObject UI;
	public GameObject winScene,dieScene;

	public bool Inverse;
	// Use this for initialization

	public void Die(){
		dieScene.transform.position = player.gameObject.transform.position;
		dieScene.gameObject.SetActive(true);
		UI.gameObject.SetActive(false);
		Camera.main.transform.parent = dieScene.gameObject.transform;
		Camera.main.transform.localPosition = new Vector3(0,0,-10);
	}
	public void Win(){
		winScene.transform.position = player.gameObject.transform.position;
		winScene.gameObject.SetActive(true);
		UI.gameObject.SetActive(false);
		player.Win();
		Camera.main.transform.parent = winScene.gameObject.transform;
		Camera.main.transform.localPosition = new Vector3(0,0,-10);

	} 	
	static GameMaster instance;
	public static GameMaster Instance{
		get {return instance;}
	}
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake() 
	{
		instance = this;
	}
	void Start(){

		if (debugMode)
			return;
		int rnd = Random.Range(0,listRooms.Count - 1);

		for (int i = 0; i < listRooms.Count; i++)
		{
			if (i == rnd){
				player.transform.position = listRooms[i].transform.GetChild(0).transform.position;
				Actualroom = listRooms[i].GetComponent<Room>();
				ChangeRoom(Actualroom);
				Debug.Log("Spawn Room is :" +  Actualroom);
			}	
		}
	}

	public void ChangeRoom(Room toChange){
		
		//Actualroom.Desactivate();
		
		Actualroom.gameObject.SetActive(false);
		
		Actualroom = toChange;
		
		Actualroom.gameObject.SetActive(true);
		
		Actualroom.Activate();
		switch(Actualroom.typeRoom){
				case 0:
					Inverse = false;
					break;
				case 1:
					Inverse = true;
					break;
		}
	}
	// Update is called once per frame
	float ElapsedTime = 0.0f;
	void Update () {
		if (lose){
			ElapsedTime += Time.deltaTime;
			if (ElapsedTime > 3){
				Die();
			}
		}
	}
}
