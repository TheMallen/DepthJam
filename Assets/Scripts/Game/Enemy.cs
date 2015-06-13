using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : Character 
{
	private List<Player> m_Players;

	protected override void Start()
	{
		m_Players = Game.a_Instance.a_Players;
		base.Start();
	}

	protected void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.gameObject.GetComponent<Player> () != null)
			OnHitPlayer ();

	}

	protected virtual void OnHitPlayer() {
	
	}

}
