using UnityEngine;
using System.Collections;

public abstract class Singleton <T> : MonoBehaviour where T : Singleton<T>
{
	protected static   	T    s_Instance ;
	public    static    T    a_Instance { get{ return s_Instance; } }
	
	protected virtual void Awake() 	
	{ 
		s_Instance = (T)this;
		
		for (int i = 0; i < transform.childCount; i++)
			transform.GetChild(i).gameObject.SetActive(false);
		
	}
	
	protected virtual void Start()
	{
		for (int i = 0; i < transform.childCount; i++)
			transform.GetChild(i).gameObject.SetActive(true);
		
	}
	
}