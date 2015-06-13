using UnityEngine;
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
		/*Player targetPlayer = NearestPlayer ();
		float step = m_MoveSpeed * Time.deltaTime;
		transform.position = Vector2.MoveTowards(
										transform.position,
										targetPlayer.transform.position,
										step
									);*/

		m_Delta = NearestPlayer().transform.position - transform.position;

	}
	
}
