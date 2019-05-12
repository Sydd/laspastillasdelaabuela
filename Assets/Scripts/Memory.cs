using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : MonoBehaviour {

	public Abuela player;
	public Transform reference;
	public float factor = 3f;
	 public float limit =6f;

	 public Animator anim;
	 public SpriteRenderer sprite;
	 Vector3 center;
	// Use this for initialization
	void Start () {
		center = transform.position;
	}
	
	void Update(){
		anim.SetFloat("MEMORY",player.Memory);
	}
	// Update is called once per frame
	void FixedUpdate () {

		 Vector3 pos = GameMaster.Instance.EndPlace.transform.position;

		 center = reference.position;

         pos.z = 0.0f;

         Vector3 dir = (pos - reference.position) * factor;

         dir = Vector3.ClampMagnitude(dir, limit);
         Vector3 tt = center + dir;
         transform.position = center + dir;		
	}
}
