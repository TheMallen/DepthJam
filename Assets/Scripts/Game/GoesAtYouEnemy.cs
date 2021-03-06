﻿using UnityEngine;
using System.Collections;

public class GoesAtYouEnemy : Enemy {
	
	const float DEFAULT_SPEED = 0.1f;
	const float TURN_SPEED = 2.5f;

	private Vector2 m_Facing = Vector2.zero;

	// Use this for initialization
	protected override void Start () 
	{
		base.Start();
		m_MoveSpeed = DEFAULT_SPEED;
		
	}

	protected override void Update() {
		base.Update();
		// interpolate
		m_Delta = TowardsPlayer();
	}
	
}
