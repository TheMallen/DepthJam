using UnityEngine;
using System.Collections.Generic;

public class Game : SceneManager <Game> 
{
	//
	//
	//


	//
	//
	//
	private List<Player> m_Players = new List<Player>();

	//pools
	[SerializeField] private ProjectilePool m_ProjectilePool = null;

	//
	//
	//
	public List<Player> a_Players {get{return m_Players;}}
	public ProjectilePool a_ProjectilePool {get{return m_ProjectilePool;}}

	//
	//
	//

	protected override void Start()
	{
		base.Start();

		Player child = null;

		for(int i = 0; i < transform.childCount; i++)
		{
			child = transform.GetChild(i).GetComponent<Player>();

			if (child != null)
				m_Players.Add (child);

		}

	}

	private void Update()
	{
		
	}

}
