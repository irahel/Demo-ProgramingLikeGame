using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotPatrol : MonoBehaviour 
{

	[SerializeField] private float robot_move_speed;

	private bool direction;

	void Start () 
	{
		//false = left
		//true = right
		direction = false;
	}
	

	void Update () 
	{
		move ();
	}

	void move()
	{
		if (direction) 
		{
			transform.Translate (Vector2.right * robot_move_speed * Time.deltaTime);
		}
		else 
		{
			transform.Translate (Vector2.left * robot_move_speed * Time.deltaTime);
		}
	}

	public void change()
	{
		direction = !direction;
	}
}
