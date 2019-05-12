using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

 /// <summary>
/// Update is called every frame, if the MonoBehaviour is enabled.
/// </summary>
void Update()
{
	if (Input.anyKeyDown){
		Invoke("StartGame",1f);
	}
}
public void StartGame(){
	
	SceneManager.LoadScene(1);
}
}