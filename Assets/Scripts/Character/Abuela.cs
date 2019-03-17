using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine;
using Spine.Unity;

public class Abuela : MonoBehaviour {

	public int treeshold = 0 ;
	public float speed = 1.0f;

	public SkeletonAnimation Anims;

	bool playing;
	public Slider lifebar;
	public float life = 1.0f;
	
	public Transform memoryHelper;

	public float dificult = 0.01f;
	public AbuelaStates ActualState;

	public float Memory = 1.0f;

	public Rigidbody2D cuerpo;
	//public Animator anim;

	bool isFliped;
	Vector2 force;
	// Use this for initialization
	void Start () {
		playing = true;
		ActualState = AbuelaStates.idle;
	}
	float elapsedTime = 1.0f;
	void FixedUpdate()
	{
		if (playing){

		if (elapsedTime < 0) {
				life = life - dificult;
				Memory = Memory - dificult * 5f;

				elapsedTime = 1.0f; 	
		}

		elapsedTime = elapsedTime - Time.fixedDeltaTime;


		lifebar.value = life;

			if (life < 0){
				GameMaster.Instance.lose = true;
				Die();
			}
		}
		
	}
	// Update is called once per frame
     
     void Update() {

		if (playing){

				force = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

				if (force != Vector2.zero){

					ChangeState(AbuelaStates.walk);
					
					if (cuerpo.velocity.x <= 0){
						Anims.gameObject.transform.localScale = new Vector3(-0.6f,0.6f,1);
					} else{
						isFliped = true;
						Anims.gameObject.transform.localScale = new Vector3(0.6f,0.6f,1);
					}
					if (GameMaster.Instance.Inverse){
						force = force *-1;
					}
					cuerpo.velocity = force * speed * Time.deltaTime;
		//			anim.SetBool("MOVIMIENTO", true);
				} else{
					cuerpo.velocity = Vector2.zero;
					ChangeState(AbuelaStates.idle);
		//			anim.SetBool("MOVIMIENTO", false);
				}
			}
	 }

	public void Die(){
		playing = false;
		ChangeState(AbuelaStates.death,false);
		speed = 0;
		cuerpo.velocity = new Vector2(0,0);
	}
	public void Win(){
		ChangeState(AbuelaStates.win);
		speed = 0;
		playing = false;
		cuerpo.velocity = new Vector2(0,0);
		//Anims.gameObject.transform.localScale = new Vector3(1,1,1);
	}
	void ChangeState(AbuelaStates state){

		if (ActualState != state){
		
			ActualState = state;

			Anims.AnimationState.SetAnimation(0,state.ToString(),true);

		}
	}

	void ChangeState(AbuelaStates state,bool loop){

		if (ActualState != state){
		
			ActualState = state;

			Anims.AnimationState.SetAnimation(0,state.ToString(),loop);

		}
	}
}
