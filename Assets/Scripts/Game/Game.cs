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

	//
	//
	//
	public List<Player> a_Players {get{return m_Players;}}

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
