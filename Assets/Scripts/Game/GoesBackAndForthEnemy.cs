using UnityEngine;
using System.Collections;

public class GoesBackAndForthEnemy : Enemy {
	
	const float DEFAULT_SPEED = 0.1f;
	
	public Vector2 m_Facing = Vector2.up;
	
	// Use this for initialization
	protected override void Start () 
	{
		base.Start();
		m_MoveSpeed = DEFAULT_SPEED;
		
	}
	
	protected override void Update() 
	{
		base.Update();
		// interpolate
		m_Delta = m_Facing;
	}

	void OnCollisionStay2D(Collision2D collision) 
	{
		m_Facing = new Vector2 (-1 * m_Facing.x, -1 * m_Facing.y);
	}
	
}
