using UnityEngine;
using System.Collections;

public class SpiralEnemy : Enemy {
	
	const float DEFAULT_SPEED = 0.05f;
	
	private int m_Facing = 1;
	
	private int m_DebounceCounter = 0;


	// Use this for initialization
	protected override void Start () 
	{
		base.Start();
		m_MoveSpeed = DEFAULT_SPEED;
		ChangeDirectionRandomly ();
		Random.seed = (int)System.DateTime.Now.Ticks;
		StartCoroutine (coro());
	}
	
	public IEnumerator coro()
	{
		yield return new WaitForSeconds(3);
		ChangeDirectionRandomly ();
		StartCoroutine (coro());
	}
	
	void OnCollisionStay2D(Collision2D collision) 
	{
		ChangeDirectionRandomly ();
	}
	
	protected override void Update ()
	{
		/**
		base.Update ();
		Player targetPlayer = NearestPlayer ();
		Vector2 towardsPlayer = transform.position - targetPlayer.transform.position;

		float step = m_MoveSpeed * Time.deltaTime;
		transform.position = Vector2.MoveTowards(
			transform.position,
			targetPlayer.transform.position,
			step
			);

		m_Delta = m_Facing;
		*/
	}

	protected void ChangeDirectionRandomly() 
	{
		m_Facing = (m_Facing == 1) ? -1 : 1;
	}
	
}
