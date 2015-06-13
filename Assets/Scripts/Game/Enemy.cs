using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : Character 
{
	[SerializeField]
	protected List<Player> m_Players;

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

	protected Player NearestPlayer() {
		Player closestPlayer = m_Players[0];
		if (m_Players.Count == 1) 
			return closestPlayer;
		float lowestDistance = 0f;

		foreach (Player player in m_Players) {
			var distance = Vector2.Distance(player.transform.position, transform.position);
			if (distance < lowestDistance) {
				lowestDistance = distance;
				closestPlayer = player;
			}
		}
		return closestPlayer;
	}

}
