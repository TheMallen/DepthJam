using UnityEngine;
using System.Collections;

public class HitParticlePool : ObjectPool<HitParticle> 
{
	private void Awake()
	{
		m_PoolSize = 64;
		m_PrefabDir = "Game/Prefabs/";
		
	}

}





