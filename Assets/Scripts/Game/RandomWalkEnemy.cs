using UnityEngine;
using System.Collections;

public class RandomWalkEnemy : Enemy {
	
	const float DEFAULT_SPEED = 0.05f;

	public Vector2 m_Facing = Vector2.zero;

	// Use this for initialization
	protected override void Start () 
	{
		base.Start();
		m_MoveSpeed = DEFAULT_SPEED;
		Random.seed = (int)System.DateTime.Now.Ticks;
	}

	void OnCollisionEnter2D(Collision2D collision) 
	{
		if (Game.isInLayer(collision.collider, "Obstacles") ||
		    Game.isInLayer(collision.collider, "Default")) {
			Vector2 newDir = RandomDirection ();
			m_Facing = (newDir == m_Facing)
							? Reverse (m_Facing)
							: newDir;
		}
	
	}

	Vector2 Reverse(Vector2 v) {
		return new Vector2 (v.x * -1, v.y * -1);
	}

	Vector2 RandomDirection() {
		int dir = Random.Range (0, 3);
		Debug.Log (dir);
		Vector2 resultVector = Vector2.zero;
		switch (dir) {
			case 0:
				resultVector = Vector2.up;
				break;
			case 1:
				resultVector = Vector2.right;
				break;
			case 2:
				resultVector = Vector2.down;
				break;
			case 3:
				resultVector = Vector2.left;
				break;
		}
		return (resultVector);
	}
	
	protected override void Update ()
	{
		base.Update ();
		Forward ();
	}

	protected void Forward() {
		m_Delta = m_Facing;
	}

}
