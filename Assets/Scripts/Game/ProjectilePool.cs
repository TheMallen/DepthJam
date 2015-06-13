using UnityEngine;
using System.Collections;

public class ProjectilePool : ObjectPool<Projectile> 
{
	private void Awake()
	{
		m_PoolSize = 64;
		m_PrefabDir = "Game/Prefabs/";

	}

}

