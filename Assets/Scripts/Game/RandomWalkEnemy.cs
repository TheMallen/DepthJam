using UnityEngine;
using System.Collections;

public class RandomWalkEnemy : Enemy {
	
	const float DEFAULT_SPEED = 0.05f;

	enum Directions {LEFT=0, RIGHT=1, DOWN=2, UP=3};

	private Vector2 m_Facing = Vector2.zero;

	private int m_DebounceCounter = 0;

	// Use this for initialization
	protected override void Start () 
	{
		base.Start();
		m_MoveSpeed = DEFAULT_SPEED;
		ChangeDirectionRandomly ();
		Random.seed = (int)System.DateTime.Now.Ticks;

	}

	void OnCollisionEnter2D(Collision2D collision) 
	{
		ChangeDirectionRandomly ();
	}
	
	protected override void Update ()
	{
		base.Update ();
		Forward ();
	}

	protected void Forward() {
		m_Delta = m_Facing;
	}

	protected void ChangeDirectionRandomly() 
	{
		m_Facing = RandomDirection ();
	}

	protected Vector2 RandomDirection() 
	{
		var r = Random.Range (0, 3);
		switch (r) {
			case (int)Directions.LEFT:
				return new Vector2(-1, 0);
			break;
			case (int)Directions.RIGHT:
				return new Vector2(1, 0);
			break;
			case (int)Directions.DOWN:
				return new Vector2(0, 1);
			break;
			case (int)Directions.UP:
				return new Vector2(0, -1);
			break;
		}
		return Vector2.zero;

	}

}
