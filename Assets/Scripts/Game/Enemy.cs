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

	private void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject != null)
		{
			if (coll.gameObject.GetComponent<Projectile>() != null)
			{
				Vector2 force = (coll.transform.position - transform.position).normalized*100f;
				
				m_Rigidbody2D.AddForce(force,ForceMode2D.Impulse);


			}

			if (coll.collider.gameObject.GetComponent<Player> () != null)
				OnHitPlayer ();

		}
		
	}

	private void OnHitPlayer()
	{

	}

}
