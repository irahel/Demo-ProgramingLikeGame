using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{

	[SerializeField] private float player_move_speed;
	[SerializeField] private float player_jump_force;

	private bool can_jump_verify;
	private int jump_counter;
	[SerializeField] private Transform floor_verify;

	private SpriteRenderer LOCAL_PLAYER_SPRITE;
	private Animator LOCAL_PLAYER_ANIMATOR;
	private Rigidbody2D LOCAL_PLAYER_RIGIDBODY;

	void Start () 
	{
		LOCAL_PLAYER_SPRITE = GetComponent<SpriteRenderer> ();
		LOCAL_PLAYER_ANIMATOR = GetComponent<Animator> ();
		LOCAL_PLAYER_RIGIDBODY = GetComponent<Rigidbody2D> ();
	}
	

	void Update () 
	{
		move ();
		jump ();
	}

	private void move()
	{
		float moving = Input.GetAxisRaw ("Horizontal");
		if (moving != 0) 
		{
			if (moving > 0) 
			{
				transform.Translate (Vector2.right * player_move_speed * Time.deltaTime);
				LOCAL_PLAYER_SPRITE.flipX = true;
			}
			else 
			{
				transform.Translate (Vector2.left * player_move_speed * Time.deltaTime);
				LOCAL_PLAYER_SPRITE.flipX = false;
			}
		}

		LOCAL_PLAYER_ANIMATOR.SetFloat ("move", Mathf.Abs (moving));
	}

	void jump()
	{
		
		can_jump_verify = Physics2D.Linecast(transform.position, floor_verify.position, 1 << LayerMask.NameToLayer("Floor"));

		if (can_jump_verify) jump_counter = 0;

		if (Input.GetButtonDown("Jump") && jump_counter < 1)
		{   			
			LOCAL_PLAYER_ANIMATOR.SetTrigger ("jump");
			LOCAL_PLAYER_RIGIDBODY.AddForce(transform.up * player_jump_force);		
			jump_counter++;
		}
	}

}
