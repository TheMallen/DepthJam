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
	[SerializeField] private Player m_Player1 = null;
	[SerializeField] private Player m_Player2 = null;

	private List<Player> m_Players = new List<Player>();

	//pools
	[SerializeField] private ProjectilePool  m_ProjectilePool  = null;
	[SerializeField] private CoinPool        m_CoinPool        = null;
	[SerializeField] private HitParticlePool m_HitParticlePool = null;


	//
	//
	//
	public List<Player> a_Players {get{return m_Players;}}

	public ProjectilePool a_ProjectilePool {get{return m_ProjectilePool;}}
	public CoinPool a_CoinPool {get{return m_CoinPool;}}
	public HitParticlePool a_CHitParticlePool {get{return m_HitParticlePool;}}

	//
	//
	//

	protected override void Start()
	{
		base.Start();

		Player child = null;

		m_Players.Add (m_Player1);
		m_Players.Add (m_Player2);

	}

	private void Update()
	{
		
	}

}
