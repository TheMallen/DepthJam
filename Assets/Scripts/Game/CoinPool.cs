﻿using UnityEngine;
using System.Collections;

public class CoinPool : ObjectPool<Coin> 
{
	private void Awake()
	{
		m_PoolSize = 64;
		m_PrefabDir = "Game/Prefabs/";
	
	}

}
