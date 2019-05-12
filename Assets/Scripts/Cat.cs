using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Cat : MonoBehaviour {
	
	Rigidbody2D body;
	public Transform player;
	public float velocity;

	public SkeletonAnimation catAnimator;
	bool searchPlayer = false;
	void Awake(){

	}
	void FixedUpdate()
	{
		if (searchPlayer){

			body.MovePosition(Vector2.Lerp(transform.position,player.position,velocity));

			//body.position = player.position;	
			if (transform.position.x > player.position.x){
				catAnimator.Skeleton.ScaleX = -1;
			}else{
				catAnimator.Skeleton.ScaleX = 1;
			}
		}
	}
	void Start(){
		//catAnimator.AnimationState.TimeScale = velocity;
		body = GetComponent<Rigidbody2D>();
		player = GameMaster.Instance.player.transform;
	}

	public void Activate(){
		searchPlayer = true;
		
		catAnimator.AnimationState.SetAnimation(0,"moving",true);
	
	}
	public void Deactivate(){
		searchPlayer = false;
		catAnimator.AnimationState.SetEmptyAnimation(0,.5f);
	}

	 /// <summary>
	/// Sent when another object enters a trigger collider attached to this
	/// object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player")){
			other.GetComponent<Abuela>().Gateado();
		}
	}

	 /// <summary>
	/// Sent when another object leaves a trigger collider attached to
	/// this object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player")){
			other.GetComponent<Abuela>().Desgatedo();
		}
	}
}
