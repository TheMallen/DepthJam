using UnityEngine;
using System.Collections;

public class GradualTurningGoesAtYouEnemy : Enemy {
	
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
		Vector2 idealDir = TowardsPlayer ();
		m_Facing = idealDir - m_Facing;
		m_Facing.Normalize();
		m_Facing *= TURN_SPEED * Time.deltaTime;
		// interpolate
		m_Delta = m_Facing;
	}
	
}
