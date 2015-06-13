/// <summary>
/// Project: GAM1550 Assignment 1/Repurposed for Capstone
/// Name: ObjectPool
/// Description: defines how an object pool
/// with a fixed pool size should work in
/// Unity.
/// Author: Joseph Cameron
/// </summary>

#region change log
//Name: Joseph Cameron
//Description: initial implementation
//Date: February 16th, 2014

//Name: Joseph Cameron
//Description: added m_PrefabDir, allowing for
// variable prefab directories
//Date: October 29th, 2014

#endregion
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour, PoolableTypeInterface
{
	//Data members 
	private List<T> m_Pool       = new List<T> ();
	private List<T> m_CheckedOut = new List<T> ();

	protected int    m_PoolSize;
	protected string m_PrefabDir;

	//Accessors
	public    List<T> a_Pool {get{return m_Pool;}}
	protected virtual string a_PrefabDir { get{return m_PrefabDir;} set{m_PrefabDir = value;} }

	// Use this for initialization
	protected virtual void Start () 
	{
		//Initialize the pool
		for (int i = 0; i < m_PoolSize; i++)
		{
			T t = ((GameObject)GameObject.Instantiate (Resources.Load (m_PrefabDir+typeof(T).ToString(), typeof(GameObject)))).GetComponent<T>();
			t.transform.parent = transform;
			t.name = typeof(T).ToString();
			//t.Start();
			
			t.gameObject.SetActive(false);
			m_Pool.Add (t);
			
		}
		
	}
	
	public bool checkOutAnItem(out T aItem)
	{
		aItem = null;
		
		//for (T item in m_Pool)
		for (int i = 0; i < m_Pool.Count; i++)
			if (m_Pool[i].gameObject.activeInHierarchy == false)
			{
				aItem = m_Pool[i];
				m_Pool[i].Reset();
				m_Pool[i].gameObject.SetActive(true);
				m_CheckedOut.Add (m_Pool[i]);
				
			
				return true;
			}
		
		return false;
		
	}
	
	// Update is called once per frame
	private void FixedUpdate () 
	{
		for (int i = 0; i < m_CheckedOut.Count; i++)
		{
			if (m_CheckedOut[i].gameObject.activeInHierarchy == false)
			{
				m_CheckedOut[i].gameObject.SetActive(true);
				{
					m_CheckedOut[i].transform.parent = transform;
					m_CheckedOut[i].Reset();
					m_CheckedOut[i].gameObject.SetActive(false);
					
				}
				m_CheckedOut.RemoveAt(i);
				
			}
			
		}
		
	}
	
	
}