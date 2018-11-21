using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarginLeft : MonoBehaviour 
{

	[SerializeField] private RobotPatrol controller;
	private bool actived;

	[SerializeField] private float total_time;
	private float elapsed_time;

	void Start () 
	{
		actived = false;
		elapsed_time = 0;
	}

	void Update()
	{		
		if (actived) 
		{
			elapsed_time += Time.deltaTime;
		}

		if (elapsed_time >= total_time) 
		{
			actived = false;
			elapsed_time = 0;
		}
	}

	void OnTriggerEnter2D(Collider2D colisor)
	{
		if (colisor.gameObject.tag == "RobotPatrol")
		{
			if (!actived) 
			{
				actived = true;
				controller.change ();
				elapsed_time = 0;
			}
		}
	}


}
