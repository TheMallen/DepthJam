using UnityEngine;
using System.Collections;

public class Heart : BaseObject, PoolableTypeInterface
{
	private const float c_Offset = 0.25f;
	private const float c_SpinSpeed = 5f;

	// Use this for initialization
	void Start () {
	
	}
	
	void Update () 
	{	
		m_Graphic.transform.localPosition = new Vector3(0,Mathf.Abs(Mathf.Sin(Time.time*5)/5f));
		
	}

	public void Reset()
	{


	}

}
